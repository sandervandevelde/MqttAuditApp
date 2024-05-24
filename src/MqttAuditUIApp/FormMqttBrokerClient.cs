using Azure.Identity;
using DeviceClientQueryLibrary;

namespace MqttAuditUIApp
{
	public partial class FormMqttBrokerClient : Form
	{
		public FormMqttBrokerClient()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			string? subscriptionId = Environment.GetEnvironmentVariable("mqtt-graph-subscriptionid");
			string? resourceGroupName = Environment.GetEnvironmentVariable("mqtt-graph-resourcegroupname");
			string? namespaceName = Environment.GetEnvironmentVariable("mqtt-graph-namespacename");

			var lines = new List<string>();

			var oldCursor = Cursor.Current;

			this.Cursor = Cursors.WaitCursor;	

			try
			{
				var cred = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ExcludeSharedTokenCacheCredential = true });

				var clients = DeviceClientQueryProvider.GetClientTopics(subscriptionId, resourceGroupName, namespaceName, cred);

				foreach (Client client in clients)
				{
					var enabledText = client.Enabled ? "Enabled" : "Disabled";

					lines.Add($"Client {client.Name} ({enabledText})");

					foreach (var topic in client.Topics)
					{
						lines.Add($"Can {topic.Usage} on: {topic.Name}");
					}

					lines.Add(string.Empty);
				}
			}
			catch (Exception)
			{
				lines.Add("This dialog can show all clients and related topics");
				lines.Add("Check this repo for details");
				lines.Add("https://github.com/sandervandevelde/MqttBrokerGraphApp");
			}
			finally
			{
				this.Cursor = oldCursor;
			}

			textBoxDeviceClients.Lines = lines.ToArray();
		}
	}
}
