﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class Card
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public string ConvertedManaCost { get; set; }
        public string Type { get; set; }
        public string RarityCode { get; set; }
        public string SetCode { get; set; }
        public string Text { get; set; }
        public string Flavor { get; set; }
        public long? ArtistId { get; set; }
        public string Number { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Layout { get; set; }
        public int? MultiverseId { get; set; }
        public string OriginalImageUrl { get; set; }
        public string Image { get; set; }
        public string OriginalText { get; set; }
        public string OriginalType { get; set; }
        public string MtgId { get; set; }
        public string Variations { get; set; }

        public virtual ICollection<CardColor> Colors { get; set; } = new List<CardColor>();
        public virtual ICollection<CardType> Types { get; set; } = new List<CardType>();
    }
}
