using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueSharp;
using RLNET;
using Spec.Core;

namespace Spec
{
    class Program
    {
        private static readonly int _Width = 100;
        private static readonly int _Height = 70;
        private static RLRootConsole _rootConsole;

        private static readonly int _mapWidth = 100;
        private static readonly int _mapHeight = 57;
        private static RLConsole _mapConsole;

        private static readonly int _messageWidth = 100;
        private static readonly int _messageHeight = 10;
        private static RLConsole _messageConsole;

        private static readonly int _titleWidth = 100;
        private static readonly int _titleHeight = 3;
        private static RLConsole _titleConsole;
        // console

        private static bool _renderRequired = true;
        public static CommandSystem CommandSystem { get; private set; }

        public static Player Player { get; private set; }
        public static DungeonMap WorldMap { get; private set; }

        static void RC(ConsoleColor back, ConsoleColor fore) // RC(ConsoleColor.,ConsoleColor.);
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
        }
        static void Line(int hm) // how many = hm
        {
            for (int i = 1; i <= hm; i++)
            {
                Console.Write("-");
            }
        }
        static void Space(int hm) // how many = hm
        {
            for (int i = 1; i <= hm; i++)
            {
                Console.Write(" ");
            }
        }
        static void EmptyLine(int hm) // how many = hm
        {
            for (int i = 1; i <= hm; i++)
            {
                Console.WriteLine("");
            }
        }
        static void Menu()
        {
            bool menu = true;
            int ms = 2;
            while (menu == true)
            {
                Console.WriteLine("                                      ▄████████    ▄███████▄    ▄████████  ▄████████");
                Console.WriteLine("                                     ███    ███   ███    ███   ███    ███ ███    ███");
                Console.WriteLine("                                     ███    █▀    ███    ███   ███    █▀  ███    █▀ ");
                Console.WriteLine("                                     ███          ███    ███  ▄███▄▄▄     ███       ");
                Console.WriteLine("                                    ▀██████████ ▀█████████▀  ▀▀███▀▀▀     ███       ");
                Console.WriteLine("                                            ███   ███          ███    █▄  ███    █▄ ");
                Console.WriteLine("                                      ▄█    ███   ███          ███    ███ ███    ███");
                Console.WriteLine("                                    ▄████████▀   ▄████▀        ██████████ ████████▀  0.13");
                Space(36);
                RC(ConsoleColor.Red, ConsoleColor.Black);
                Console.Write("The launcher");
                Console.Write(ms);
                RC(ConsoleColor.Black, ConsoleColor.White);
                Console.WriteLine("");
                if (ms == 1) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Play");
                if (ms == 2) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Credits");
                Console.ResetColor();
                EmptyLine(2); Console.Write("Type "); RC(ConsoleColor.Black, ConsoleColor.Green); Console.Write("W"); Console.ResetColor(); Console.Write(" four times to go up.");
                EmptyLine(1); Console.Write("Type "); RC(ConsoleColor.Black, ConsoleColor.Green); Console.Write("S"); Console.ResetColor(); Console.Write(" four times to go down.");
                EmptyLine(1); Console.Write("Type "); RC(ConsoleColor.Black, ConsoleColor.Green); Console.Write("G"); Console.ResetColor(); Console.Write(" four times to click a button.");
                if (Console.ReadKey().Key == ConsoleKey.W)
                {
                    ms = ms - 1;
                }
                if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    ms = ms + 1;
                }
                if (Console.ReadKey().Key == ConsoleKey.G & ms == 1)
                {
                    menu = false;
                    Console.Clear();
                    Draw();
                }
                if (Console.ReadKey().Key == ConsoleKey.G & ms == 2)
                {
                    menu = false;
                    Console.Clear();
                    Credits();
                }
                Console.Clear();
            }
        }
        static void Draw()
        {
            string font = "terminal8x8.png"; // font
            string title = "Spec"; // title

            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight);
            WorldMap = mapGenerator.CreateMap();

            Player = new Player();
            WorldMap.UpdatePlayerFieldOfView();

            CommandSystem = new CommandSystem();

            _rootConsole = new RLRootConsole(font, _Width, _Height,8,8,1f,title); // console
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _titleConsole = new RLConsole(_titleWidth, _titleHeight);

            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;
            // game loop
            _rootConsole.Run();
        }
        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {/*
            _mapConsole.SetBackColor(0, 0, _mapWidth, _mapHeight, RLColor.Black);
            _mapConsole.Print(1, 1, "Map", RLColor.White);
            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, RLColor.Gray);
            _messageConsole.Print(1, 1, "Messages", RLColor.White);
            _titleConsole.SetBackColor(0, 0, _titleWidth, _titleHeight, RLColor.LightGray);
            _titleConsole.Print(1, 1, "Spec 0.13", RLColor.White);*/
        } // update
        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            RLConsole.Blit(_titleConsole, 0, 0, _titleWidth, _titleHeight,
              _rootConsole, 0, 0);
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight,
              _rootConsole, 0, _titleHeight);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight,
              _rootConsole, 0, _Height - _messageHeight);

            _rootConsole.Draw();
            WorldMap.Draw(_mapConsole);

            Player.Draw(_mapConsole, WorldMap);
        } // render
        static void Credits()
        {
            Console.WriteLine("this was made by your boi zelo/zolo101."); Console.WriteLine("this will go back to the menu in 4 seconds."); System.Threading.Thread.Sleep(4000); Console.Clear(); Menu();
        }
        static void Main(string[] args)
        {
            Console.Title = "Spec Launcher";
            Menu();
            Console.ReadKey();
        }
    }
}