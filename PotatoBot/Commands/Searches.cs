using System;
using System.Net.Http;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using Newtonsoft.Json;

namespace PotatoBot.Commands
{
    public class Searches
    {
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
