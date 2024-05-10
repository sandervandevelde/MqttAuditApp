

namespace MqttTopicManager
{
	public class TopicManager
	{
		public Dictionary<string, TopicHistory> TopicHistories { get; private set; }

        public TopicManager()
        {
			TopicHistories = new Dictionary<string, TopicHistory>();
        }

        public void Receive(string topic, string payload)
		{
			if (!TopicHistories.Keys.Contains(topic))
			{
				var topicHistory = new TopicHistory(50);

				TopicHistories.Add(topic, topicHistory);
			}

			var topicToUpdate = TopicHistories[topic];

			topicToUpdate.Add(DateTime.Now,payload);

			topicToUpdate.Trim();
		}
	}

}
