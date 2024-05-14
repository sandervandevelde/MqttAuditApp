

namespace MqttTopicManager
{
	public class TopicManager
	{
		private Config _config;

		public Dictionary<string, TopicHistory> TopicHistories { get; private set; }

        public TopicManager(Config config)
        {
			_config = config;

			TopicHistories = new Dictionary<string, TopicHistory>();
        }

        public void Receive(string topic, string payload)
		{
			if (!TopicHistories.Keys.Contains(topic))
			{
				var topicHistory = new TopicHistory();

				TopicHistories.Add(topic, topicHistory);
			}

			TopicHistories[topic].Add(DateTime.Now, payload, _config.HistoryLength);
		}
	}
}
