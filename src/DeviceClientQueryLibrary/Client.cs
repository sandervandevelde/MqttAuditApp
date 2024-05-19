namespace DeviceClientQueryLibrary
{
	public class Client
	{
		public Client() 
		{
			Topics = new List<Topic>();
		}

        public string Name { get; set; }

		public List<Topic> Topics { get; private set; }
    }
}
