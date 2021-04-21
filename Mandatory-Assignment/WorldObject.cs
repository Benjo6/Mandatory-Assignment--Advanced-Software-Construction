using Mandatory_Assignment.Randomizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{
    public class WorldObject
    {
        private ItemFactoryRandomized randomized = new ItemFactoryRandomized();
        private World world;

        public Sword _sword = new Sword();
        public Shield _shield = new Shield();
        public int Health = 5;
        public WorldObject(Position position, Pixel pixel)
        {
            Loot = randomized.GetQuality();
            Name = "Chest";
            Position = position;
            Pixel = pixel;
        }
        public WorldObject()
        {
        }

        public bool Horse { get; set; }
        public object Loot { get; set; }
        public bool Lootable { get; set; }
        public string Name { get; set; }
        public bool Removable { get; set; }
        public Position Position { get; set; }
        public Pixel Pixel { get; set; }


        
    }
}
