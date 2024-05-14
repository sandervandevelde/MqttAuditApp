using MqttTopicManager;
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
	public partial class FormSettings : Form
	{
		Config _config;

		public FormSettings()
		{
			InitializeComponent();
		}

		public FormSettings(Config config) : this()
		{
			_config = config;

			checkBoxFollowLastTopic.Checked = _config.FollowLastTopic;
			numericUpDownHistoryLength.Value = _config.HistoryLength;
			textBoxTopicFilter.Text = _config.TopicFilter;
		}

		private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				_config.FollowLastTopic = checkBoxFollowLastTopic.Checked;
				_config.HistoryLength = Convert.ToInt32(numericUpDownHistoryLength.Value);
				_config.TopicFilter = textBoxTopicFilter.Text;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
