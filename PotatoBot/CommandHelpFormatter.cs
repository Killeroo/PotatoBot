using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;

namespace PotatoBot
{
    /// <summary>
    /// Generates a help message for a command
    /// </summary>
    public class CommandHelpFormatter : IHelpFormatter
    {
        private StringBuilder MessageBuilder { get; }

        // Constructor
        public CommandHelpFormatter()
        {
            this.MessageBuilder = new StringBuilder();
        }

        // Builds the completed help message
        public CommandHelpMessage Build()
        {
            return new CommandHelpMessage(this.MessageBuilder.ToString().Replace("\r\n", "\n"));
        }

        // Sets the name of the command 
        public IHelpFormatter WithCommandName(string name)
        {
            this.MessageBuilder.Append(Formatter.Underline("Command:"))
                .AppendLine(" " + Formatter.Bold(name))
                .AppendLine();

            return this;
        }

        // Sets the description of the command
        public IHelpFormatter WithDescription(string description)
        {
            this.MessageBuilder.Append(Formatter.Underline("Description:"))
                .AppendLine(" " + description)
                .AppendLine();

            return this;
        }

        // Sets if the command can be executed without any other arguments
        public IHelpFormatter WithGroupExecutable()
        {
            this.MessageBuilder.AppendLine(Formatter.Underline("This group is a standalone command."));

            return this;
        }

        // Sets the alias for the command
        public IHelpFormatter WithAliases(IEnumerable<string> aliases)
        {
            this.MessageBuilder.Append(Formatter.Underline("Aliases:"))
                .AppendLine(" " + Formatter.Italic(string.Join(", ", aliases)))
                .AppendLine();

            return this;
        }

        // Sets the arguments required for this class
        public IHelpFormatter WithArguments(IEnumerable<CommandArgument> arguments)
        {
            this.MessageBuilder.Append(Formatter.Underline("Arguments:"))
                .AppendLine(" " + Formatter.Bold(string.Join(", ", arguments.Select(xarg => $"{xarg.Name} ({xarg.Type.ToUserFriendlyName()})"))))
                .AppendLine();

            return this;
        }

        // Sets any subcommands used by the command
        public IHelpFormatter WithSubcommands(IEnumerable<Command> subcommands)
        {
            this.MessageBuilder.Append(Formatter.Underline("Subcommands:"))
                .AppendLine(" " + Formatter.Italic(string.Join(", ", subcommands.Select(xc => xc.Name))))
                .AppendLine();

            return this;
        }
    }
}
