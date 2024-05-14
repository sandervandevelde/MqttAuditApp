namespace MqttAuditUIApp
{
	partial class FormAbout
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
			buttonClose = new Button();
			richTextBox1 = new RichTextBox();
			SuspendLayout();
			// 
			// buttonClose
			// 
			buttonClose.Anchor = AnchorStyles.Bottom;
			buttonClose.Location = new Point(323, 433);
			buttonClose.Name = "buttonClose";
			buttonClose.Size = new Size(150, 46);
			buttonClose.TabIndex = 0;
			buttonClose.Text = "Close";
			buttonClose.UseVisualStyleBackColor = true;
			buttonClose.Click += buttonClose_Click;
			// 
			// richTextBox1
			// 
			richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			richTextBox1.BorderStyle = BorderStyle.None;
			richTextBox1.Location = new Point(53, 33);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
			richTextBox1.Size = new Size(686, 365);
			richTextBox1.TabIndex = 1;
			richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// FormAbout
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 500);
			Controls.Add(richTextBox1);
			Controls.Add(buttonClose);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "FormAbout";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "About";
			ResumeLayout(false);
		}

		#endregion

		private Button buttonClose;
		private RichTextBox richTextBox1;
	}
}