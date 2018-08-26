using System;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;

namespace PotatoBot
{
    public class UngrouppedCommands
    {
        private Random rng = new Random();

        [Command("greetings")]
        [Description("Say hi to potato bot")]
        [Aliases("hi", "yo", "yoyo", "sup")]
        [RequireRolesAttribute("unbaked one")]
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

        [Command("dance")]
        [Description("Instructs PotatoBot to initate dance routines")]
        [Aliases("kickit")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Dance(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.Gray,
                ImageUrl = GIF.DANCE_LINKS[rng.Next(GIF.DANCE_LINKS.Length)]
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("lol")]
        [Description("hehehehehehehhe")]
        [Aliases("lel", "lul", "lil", "lewl")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Lol(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.Gray,
                ImageUrl = "https://i.imgur.com/ULasYGL.png",
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("ooo")]
        [Description("er... ?")]
        [Aliases("urgh", "mmm", "orgasm", "o", "oo")]
        [RequireRolesAttribute("unbaked one")]
        public async Task ooo(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.Gray,
                ImageUrl = GIF.OOO_LINKS[rng.Next(GIF.OOO_LINKS.Length)],
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = $"{DiscordEmoji.FromName(ctx.Client, ":thermometer:")} {DiscordEmoji.FromName(ctx.Client, ":prayer_beads:")} {DiscordEmoji.FromName(ctx.Client, ":ok_hand:")}",
                }
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("boobies")]
        [Description("Erm... Don't look at me, I didn't program myself...")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Boobies(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                ImageUrl = GIF.BOOB_LINKS[rng.Next(GIF.BOOB_LINKS.Length)],
                Color = DiscordColor.Gray
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("cute")]
        [Description("Show a random cute gif")]
        [Aliases("eyebleech")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Cute(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.Gray,
                ImageUrl = GIF.CUTE_LINKS[rng.Next(GIF.CUTE_LINKS.Length)]
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
                Color = DiscordColor.Gray,
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
            string[] responses = new string[] {"Signs point to yes.", "Yes.", "Without a doubt.", "As I see it, yes.", "You may rely on it.", "It is decidedly so.", "Yes - definitely.", "It is certain.", "Most likely.", "Outlook good.",
                                               "Reply hazy, try again.", "Concentrate and ask again.", "Better not tell you now.", "Cannot predict now.", "Ask again later.",
                                               "My sources say no.", "Outlook not so good.", "Very doubtful.", "My reply is no.", "Don't count on it."};
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{emoji} My magic 8ball says... '{responses[rng.Next(responses.Length)]}'");
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

        [Command("tb")]
        [Description("Summon our lord and savior, TotalBiscuit")]
        [Aliases("totalbiscuit", "totalhalibut", "cynicalbrit", "johnbain")]
        [RequireRolesAttribute("unbaked one")]
        public async Task TotalBiscuit(CommandContext ctx)
        {
            DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, ":heart:");
            
            var embed = new DiscordEmbedBuilder {
                ImageUrl = GIF.TOTALBISCUIT_LINKS[rng.Next(GIF.TOTALBISCUIT_LINKS.Length)],
                Color = DiscordColor.Gray,
                Footer = new DiscordEmbedBuilder.EmbedFooter {
                    Text = $"RIP John Bain, 8th July 1984 - 23th May 2018 {emoji} ",
                }
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
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

        [Command("bullshit")]
        [Description("Potatobot calls it how it is")]
        [Aliases("bs", "horseshiet", "horseshit")]
        [RequireRolesAttribute("unbaked one")]
        public async Task BullShit(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                ImageUrl = GIF.BULLSHIT_LINKS[rng.Next(GIF.BULLSHIT_LINKS.Length)],
                Color = DiscordColor.Gray
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("karlpilkington")]
        [Description("Potatobot calls it how it is")]
        [Aliases("kp", "twat", "pilkington")]
        [RequireRolesAttribute("unbaked one")]
        public async Task KarlPilkington(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                ImageUrl = "https://media1.tenor.com/images/17df42b7caee166ab307e180a3b4b7cc/tenor.gif",
                Color = DiscordColor.Gray
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
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
            Events.ShowCommandNotFoundMsg = !Events.ShowCommandNotFoundMsg;
        }

        [Command("urbandictionary")]
        [Description("Instructs Potatobot to search for a term on UrbanDictionary.com")]
        [Aliases("ud", "urbandict", "lookup", "define")]
        [RequireRolesAttribute("unbaked one")]
        // Source: https://github.com/Kwoth/NadekoBot/blob/f274af8ba20e1630ff663320ca6235114aa8fd46/NadekoBot.Core/Modules/Searches/Searches.cs#L529
        public async Task UrbanDictionary(CommandContext ctx, [RemainingText] string query = null)
        {
            // Sanity check
            if (string.IsNullOrWhiteSpace(query)) {
                return;
            }

            ctx.Client.DebugLogger.LogMessage(LogLevel.Debug, "PotatoBot", $"Searching for term '{query}' on UrbanDictionary . . . ", DateTime.Now);
            using (var http = new HttpClient()) {

                // Send request to urban dictionary with query
                var response = await http.GetStringAsync($"http://api.urbandictionary.com/v0/define?term={Uri.EscapeUriString(query)}");

                try {
                    // Convert JSON result
                    var results = JsonConvert.DeserializeObject<UrbanDictionaryResponse>(response).List;

                    // Check if there is anything there
                    if (results.Any()) {

                        // Build embed (not only use the first result)
                        var embed = new DiscordEmbedBuilder {
                            Color = DiscordColor.Gold,
                            ThumbnailUrl = "http://i.imgur.com/nwERwQE.jpg",
                            Author = new DiscordEmbedBuilder.EmbedAuthor {
                                //IconUrl = "http://i.imgur.com/nwERwQE.jpg",
                                Name = DiscordEmoji.FromName(ctx.Client, ":books:") + " " + results[0].Word
                            },
                            Description = results[0].Definition.Replace("[", "").Replace("]", ""),
                            Url = results[0].PermaLink,
                            Footer = new DiscordEmbedBuilder.EmbedFooter {
                                Text = $"Sire, here is what I found when I interogated UrbanDictionary. {DiscordEmoji.FromName(ctx.Client, ":gun:")}",
                            }
                        };
                        embed.AddField("example", Formatter.Italic(results[0].Example.Replace("[", "").Replace("]", "")));

                        await ctx.TriggerTypingAsync();
                        await ctx.RespondAsync(embed: embed);
                    }
                } catch (Exception e) {
                    ctx.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", $"Exception [{e.GetType().ToString()}] occured: {e.Message}", DateTime.Now);
                }
                
            }
        }
    }
}
