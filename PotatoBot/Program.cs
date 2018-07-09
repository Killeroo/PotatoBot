// TODO: Add events
// TODO: Add status command

// TODO: Refresh API token
// TODO: Add debug output for each part of the initial load?

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;

namespace PotatoBot
{
    class Program
    {
        public DiscordClient Client { get; set; }
        public CommandsNextModule Commands { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("PotatoBot Version 0.2");

            // Due to the nature of DSharpPlus, the bot needs to run in async
            // so we pipe out program class through an async method to run
            var program = new Program();
            program.RunBotAsync().GetAwaiter().GetResult();
        }

        // Main bot method
        public async Task RunBotAsync()
        {
            // Open our json config file
            // TODO: Add check for config
            string jsonData = "";
            using (FileStream fs = File.OpenRead("config.json"))
            using (StreamReader sr = new StreamReader(fs, new UTF8Encoding(false))) {
                jsonData = await sr.ReadToEndAsync();
            }

            // Load configuration data from it
            ConfigJson cfgjson = JsonConvert.DeserializeObject<ConfigJson>(jsonData);
            DiscordConfiguration cfg = new DiscordConfiguration {
                Token = cfgjson.Token,
                TokenType = TokenType.Bot,

                AutoReconnect = true,
                LogLevel = LogLevel.Debug, // TODO: Move to config?
                UseInternalLogHandler = true
            };

            // Instantiate our client
            this.Client = new DiscordClient(cfg);

            // Hook up some events
            // TODO: Setup moar events
            this.Client.Ready += Events.Client_Ready;
            this.Client.MessageCreated += Events.Message_Created;
            //this.Client.GuildMemberAdded += 
            //this.Client.GuildMemberUpdated +=
            this.Client.
            //this.Client.GuildAvailable += this.Client_GuildAvailable;
            //this.Client.ClientErrored += this.Client_ClientError;

            // Setup command configuration
            CommandsNextConfiguration ccfg = new CommandsNextConfiguration {
                StringPrefix = cfgjson.CommandPrefix,

                EnableDms = true,
                EnableMentionPrefix = true
            };
            this.Commands = this.Client.UseCommandsNext(ccfg);

            // Hook up some command events
            this.Commands.CommandExecuted += Events.Command_Executed;
            this.Commands.CommandErrored += Events.Command_Errored;

            // Next, load/register our commands
            // TODO: Add moar commands
            this.Commands.RegisterCommands<UngrouppedCommands>();
            //this.Commands.RegisterCommands<GroupedCommands>();
            //this.Commands.RegisterCommands<ExecutableGroupCommands>();

            // Setup our help command formatter
            this.Commands.SetHelpFormatter<CommandHelpFormatter>();

            // Finally lets connect to discord
            await this.Client.ConnectAsync();

            // This next line prevents premature quiting
            await Task.Delay(-1);
        }
    }
}
