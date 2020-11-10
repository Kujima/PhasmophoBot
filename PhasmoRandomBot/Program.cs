using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace PhasmoRandomBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Function permettant de démarrer le Bot 
        /// </summary>
        /// <returns></returns>
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            _commands = new CommandService();

            // Création du CommandHandler 
            CommandHandler commandHandler = new CommandHandler(_client, _commands);
            await commandHandler.InstallCommandsAsync();

            _client.Log += Log;

            // On log le client 
            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("TokenPhasmoRandomBot", EnvironmentVariableTarget.User));

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        /// <summary>
        /// function permettant d'écrire les log dans la console 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}
