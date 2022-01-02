using System;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using PotatoBot.Data;

namespace PotatoBot.Commands
{
    public class Fun
    {
        private Random rng = new Random();

        [Command("greetings")]
        [Description("Say hi to potato bot")]
        [Aliases("hi", "yo", "yoyo", "sup")]
        public async Task Greetings(CommandContext ctx)
        {
            string[] greetingsPhrases = {
                "Greetings master.",
                "Praise be the potato.",
                "I await your instructions.",
                "I live to serve."
            };

            // Show typing symbol for PotatoBot
            await ctx.TriggerTypingAsync();

            // Send message
            await ctx.RespondAsync(greetingsPhrases[rng.Next(greetingsPhrases.Length)]);
        }

        [Command("dance")]
        [Description("Instructs PotatoBot to initate dance routines")]
        [Aliases("kickit")]
        public async Task Dance(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.DANCE_LINKS[rng.Next(Links.DANCE_LINKS.Length)]
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("ooo")]
        [Description("er... ?")]
        [Aliases("urgh", "mmm", "orgasm", "o", "oo")]
        public async Task ooo(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.OOO_LINKS[rng.Next(Links.OOO_LINKS.Length)],
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = $"{DiscordEmoji.FromName(ctx.Client, ":thermometer:")} {DiscordEmoji.FromName(ctx.Client, ":prayer_beads:")} {DiscordEmoji.FromName(ctx.Client, ":ok_hand:")}",
                }
            };

            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("cute")]
        [Description("Show a random cute gif")]
        [Aliases("eyebleech")]
        public async Task Cute(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.CUTE_LINKS[rng.Next(Links.CUTE_LINKS.Length)]
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("tb")]
        [Description("Summon our lord and savior, TotalBiscuit")]
        [Aliases("totalbiscuit", "totalhalibut", "cynicalbrit", "johnbain")]
        public async Task TotalBiscuit(CommandContext ctx)
        {
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":heart:");

            var embed = new DiscordEmbedBuilder {
                ImageUrl = Links.TOTALBISCUIT_LINKS[rng.Next(Links.TOTALBISCUIT_LINKS.Length)],
                Color = DiscordColor.DarkButNotBlack,
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = $"RIP John Bain, 8th July 1984 - 23th May 2018 {emoji} ",
                }
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("bullshit")]
        [Description("Potatobot calls it how it is")]
        [Aliases("bs", "horseshiet", "horseshit")]
        public async Task BullShit(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                ImageUrl = Links.BULLSHIT_LINKS[rng.Next(Links.BULLSHIT_LINKS.Length)],
                Color = DiscordColor.Gray
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("karlpilkington")]
        [Description("Potatobot calls it how it is")]
        [Aliases("kp", "twat", "pilkington")]
        public async Task KarlPilkington(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                ImageUrl = Links.KARL_PILK_BS,
                Color = DiscordColor.DarkButNotBlack
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("fact")]
        [Description("Get yourself some potato (fact-based) education son.")]
        [Aliases("potatofacts", "facts", "factets", "potatofact", "factet")]
        public async Task PotatoFact(CommandContext ctx)
        {
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":books:");

            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(Formatter.Italic(Strings.POTATO_FACTS[rng.Next(Strings.POTATO_FACTS.Length)]));
        }
    }
}
