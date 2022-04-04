using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class BasicItem : Item
    {
        public BasicItem(string name, int sellIn, int quality)
            : base(name, sellIn, quality) 
        { 
        }
        public override void updateQuality()
        {
            if (SellIn < 0)
            {
                Quality = Quality - 2;
            }
            else
                Quality--;
            
            base.updateQuality();
        }
    }
}
