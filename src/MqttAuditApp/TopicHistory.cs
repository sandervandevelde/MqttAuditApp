

namespace MqttTopicManager
{
	public class TopicHistory : Dictionary<DateTime, string>
	{
		public int TrimCapacity { get; private set; }

        public TopicHistory(int trimCapacity)
        {
			TrimCapacity = trimCapacity;
		}

		public void Trim()
		{
			if (Count > TrimCapacity)
			{
				var key = this.OrderBy(x => x.Key).First().Key;

				this.Remove(key);
			}
		}
    }

}
