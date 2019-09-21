using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Slack.Net
{
    public class SlackClient : ISlackClient
    {
        private readonly HttpClient httpClient;

        public SlackClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Post a message using simple strings
        public async Task SendMessageAsync(string text, string username = null, string channel = null)
        {
            Payload payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Text = text
            };

            var response = await httpClient.PostAsJsonAsync("", payload);
            response.EnsureSuccessStatusCode();
        }
    }

    //This class serializes into the Json payload required by Slack Incoming WebHooks
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
