using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;

namespace PotatoBot
{
    /// <summary>
    /// Contains all event code for potatobot
    /// </summary>
    public static class Events
    {
        public static bool ShowCommandNotFoundMsg { get; set; } = true;

        #region Client events

        public static Task Client_Ready(ReadyEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", "Client is ready to handle events.", DateTime.Now);

            return Task.CompletedTask;
        }

        public static Task Client_Error(ClientErrorEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", $"Exception occured: {e.Exception.GetType()}: {e.Exception.Message}", DateTime.Now);
            Stats.ClientErrors++;

            return Task.CompletedTask;
        }

        public static Task Message_Created(MessageCreateEventArgs e)
        {
            // Count potatobot mentions
            if (e.Message.Content.ToLower().Contains("potatobot")) {
                e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Mentioned: [{e.Author.Username}] \"{e.Message.Content.ToString()}\"", DateTime.Now);
                Stats.Mentions++;
            }

            // TODO: Check permissions

            // Check the first word doesnt contain potatobot 
            // So we dont trip up any of the commands stuff
            var splitWords = e.Message.Content.ToString().Split(" ");
            if (!splitWords[0].ToLower().Contains("potatobot") && e.Message.Content.ToLower().Contains("potatobot") && !e.Author.IsBot) {
                
                // Check for some arbitary questions or commands
                if (e.Message.Content.ToLower().Contains("hi") ||
                    e.Message.Content.ToLower().Contains("yo") ||
                    e.Message.Content.ToLower().Contains("hello") ||
                    e.Message.Content.ToLower().Contains("sup") ||
                    e.Message.Content.ToLower().Contains("yoo") ||
                    e.Message.Content.ToLower().Contains("howdy") ||
                    e.Message.Content.ToLower().Contains("wassap")) {

                    Random rng = new Random();
                    string[] greetingsPhrases = {
                        "Greetings master.",
                        "Praise be the potato.",
                        "I await your instructions.",
                        "I live to serve."
                    };

                    e.Channel.SendMessageAsync(greetingsPhrases[rng.Next(greetingsPhrases.Length)]);
                }
            }

            return Task.CompletedTask;
        }

        #endregion

        #region Guild events

        public static Task Guild_Available(GuildCreateEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Guild available: {e.Guild.Name}", DateTime.Now);

            return Task.CompletedTask;
        }

        public static Task Guild_Member_Added(GuildMemberAddEventArgs e)
        {
            e.Member.GrantRoleAsync(e.Guild.Roles[2]); // TEST
            e.Member.SendMessageAsync($"Welcome to {e.Guild.Name} {e.Member.Mention}. For now you are but a fledgling potato, but soon you may ascend. I am PotatoBot, guardian of this land. Fear my wrath.");

            return Task.CompletedTask;
        }

        #endregion

        #region Command events

        public static Task Command_Executed(CommandExecutionEventArgs e)
        {
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"[{e.Context.User.Username}] successfully executed '{e.Command.QualifiedName}'", DateTime.Now);
            Stats.CommandsExecuted++;

            return Task.CompletedTask;
        }


        public async static Task Command_Errored(CommandErrorEventArgs e)
        {
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", $"[{e.Context.User.Username}] tried executing '{e.Command?.QualifiedName ?? "<unknown command>"}' but it encountered an error: {e.Exception.GetType()}: {e.Exception.Message ?? "<no message>"}", DateTime.Now);
            Stats.CommandErrors++;

            if (e.Exception is ChecksFailedException) {

                e.Context.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", $"Kicking low role user [{e.Context.User.Username}] ...", DateTime.Now);

                // Kick lower user for speaking to potatobot
                var emoji = DiscordEmoji.FromName(e.Context.Client, ":skull_crossbones:");
                var embed = new DiscordEmbedBuilder {
                    Title = "SILENCE MORTAL",
                    Description = $"{emoji} Feel the wrath of PotatoBot",
                    Color = DiscordColor.Red
                };
                await e.Context.TriggerTypingAsync();
                await e.Context.RespondAsync("", embed: embed);
                await Task.Delay(3000);
                await e.Context.Member.RemoveAsync("You are not worthy of communicating with PotatoBot.");
            }
            
            if (e.Exception is CommandNotFoundException ex && ShowCommandNotFoundMsg) {

                Random rng = new Random();

                // Inform user that command isnt found
                var emoji = DiscordEmoji.FromName(e.Context.Client, ":confused:");
                var embed = new DiscordEmbedBuilder {
                    Title = $"Sire I do not know that command. {emoji}",
                    Description = "Please consult 'potatobot help'.",
                    ImageUrl = GIF.COMMANDNOTFOUND_LINKS[rng.Next(GIF.COMMANDNOTFOUND_LINKS.Length)],
                    Color = DiscordColor.DarkRed
                };
                await e.Context.RespondAsync("", embed: embed);
            }
        }

        #endregion
    }
}
