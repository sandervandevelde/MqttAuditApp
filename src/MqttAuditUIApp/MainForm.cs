using MQTTnet.Client.Extensions;
using MQTTnet.Client;
using MQTTnet;
using MqttTopicManager;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;

namespace MqttAuditUIApp
{
	public partial class MainForm : Form
	{
		Config _config;

		private TopicManager _topicManager;

		private Series _serieDecimals;

		private List<DateTime> _timeDecimalValues = new();
		private List<double> _fieldDecimalValues = new();

		bool _onceAlready = false;

		public MainForm(TopicManager topicManager, Config config) : this()
		{
			_topicManager = topicManager;

			_config = config;
		}


		public MainForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			chartDecimals.ChartAreas.Clear();
			var chartAreaDecimals = chartDecimals.ChartAreas.Add("chartArea");
			chartAreaDecimals.AxisX.LabelStyle.Format = "HH:mm:ss";
			chartAreaDecimals.AxisX.LabelStyle.Angle = 45;
			chartAreaDecimals.AxisX.LabelAutoFitStyle =
				LabelAutoFitStyles.DecreaseFont
					| LabelAutoFitStyles.IncreaseFont
					| LabelAutoFitStyles.WordWrap;

			chartDecimals.Series.Clear();
			_serieDecimals = chartDecimals.Series.Add("serie1");
			_serieDecimals.ChartType = SeriesChartType.Line;
			_serieDecimals.MarkerStyle = MarkerStyle.Circle;
			_serieDecimals.BorderWidth = 4;
			_serieDecimals.ShadowOffset = 1;
			_serieDecimals.Color = Color.Red;


			_serieDecimals.IsVisibleInLegend = false;

			_serieDecimals.XValueType = ChartValueType.DateTime;
			_serieDecimals.YValueType = ChartValueType.Double;

			_serieDecimals.Points.Clear();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// CONNECT TO BROKER
			var cs = MqttConnectionSettings.CreateFromEnvVars();
			var mqttClient = new MqttFactory().CreateMqttClient(MqttNetTraceLogger.CreateTraceLogger());
			var connAck = mqttClient!.ConnectAsync(new MqttClientOptionsBuilder().WithConnectionSettings(cs).Build()).Result;

			// LISTEN FOR INCOMING MESSAGES
			mqttClient.ApplicationMessageReceivedAsync += (s) =>
			{
				Console.WriteLine($"Client '{s.ClientId}' received on topic '{s.ApplicationMessage.Topic}' the following message:\n{s.ApplicationMessage.ConvertPayloadToString()}");

				_topicManager.Receive(s.ApplicationMessage.Topic, s.ApplicationMessage.ConvertPayloadToString());

				this.Invoke(delegate ()
				{
					if (!treeViewtopics.Nodes.ContainsKey(s.ApplicationMessage.Topic))
					{
						var treeNode = new TreeNode();

						treeNode.Name = s.ApplicationMessage.Topic;
						treeNode.Text = s.ApplicationMessage.Topic;
						treeNode.Tag = _topicManager.TopicHistories[s.ApplicationMessage.Topic];

						treeViewtopics.Nodes.Add(treeNode);

						treeViewtopics.Sort();
					}

					if (!string.IsNullOrWhiteSpace(_config.TopicFilter))
					{
						for (int i = treeViewtopics.Nodes.Count - 1; i >= 0; i--)
						{
							if (!treeViewtopics.Nodes[i].Name.Contains(_config.TopicFilter))
							{
								treeViewtopics.Nodes[i].Remove();
							}
						}
					}

					if (treeViewtopics.Nodes.Count == 0)
					{
						listBoxHistory.Items.Clear();
						_timeDecimalValues.Clear();
						_fieldDecimalValues.Clear();
					}
					else
					{
						// force tree node selection (switch to the right representation) if needed
						if (_config.FollowLastTopic
								|| treeViewtopics.SelectedNode.Name == s.ApplicationMessage.Topic)
						{
							if (treeViewtopics.Nodes.ContainsKey(s.ApplicationMessage.Topic))
							{
								treeViewtopics.SelectedNode = null;
								treeViewtopics.SelectedNode = treeViewtopics.Nodes[s.ApplicationMessage.Topic];
							}
						}
					}
				});

				return Task.CompletedTask;
			};

			mqttClient.SubscribeAsync("#", MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).Wait();
		}

		private void treeViewtopics_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (_config.Paused)
			{
				return;
			}

			listBoxHistory.Items.Clear();
			_timeDecimalValues.Clear();
			_fieldDecimalValues.Clear();

			var orderedHistory = (e.Node.Tag as TopicHistory).OrderBy(x => x.Key);

			// check if we need to show floats
			float dummy;
			var isFloat = float.TryParse(orderedHistory.First().Value, out dummy);

			if (!isFloat)
			{
				listBoxHistory.BringToFront();

				// show json?
				foreach (var hist in orderedHistory)
				{
					listBoxHistory.Items.Add($"{hist.Key}\t{hist.Value}");
				}
			}
			else
			{
				// show floats
				chartDecimals.BringToFront();

				foreach (var hist in orderedHistory)
				{
					_timeDecimalValues.Add(hist.Key);
					_fieldDecimalValues.Add(Convert.ToDouble(hist.Value));
					_serieDecimals.Points.DataBindXY(_timeDecimalValues, _fieldDecimalValues);
				}
			}
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			UpdateHistory();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			if (!_onceAlready)
			{
				_onceAlready = true;
				UpdateHistory();
				listBoxHistory.BringToFront();
			}
		}

		private void UpdateHistory()
		{
			chartDecimals.Location = listBoxHistory.Location;
			chartDecimals.Size = listBoxHistory.Size;
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var formSettings = new FormSettings(_config);

			formSettings.ShowDialog();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var formAbout = new FormAbout();

			formAbout.ShowDialog();
		}

		private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_config.Paused = pauseToolStripMenuItem.Checked;
		}

		private void deviceClientsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var formDeviceClient = new FormDeviceClient();

			formDeviceClient.ShowDialog();
		}

		private void listBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
