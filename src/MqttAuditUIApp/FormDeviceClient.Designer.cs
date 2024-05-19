namespace MqttAuditUIApp
{
	partial class FormDeviceClient
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
			buttonClose = new Button();
			textBoxDeviceClients = new TextBox();
			SuspendLayout();
			// 
			// buttonClose
			// 
			buttonClose.Anchor = AnchorStyles.Bottom;
			buttonClose.Location = new Point(337, 378);
			buttonClose.Name = "buttonClose";
			buttonClose.Size = new Size(150, 46);
			buttonClose.TabIndex = 1;
			buttonClose.Text = "Close";
			buttonClose.UseVisualStyleBackColor = true;
			buttonClose.Click += buttonClose_Click;
			// 
			// textBoxDeviceClients
			// 
			textBoxDeviceClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBoxDeviceClients.Location = new Point(28, 24);
			textBoxDeviceClients.Multiline = true;
			textBoxDeviceClients.Name = "textBoxDeviceClients";
			textBoxDeviceClients.ReadOnly = true;
			textBoxDeviceClients.ScrollBars = ScrollBars.Both;
			textBoxDeviceClients.Size = new Size(741, 325);
			textBoxDeviceClients.TabIndex = 2;
			// 
			// FormDeviceClient
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textBoxDeviceClients);
			Controls.Add(buttonClose);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			Name = "FormDeviceClient";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Device clients";
			Activated += FormDeviceClient_Activated;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonClose;
		private TextBox textBoxDeviceClients;
	}
}