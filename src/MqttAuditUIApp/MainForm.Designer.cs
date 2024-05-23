using System;

namespace MqttAuditUIApp
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
			menuStrip1 = new MenuStrip();
			toolStripMenuItemTools = new ToolStripMenuItem();
			settingsToolStripMenuItem = new ToolStripMenuItem();
			mqttBrokerClientsToolStripMenuItem = new ToolStripMenuItem();
			pauseToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItemHelp = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			panel1 = new Panel();
			chartDecimals = new System.Windows.Forms.DataVisualization.Charting.Chart();
			splitContainer1 = new SplitContainer();
			((System.ComponentModel.ISupportInitialize)topicManagerBindingSource).BeginInit();
			menuStrip1.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)chartDecimals).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// topicManagerBindingSource
			// 
			topicManagerBindingSource.DataSource = typeof(MqttTopicManager.TopicManager);
			// 
			// treeViewtopics
			// 
			treeViewtopics.Dock = DockStyle.Fill;
			treeViewtopics.FullRowSelect = true;
			treeViewtopics.Location = new Point(0, 0);
			treeViewtopics.Name = "treeViewtopics";
			treeViewtopics.PathSeparator = "/";
			treeViewtopics.Size = new Size(504, 799);
			treeViewtopics.TabIndex = 0;
			treeViewtopics.AfterSelect += treeViewtopics_AfterSelect;
			// 
			// listBoxHistory
			// 
			listBoxHistory.Dock = DockStyle.Fill;
			listBoxHistory.FormattingEnabled = true;
			listBoxHistory.Location = new Point(0, 0);
			listBoxHistory.Name = "listBoxHistory";
			listBoxHistory.Size = new Size(1006, 799);
			listBoxHistory.TabIndex = 1;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(32, 32);
			menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemTools, toolStripMenuItemHelp });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1514, 42);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItemTools
			// 
			toolStripMenuItemTools.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, mqttBrokerClientsToolStripMenuItem, pauseToolStripMenuItem });
			toolStripMenuItemTools.Name = "toolStripMenuItemTools";
			toolStripMenuItemTools.Size = new Size(89, 38);
			toolStripMenuItemTools.Text = "Tools";
			// 
			// settingsToolStripMenuItem
			// 
			settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			settingsToolStripMenuItem.Size = new Size(363, 44);
			settingsToolStripMenuItem.Text = "Settings";
			settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
			// 
			// mqttBrokerClientsToolStripMenuItem
			// 
			mqttBrokerClientsToolStripMenuItem.Name = "mqttBrokerClientsToolStripMenuItem";
			mqttBrokerClientsToolStripMenuItem.Size = new Size(363, 44);
			mqttBrokerClientsToolStripMenuItem.Text = "MQTT Broker clients";
			mqttBrokerClientsToolStripMenuItem.Click += mqttBrokerClientsToolStripMenuItem_Click;
			// 
			// pauseToolStripMenuItem
			// 
			pauseToolStripMenuItem.CheckOnClick = true;
			pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			pauseToolStripMenuItem.Size = new Size(363, 44);
			pauseToolStripMenuItem.Text = "Pause";
			pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
			// 
			// toolStripMenuItemHelp
			// 
			toolStripMenuItemHelp.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
			toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
			toolStripMenuItemHelp.Size = new Size(84, 38);
			toolStripMenuItemHelp.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(212, 44);
			aboutToolStripMenuItem.Text = "About";
			aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
			// 
			// panel1
			// 
			panel1.Controls.Add(menuStrip1);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(1514, 43);
			panel1.TabIndex = 1;
			// 
			// chartDecimals
			// 
			chartDecimals.Dock = DockStyle.Fill;
			chartDecimals.Location = new Point(0, 0);
			chartDecimals.Name = "chartDecimals";
			chartDecimals.Size = new Size(1006, 799);
			chartDecimals.TabIndex = 2;
			chartDecimals.Text = "chart2";
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 43);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(treeViewtopics);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(chartDecimals);
			splitContainer1.Panel2.Controls.Add(listBoxHistory);
			splitContainer1.Size = new Size(1514, 799);
			splitContainer1.SplitterDistance = 504;
			splitContainer1.TabIndex = 3;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1514, 842);
			Controls.Add(splitContainer1);
			Controls.Add(panel1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Azure EventGrid Namespace MQTT Explorer";
			Load += MainForm_Load;
			Shown += MainForm_Shown;
			Resize += MainForm_Resize;
			((System.ComponentModel.ISupportInitialize)topicManagerBindingSource).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)chartDecimals).EndInit();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private BindingSource topicManagerBindingSource;
		private TreeView treeViewtopics;
		private ListBox listBoxHistory;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem toolStripMenuItemTools;
		private ToolStripMenuItem settingsToolStripMenuItem;
		private ToolStripMenuItem toolStripMenuItemHelp;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Panel panel1;
		private ToolStripMenuItem pauseToolStripMenuItem;
		private ToolStripMenuItem mqttBrokerClientsToolStripMenuItem;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartDecimals;
		private SplitContainer splitContainer1;
	}
}
