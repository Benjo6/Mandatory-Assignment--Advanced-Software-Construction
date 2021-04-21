using Mandatory_Assignment;
using Mandatory_Assignment.Interfaces;
using Mandatory_Assignment.StateTable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class App
    {
        private World world = new World(64,32);
        private IStateMachine sm = new StateMachineTable();
        private TraceSource ts;

        public App()
        {
            ts = new TraceSource("Mandatory-Assignment");
            ts.Switch = new SourceSwitch("Mandatory-Assignment", "All");

            TraceListener fileLog = new TextWriterTraceListener(new StreamWriter("text.txt"));
            ts.Listeners.Add(fileLog);

            TraceListener consoleLog = new ConsoleTraceListener();
            ts.Listeners.Add(consoleLog);

            TraceListener logListener = new EventLogTraceListener("Application");
            ts.Listeners.Add(logListener);


        }
        public void Start()
        {
            #region Instance
            bool game = true;
            ts.TraceEvent(TraceEventType.Information,444, "\r\n\r\n\r\n\r\nWelcome to Hell");
            ts.Close();
            #endregion




            #region Game
            while (game)
            {
                world.PrintPlayground();
                InputType input = ReadNextEvent();
                CreatureStatesTypes nextMove = sm.NextMove(input);
                if(world._loot.Horse == true)
                {
                    game = world.DoNextMove(nextMove); world.DoNextMove(nextMove);


                }
                else
                {
                    game = world.DoNextMove(nextMove);

                }


                //world.EnemyInfo();

                if (world._hero.Dead)
                {
                    game = false;
                    Console.WriteLine("\r\nTHE EMPEROR IS DEAD");

                    if (world.Point == 1)
                    {
                        Console.WriteLine("YOU CONQUEROR 0 LAND, PATHETIC");

                    }
                    else if (world.Point == 2)
                    {
                        Console.WriteLine("YOU CONQUEROR {0} COUNTRY ", world.Point-1);

                    }
                    else
                        Console.WriteLine("YOU CONQUEROR {0} COUNTRIES ", world.Point-1);
                }

            }






            Console.WriteLine();
          


            #endregion

        }
        #region Movement
        public InputType ReadNextEvent()
        {
            InputType ev = InputType.Up;
            bool ok = false;
            while (!ok)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                char c = info.KeyChar;
                if (world._loot.Horse == true)
                {
                    switch (c)
                    {
                        case 'l':
                            ev = InputType.Loot;
                            ok = true;
                            if (ok && TestRange(2, world._hero.Position.X, world._hero.Position.Y, world._loot.Position.X, world._loot.Position.Y))
                            {
                                world._hero.Loot(world);
                            }
                            break;

                        case 'f':
                            ev = InputType.Attack;
                            ok = true;
                            if (ok)
                            {
                                if (c == 'f' && TestRange(2, world._hero.Position.X, world._hero.Position.Y, world._enemy.Position.X, world._enemy.Position.Y))
                                {
                                    world._hero.Attack(world._enemy);
                                    world._enemy.Attack(world._hero, world._enemy);
                                }
                                if (c == 'f' && TestRange(2, world._hero.Position.X, world._hero.Position.Y, world._enemy2.Position.X, world._enemy2.Position.Y))
                                {
                                    world._hero.Attack(world._enemy2);
                                    world._enemy.Attack(world._hero, world._enemy2
                                        );
                                }
                            };
                            break;
                        case 'w':
                            ev = InputType.Up;
                            ok = true;
                            break;
                        case 's':
                            ev = InputType.Down;
                            ok = true;
                            break;
                        case 'a':
                            ev = InputType.Left;
                            ok = true;
                            break;
                        case 'd':
                            ev = InputType.Right;
                            ok = true;
                            break;
                    }
                }
                else
                {
                    switch (c)
                    {
                        case 'l':
                            ev = InputType.Loot;
                            ok = true;
                            if (ok && TestRange(1, world._hero.Position.X, world._hero.Position.Y, world._loot.Position.X, world._loot.Position.Y))
                            {
                                world._hero.Loot(world);
                            }
                            break;

                        case 'f':
                            ev = InputType.Attack;
                            ok = true;
                            if (ok)
                            {
                                if (c == 'f' && TestRange(1, world._hero.Position.X, world._hero.Position.Y, world._enemy.Position.X, world._enemy.Position.Y))
                                {
                                    world._hero.Attack(world._enemy);
                                    world._enemy.Attack(world._hero, world._enemy);
                                }
                                if (c == 'f' && TestRange(1, world._hero.Position.X, world._hero.Position.Y, world._enemy2.Position.X, world._enemy2.Position.Y))
                                {
                                    world._hero.Attack(world._enemy2);
                                    world._enemy.Attack(world._hero, world._enemy2
                                        );
                                }
                            };
                            break;
                        case 'w':
                            ev = InputType.Up;
                            ok = true;
                            break;
                        case 's':
                            ev = InputType.Down;
                            ok = true;
                            break;
                        case 'a':
                            ev = InputType.Left;
                            ok = true;
                            break;
                        case 'd':
                            ev = InputType.Right;
                            ok = true;
                            break;

                    }
                }



            }
            return ev;
        }

        bool TestRange(int plusNumber,  int bottom, int top, int bottom2, int top2)
        {
            int b;
            int f;
            int b2;
            int f2;
            b= bottom - bottom2;
            f = top - top2;
            b2 = bottom2 - bottom;
            f2 = top2 - top;
            
            return (plusNumber >= b && b>=0 && plusNumber >= f && f >= 0 || plusNumber >= b2 && b2 >= 0 && plusNumber >= f2 && f2 >= 0);
        }

        
        
        #endregion


    }
}
