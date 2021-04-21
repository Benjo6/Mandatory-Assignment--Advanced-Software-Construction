using Mandatory_Assignment.Interfaces;
using System;
using System.Collections.Generic;

namespace Mandatory_Assignment
{
    public class World
    {
        #region Instance
        private Sword sword = new Sword();
        private Shield shield = new Shield();

        
        
        private char[,] _world;
        private static int maxWidth;
        private static int maxHeight;
        private int i;
        private static Random rnd = new Random();
        #endregion
        #region constructor

        public World(int width, int height)
        {
            Point = 1;
            _world = new char[width, height];
            maxHeight = height;
            maxWidth = width;
            
            
            _hero = new Hero("Napoleon", 25, new Pixel("Napoleon", ConsoleColor.Blue), new Position(width / 2, height / 2));
            _enemy = new Enemy("", rnd.Next(15, 20), new Pixel("", ConsoleColor.White), new Position(rnd.Next(1, maxWidth-1), rnd.Next(1, maxHeight-1)));
            _loot = new WorldObject(new Position(rnd.Next(1, maxWidth-1), rnd.Next(1, maxHeight-1)), new Pixel("", ConsoleColor.DarkCyan));
            _enemy2 = new Enemy("", rnd.Next(15, 20), new Pixel("", ConsoleColor.Yellow), new Position(rnd.Next(1, maxWidth-1), rnd.Next(1, maxHeight-1)));
            


        }
        #endregion
        #region Properties
        public WorldObject _loot { get; set; }
        public Enemy _enemy { get; set; }
        public Enemy _enemy2 { get;  set; }
        public Hero _hero { get; set; }
        public int Point { get; set; }

        #endregion
        #region Method
        public void Looting()
        {
            _loot.Lootable = true;
            if (_loot.Lootable)
            {
                _loot.Removable = true;

                if (_hero.Shield.Power < _loot._shield.Power)
                {
                    _hero.Shield = _loot._shield;
                }
                if (_hero.Sword.Power < _loot._sword.Power)
                {
                    _hero.Sword = _loot._sword;
                }
                if (_loot.Removable)
                {
                    _loot = new WorldObject(new Position(rnd.Next(1, 63), rnd.Next(1, 31)), new Pixel("", ConsoleColor.DarkCyan));
                }
                if (_loot.Loot is int)
                {
                    _hero.Health = _hero.Health + _loot.Health;

                }
                if(_loot.Loot is bool)
                {
                    _loot.Horse = true;
                }
            }
        }

        public bool DoNextMove(CreatureStatesTypes move)
        {
            _hero.Move(move);

            bool inside = _hero.CheckIfInsideOfTheWalls(maxWidth, maxHeight);

            return inside;
        }
        public void Enemyspawn()
        {
            if (_enemy.Dead)
            {

                Point = Point + 1;
                _enemy = new Enemy("", rnd.Next(15, 20), new Pixel("", ConsoleColor.Red), new Position(rnd.Next(0, maxWidth), rnd.Next(0, maxHeight)));
                if (_enemy2.Alive && Point > 2)
                {
                    _enemy2 = new Enemy("", rnd.Next(15, 20), new Pixel("", ConsoleColor.Yellow), new Position(rnd.Next(0, maxWidth), rnd.Next(0, maxHeight)));


                }
            }
            if (_enemy2.Dead)
            {
                Point = Point + 1;
                _enemy2 = new Enemy("", rnd.Next(15, 20), new Pixel("", ConsoleColor.Yellow), new Position(rnd.Next(0, maxWidth), rnd.Next(0, maxHeight)));

            }
        }

        public void PrintPlayground()
        {
            if (Point > 2)
            {
                _enemy2.Alive = true;
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            DrawPixel(_enemy.Pixel, _enemy.Position);
            DrawBorder();
            DrawPixel(_hero.Pixel, _hero.Position);
            DrawPixel(_loot.Pixel, _loot.Position);
            Enemyspawn();
            if (_enemy2.Alive)
            {
                DrawPixel(_enemy2.Pixel, _enemy2.Position);
            }

            HeroInfo();
            EnemyInfo();
            if (_enemy2.Alive)
            {
                Enemy2Info();
            }

        }




        #endregion
        #region DrawPixel
        static void DrawPixel(Pixel pixel, Position position)
        {
            
            Console.WriteLine(pixel.Name);
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = pixel.ScreenColor;
            Console.Write("■");
        }
        #endregion
        #region Borders (lol)

        static void DrawBorder()
        {
            Console.WindowWidth =  maxWidth+1;
            Console.WindowHeight = maxHeight+1;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");

                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");

                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write("■");
            }
        }
        #endregion

        #region ReadInfo
        public void HeroInfo()
        {
            Console.WriteLine("\r\nNapoleon");
            Console.WriteLine("Health:{0}",_hero.HealthBar());
            Console.WriteLine("Sword:{0}",_hero.Sword.Quality);
            Console.WriteLine("Shield:{0}",_hero.Shield.Quality);
            Console.WriteLine("Horse:{0}", _loot.Horse);

        }

        public void EnemyInfo()
        {
            Console.WriteLine("\r\nEnemy:{0}", _enemy.Kind.ToString());
            Console.WriteLine("Health:{0}",_enemy.HealthBar());
        }
        public void Enemy2Info()
        {
            Console.WriteLine("\r\nEnemy2:{0}", _enemy2.Kind.ToString());
            Console.WriteLine("Health:{0}", _enemy2.HealthBar());
        }
        #endregion


    }
}
