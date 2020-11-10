using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoRandomBot.PhasmoRandom.Models
{
    public class Item
    {
        public string Label { get; private set; }
        public int Max { get; private set; }
        public int NbrUse { get; set; }

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="max"></param>
        public Item(string label, int max)
        {
            this.Label = label;
            this.Max = max;
            this.NbrUse = 0;
        }
    }
}
