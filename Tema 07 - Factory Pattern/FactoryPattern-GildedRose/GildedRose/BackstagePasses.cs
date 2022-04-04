using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class BackstagePasses : Item
    {
        public BackstagePasses(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (SellIn < 11 && SellIn>5)
            {
                if (Quality < 50)
                {
                    Quality=Quality+2;
                }
            }
            if (SellIn < 6)
            {
                if (Quality < 50)
                {
                    Quality =Quality+3;
                }
            }
            if (SellIn < 0)
            {
                Quality = 0;
            }

            base.updateQuality();

        }
    }
}
