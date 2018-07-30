// Fix permissions

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using DSharpPlus.Interactivity;

namespace PotatoBot
{
    class Program
    {
        // Move to other class
        public const string VERSION = "0.4";

        public DiscordClient Client { get; set; }
        public CommandsNextModule Commands { get; set; }

        // Contains all async events
        private AsyncEvents asyncEvents = new AsyncEvents();

        static void Main(string[] args)
        {
            Stats.StartTime = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} - {DateTime.Now.Hour}:{DateTime.Now.Minute}";
            Stats.PCName = Environment.MachineName;

            // Due to the nature of DSharpPlus, the bot needs to run in async
            // so we pipe out program class through an async method to run
            var program = new Program();
            program.RunBotAsync().GetAwaiter().GetResult();
        }

        // Main bot method
        public async Task RunBotAsync()
        {
            Console.WriteLine($"PotatoBot Version {VERSION}");

            // Load config file & configure client
            ConfigJson cfgjson = ReadConfigFile("config.json");
            DiscordConfiguration cfg = SetupDiscordConfig(cfgjson);
            Console.WriteLine("Initiating discord client . . . ");
            this.Client = new DiscordClient(cfg);

            // Setup client events and commands
            SetupInteractivity();
            SetupClientEvents();
            SetupCommands(cfgjson);

            // Finally lets connect to discord
            Client.DebugLogger.LogMessage(LogLevel.Debug, "PotatoBot", "Connecting to discord server", DateTime.Now);
            await this.Client.ConnectAsync();

            //  Prevent immature async quiting
            await Task.Delay(-1);
        }

        #region Setup code

        private ConfigJson ReadConfigFile(string path)
        {
            Console.WriteLine($"Reading {path}");
            string data = "";
            try {
                using (FileStream fs = File.OpenRead("config.json"))
                using (StreamReader sr = new StreamReader(fs, new UTF8Encoding(false))) {
                    data = sr.ReadToEnd();
                }
            } catch (Exception e) {
                Console.WriteLine($"Error reading config file: {e.GetType()}: {e.Message}");
                Console.Read();
                Environment.Exit(1);
            }
            ConfigJson cfgjson = JsonConvert.DeserializeObject<ConfigJson>(data);

            return cfgjson;
        }

        private DiscordConfiguration SetupDiscordConfig(ConfigJson config)
        {
            Console.WriteLine("Configuring client");

            // Setup loglevel based on config file string
            LogLevel ll = new LogLevel();
            switch (config.LogLevel) {
                case "debug": ll = LogLevel.Debug; break;
                case "info": ll = LogLevel.Info; break;
                case "critical": ll = LogLevel.Critical; break;
                case "error": ll = LogLevel.Error; break;
                case "warning": ll = LogLevel.Warning; break;
                default: ll = LogLevel.Info; break;
            }

            // Setup discord config object
            DiscordConfiguration cfg = new DiscordConfiguration {
                Token = config.Token,
                TokenType = TokenType.Bot,

                AutoReconnect = true,
                LogLevel = ll,
                UseInternalLogHandler = true
            };

            return cfg;
        }

        private void SetupClientEvents()
        {
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupClientEvents", $"Hooking up events", DateTime.Now);
            this.Client.Ready += Events.Client_Ready;
            this.Client.ClientErrored += Events.Client_Error;
            //Timer ti = new Timer(TimerCallback);
            //this.Client.MessageCreated += Events.Message_Created; // Causing trip up?
            this.Client.GuildAvailable += Events.Guild_Available;
            this.Client.GuildMemberAdded += Events.Guild_Member_Added;
            this.Client.GuildMemberUpdated += asyncEvents.Guild_Member_Updated;
        }

        private void SetupCommands(ConfigJson config)
        {
            // Setup command configuration
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupCommands", $"Configuring commands", DateTime.Now);
            CommandsNextConfiguration ccfg = new CommandsNextConfiguration {
                StringPrefix = config.CommandPrefix,

                CaseSensitive = false,
                EnableDms = true,
                EnableMentionPrefix = true
            };
            this.Commands = this.Client.UseCommandsNext(ccfg);

            // Hook up some command events
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupCommands", $"Hooking up events", DateTime.Now);
            this.Commands.CommandExecuted += Events.Command_Executed;
            this.Commands.CommandErrored += Events.Command_Errored;

            // Next, load/register our commands
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupCommands", $"Registering commands", DateTime.Now);
            this.Commands.RegisterCommands<UngrouppedCommands>();
            //this.Commands.RegisterCommands<GroupedCommands>();
            //this.Commands.RegisterCommands<ExecutableGroupCommands>();

            // Setup our help command formatter
            Client.DebugLogger.LogMessage(LogLevel.Debug, "SetupCommands", $"Setting up HelpFormatter", DateTime.Now);
            this.Commands.SetHelpFormatter<CommandHelpFormatter>();
        }

        private void SetupInteractivity()
        {
            // Setup interactivity with some default options
            this.Client.UseInteractivity(new InteractivityConfiguration {
                PaginationBehaviour = TimeoutBehaviour.Ignore,
                PaginationTimeout = TimeSpan.FromMinutes(5),
                Timeout = TimeSpan.FromMinutes(2)
            });
        }

        #endregion

    }
}
