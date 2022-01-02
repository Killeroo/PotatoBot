using System;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using PotatoBot.Data;

namespace PotatoBot.Commands
{
    public class Emotes
    {
        [Command("ok")]
        [Description("Chill the fuck out bro, its cool.")]
        [Aliases("k", "oke", "kk", "affirmative", "ye", "yes", "yas")]
        public async Task Ok(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.PREACH_OK,
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("lol")]
        [Description("hehehehehehehhe")]
        [Aliases("lel", "lul", "lil", "lewl")]
        public async Task Lol(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.LUL_IMAGE,
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("salt")]
        [Description("Dead sea levels mayte")]
        [Aliases("saltyboy", "salty")]
        public async Task Salt(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.SALT_IMAGE,
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }

        [Command("salute")]
        [Description("Dead sea levels mayte")]
        [Aliases("sir", "yessir")]
        public async Task Salute(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder {
                Color = DiscordColor.DarkButNotBlack,
                ImageUrl = Links.SALUTE_IMAGE,
            };
            await ctx.Channel.SendMessageAsync(embed: embed);
        }
    }
}
