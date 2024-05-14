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
			chartControlHistory = new Syncfusion.Windows.Forms.Chart.ChartControl();
			menuStrip1 = new MenuStrip();
			toolStripMenuItemTools = new ToolStripMenuItem();
			settingsToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItemHelp = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			panel1 = new Panel();
			((System.ComponentModel.ISupportInitialize)topicManagerBindingSource).BeginInit();
			menuStrip1.SuspendLayout();
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
			treeViewtopics.Location = new Point(0, 43);
			treeViewtopics.Name = "treeViewtopics";
			treeViewtopics.PathSeparator = "/";
			treeViewtopics.Size = new Size(752, 799);
			treeViewtopics.TabIndex = 0;
			treeViewtopics.AfterSelect += treeViewtopics_AfterSelect;
			// 
			// listBoxHistory
			// 
			listBoxHistory.Dock = DockStyle.Fill;
			listBoxHistory.FormattingEnabled = true;
			listBoxHistory.Location = new Point(752, 43);
			listBoxHistory.Name = "listBoxHistory";
			listBoxHistory.Size = new Size(762, 799);
			listBoxHistory.TabIndex = 1;
			// 
			// chartControlHistory
			// 
			chartControlHistory.ChartArea.CursorLocation = new Point(0, 0);
			chartControlHistory.ChartArea.CursorReDraw = false;
			chartControlHistory.IsWindowLess = false;
			// 
			// 
			// 
			chartControlHistory.Legend.Location = new Point(643, 31);
			chartControlHistory.Legend.Visible = false;
			chartControlHistory.Localize = null;
			chartControlHistory.Location = new Point(592, 155);
			chartControlHistory.Name = "chartControlHistory";
			chartControlHistory.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
			chartControlHistory.PrimaryXAxis.Margin = true;
			chartControlHistory.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
			chartControlHistory.PrimaryYAxis.Margin = true;
			chartControlHistory.Size = new Size(800, 600);
			chartControlHistory.TabIndex = 2;
			// 
			// 
			// 
			chartControlHistory.Title.Name = "Default";
			chartControlHistory.ToolBar.ButtonSize = new Size(44, 44);
			chartControlHistory.VisualTheme = "";
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(32, 32);
			menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemTools, toolStripMenuItemHelp });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1514, 40);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItemTools
			// 
			toolStripMenuItemTools.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
			toolStripMenuItemTools.Name = "toolStripMenuItemTools";
			toolStripMenuItemTools.Size = new Size(89, 36);
			toolStripMenuItemTools.Text = "Tools";
			// 
			// settingsToolStripMenuItem
			// 
			settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			settingsToolStripMenuItem.Size = new Size(233, 44);
			settingsToolStripMenuItem.Text = "Settings";
			settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
			// 
			// toolStripMenuItemHelp
			// 
			toolStripMenuItemHelp.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
			toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
			toolStripMenuItemHelp.Size = new Size(84, 36);
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
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1514, 842);
			Controls.Add(chartControlHistory);
			Controls.Add(listBoxHistory);
			Controls.Add(treeViewtopics);
			Controls.Add(panel1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MQTT Audit";
			Load += MainForm_Load;
			Shown += MainForm_Shown;
			Resize += MainForm_Resize;
			((System.ComponentModel.ISupportInitialize)topicManagerBindingSource).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private BindingSource topicManagerBindingSource;
		private TreeView treeViewtopics;
		private ListBox listBoxHistory;
		private Syncfusion.Windows.Forms.Chart.ChartControl chartControlHistory;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem toolStripMenuItemTools;
		private ToolStripMenuItem settingsToolStripMenuItem;
		private ToolStripMenuItem toolStripMenuItemHelp;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Panel panel1;
	}
}
