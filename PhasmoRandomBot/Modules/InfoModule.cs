using Discord;
using Discord.Commands;
using PhasmoRandomBot.PhasmoRandom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhasmoRandomBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Répond au pig de l'utilisateur")]
        public async Task PingAsync()
        {
            await ReplyAsync("pong !");
        }

        [Command("random")]
        [Summary("Permet de tirer des objet aléatoire à un nombre de personne souhaité")]
        public async Task PhasmoRandom([Remainder] string pText)
        {
            // Parse du text 
            string[] words = pText.Split(' ');

            int nbrItem = 0;
            List<String> listNamePlayers = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                {
                    try
                    {
                        nbrItem = Int32.Parse(words[i]);
                    }
                    catch (Exception)
                    {
                        await ReplyAsync("Synthaxe incorrecte");
                    }
                }
                else
                {
                    listNamePlayers.Add(words[i]);
                }
            }

            if (nbrItem != 0)
            {
                PhasmoRandomHandler phasmoRandomHandler = new PhasmoRandomHandler(nbrItem, listNamePlayers);
                phasmoRandomHandler.StartRandomize();
                string resultMessage = phasmoRandomHandler.DisplayResult();
                await ReplyAsync(resultMessage);
            }

        }


    }
}
