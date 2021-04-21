using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{
    public class Shield
    {
        #region Instance
        private Random _random = new Random();
        private QualityFactoryRandomized randomized = new QualityFactoryRandomized();
        #endregion
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="T:Mandatory_Assignment.Shield" /> class.
        /// Power gets its value from the ShieldPower().
        /// Quality gets its value from the randomized.GetQuality().
        /// </summary>
        public Shield()
        {
            _random = new Random();
            Power = ShieldPower();
            Quality = randomized.GetQuality();
        }
        #endregion
        #region Properties
        /// <summary>Gets or sets the quality and Power.</summary>
        public Quality Quality { get; set; }
        public int Power { get; set; }
        #endregion

        #region Method


        /// <summary>Shield power for Hero's shield</summary>
        /// <returns>
        ///  It returns the power of the shield
        /// </returns>
        public int ShieldPower()
        {
            int power = 0;
            switch (Quality)
            {
                case Quality.common:
                    power = _random.Next(0, 2);
                    break;
                case Quality.rare:
                    power = _random.Next(0, 3);
                    break;
                case Quality.epic:
                    power = _random.Next(0, 5);
                    break;
                case Quality.legendary:
                    power = _random.Next(1, 8);
                    break;


            }
            return power;
        }
        #endregion
    }
}
