using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot.Commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task MeuPrimeiroComando(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Olá {ctx.User.Username}");
            await ctx.Channel.SendMessageAsync(ctx.User.AvatarUrl);
            
        }

        [Command("embed")]
        public async Task Embed(CommandContext ctx)
        {
            var message = new DiscordMessageBuilder()
                 .AddEmbed(new DiscordEmbedBuilder()
                 .WithColor(color: DiscordColor.PhthaloGreen)
                 .WithTitle("Esse é meu primeiro bot de discord!")
                 .WithThumbnail(ctx.User.AvatarUrl)
                 .WithDescription($"This command was executed by {ctx.User.Username}")
                 .ClearFields()
                 );

            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
