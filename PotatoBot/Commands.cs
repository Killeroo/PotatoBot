using System;
using System.Threading.Tasks;
using System.Linq;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace PotatoBot
{
    public class UngrouppedCommands
    {
        [Command("greetings")]
        [Description("Say hi to potato bot")]
        [Aliases("hi", "yo", "yoyo", "sup")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Greetings(CommandContext ctx)
        {
            Random rng = new Random();
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
                ImageUrl = "https://i.imgur.com/SFmnXiA.png", 
                ThumbnailUrl = "https://cdn.dribbble.com/users/174182/screenshots/1462892/glados_teaser.jpg"
                
            };
            embed.AddField("Version", Program.VERSION, true);
            embed.AddField("DSharp Version", ctx.Client.VersionString, true);
            embed.AddField("Ping", ctx.Client.Ping.ToString(), true);
            embed.AddField("Connected to", ctx.Guild.Name.ToString());
            embed.AddField("Server location", ctx.Guild.RegionId, true);
            embed.AddField("Started @", Stats.StartTime);
            embed.AddField("Running on", Stats.PCName);
            //embed.AddField("Commands Executed", Stats.CommandsExecuted.ToString());
            embed.AddField("Mentions", Stats.Mentions.ToString());
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
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = "Praise be the potato",
                }
            };
            embed.AddField("Version 0.5.1",
                "- Fixed some small typos");
            embed.AddField("Version 0.5",
                "- Added response to hi" +
                "- Auto role assignment on first join" +
                "- Now tracks mentions" +
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

        [Command("dance")]
        [Description("Instructs PotatoBot to initate dance routines")]
        [Aliases("kickit")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Dance(CommandContext ctx)
        {
            Random rng = new Random();
            string[] danceLinks = {
                "https://rosesturnblog.files.wordpress.com/2014/12/dandy-butt-dancing.gif",
                "https://i.pinimg.com/originals/c3/e0/c2/c3e0c2c8fe4f6358d1c2c5f716096369.gif",
                "https://i.pinimg.com/originals/c2/31/c2/c231c28caeda52c315d8993b6cb59607.gif",
                "https://i.gifer.com/CX3o.gif"
            };

            await ctx.TriggerTypingAsync();
            var embed = new DiscordEmbedBuilder {
                ImageUrl = danceLinks[rng.Next(danceLinks.Length)]
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("boobies")]
        [Description("Erm... Don't look at me, I didn't program myself...")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Boobies(CommandContext ctx)
        {
            Random rng = new Random();
            string[] boobLinks = {
                "https://media.giphy.com/media/cnQoYYnMyDMLS/giphy.gif",
                "http://gifimage.net/wp-content/uploads/2018/05/space-dandy-honey-gif-11.gif",
                "https://i1.kym-cdn.com/photos/images/newsfeed/000/673/939/a52.gif"
            };

            await ctx.TriggerTypingAsync();
            var embed = new DiscordEmbedBuilder {
                ImageUrl = boobLinks[rng.Next(boobLinks.Length)]
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("eyebleach")]
        [Description("Show a random cute gif")]
        [Aliases("cute")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Eyebleach(CommandContext ctx)
        {
            Random rng = new Random();
            string[] cuteLinks = {
                "https://i.imgur.com/dJt6R2m.gif",
                "https://i.redd.it/5mvhyjwspvb11.jpg",
                "https://i.imgur.com/oVzjfsJ.gif",
                "https://i.imgur.com/M2SipsG.gif",
                "https://i.imgur.com/uK2ibur.gif",
                "https://i.redd.it/mcb5aia2pva11.jpg",
                "https://i.redd.it/el6qj0ks6ta11.jpg",
                "https://i.imgur.com/1VwVgyi.gif",
                "https://i.imgur.com/l7zFf2u.gif",
                "https://i.redd.it/wfo733tpke711.jpg",
                "https://i.imgur.com/5GFKN0z.gif",
                "https://i.imgur.com/23cSCsr.gif",
                "https://i.imgur.com/rubjA1m.gif",
                "https://i.imgur.com/4cgSS0U.gif"
            };

            await ctx.TriggerTypingAsync();
            var embed = new DiscordEmbedBuilder {
                ImageUrl = cuteLinks[rng.Next(cuteLinks.Length)]
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("purge")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Purge(CommandContext ctx)
        {
            //TODO: Fix permissions
            throw new NotImplementedException();
        }

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
            Random rng = new Random();
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":game_die:");

            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{emoji} {ctx.Member.Mention} rolls {rng.Next(0, 101)} (0-100)");
        }

        [Command("announce")]
        [Description("Announces a message to the server")]
        [Aliases("say", "tell", "yell")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Announce(CommandContext ctx, [Description("What should be announced")] params string[] message)
        {
            string annoucement = string.Join(" ", message);
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":trumpet:");
            ctx.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"{ctx.Member.Username} announces \"{annoucement}\" to the server", DateTime.Now);

            var embed = new DiscordEmbedBuilder {
                Title = $"{emoji} Announcement",
                Color = DiscordColor.Orange,
                Description = Formatter.Bold(annoucement) + " - " + Formatter.Italic(ctx.Member.Username),
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = "Praise be the potato",
                }
            };

            foreach (var channel in ctx.Guild.Channels) {
                if (channel.Type == ChannelType.Text) { 
                    await channel.TriggerTypingAsync();
                    await channel.SendMessageAsync(embed: embed);
                }
            }
        }
    }
}
