# Slack.Net

> A simple client to send messages to Slack

## Installation

You can download the package from MyGet https://www.myget.org/feed/oli/package/nuget/Slack.Net

```
PM> Install-Package Slack.Net -Version 1.0.0-CI00000 -Source https://www.myget.org/F/oli/api/v3/index.json
```

## Configuration

appsettings.json

```json
{
	"SlackUrl": "<slack post url>",
}
```
Startup.cs

```cs
public void ConfigureServices(IServiceCollection services)
{
	services.AddHttpClient<ISlackClient, SlackClient>(c =>
		{
			c.BaseAddress = new Uri(Configuration["SlackUrl"]);
		});
}
```
Usage example in a Razor page

```cs
public class IndexModel : PageModel
{
    public ISlackClient slack { get; }

    public IndexModel(ISlackClient slackClient)
    {
        slack = slackClient;
    }

    public async Task OnGetAsync()
    {
        await slack.SendMessageAsync("Hello").ConfigureAwait(false);
    }
}
```
