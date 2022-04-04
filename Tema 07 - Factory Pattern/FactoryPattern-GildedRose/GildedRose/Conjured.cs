using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class Conjured : Item
    {
        public Conjured(string name, int sellIn, int quality)
            : base(name, sellIn, quality)
        {
        }
        public override void updateQuality()
        {
            Quality = Quality - 4;
            base.updateQuality();
        }
    }
}
