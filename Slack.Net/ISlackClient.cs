using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Net
{
    public interface ISlackClient
    {
        Task SendMessageAsync(string text, string username = null, string channel = null);
    }
}
