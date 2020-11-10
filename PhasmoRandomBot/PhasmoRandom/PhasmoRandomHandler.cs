using PhasmoRandomBot.PhasmoRandom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoRandomBot.PhasmoRandom
{
    public class PhasmoRandomHandler
    {
        private List<Player> _listPlayers;
        private List<Item> _listItems;
        private List<Item> _listItemDeleteTmp;
        private int _nbrItem;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ptext"></param>
        public PhasmoRandomHandler(int nbrItem, List<string> listNamePlayers)
        {
            // récupération du nombre d'item par joueur 
            _nbrItem = nbrItem;

            // récupération des joueurs 
            _listPlayers = new List<Player>();

            foreach (string namePlayer in listNamePlayers)
                _listPlayers.Add(new Player(namePlayer));

            // Initialisation de la liste des Items 
            SetListItems();
        }

        /// <summary>
        /// Permet d'effectuer le tirage aléatoirement 
        /// </summary>
        public void StartRandomize()
        {
            this._listItemDeleteTmp = new List<Item>();

            foreach (Player player in this._listPlayers)
            {
                for (int i = 0; i < _nbrItem; i++)
                {
                    int nbrAlea = GetAleaNbr();
                    Item itemSelect = this._listItems[nbrAlea];

                    player.InsertItem(itemSelect);

                    // On vérifie que l'objet peut etre encore tiré par un autre joueur 
                    itemSelect.NbrUse++;

                    if (itemSelect.NbrUse < itemSelect.Max)
                    {
                        // On supprime temporairement l'item de la liste pour ne pas qu'il le repioche
                        this._listItemDeleteTmp.Add(itemSelect);
                    }

                    this._listItems.RemoveAll(i => i.Label == itemSelect.Label);
                }

                // On change de joueur à remet les items temporairement supprimer 
                this._listItems.AddRange(_listItemDeleteTmp);
                this._listItemDeleteTmp.Clear();
            }
        }

        public string DisplayResult()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Player player in _listPlayers)
            {
                sb.AppendFormat("{0} : ", player.Name);

                for (int i = 0; i < player.ListItems.Count; i++)
                {
                    if (i == player.ListItems.Count -1 )
                    {
                        sb.Append(player.ListItems[i].Label);
                    }
                    else
                    {
                        sb.AppendFormat("{0}, ", player.ListItems[i].Label);
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Méthode permettant de récupérer la liste des Items
        /// </summary>
        private void SetListItems()
        {
            _listItems = new List<Item>();
            _listItems.Add(new Item("Lecteur EMF", 2));
            _listItems.Add(new Item("Lampe de poche", 4));
            _listItems.Add(new Item("Appareil photo", 3));
            _listItems.Add(new Item("Briquet", 2));
            _listItems.Add(new Item("Bougie", 4));
            _listItems.Add(new Item("Lampe UV", 2));
            _listItems.Add(new Item("Crucifix", 2));
            _listItems.Add(new Item("Caméra Vidéo", 6));
            _listItems.Add(new Item("Spirit Box", 2));
            _listItems.Add(new Item("Sel", 2));
            _listItems.Add(new Item("Bâton d'encens", 4));
            _listItems.Add(new Item("Trepied", 5));
            _listItems.Add(new Item("Lampe de poche puissante", 4));
            _listItems.Add(new Item("Détecteur de mouvement", 4));
            _listItems.Add(new Item("Capteur sonore", 4));
            _listItems.Add(new Item("Thermomètre", 3));
            _listItems.Add(new Item("Pilules calmantes", 4));
            _listItems.Add(new Item("Livre d'écriture fantomatique", 2));
            _listItems.Add(new Item("Capteur à lumière infrarouge", 4));
            _listItems.Add(new Item("Microphone parabolique", 2));
            _listItems.Add(new Item("Bâton lumineux", 2));
        }

        /// <summary>
        /// Méthode permettant de retourner un nombre random entre 0 et le nbr d'items présent dans la liste _listItems
        /// </summary>
        /// <returns></returns>
        private int GetAleaNbr()
        {
            Random random = new Random();
            return random.Next(_listItems.Count);
        }
    }
}
