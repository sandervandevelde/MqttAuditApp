using MQTTnet.Client.Extensions;
using MQTTnet.Client;
using MQTTnet;
using MqttTopicManager;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;

namespace MqttAuditUIApp
{
	public partial class MainForm : Form
	{
		protected TopicManager _topicManager = new TopicManager();

		ChartSeries _chartSeries;

		bool _onceAlready = false;

		public MainForm()
		{
			InitializeComponent();

			_chartSeries = new ChartSeries("MQTT");
			chartControlHistory.Series.Add(_chartSeries);
			chartControlHistory.PrimaryXAxis.ValueType = ChartValueType.DateTime;
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

					// force select if needed
					if (checkBoxFollowLastTopic.Checked
							|| treeViewtopics.SelectedNode.Name == s.ApplicationMessage.Topic)
					{
						treeViewtopics.SelectedNode = null;
						treeViewtopics.SelectedNode = treeViewtopics.Nodes[s.ApplicationMessage.Topic];
					}
				});

				return Task.CompletedTask;
			};

			mqttClient.SubscribeAsync("#", MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).Wait();
		}

		private void treeViewtopics_AfterSelect(object sender, TreeViewEventArgs e)
		{
			listBoxHistory.Items.Clear();

			_chartSeries.Points.Clear();

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
				chartControlHistory.BringToFront();

				foreach (var hist in orderedHistory)
				{
					_chartSeries.Points.Add(hist.Key, Convert.ToDouble(hist.Value));
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
			chartControlHistory.Location = listBoxHistory.Location;
			chartControlHistory.Size = listBoxHistory.Size;
		}
	}
}
