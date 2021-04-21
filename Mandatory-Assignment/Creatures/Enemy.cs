using Mandatory_Assignment.Randomizers;
using System;

namespace Mandatory_Assignment
{
    public class Enemy : CreatureBase
    {
        #region Instance
        private EnemyQualityFactoryRandomized randomized = new EnemyQualityFactoryRandomized();
        #endregion
        #region Constructor
        /// <summary>
        /// Initialiserer en ny instancer af <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="name">Enemy's name</param>
        /// <param name="maxHealth">maxHealth for Enemy</param>
        /// <param name="pixel">pixel for Enemy</param>
        /// <param name="position">position hvor Enemy skal være</param>
        public Enemy( string name, int maxHealth, Pixel pixel, Position position) : base( name, maxHealth, pixel,position)
        {
            Kind = randomized.GetQuality();
            FullHealth();

        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets eller Sets en værdi
        /// </summary>
        public bool Alive { get; set; }
        public World World { get; set; }
        public EnemyKind Kind { get; set; }
        public int Power { get; set; }


        #endregion

        #region Metoder
        /// <summary>
        /// Attack metoden giver Enemy mulighed for angreb Heroen.
        /// </summary>
        /// <param name="hero">man skal indsætte hvilket Hero der skal modtage damage</param>
        /// <param name="enemy">Man skal indsætte hvilket Enemy der skal angreb heroen</param>

        public void Attack(Hero hero, Enemy enemy)
        {
            int damage = UnitPower(enemy);
            hero.ReceiveDamage(damage);
        }
        /// <summary>
        /// Enemy modtager damage fra Hero via den her metode.
        /// </summary>
        /// <param name="power"> power den styrke som Hero skader enemy med</param>
        public override void ReceiveDamage(int power)
        {
            Health = Health - power;
        }

    
        
        /// <summary>
        /// Unitpower er en metode da checker hvilke Kind enemy er derefter kan den finde ud af hvilke damage der skal returnes
        /// </summary>
        /// <param name="enemy">Man er nødtaget til at sige hvilke enemy der skal igennem denne process</param>
        /// <returns>Unitpower returner en damage niveau. Niveauet er bestemt igennem hvilke Kind Enemy er.</returns>
        public int UnitPower(Enemy enemy)
        {
            int damage = 0;
            switch (enemy.Kind)
            {
                case EnemyKind.Warrior: damage = _random.Next(1, 3);
                    break;
                case EnemyKind.Phalanx: damage = _random.Next(2, 4);
                    break;
                case EnemyKind.Legion:
                    damage = _random.Next(3, 4);
                    break;
                case EnemyKind.Pikemen:
                    damage = _random.Next(3, 5);
                    break;
                case EnemyKind.Knights:
                    damage = _random.Next(3, 6);
                    break;
                case EnemyKind.Muskesteers:
                    damage = _random.Next(4, 7);
                    break;
                case EnemyKind.Riflemen:
                    damage = _random.Next(5, 8);
                    break;
                
            }
            return damage;

            
        }
        #endregion
    }
}