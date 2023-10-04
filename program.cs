using Discord;
using discord_bot.Commands;
using discord_bot.configuration;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot
{
    internal class program
    {
        private static DiscordClient? Client { get; set; }
        private static CommandsNextExtension? Commands { get; set; }
        private static TokenHandler Token { get; set; }
        

        static async Task Main(string[] args)
        {
            var token = Environment.GetEnvironmentVariable("DISCORDTOKEN");
            if(token != null)
            {
                var discordConfig = new DiscordConfiguration()
                {
                    Intents = DiscordIntents.All,
                    Token = token,
                    TokenType = DSharpPlus.TokenType.Bot,
                    AutoReconnect = true

                };

                Client = new DiscordClient(discordConfig);
                Client.Ready += Client_Ready;

                var commandsConfig = new CommandsNextConfiguration()
                {
                    StringPrefixes = new string[] { "!" },
                    EnableMentionPrefix = true,
                    EnableDms = true,
                    EnableDefaultHelp = true,
                };

                Commands = Client.UseCommandsNext(commandsConfig);
                Commands.RegisterCommands<TestCommands>();

                await Client.ConnectAsync();
                await Task.Delay(-1);
            }

        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
