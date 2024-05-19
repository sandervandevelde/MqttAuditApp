using System.Text.RegularExpressions;

namespace DeviceClientQueryLibrary
{
	public class DeviceClientQueryHelper
	{
		// attributes.type IN ['audit']
		// attributes.type IN ['audit', 'a', 'AA',99]
		// attributes.type = "audit"
		// attributes.type != "audit"
		// attributes.type <> "audit"
		public static bool Query(string query, KeyValuePair<string, System.BinaryData> attribute)
		{
			// attribute
			var key = attribute.Key;
			var value = attribute.Value.ToString().Replace("\"", "");

			if (query.Contains(" IN ")
					|| query.Contains(" in "))
			{
				// IN pattern
				string pattern = @"attributes\.(\w+) [IN|in]+ \[([a-zA-Z',\s\d]+)\]";

				foreach (Match m in Regex.Matches(query, pattern))
				{
					var groupKey = m.Groups[1].Value;
					var groupValues = m.Groups[2].Value;

					groupValues = groupValues.Replace("'", "");
					groupValues = groupValues.Replace(" ", "");

					var groupValuesList = groupValues.Split(',');

					foreach (var groupValue in groupValuesList)
					{
						if (key == groupKey && value == groupValue)
						{
							return true;
						}
					}
				}
			}

			if (query.Contains(" = "))
			{
				// IN pattern
				string pattern = @"attributes\.(\w+) = ""([a-zA-Z',\s\d]+)""";

				foreach (Match m in Regex.Matches(query, pattern))
				{
					var groupKey = m.Groups[1].Value;
					var groupValue = m.Groups[2].Value;

					if (key == groupKey && value == groupValue)
					{
						return true;
					}
				}
			}

			if (query.Contains(" <> ")
					|| query.Contains(" != "))
			{
				// IN pattern
				string pattern = @"attributes\.(\w+) [<>|!=]+ ""([a-zA-Z',\s\d]+)""";

				var MatchFound = false;

				foreach (Match m in Regex.Matches(query, pattern))
				{
					var groupKey = m.Groups[1].Value;
					var groupValue = m.Groups[2].Value;

					if (key == groupKey && value == groupValue)
					{
						MatchFound = true;

						break;
					}
				}

				return !MatchFound;
			}

			return false;
		}
	}
}
