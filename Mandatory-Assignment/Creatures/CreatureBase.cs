using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{
    public abstract class CreatureBase
    {
        #region Instance Fields
        private string _name;
        private int _health;
        private int _maxHealth;

        protected Random _random;
        private Pixel _pixel;
        private Position _position;
        #endregion
        #region Constructor
        /// <summary>
        /// Initialiserer en ny instancer af <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="name"> Creature Name</param>
        /// <param name="maxHealth"> Creature maxHealth</param>
        /// <param name="pixel"> Creature pixel</param>
        /// <param name="position">Creature's position</param>
        public CreatureBase(string name, int maxHealth, Pixel pixel, Position position)
        {
            _name = name;
            _maxHealth = maxHealth;
            _pixel = pixel;
            _position = position;

            _random = new Random() ;
            FullHealth();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets eller Sets en værdi
        /// </summary>
        public Pixel Pixel { get=>_pixel; set=> _pixel = value; }
        public Position Position { get => _position; set=> _position= value; }
        public int Health { get => _health; set => _health = value; }
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// Dead kan kun gets når _health rammer 0
        /// </summary>
        public bool Dead { get { return (_health <= 0); } }


        #endregion
        #region Methods
        /// <summary>
        /// En metode da genstarter health til maxhealth. 
        /// Metoder bliver brugt til at genstart Heros liv når spillet er slut
        /// </summary>
        public void FullHealth()
        {
            _health = _maxHealth;
        }
        /// <summary>
        /// En abstract metode, hvor et creature can modtage damage.
        /// </summary>
        /// <param name="power"> power bestemmer hvor meget damage modstanden (hero/enemy) modtager</param>
        public abstract void ReceiveDamage(int power); 
        

        /// <summary>
        /// HealthBar skaber en console line som fremviser hvor meget health hero eller enemy har i spillet.
        /// </summary>
        /// <returns> HealthBar returner en line af #s, hver # er et 1 health.</returns>
        public string HealthBar()
        {
            string s = "[";
            int total = _maxHealth;
            double count = Math.Round(((double)_health / _maxHealth) * total);
            
            for (int i = 0; i < count; i++)
                s += "#";
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }

        #endregion

    }
}
