using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot.configuration
{
    public class TokenHandler
    {
        public string Token { get; set; }
        public string prefix { get; set; }

        public async Task GetToken()
        {
            var env = Environment.GetEnvironmentVariable("DISCORDTOKEN");

            this.prefix = "!";
            this.Token = env;
        }
    }
}
