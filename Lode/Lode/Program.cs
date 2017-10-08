using System;
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
        static int[,] PoleHrac1 = new int[12, 12];
        static int kolikatyRadek = 0;
        
        
        public static void Main(string[] args)
        {

            /*
            Typy moznost = Typy.Prazdno;
            Typy[] more = new Typy[3];

            more[0] = Typy.Lod;
            more[1] = Typy.Trefa;
            more[2] = Typy.Prazdno;
            */

            int[,] PoleHrac2 = new int[12, 12];
            bool isTrue = true;
            
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
                for (int i = 0; i < PoleHrac1.GetLength(0)-1; i++)
                {
                    for (int f = 0; f < PoleHrac1.GetLength(1)-1; f++)
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


                int uzRadek = KolikRadek();
                Console.WriteLine("Zadejte řádek:");
                int uzSloupec = Convert.ToInt32(Console.ReadLine());
                int povoleno = 0;
                int overeni1 = uzRadek - 1;
                int overeni2 = uzRadek - 1;
                int overeni3 = uzRadek - 1;
                if(uzRadek==10)
                {
                    povoleno = 1;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine("NEW LINE:");
                        Console.WriteLine(uzSloupec - 1 + ";" + overeni1);

                        Console.WriteLine(uzSloupec + ";" + overeni2);
                        Console.WriteLine(uzSloupec + 1 + ";" + overeni3);
                        if (PoleHrac1[uzSloupec - 1, overeni1] == 0)
                        {
                            overeni1++;
                        }
                        else
                        {
                            Console.WriteLine("Chyba!!");
                            povoleno = 1;
                            break;
                        }
                        if (PoleHrac1[uzSloupec, overeni2] == 0)
                        {
                            overeni2++;
                        }
                        else
                        {
                            Console.WriteLine("Chyba!!");
                            povoleno = 1;
                            break;
                        }
                        if (PoleHrac1[uzSloupec + 1, overeni3] == 0)
                        {
                            overeni3++;
                        }
                        else
                        {
                            Console.WriteLine("Chyba!!");
                            povoleno = 1;
                            break;
                        }

                    }
                }
                
                
                if(PoleHrac1[5,5]==1)
                {
                    Console.WriteLine("ALOHA");
                }
                
                if (povoleno == 1)
                {
                    //Console.Clear();
                    Console.WriteLine("      !!Sem nelze loď umístit!!");
                    Console.WriteLine("");
                }
                else
                {
                    PridejLod(2, uzSloupec, uzRadek);
                    //Console.Clear();
                }
                
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
        public static int KolikRadek()
        {
            bool rightznak = true;
            String[] pismenaPole = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            while (rightznak)
            {
                Console.WriteLine("Zadejte sloupec:");
                string uzRadek = Console.ReadLine().ToUpper();

                if (pismenaPole.Contains(uzRadek))
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (pismenaPole[i] == uzRadek)
                        {
                            kolikatyRadek = i+1;
                            rightznak = false;
                            break;

                        }

                    }
                }
                else
                {
                    Console.WriteLine("Špatný vstup!");
                }
            }
            return kolikatyRadek;
        }
    }
}