using System;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using PotatoBot.Events;

namespace PotatoBot.Commands
{
    public class Utility
    {
        [Command("status")]
        [Description("Displays the current state of PotatoBot")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Status(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            // Construct embed
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":tools:");
            var embed = new DiscordEmbedBuilder {
                Title = $"{emoji} Status",
                ImageUrl = Links.PREACH_OK,
                ThumbnailUrl = Links.ICON_IMAGE

            };
            embed.AddField("Version", Program.VERSION, true);
            embed.AddField("DSharp Version", ctx.Client.VersionString, true);
            embed.AddField("Ping", ctx.Client.Ping.ToString(), true);
            embed.AddField("Connected to", ctx.Guild.Name.ToString());
            embed.AddField("Server location", ctx.Guild.RegionId, true);
            embed.AddField("Uptime", (DateTime.Now - Stats.StartTime).ToString());
            embed.AddField("Running on", Stats.PCName);
            embed.AddField("Mentions", Stats.Mentions.ToString());
            embed.AddField("Commands Executed", Stats.CommandsExecuted.ToString());
            embed.AddField("Command Errors", Stats.CommandErrors.ToString(), true);
            embed.AddField("Client Errors", Stats.ClientErrors.ToString(), true);
            embed.WithColor(DiscordColor.Goldenrod);
            embed.WithFooter("<3 PotatoBot & Pals");

            // Display embed
            await ctx.RespondAsync(embed: embed);
        }
        
        [Command("changelog")]
        [Description("Shows current changes made to potatobot")]
        [Aliases("changes")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Changelog(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            // Create embed
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":tools:");
            var embed = new DiscordEmbedBuilder {
                Title = $"{emoji} Changelog",
                Color = DiscordColor.Goldenrod,
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = "Praise be the potato",
                }
            };
            embed.AddField("Version 0.6",
                "- Added urbandictonary command\n" +
                "- Added karlpilkington command\n" +
                "- Added toggleerrormsg command\n" +
                "- Added some more gifs\n" +
                "- Switched names of some commands\n" +
                "- Removed reply trigger from gif commands\n ");
            embed.AddField("Version 0.5.8",
                "- Updated togethertube command");
            embed.AddField("Version 0.5.7",
                "- Removed timer code\n" +
                "- Added 8ball command\n" +
                "- Added togethertube command\n");
            embed.AddField("Version 0.5.6",
                "- Added bullshit command\n");
            embed.AddField("Version 0.5.5",
                "- Updated TB command footer\n" +
                "- Added ping pong command (from example-bots)\n" +
                "- Added some aliases \n" +
                "- Deleting of announce message\n");
            embed.AddField("Version 0.5.4",
                "- Added TotalBiscuit command\n" +
                "- Some refactoring\n" +
                "- More gifs\n");
            embed.AddField("Version 0.5.3",
                "- Fixed formatting in changelog\n" +
                "- Added some more gifs\n");
            embed.AddField("Version 0.5.2",
                "- Added lol command\n" +
                "- Added commands executed\n");
            embed.AddField("Version 0.5.1\n",
                 "- Fixed some small typos");
            embed.AddField("Version 0.5",
                "- Added response to hi\n" +
                "- Auto role assignment on first join\n" +
                "- Now tracks mentions\n" +
                "- Added changelog command\n" +
                "- Did up announcement command");
            embed.AddField("Version 0.4",
                "- Added roll the dice command (rtd)\n" +
                "- Added announce command\n" +
                "- Added poll command\n" +
                "- Updated status and statistics command\n" +
                "- Refactoring and cleanup\n");
            embed.AddField("Version 0.3",
                "- Added more events\n" +
                "- Added message logging\n" +
                "- Reorganised startup\n");
            embed.AddField("Version 0.2",
                "- Added greetings command\n" +
                "- Add basic events\n" +
                "- Removed examplebot code\n" +
                "- Added Command help formatter\n");
            embed.AddField("Version 0.1",
                "- Initial release");
            embed.WithColor(DiscordColor.Goldenrod);

            // Present the embed
            await ctx.RespondAsync(embed: embed);
        }

        [Command("announce")]
        [Description("Announces a message to the server")]
        [Aliases("say", "tell", "yell", "shout")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Announce(CommandContext ctx, [Description("What should be announced")] params string[] message)
        {
            string annoucement = string.Join(" ", message);
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":trumpet:");
            ctx.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"{ctx.Member.Username} announces \"{annoucement}\" to the server", DateTime.Now);

            // Construct embed
            var embed = new DiscordEmbedBuilder {
                Title = $"{emoji} Announcement",
                Color = DiscordColor.Orange,
                Description = Formatter.Bold(annoucement) + " - " + Formatter.Italic(ctx.Member.Username),
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = "Praise be the potato",
                }
            };

            // Delete command message
            await ctx.Message.DeleteAsync();

            // Send embed to all channels in guild
            foreach (var channel in ctx.Guild.Channels) {
                if (channel.Type == ChannelType.Text) {
                    await channel.TriggerTypingAsync();
                    await channel.SendMessageAsync(embed: embed);
                }
            }
        }

        [Command("ping")]
        [Description("Displays potatobot's current ping")]
        [Aliases("pong")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Ping(CommandContext ctx)
        {
            // respond with current ping
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{DiscordEmoji.FromName(ctx.Client, ":ping_pong:")} Pong! Ping: {ctx.Client.Ping}ms");
        }

        [Command("youtube")]
        [Description("Potatobot calls upon the dark void and summons a mad land where you can watch youtube together")]
        [Aliases("togethertube", "watch", "watch2gether", "yt", "yout00b")]
        [RequireRolesAttribute("unbaked one")]
        //TODO: Replace with dynamic room creation like:
        //https://github.com/Kwoth/NadekoBot/blob/f274af8ba20e1630ff663320ca6235114aa8fd46/NadekoBot.Core/Modules/Utility/Utility.cs#L46
        public async Task TogetherTube(CommandContext ctx)
        {
            var target = new Uri("https://togethertube.com/rooms/potatotheater");
            var embed = new DiscordEmbedBuilder {
                Title = $"{DiscordEmoji.FromName(ctx.Client, ":tv:")} Together Tube",
                Color = DiscordColor.IndianRed,
                Url = target.AbsoluteUri,
                ThumbnailUrl = "https://togethertube.com/assets/img/favicons/favicon-160x160.png",
                Description = $"Sire, I have summoned your personnal TogetherTube room: {target}"
            };

            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("errors")]
        [Description("Instructs Potatobot to not display any error messages")]
        [Aliases("noerrors", "noerrormsg")]
        [RequireRolesAttribute("unbaked one")]
        public async Task ToggleCommandNotFoundMsg(CommandContext ctx)
        {
            StaticEvents.ShowCommandNotFoundMsg = !StaticEvents.ShowCommandNotFoundMsg;
        }

    }
}
