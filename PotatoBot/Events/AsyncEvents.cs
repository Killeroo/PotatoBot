using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.EventArgs;

namespace PotatoBot.Events
{
    /// <summary>
    /// Contains all async event code for potatobot
    /// </summary>
    public class AsyncEvents
    {
        public async Task<Task> Guild_Member_Updated(GuildMemberUpdateEventArgs e)
        {
            // Quickly work out the sum of all role positions the user has
            int totalPosBefore = 0, totalPosAfter = 0;
            foreach (var role in e.RolesBefore) { totalPosBefore += role.Position; }
            foreach (var role in e.RolesAfter) { totalPosAfter += role.Position; }

            // Announce to all text channels in the server
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "PotatoBot", $"Member_Updated: {e.Member.Username}: Role position total {totalPosBefore} -> {totalPosAfter}", DateTime.Now);
            foreach (var channel in e.Guild.Channels) {
                if (channel.Type == ChannelType.Text) {
                    if (totalPosBefore < totalPosAfter) {
                        // Promoted 
                        await channel.TriggerTypingAsync();
                        await channel.SendMessageAsync($"Congratulations {e.Member.Mention} on your ascention. May you travel far young potato.");
                    } else if (totalPosBefore > totalPosAfter) {
                        // Demoted
                        await channel.TriggerTypingAsync();
                        await channel.SendMessageAsync($"Shame on you {e.Member.Mention}. You have fallen from grace. May the potato Gods have mercy on you...");
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
