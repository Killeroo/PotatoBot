using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace PotatoBot
{
    class Program
    {
        static DiscordClient discord;

        static void Main(string[] args)
        {
            Console.WriteLine("PotatoBot Online.");
            MainAysnc(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAysnc(string[] args)
        {
            // Declare bot
            discord = new DiscordClient(new DiscordConfiguration {
                Token = "NDY0MTQwOTM4NzAxMzA3OTE0.Dh6ozw.AWfkjOujiAlF6SbjuRTlliyEwz0",
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e => {
                if (e.Message.Content.ToLower().StartsWith("potatobot")) {
                    await e.Message.RespondAsync("I await your instructions.");
                }
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
