using System;
using System.Threading.Tasks;
using System.Text;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace PotatoBot
{
    public class UngrouppedCommands
    {
        [Command("greetings")]
        [Description("Say hi to potato bot")]
        [Aliases("hi", "yo", "yoyo", "sup")]
        public async Task Greetings(CommandContext ctx)
        {
            // Show typing symbol for PotatoBot
            await ctx.TriggerTypingAsync();

            // Send message
            var emoji = DiscordEmoji.FromName(ctx.Client, ":bust_in_silhouette:");
            await ctx.RespondAsync($"{emoji} Greetings master.");
        }
    }
}
