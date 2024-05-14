using MqttTopicManager;

namespace MqttAuditUIApp
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");

			var config = new Config();

			var _topicManager = new TopicManager(config);

			var form = new MainForm(_topicManager, config);

			Application.Run(form);
		}
	}
}