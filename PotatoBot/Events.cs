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

        public static Task Client_Error(ClientErrorEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Error, "PotatoBot", $"Exception occured: {e.Exception.GetType()}: {e.Exception.Message}", DateTime.Now);

            return Task.CompletedTask;
        }

        #endregion

        // Replies to any mnention of name in chat
        // TODO: This event being fired fucks with the commands being executed, maybe we need a different event?
        public static Task Message_Created(MessageCreateEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", e.Message.Author.Username.ToString(), DateTime.Now); 

            if (e.Message.Content.ToString().ToLower().Contains("potatobot")) {
                e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", "Name detected: " + e.Message.ToString(), DateTime.Now);
                
                if (e.Message.Content.ToString().ToLower().Contains("fuck you")) {
                    e.Message.RespondAsync("Ey fuck you budday.");
                }
                if (e.Message.Content.ToString().ToLower().Contains("fag")) {
                    e.Message.RespondAsync("Hey you don't know that pal.");
                }
            }

            return Task.CompletedTask;
        }

        #region Guild events

        public static Task Guild_Available(GuildCreateEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Guild available: {e.Guild.Name}", DateTime.Now);

            return Task.CompletedTask;
        }

        public static Task Guild_Member_Added(GuildMemberAddEventArgs e)
        {
            e.Member.SendMessageAsync($"Welcome to {e.Guild.Name} {e.Member.Mention}. For now you are but a fledling potato, but soon you may ascend. I am PotatoBot, guardian of this land. Fear my wrath.");
            //e.Member.GrantRoleAsync(new Disco) // Potato fledgling role
            return Task.CompletedTask;
        }

        //public async Task Guild_Member_Updated(GuildMemberUpdateEventArgs e)
        //{
        //    // Check for raise or fall in rank
        //    e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Member_Updated: {e.Member.Username}: {e.RolesBefore.ToString()} -> {e.RolesAfter.ToString()}", DateTime.Now);
        //    //e.Member.Guild.Channels($"Congratulations {e.Member.Mention} on your ascention. May you travel far young potato.");
        //    foreach (var channel in e.Guild.Channels) {
        //        await channel.SendMessageAsync($"Congratulations {e.Member.Mention} on your ascention. May you travel far young potato.");
        //    }

        //    return Task.CompletedTask;
        //}

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

            if (e.Exception is ChecksFailedException) {

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
            
            if (e.Exception is CommandNotFoundException ex) {

                Random rng = new Random();
                string[] confusedLinks = {
                    "https://media.giphy.com/media/yFm0w98tu3ela/giphy.gif",
                    "https://thumbs.gfycat.com/DisastrousInsecureConch-size_restricted.gif",
                    "https://thumbs.gfycat.com/FewJointFish-size_restricted.gif",
                    "http://sailorsbeat.com/wp-content/uploads/2017/03/Dazed-Confused.gif",
                    "https://media1.tenor.com/images/2c7fa0bfa6a69bb45b1a1ad7e715a6d7/tenor.gif"
                };

                // Inform user that command isnt found
                var emoji = DiscordEmoji.FromName(e.Context.Client, ":confused:");
                var embed = new DiscordEmbedBuilder {
                    Title = $"Sire I do not know that command. {emoji}",
                    Description = "Please consult 'potatobot help'.",
                    ImageUrl = confusedLinks[rng.Next(confusedLinks.Length)],
                    Color = DiscordColor.DarkRed
                };
                await e.Context.RespondAsync("", embed: embed);
            }
        }

        #endregion
    }
}
