

namespace MqttTopicManager
{
	public class Config
	{
		public int HistoryLength { get; set; } = 50;

		public bool FollowLastTopic { get; set; } = true;

		public string TopicFilter { get; set; }

		public bool Paused { get; set; }
	}
}
