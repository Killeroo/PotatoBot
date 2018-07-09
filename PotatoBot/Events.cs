using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;

namespace PotatoBot
{
    /// <summary>
    /// Contains all event code for potatobot
    /// </summary>
    public static class Events
    {
        #region Client events

        public static Task Client_Ready(ReadyEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", "Client is ready to handle events.", DateTime.Now);

            return Task.CompletedTask;
        }

        #endregion

        #region Command events

        public static Task Command_Executed(CommandExecutionEventArgs e)
        {
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"{e.Context.User.Username} successfully executed '{e.Command.QualifiedName}'", DateTime.Now);

            return Task.CompletedTask;
        }

        public async static Task Command_Errored(CommandErrorEventArgs e)
        {
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", $"{e.Context.User.Username} tried executing '{e.Command?.QualifiedName ?? "<unknown command>"}' but it encountered an error: {e.Exception.GetType()}: {e.Exception.Message ?? "<no message>"}", DateTime.Now);

            // Check what type of error it was
            if (e.Exception is CommandNotFoundException ex) {

                // Inform user that command isnt found
                var emoji = DiscordEmoji.FromName(e.Context.Client, ":question:");

                // Use embed for our response
                var embed = new DiscordEmbedBuilder {
                    Title = "Command not found",
                    Description = $"{emoji} Sire I do not know that command. Please consult 'potatobot help'. {emoji}",
                    Color = new DiscordColor(0xFF0000)
                };
                await e.Context.RespondAsync("", embed: embed);
            }
        }

        #endregion
    }
}
