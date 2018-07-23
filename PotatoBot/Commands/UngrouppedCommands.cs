using System;
using System.Threading.Tasks;
using System.Linq;
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
        [RequireRolesAttribute("unbaked one")]
        public async Task Greetings(CommandContext ctx)
        {
            string[] greetingsPhrases = {
                "Greetings master.",
                "Pra"
            };

            // Show typing symbol for PotatoBot
            await ctx.TriggerTypingAsync();

            // Send message
            var emoji = DiscordEmoji.FromName(ctx.Client, ":heart:");
            await ctx.RespondAsync($"{emoji} Greetings master.");
        }

        [Command("status")]
        [Description("Displays the current state of PotatoBot")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Status(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder {
                Title = "Status",
                ImageUrl = "https://i.ytimg.com/vi/cXzZDHa8i_g/maxresdefault.jpg",//"http://www.stickpng.com/assets/images/58582c01f034562c582205ff.png",
                ThumbnailUrl = "https://cdn.dribbble.com/users/174182/screenshots/1462892/glados_teaser.jpg"
                
            };
            embed.AddField("Version", Program.VERSION, true);
            embed.AddField("DSharp Version", ctx.Client.VersionString, true);
            embed.AddField("Ping", ctx.Client.Ping.ToString(), true);
            embed.AddField("Connected to", ctx.Guild.Name.ToString());
            embed.AddField("Server location", ctx.Guild.RegionId, true);
            embed.AddField("Started @", Program.StartTime);
            embed.WithColor(DiscordColor.Goldenrod);
            embed.WithFooter("<3 PotatoBot & Pals");
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
                Title = "We're All Fools, So Lets Dance, Baby",
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

        [Command("purge")]
        [RequireRolesAttribute("unbaked one")]
        public async Task Purge(CommandContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
