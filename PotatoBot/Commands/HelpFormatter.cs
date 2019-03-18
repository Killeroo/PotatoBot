using System.Collections.Generic;
using System.Text;
using System.Linq;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;

namespace PotatoBot
{
    /// <summary>
    /// Generates a help message for a command
    /// </summary>
    public class HelpFormatter : IHelpFormatter
    {
        private DiscordEmbedBuilder EmbedBuilder { get; }

        // Constructor
        public HelpFormatter()
        {
            this.EmbedBuilder = new DiscordEmbedBuilder();
            EmbedBuilder.Color = DiscordColor.Goldenrod;
            EmbedBuilder.Footer = new DiscordEmbedBuilder.EmbedFooter {
                Text = "<3 PotatoBot & Pals"
            };
        }

        // Builds the completed help message
        public CommandHelpMessage Build()
        {
            return new CommandHelpMessage(embed: EmbedBuilder);
        }

        // Sets the name of the command 
        public IHelpFormatter WithCommandName(string name)
        {
            this.EmbedBuilder.AddField("Command Name", Formatter.Underline(name), true);

            return this;
        }

        // Sets the description of the command
        public IHelpFormatter WithDescription(string description)
        {
            this.EmbedBuilder.AddField("Description", Formatter.InlineCode(description));

            return this;
        }

        // Sets if the command can be executed without any other arguments
        public IHelpFormatter WithGroupExecutable()
        {
            this.EmbedBuilder.AddField("This group is a standalone command", "");

            return this;
        }

        // Sets the alias for the command
        public IHelpFormatter WithAliases(IEnumerable<string> aliases)
        {
            this.EmbedBuilder.AddField("Other names",
                string.Join(", ", aliases), true);

            return this;
        }

        // Sets the arguments required for this class
        public IHelpFormatter WithArguments(IEnumerable<CommandArgument> arguments)
        {
            this.EmbedBuilder.AddField("Arguments",
                string.Join(", ", arguments.Select(xarg => $"{Formatter.Italic(xarg.Name)} ({xarg.Type.ToUserFriendlyName()})")));

            return this;
        }

        // Sets any subcommands used by the command
        public IHelpFormatter WithSubcommands(IEnumerable<Command> subcommands)
        {
            EmbedBuilder.AddField("Commands", " -> " + string.Join("\n -> ", subcommands.Select(xc => Formatter.Bold(xc.Name))));
            EmbedBuilder.Footer = null;
            EmbedBuilder.Footer = new DiscordEmbedBuilder.EmbedFooter {
                Text = "Type '/help *command*' for more info"
            };
            return this;
        }
    }
}
