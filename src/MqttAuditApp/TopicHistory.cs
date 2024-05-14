

namespace MqttTopicManager
{
	public class TopicHistory : Dictionary<DateTime, string>
	{
		private void Trim(int trimCapacity)
		{
			if (Count > trimCapacity)
			{
				var key = this.OrderBy(x => x.Key).First().Key;

				this.Remove(key);
			}
		}

		public void Add(DateTime timeStamp, string value, int trimCapacity)
		{
			this.Add(timeStamp, value);

			Trim(trimCapacity);
		}
    }
}
