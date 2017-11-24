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
        static void menu()
        {
            bool menu = false;
            int ms = 2;
            ConsoleKeyInfo rk;
            while (menu == false)
            {
                Console.WriteLine("                                      ▄████████    ▄███████▄    ▄████████  ▄████████");
                Console.WriteLine("                                     ███    ███   ███    ███   ███    ███ ███    ███");
                Console.WriteLine("                                     ███    █▀    ███    ███   ███    █▀  ███    █▀ ");
                Console.WriteLine("                                     ███          ███    ███  ▄███▄▄▄     ███       ");
                Console.WriteLine("                                    ▀██████████ ▀█████████▀  ▀▀███▀▀▀     ███       ");
                Console.WriteLine("                                            ███   ███          ███    █▄  ███    █▄ ");
                Console.WriteLine("                                      ▄█    ███   ███          ███    ███ ███    ███");
                Console.WriteLine("                                    ▄████████▀   ▄████▀        ██████████ ████████▀ ");
                Space(36);
                RC(ConsoleColor.Red, ConsoleColor.Black);
                Console.Write("Yall should of seen this coming");
                Console.WriteLine(ms);
                RC(ConsoleColor.Black, ConsoleColor.White);
                Console.WriteLine("");
                if (ms == 1) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Play");
                if (ms == 2) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Credits");
                if (ms == 3) RC(ConsoleColor.White, ConsoleColor.Black); else Console.ResetColor();
                Console.WriteLine("Exit (doesnt work yet)");
                Console.ResetColor();
                rk = Console.ReadKey();
                if (ms <= 3)
                {
                    if (ms >= 1)
                    {
                        if (Console.ReadKey().Key != ConsoleKey.W)
                        {
                            ms = ms + 1;
                        }
                        if (Console.ReadKey().Key != ConsoleKey.S)
                        {
                            ms = ms - 1;
                        }
                    }
                }
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            menu();
        }
    }
}