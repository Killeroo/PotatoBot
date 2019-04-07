using System;
using System.Diagnostics;
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
        [RequireRolesAttribute("Unbaked One")]
        public async Task Status(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            // Construct embed
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":tools:");
            var embed = new DiscordEmbedBuilder {
                Title = $"{emoji} Status",
                ImageUrl = Links.PREACH_OK,
                ThumbnailUrl = Links.POTATOBOT_ICON

            };
            embed.AddField("Version", Program.VERSION, true);
            embed.AddField("DSharp Version", ctx.Client.VersionString, true);
            embed.AddField("Spudule", Process.GetProcessesByName("Spudule").Length != 0 ? "Running" : "Not Running");
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
        [RequireRolesAttribute("Coverted Solanum", "Unbaked One")]
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
            embed.AddField("0.9.0",
                "- Added Salt and Salute command" +
                "- Changed embed colour to be more subtle" +
                "- Fixed permission" +
                "- Misc cleanup and refactors to potatobot's core");
            embed.AddField("0.8.5",
                "- Added spam command" +
                "- Added ok command" +
                "- Announce command only posts to #announcements");
            embed.AddField("Version 0.8", 
                "- Added facts command\n" +
                "- Added delete command\n" +
                "- Improved help command\n");
            embed.AddField("Version 0.7",
                "- Refactored commands\n" +
                "- Converted help command to use embeds\n" +
                "- Added spudule to status");
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
        [RequireRolesAttribute("Unbaked One")]
        public async Task Announce(CommandContext ctx, [Description("What should be announced")] params string[] message)
        {
            string annoucement = string.Join(" ", message);
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":trumpet:");
            ctx.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"{ctx.Member.Username} announces \"{annoucement}\" to the server", DateTime.Now);

            // Construct embed
            var embed = new DiscordEmbedBuilder {
                Title = $"{emoji} Announcement",
                Color = DiscordColor.Orange,
                Description = Formatter.Bold(annoucement) + " \n" + Formatter.Italic(ctx.Member.Username),
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = "Praise be the potato",
                }
            };

            // Delete command message
            await ctx.Message.DeleteAsync();

            // Send embed to all channels in guild
            foreach (var channel in ctx.Guild.Channels) {
                if (channel.Type == ChannelType.Text && channel.Name == "announcements") {
                    await channel.TriggerTypingAsync();
                    await channel.SendMessageAsync(embed: embed);
                }
            }
        }

        [Command("ping")]
        [Description("Displays potatobot's current ping")]
        [Aliases("pong")]
        [RequireRolesAttribute("Coverted Solanum", "Unbaked One")]
        public async Task Ping(CommandContext ctx)
        {
            // respond with current ping
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{DiscordEmoji.FromName(ctx.Client, ":ping_pong:")} Pong! Ping: {ctx.Client.Ping}ms");
        }

        [Command("youtube")]
        [Description("Potatobot calls upon the dark void and summons a mad land where you can watch youtube together")]
        [Aliases("togethertube", "watch", "watch2gether", "yt", "yout00b")]
        [RequireRolesAttribute("Coverted Solanum", "Unbaked One")]
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
        [RequireRolesAttribute("Unbaked One")]
        public async Task ToggleCommandNotFoundMsg(CommandContext ctx)
        {
            StaticEvents.ShowCommandNotFoundMsg = !StaticEvents.ShowCommandNotFoundMsg;
        }

        [Command("delete")]
        [Description("Deletes X number of messages from the current channel")]
        [Aliases("dm", "del", "deletemessages")]
        [RequireRolesAttribute("Taytus Administratus")]
        public async Task DeleteMessages(CommandContext ctx, [Description("How many messages to delete")] params string[] messageCount)
        {
            int count = 1;
            
            // Read number of messages to delete from arguments
            if (messageCount.Length != 0) {
                // Convert argument to int
                try {
                    count = Convert.ToInt32(messageCount[0]);
                } catch (Exception) {
                    // Silently continue on exception
                    ctx.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", "Problem converting arguments for delete command.", DateTime.Now);
                } 
            }

            // Delete command message
            await ctx.Message.DeleteAsync();

            // Bounds check
            if (count > 1000) {
                count = 1000;
            } else if (count <= 1) {
                count = 1;
            }

            // Retrieve and delete messages
            var messages = await ctx.Channel.GetMessagesAsync(count);
            await ctx.Channel.DeleteMessagesAsync(messages);

            ctx.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Deleted {count} messages from #{ctx.Channel.Name}.", DateTime.Now);
        }

        [Command("spam")]
        [Description("Spams a message to every channel in the server")]
        [Aliases("fuckyou")]
        [RequireRolesAttribute("Unbaked One")]
        public async Task SpamMessage(CommandContext ctx, [Description("What should be spammed")] params string[] message)
        {
            string annoucement = string.Join(" ", message);
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":bangbang:");
            ctx.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Spamming \"{annoucement}\" to the server", DateTime.Now);

            // Delete command message
            await ctx.Message.DeleteAsync();

            // Send embed to all channels in guild
            foreach (var channel in ctx.Guild.Channels)
            {
                if (channel.Type == ChannelType.Text)
                {
                    await channel.TriggerTypingAsync();
                    await channel.SendMessageAsync($"{emoji} {Formatter.Bold(annoucement)} {emoji}");
                }
            }
        }
    }
}
