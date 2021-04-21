using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{
    public class Sword
    {
        private Random _random = new Random();
        private QualityFactoryRandomized randomized = new QualityFactoryRandomized();
        public Quality Quality { get; set; }
        
        public Sword()
        {
            Quality = randomized.GetQuality();
            Power = SwordPower();

        }

        public int Power { get; set; }


        public int SwordPower()
        {
            int damage = 0;
            switch (Quality)
            {
                case Quality.common:
                    damage = _random.Next(2, 4);
                    break;
                case Quality.rare:
                    damage = _random.Next(4, 6);
                    break;
                case Quality.epic:
                    damage = _random.Next(6, 8);
                    break;
                case Quality.legendary:
                    damage = _random.Next(8, 10);
                    break;


            }
            return damage;


        }
    }
}
