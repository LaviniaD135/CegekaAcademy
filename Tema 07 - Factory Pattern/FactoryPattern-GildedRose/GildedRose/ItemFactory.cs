using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured Mana Cake";
        public static Item CreateItem(string name, int sellIn, int quality)
        {
            
                switch (name)
                {
                    case AgedBrie:
                        return new AgedBrie(name, sellIn, quality);
                    case Backstage:
                        return new BackstagePasses(name, sellIn, quality);
                    case Sulfuras:
                        return new Sulfuras(name, sellIn, quality);
                    case Conjured:
                        return new Conjured(name, sellIn, quality);
                    default:
                        return new BasicItem(name, sellIn, quality);
                }
            }
        }
    }
