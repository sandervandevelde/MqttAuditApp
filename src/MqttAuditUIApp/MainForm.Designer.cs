﻿namespace MqttAuditUIApp
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			topicManagerBindingSource = new BindingSource(components);
			treeViewtopics = new TreeView();
			listBoxHistory = new ListBox();
			panel1 = new Panel();
			checkBoxFollowLastTopic = new CheckBox();
			((System.ComponentModel.ISupportInitialize)topicManagerBindingSource).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// topicManagerBindingSource
			// 
			topicManagerBindingSource.DataSource = typeof(MqttTopicManager.TopicManager);
			// 
			// treeViewtopics
			// 
			treeViewtopics.Dock = DockStyle.Left;
			treeViewtopics.FullRowSelect = true;
			treeViewtopics.Location = new Point(0, 85);
			treeViewtopics.Name = "treeViewtopics";
			treeViewtopics.PathSeparator = "/";
			treeViewtopics.Size = new Size(752, 757);
			treeViewtopics.TabIndex = 0;
			treeViewtopics.AfterSelect += treeViewtopics_AfterSelect;
			// 
			// listBoxHistory
			// 
			listBoxHistory.Dock = DockStyle.Fill;
			listBoxHistory.FormattingEnabled = true;
			listBoxHistory.Location = new Point(752, 85);
			listBoxHistory.Name = "listBoxHistory";
			listBoxHistory.Size = new Size(762, 757);
			listBoxHistory.TabIndex = 1;
			// 
			// panel1
			// 
			panel1.Controls.Add(checkBoxFollowLastTopic);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(1514, 85);
			panel1.TabIndex = 1;
			// 
			// checkBoxFollowLastTopic
			// 
			checkBoxFollowLastTopic.AutoSize = true;
			checkBoxFollowLastTopic.Checked = true;
			checkBoxFollowLastTopic.CheckState = CheckState.Checked;
			checkBoxFollowLastTopic.Location = new Point(20, 24);
			checkBoxFollowLastTopic.Name = "checkBoxFollowLastTopic";
			checkBoxFollowLastTopic.Size = new Size(226, 36);
			checkBoxFollowLastTopic.TabIndex = 0;
			checkBoxFollowLastTopic.Text = "Follow Last Topic";
			checkBoxFollowLastTopic.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1514, 842);
			Controls.Add(listBoxHistory);
			Controls.Add(treeViewtopics);
			Controls.Add(panel1);
			Name = "MainForm";
			Text = "MQTT Audit";
			Load += MainForm_Load;
			((System.ComponentModel.ISupportInitialize)topicManagerBindingSource).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private BindingSource topicManagerBindingSource;
		private TreeView treeViewtopics;
		private ListBox listBoxHistory;
		private Panel panel1;
		private CheckBox checkBoxFollowLastTopic;
	}
}