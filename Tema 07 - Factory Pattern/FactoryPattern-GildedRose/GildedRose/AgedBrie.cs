
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class AgedBrie : Item
    {
        public AgedBrie(string name, int sellIn, int quality)
        : base(name, sellIn, quality)
        {
        }
        public override void updateQuality()
        {
            base.updateQuality();
            Quality++;
        }
    }
}
