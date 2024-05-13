# MqttAuditApp

## Introduction

This tool can visualize all incoming MQTT messages on all topic. It simply listens to '#'.
 Notice this only works when a device client is created with this ability.

 ## MQTTnet client extensions

 This tool is build around the MQTTnet.Client.Extensions library, available at [GitHub](https://github.com/Azure-Samples/MqttApplicationSamples/tree/main/mqttclients/dotnet).

 This means you need to create an Azure EventGrid MQTT client and fill in the environment variables as seen [here](https://github.com/Azure-Samples/MqttApplicationSamples/tree/main/mqttclients).

 ## EventGrid namespace MQTT client

 The following EventGrid namespace MQTT client settings must be added to your MQTT broker:

 - A client must be created using an X509 client certificate
 - This client has a client string attribute with key 'type' and value 'audit'
 - A client group named 'auditgroup' with query "attributes.type IN ['audit']" points to this device
 - A topic space named 'audit-topic' contains a template with name 'audit-topic' and value '#'
 - A permission binding named 'audit-subscribe-to-all-topics' for client group 'Client group name' and Topic space name 'audit-topic' with Permission 'Subscriber' is created

## Winform

This demonstration is created as a Winform application.

For the line chart, a (community) license of the Syncfusion library is used.

## Contributions

Feel free to contribute, pull requests are apriciated.

Another kind of UI or automatic client registration in the MQTT broker could be great additions.
