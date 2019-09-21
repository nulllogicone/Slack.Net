# Slack.Net

> A simple client to send messages to Slack

## Installation

You can download the package from MyGet

## Configuration

appsettings.json

```json
{
	  "SlackUrl": "<slack post url>",
}
```
Startup.cs

```cs
        services.AddHttpClient<ISlackClient, SlackClient>(c =>
            {
                c.BaseAddress = new Uri(Configuration["SlackUrl"]);
            });
```