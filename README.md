# Azure EventGrid namespace Mqtt Audit App

## Introduction

This tool can visualize all incoming Azure EventGrid namespace MQTT broker messages on all topics. It simply listens to '#'.

Notice this only works when a device client is created with this ability.

## What is offered? 

Depending on the first value received for a certain topic, a bar chart or a list box is shown:

![image](https://github.com/sandervandevelde/MqttAuditApp/assets/694737/3041ea3e-33ce-4d38-b7d9-749993500112)

Per topic, the last 50 values are remembered.

Using a checkbox, you can toggle between updating the preview to the last incoming topic value or following just one selected topic.


## MQTTnet client extensions

This tool is built around the MQTTnet.Client.Extensions library, available at [GitHub](https://github.com/Azure-Samples/MqttApplicationSamples/tree/main/mqttclients/dotnet).

This means you need to create an Azure EventGrid MQTT client and fill in the environment variables as seen [here](https://github.com/Azure-Samples/MqttApplicationSamples/tree/main/mqttclients).

## EventGrid namespace MQTT client

The following EventGrid namespace MQTT client settings must be added to your MQTT broker:

- A client must be created using an X509 client certificate
- This client has a client string attribute with key 'type' and value 'audit'
- A client group named 'auditgroup' with query "attributes.type IN ['audit']" points to this device
- A topic space named 'audit-topic' contains a template with the name 'audit-topic' and value '#'
- A permission binding named 'audit-subscribe-to-all-topics' for client group 'Client group name' and Topic space name 'audit-topic' with Permission 'Subscriber' is created

## Winform

This demonstration is created as a Winform application.

A (community) license of the [Syncfusion](https://www.syncfusion.com/) library is used for the bar chart.

The code is checked in without a key so you get a notification when you start the application.

You can rebuild the tool using your own valid key.

## Contributions

Feel free to contribute, pull requests are appreciated.

Another kind of UI or automatic client registration in the MQTT broker could be a great addition.
