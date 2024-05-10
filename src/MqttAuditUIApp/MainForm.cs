using MQTTnet.Client.Extensions;
using MQTTnet.Client;
using MQTTnet;
using MqttTopicManager;

namespace MqttAuditUIApp
{
	public partial class MainForm : Form
	{
		protected TopicManager _topicManager = new TopicManager();

		public MainForm()
		{
			InitializeComponent();
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
				Console.WriteLine($"Client '{s.ClientId}' received on topic '{s.ApplicationMessage.Topic}' the following message:\n{System.Text.Encoding.UTF8.GetString(s.ApplicationMessage.Payload)}");

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

					if (checkBoxFollowLastTopic.Checked
							|| treeViewtopics.SelectedNode.Name == s.ApplicationMessage.Topic)
					{
						treeViewtopics.SelectedNode = null;
						treeViewtopics.SelectedNode = treeViewtopics.Nodes[s.ApplicationMessage.Topic];

					//	treeViewtopics.Update();
					}
				});

				return Task.CompletedTask;
			};

			mqttClient.SubscribeAsync("#", MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).Wait();
		}

		private void treeViewtopics_AfterSelect(object sender, TreeViewEventArgs e)
		{
			listBoxHistory.Items.Clear();

			var orderedHistory = (e.Node.Tag as TopicHistory).OrderBy(x => x.Key);

			foreach (var hist in orderedHistory)
			{
				listBoxHistory.Items.Add($"{hist.Key}\t{hist.Value}");
			}
		}
	}
}
