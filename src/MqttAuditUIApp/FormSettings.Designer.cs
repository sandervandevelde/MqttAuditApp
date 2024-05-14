namespace MqttAuditUIApp
{
	partial class FormSettings
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
			checkBoxFollowLastTopic = new CheckBox();
			buttonCancel = new Button();
			buttonOK = new Button();
			numericUpDownHistoryLength = new NumericUpDown();
			labelHistoryLength = new Label();
			((System.ComponentModel.ISupportInitialize)numericUpDownHistoryLength).BeginInit();
			SuspendLayout();
			// 
			// checkBoxFollowLastTopic
			// 
			checkBoxFollowLastTopic.AutoSize = true;
			checkBoxFollowLastTopic.Location = new Point(80, 66);
			checkBoxFollowLastTopic.Name = "checkBoxFollowLastTopic";
			checkBoxFollowLastTopic.Size = new Size(226, 36);
			checkBoxFollowLastTopic.TabIndex = 0;
			checkBoxFollowLastTopic.Text = "Follow Last Topic";
			checkBoxFollowLastTopic.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.DialogResult = DialogResult.Cancel;
			buttonCancel.Location = new Point(623, 377);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(150, 46);
			buttonCancel.TabIndex = 1;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// buttonOK
			// 
			buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonOK.DialogResult = DialogResult.OK;
			buttonOK.Location = new Point(440, 377);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new Size(150, 46);
			buttonOK.TabIndex = 1;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += buttonOK_Click;
			// 
			// numericUpDownHistoryLength
			// 
			numericUpDownHistoryLength.Location = new Point(80, 208);
			numericUpDownHistoryLength.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
			numericUpDownHistoryLength.Name = "numericUpDownHistoryLength";
			numericUpDownHistoryLength.Size = new Size(240, 39);
			numericUpDownHistoryLength.TabIndex = 2;
			numericUpDownHistoryLength.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// labelHistoryLength
			// 
			labelHistoryLength.AutoSize = true;
			labelHistoryLength.Location = new Point(80, 163);
			labelHistoryLength.Name = "labelHistoryLength";
			labelHistoryLength.Size = new Size(170, 32);
			labelHistoryLength.TabIndex = 3;
			labelHistoryLength.Text = "History length:";
			// 
			// FormSettings
			// 
			AcceptButton = buttonOK;
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = buttonCancel;
			ClientSize = new Size(800, 450);
			Controls.Add(labelHistoryLength);
			Controls.Add(numericUpDownHistoryLength);
			Controls.Add(buttonOK);
			Controls.Add(buttonCancel);
			Controls.Add(checkBoxFollowLastTopic);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "FormSettings";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Settings";
			FormClosing += FormSettings_FormClosing;
			((System.ComponentModel.ISupportInitialize)numericUpDownHistoryLength).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private CheckBox checkBoxFollowLastTopic;
		private Button buttonCancel;
		private Button buttonOK;
		private NumericUpDown numericUpDownHistoryLength;
		private Label labelHistoryLength;
	}
}