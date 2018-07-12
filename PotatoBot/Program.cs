// TODO: Add events
// TODO: Add status command
// TODO: Seperate out startup

// TODO: Refresh API token
// TODO: Add debug output for each part of the initial load?
// TODO: Check permissions of user

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
            Console.WriteLine("PotatoBot Version 0.25");

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
            //string jsonData = "";
            //using (FileStream fs = File.OpenRead("config.json"))
            //using (StreamReader sr = new StreamReader(fs, new UTF8Encoding(false))) {
            //    jsonData = await sr.ReadToEndAsync();
            //}
            ConfigJson cfgjson = ReadConfigFile("config.json");

            // Load configuration data from it
            //ConfigJson cfgjson = JsonConvert.DeserializeObject<ConfigJson>(jsonData);
            //DiscordConfiguration cfg = new DiscordConfiguration {
            //    Token = cfgjson.Token,
            //    TokenType = TokenType.Bot,

            //    AutoReconnect = true,
            //    LogLevel = LogLevel.Debug, // TODO: Move to config?
            //    UseInternalLogHandler = true
            //};
            DiscordConfiguration cfg = SetupDiscordConfig(cfgjson);

            // Instantiate our client
            this.Client = new DiscordClient(cfg);
            Client.DebugLogger.LogMessage(LogLevel.Debug, "PotatoBot", "Initiating DiscordClient ...", DateTime.Now);


            //// Hook up some events
            //this.Client.Ready += Events.Client_Ready;
            //this.Client.ClientErrored += Events.Client_Error;
            ////this.Client.MessageCreated += Events.Message_Created; // Causing trip up?
            //this.Client.GuildAvailable += Events.Guild_Available;
            //this.Client.GuildMemberAdded += Events.Guild_Member_Added;
            //this.Client.GuildMemberUpdated += Events.Guild_Member_Updated;
            SetupClientEvents();

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

        public ConfigJson ReadConfigFile(string path)
        {
            Client.DebugLogger.LogMessage(LogLevel.Debug, "ReadConfigFile", $"Reading {path} ...", DateTime.Now);
            string data = "";
            try {
                using (FileStream fs = File.OpenRead("config.json"))
                using (StreamReader sr = new StreamReader(fs, new UTF8Encoding(false))) {
                    data = sr.ReadToEnd();
                }
            } catch (Exception e) {
                Client.DebugLogger.LogMessage(LogLevel.Critical, "ReadConfigFile", $"Error reading config file: {e.GetType()}: {e.Message}", DateTime.Now);
                Console.Read();
                Environment.Exit(1);
            }
            ConfigJson cfgjson = JsonConvert.DeserializeObject<ConfigJson>(data);

            return cfgjson;
        }

        public DiscordConfiguration SetupDiscordConfig(ConfigJson config)
        {
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupDiscordConfig", $"Configuring discord client ...", DateTime.Now);
            DiscordConfiguration cfg = new DiscordConfiguration {
                Token = config.Token,
                TokenType = TokenType.Bot,

                AutoReconnect = true,
                LogLevel = LogLevel.Debug, // TODO: Move to config?
                UseInternalLogHandler = true
            };

            return cfg;
        }

        public void SetupClientEvents()
        {
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupClientEvents", $"Hooking up events ...", DateTime.Now);
            this.Client.Ready += Events.Client_Ready;
            this.Client.ClientErrored += Events.Client_Error;
            //this.Client.MessageCreated += Events.Message_Created; // Causing trip up?
            this.Client.GuildAvailable += Events.Guild_Available;
            this.Client.GuildMemberAdded += Events.Guild_Member_Added;
            this.Client.GuildMemberUpdated += Events.Guild_Member_Updated;
        }

        public void SetupCommands(ConfigJson config)
        {
            // Setup command configuration
            CommandsNextConfiguration ccfg = new CommandsNextConfiguration {
                StringPrefix = config.CommandPrefix,

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
        }
    }
}
