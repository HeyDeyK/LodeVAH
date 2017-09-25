﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    enum Typy
    {
        Minuto, Lod
    }

    class Program
    {
        static int[,] PoleHrac1 = new int[11, 11];
        public static void Main(string[] args)
        {

            /*
            Typy moznost = Typy.Prazdno;
            Typy[] more = new Typy[3];

            more[0] = Typy.Lod;
            more[1] = Typy.Trefa;
            more[2] = Typy.Prazdno;
            */

            int[,] PoleHrac2 = new int[11, 11];
            bool isTrue = true;
            bool rightznak = true;
            char[] pismenaPole = "ABCDEFGHIJ".ToCharArray();
            String[] ZnakyPole = { "[A]", "[B]", "[C]", "[D]", "[E]", "[F]", "[G]", "[H]", "[I]", "[J]" };
            String[] CislaPole = { "[1] ", "[2] ", "[3] ", "[4] ", "[5] ", "[6] ", "[7] ", "[8] ", "[9] ", "[10]" };

            /*
            if ((int)Typy.Minuto==PoleHrac1[1,2])
            {
                Console.WriteLine("Vedle!");
            }
            else
            {
                Console.WriteLine("Trefa!");
            }
            */
            while (isTrue)
            {
                for (int i = 0; i < PoleHrac1.GetLength(0); i++)
                {
                    for (int f = 0; f < PoleHrac1.GetLength(1); f++)
                    {
                        if (i == 0 && f > 0 && f < 11)
                        {
                            Console.Write(ZnakyPole[f - 1]);
                        }
                        else if (f == 0 && i > 0 && i < 11)
                        {
                            Console.Write(CislaPole[i - 1]);
                        }
                        else if (i == 0 && f == 0)
                        {
                            Console.Write("[ ] ");
                        }
                        else
                        {
                            //Console.Write(PoleHrac1[i, f]);
                            if (PoleHrac1[i, f] == (int)Typy.Minuto)
                            {
                                Console.Write("[ ]");
                            }
                            else
                            {
                                Console.Write("[X]");
                            }
                        }

                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Zadejte řádek:");
                int uzRadek = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Zadejte sloupec:");
                while (rightznak)
                {
                    int hexcislo = 0;
                    string input2 = Console.ReadLine().ToUpper();
                    string hex = string.Join(string.Empty,
                        input2.Select(c => ((int)c).ToString("X")).ToArray());
                    hexcislo = int.Parse(hex);
                    if (hexcislo > 40 && hexcislo < 50)
                    {
                        Console.WriteLine("Správně");
                        Console.WriteLine(hex);
                    }
                    else
                    {
                        Console.WriteLine("megašpatne");
                    }
                }
                int uzSloupec = Convert.ToInt32(Console.ReadLine());
                PridejLod(2, uzRadek, uzSloupec);
                Console.Clear();
            }

            Console.ReadLine();
        }
        public static void PridejLod(int x, int radek, int sloupec)
        {

            for (int i = 0; i < x; i++)
            {
                PoleHrac1[radek, sloupec] = 1;
                sloupec = sloupec + 1;
            }
        }
    }
}