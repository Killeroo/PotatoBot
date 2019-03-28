using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

using PotatoBot.Data;

namespace PotatoBot.Commands
{
    class Games
    {
        private Random rng = new Random();

        [Command("poll")]
        [Description("Run a poll with reactions.")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Poll(CommandContext ctx,
                        [Description("How long the poll should last.")] TimeSpan duration,
                        [Description("What options should the poll have.")] params DiscordEmoji[] options)
        {
            ctx.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"{ctx.Member.Username} started a poll between: {options.ToString()}", DateTime.Now);

            // Load interactivity module and poll options
            InteractivityModule interactivity = ctx.Client.GetInteractivityModule();
            var pollOptions = options.Select(xe => xe.ToString());

            // Display the poll
            var embed = new DiscordEmbedBuilder {
                Title = "Poll Time!",
                Color = DiscordColor.DarkGray,
                Description = "Choose your fighter: " + string.Join(" ", pollOptions)
            };
            DiscordMessage msg = await ctx.RespondAsync(embed: embed);

            // Add options as reactions
            for (int i = 0; i < options.Length; i++) {
                await msg.CreateReactionAsync(options[i]);
            }

            // Collect responses
            ReactionCollectionContext pollResult = await interactivity.CollectReactionsAsync(msg, duration); //TODO: Why this not working?
            var results = pollResult.Reactions.Where(xkvp => options.Contains(xkvp.Key))
                .Select(xkvp => $"{xkvp.Key}: {xkvp.Value}");

            // Post response
            await ctx.RespondAsync(string.Join("\n", results));
        }

        [Command("rtd")]
        [Description("Rolls a dice for a user")]
        [Aliases("roll", "rollthedice")]
        [RequireRolesAttribute("unbaked one")]
        public async Task RollTheDice(CommandContext ctx)
        {
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":game_die:");

            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{emoji} {ctx.Member.Mention} rolls {rng.Next(0, 101)} (0-100)");
        }

        [Command("8ball")]
        [Description("Potatobot consults his magic 8ball")]
        [Aliases("future")]
        [RequireRolesAttribute("unbaked one")]
        // Source: https://github.com/MonikaDiscord/Monika/blob/71b025237010da9e7c9a914721d9d75e1aad3cc4/modules/fun.py#L93
        public async Task EightBall(CommandContext ctx)
        {
            Random rng = new Random();
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":8ball:");

            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{emoji} My magic 8ball says... '{Strings.MAGIC_EIGHT_BALL_RESPONSES[rng.Next(Strings.MAGIC_EIGHT_BALL_RESPONSES.Length)]}'");
        }
    }
}
