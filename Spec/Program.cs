using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    class Program
    {
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
        static void menu()
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
                Console.WriteLine("                                    ▄████████▀   ▄████▀        ██████████ ████████▀   0.12");
                Space(36);
                RC(ConsoleColor.Red, ConsoleColor.Black);
                Console.Write("Now with more semi-colons");
                Console.WriteLine(ms);
                RC(ConsoleColor.Black, ConsoleColor.White);
                Console.WriteLine("");
                if (ms == 1) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Play");
                if (ms == 2) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Credits");
                Console.ResetColor();
                EmptyLine(4); Console.Write("Type "); RC(ConsoleColor.Black, ConsoleColor.Green); Console.Write("G"); Console.ResetColor(); Console.Write(" three times to click a button.");
                if (ms <= 2)
                {
                    if (ms >= 1)
                    {
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
                            Setup();
                        }
                        if (Console.ReadKey().Key == ConsoleKey.G & ms == 2)
                        {
                            menu = false;
                            Console.Clear();
                            Credits();
                        } 
                    }
                }
                Console.Clear();
            }
        }
        static void Setup()
        {
            string name = "NaN";
            string world = "NaN";
            RC(ConsoleColor.Blue, ConsoleColor.Black); Console.WriteLine("What is your atom's name?"); Console.ResetColor(); name = Console.ReadLine();
            RC(ConsoleColor.Blue, ConsoleColor.Black); Console.WriteLine("What name would you like your world to be called?"); Console.ResetColor(); world = Console.ReadLine();
            Draw(name, world);
        }
        static void Draw(string name, string world)
        {
            bool game = true;
            int i = 0; // map
            int x = 0; int y = 0;
            int[] worldmap = {0,1,1,1,1,1,0,
                              0,0,0,1,0,0,0,
                              1,0,1,0,1,1,0,
                              1,1,1,1,1,1,0,
                              0,0,0,0,0,0,0,
                              0,0,0,0,1,0,1,
                              1,0,1,0,1,0,0};
            while (game == true)
            {
                Console.Clear();
                Console.WriteLine(name);
                Console.WriteLine(world);
                EmptyLine(2);
                for (i = 0; i < 49; i++ )
                {
                    Console.Write("");
                }
                Console.ReadLine(); 
            }
        }
        static void Credits()
        {
            Console.WriteLine("this was made by your boi zelo/zolo101."); Console.WriteLine("this will go back to the menu in 4 seconds."); System.Threading.Thread.Sleep(4000); Console.Clear(); menu();
        }
        static void Main(string[] args)
        {
            menu();
            Console.ReadKey();
        }
    }
}