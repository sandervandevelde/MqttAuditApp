using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager;
using Azure.Identity;
using System.Collections.Generic;

namespace DeviceClientQueryLibrary
{
	public class DeviceClientQueryProvider
	{
		public static List<Client> GetClientTopics(string subscriptionId, string resourceGroupName, string namespaceName, DefaultAzureCredential cred)
		{
			ArmClient armClient = new ArmClient(cred);

			var eventGridNamespaceResourceId = EventGridNamespaceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, namespaceName);
			EventGridNamespaceResource eventGridNamespace = armClient.GetEventGridNamespaceResource(eventGridNamespaceResourceId);

			var collectionClients = eventGridNamespace.GetEventGridNamespaceClients();
			var allClients = collectionClients.GetAll();
			var listClients = allClients.ToList();

			var collectionClientGroups = eventGridNamespace.GetEventGridNamespaceClientGroups();
			var allClientGroups = collectionClientGroups.GetAll();
			var listClientGroups = allClientGroups.ToList();

			var collectionPermissionBindings = eventGridNamespace.GetEventGridNamespacePermissionBindings();
			var allPermissionBindings = collectionPermissionBindings.GetAll();
			var listPermissionBindings = allPermissionBindings.ToList();

			var collectionTopicSpaces = eventGridNamespace.GetTopicSpaces();
			var allTopicSpaces = collectionTopicSpaces.GetAll();
			var listTopicSpaces = allTopicSpaces.ToList();

			var clients = new List<Client>();

			// all clients related to the query eg. " attributes.type IN ['audit'] "
			foreach (var clientInList in listClients)
			{
				var clientInGroups = new List<EventGridNamespaceClientGroupResource>();

				var clientPublisherPermissingBindings = new List<EventGridNamespacePermissionBindingResource>();

				var clientSubscriberPermissingBindings = new List<EventGridNamespacePermissionBindingResource>();

				var clientPublisherTopicTemplates = new List<string>();

				var clientSubscriberTopicTemplates = new List<string>();

				foreach (var attribute in clientInList.Data.Attributes)
				{
					foreach (var clientGroup in listClientGroups)
					{
						if ((clientGroup.Data.Query.ToLower() == "true")
								|| DeviceClientQueryHelper.Query(clientGroup.Data.Query, attribute))
						{
							if (!clientInGroups.Any(x => x.Id == clientGroup.Id))
							{
								clientInGroups.Add(clientGroup);
							}
						}
					}
				}

				foreach (var permissionBinding in listPermissionBindings)
				{
					var clientGroup = clientInGroups.FirstOrDefault(x => x.Data.Name == permissionBinding.Data.ClientGroupName);

					if (clientGroup != null)
					{
						if (permissionBinding.Data.Permission.Value == PermissionType.Subscriber)
						{
							if (!clientSubscriberPermissingBindings.Any(x => x.Id == permissionBinding.Id))
							{
								clientSubscriberPermissingBindings.Add(permissionBinding);
							}
						}

						if (permissionBinding.Data.Permission.Value == PermissionType.Publisher)
						{
							if (!clientPublisherPermissingBindings.Any(x => x.Id == permissionBinding.Id))
							{
								clientPublisherPermissingBindings.Add(permissionBinding);
							}
						}
					}
				}

				foreach (var clientPublisherPermissingBinding in clientPublisherPermissingBindings)
				{
					var topicSpace = listTopicSpaces.First(x => x.Data.Name == clientPublisherPermissingBinding.Data.TopicSpaceName);

					clientPublisherTopicTemplates.AddRange(topicSpace.Data.TopicTemplates);
				}

				foreach (var clientSubscriberPermissingBinding in clientSubscriberPermissingBindings)
				{
					var topicSpace = listTopicSpaces.First(x => x.Data.Name == clientSubscriberPermissingBinding.Data.TopicSpaceName);

					clientSubscriberTopicTemplates.AddRange(topicSpace.Data.TopicTemplates);
				}

				var client = new Client();
				client.Name = clientInList.Data.Name;
				client.Enabled = clientInList.Data.State.Value.ToString() == "Enabled";

				foreach (var topicTemplate in clientPublisherTopicTemplates)
				{
					var topicName = topicTemplate.Replace("${client.authenticationName}", clientInList.Data.Name);

					var topic = new Topic();
					topic.Name = topicName;
					topic.Usage = "Publish";
					client.Topics.Add(topic);
				}

				foreach (var topicTemplate in clientSubscriberTopicTemplates)
				{
					var topicName = topicTemplate.Replace("${client.authenticationName}", clientInList.Data.Name);

					var topic = new Topic();
					topic.Name = topicName;
					topic.Usage = "Subscribe";
					client.Topics.Add(topic);
				}

				clients.Add(client);
			}

			return clients;
		}
	}
}
