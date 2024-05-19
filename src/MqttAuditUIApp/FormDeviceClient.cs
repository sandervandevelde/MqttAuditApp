﻿using Azure.Identity;
using DeviceClientQueryLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MqttAuditUIApp
{
	public partial class FormDeviceClient : Form
	{
		public FormDeviceClient()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormDeviceClient_Activated(object sender, EventArgs e)
		{
			string? subscriptionId = Environment.GetEnvironmentVariable("mqtt-graph-subscriptionid");
			string? resourceGroupName = Environment.GetEnvironmentVariable("mqtt-graph-resourcegroupname"); ;
			string? namespaceName = Environment.GetEnvironmentVariable("mqtt-graph-namespacename");

			var lines = new List<string>();

			this.Cursor = Cursors.WaitCursor;

			try
			{
				var cred = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ExcludeSharedTokenCacheCredential = true });

				var clients = DeviceClientQueryProvider.GetClientTopics(subscriptionId, resourceGroupName, namespaceName, cred);

				foreach (Client client in clients)
				{
					lines.Add($"Client {client.Name}");

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
				this.Cursor = Cursors.Default;
			}

			textBoxDeviceClients.Lines = lines.ToArray();
		}
	}
}