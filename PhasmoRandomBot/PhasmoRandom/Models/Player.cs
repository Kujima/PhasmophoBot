using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoRandomBot.PhasmoRandom.Models
{
    public class Player
    {
        public string Name { get; private set; }        
        public List<Item> ListItems { get; private set; }

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name; 
        }

        /// <summary>
        /// Méthode permettant d'insérer un item dans la liste 
        /// </summary>
        /// <param name="item"></param>
        public void InsertItem(Item item)
        {
            if (ListItems == null)
            {
                this.ListItems = new List<Item>();
            }

            this.ListItems.Add(item);
        }
    }
}
