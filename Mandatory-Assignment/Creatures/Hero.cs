using Mandatory_Assignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{
    public class Hero : CreatureBase
    {
        #region Instance
        private Random rnd = new Random();
        #endregion

        #region Constructor
        /// <summary>
        /// Initialiserer en ny instancer af <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="name">Heros name</param>
        /// <param name="maxHealth">Heros maxHealth</param>
        /// <param name="pixel">Heros pixel aka en prik på consolen</param>
        /// <param name="position">Position for Heroen</param>
        public Hero( string name, int maxHealth, Pixel pixel, Position position ) : base(name, maxHealth,pixel,position)
        {
            
            Shield = new Shield();
            Sword = new Sword();
            FullHealth();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets eller Sets en værdi
        /// </summary>
        public Sword Sword { get; set; }
        public Shield Shield { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Attack metoden giver Hero mulighed for angreb Enemyen.
        /// </summary>
        /// <param name="enemy">Man skal indgive hvilket Enemy der skal modtage angrebet</param>
        public void Attack(Enemy enemy)
        {
            int damage = Sword.Power;
            enemy.ReceiveDamage(damage);


        }

        /// <summary>
        /// En loot modtage som gør at Hero kan åben en crest.
        /// </summary>
        /// <param name="world"> Man kan indgive hvilket verden man ønsker er lootable</param>
        public void Loot( World world)
        {
            world.Looting();
        }

        /// <summary>
        /// Hero modtager damage fra Enemy via den her metode. 
        /// Den her metode er lidt anderledes end Enemy ReceiveDamage. 
        /// Forskellen er indsættelsen af Shield.Power.
        /// </summary>
        /// <param name="power">power den styrke som Enemy skader Hero med</param>
        public override void ReceiveDamage(int power)
        {
           Health = Health - power + Shield.Power;
        }
        /// <summary>
        /// Move er en metode der bestemmer hvilket retning Hero skal gå mod.
        /// </summary>
        /// <param name="direction"> Man skal indsætte en CreatureStatesTypes før Move metoden virker.</param>
        public void Move(CreatureStatesTypes direction)
        {
            switch (direction)
            {
                case CreatureStatesTypes.North: 
                    Position.X--;
                    break;
                case CreatureStatesTypes.South:
                    Position.X++;
                    break;
                case CreatureStatesTypes.East:
                    Position.Y++;
                    break;
                case CreatureStatesTypes.West:
                    Position.Y--;
                    break;
            }
        }
        /// <summary>
        /// En metode der checker om Heroen er indenfor walls.
        /// </summary>
        /// <param name="maxWidth"> Man skal indsætte en max width for consolen</param>
        /// <param name="maxHeight">Man skal indsætte en max height for consolen</param>
        /// <returns>Den returner en true/false statement, hvis den er indenfor the walls er den True 
        /// og hvis den er udenfor er den false</returns>
        public bool CheckIfInsideOfTheWalls(in int maxWidth, in int maxHeight)
        {
            return !(Position.X == maxWidth || Position.X == -1 || Position.Y == maxHeight || Position.Y == -1) ;
        }
        #endregion
    }
}
