using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    enum Typy
    {
        Prazdno, Lod,Trefa,Vedle
    }

    class Program
    {
        static int[,] PoleHrac1 = new int[12, 12];
        static int[,] FinHrac1 = new int[12, 12];
        static int[,] FinHrac2 = new int[12, 12];
        static String[] ZnakyPole = { "[A]", "[B]", "[C]", "[D]", "[E]", "[F]", "[G]", "[H]", "[I]", "[J]" };
        static String[] CislaPole = { "[1] ", "[2] ", "[3] ", "[4] ", "[5] ", "[6] ", "[7] ", "[8] ", "[9] ", "[10]" };

        static int kolikatyRadek = 0;
        static int povoleno = 0;


        public static void Main(string[] args)
        {

            /*
            Typy moznost = Typy.Prazdno;
            Typy[] more = new Typy[3];

            more[0] = Typy.Lod;
            more[1] = Typy.Trefa;
            more[2] = Typy.Prazdno;
            */
            
            bool isTrue = true;
            bool celyProgram = true;
            bool isTrueHra = true;
            int pocetLodi = 0;
            int pocetUlozenych = 0;
            int velikostLode = 0;
            int aktHrac = 0;
            string posledniTah = "";
            int potopena = 0;
            int zasah = 1;
            int ctrZasah1 = 0;
            int ctrZasah2 = 0;




            while (celyProgram)
            {
                Console.Clear();
                int moznost = Menu();
                Console.Clear();
                if (moznost==0)
                {
                    while (isTrue)
                    {
                        if (pocetLodi == 6 && pocetUlozenych == 1)
                        {
                            Array.Copy(PoleHrac1, 0, FinHrac2, 0, PoleHrac1.Length);
                            Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                            break;
                        }
                        else if (pocetLodi == 6 && pocetUlozenych == 0)
                        {
                            Array.Copy(PoleHrac1, 0, FinHrac1, 0, PoleHrac1.Length);
                            Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                            pocetUlozenych = 1;
                            pocetLodi = 0;
                            velikostLode = 0;
                            Console.WriteLine("Nyní ukládá lodě hráč číslo 2\n");
                        }

                        for (int i = 0; i < PoleHrac1.GetLength(0) - 1; i++)
                        {
                            for (int f = 0; f < PoleHrac1.GetLength(1) - 1; f++)
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
                                    if (PoleHrac1[i, f] == (int)Typy.Prazdno)
                                    {
                                        Console.Write("[ ]");
                                    }
                                    else
                                    {
                                        Console.Write("[■]");
                                    }
                                }

                            }
                            Console.WriteLine();
                        }

                        if (pocetLodi < 3)
                        {
                            Console.WriteLine("\nUmístěte loď o velikosti dvou políček\n");
                        }
                        else
                        {
                            Console.WriteLine("\nUmístěte loď o velikosti jednoho políčka:\n");
                            velikostLode = 1;
                        }

                        int uzRadek = KolikRadek();

                        int uzSloupec = KolikSloupec();
                        int overeni1 = uzRadek - 1;
                        int overeni2 = uzRadek - 1;
                        int overeni3 = uzRadek - 1;
                        if ((uzRadek == 10 && velikostLode == 0) || uzSloupec > 10)
                        {
                            povoleno = 1;
                        }
                        else
                        {
                            for (int i = 0; i < 4 - velikostLode; i++)
                            {

                                if (PoleHrac1[uzSloupec - 1, overeni1] == 0)
                                {
                                    overeni1++;
                                }
                                else
                                {
                                    povoleno = 1;
                                    break;
                                }
                                if (PoleHrac1[uzSloupec, overeni2] == 0)
                                {
                                    overeni2++;
                                }
                                else
                                {
                                    povoleno = 1;
                                    break;
                                }
                                if (PoleHrac1[uzSloupec + 1, overeni3] == 0)
                                {
                                    overeni3++;
                                }
                                else
                                {
                                    povoleno = 1;
                                    break;
                                }

                            }
                        }


                        if (povoleno == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("      !!Sem nelze loď umístit!!\n");
                            povoleno = 0;
                        }
                        else
                        {
                            PridejLod(2, uzSloupec, uzRadek, velikostLode);
                            pocetLodi++;
                            Console.Clear();
                        }

                    }

                    while (isTrueHra)
                    {
                        
                        Console.Clear();
                        Console.WriteLine(posledniTah);

                        if (aktHrac == 0)
                        {
                            Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                            Array.Copy(FinHrac2, 0, PoleHrac1, 0, FinHrac2.Length);
                            Console.WriteLine("Nyní útočí hráč číslo 1\n");
                        }
                        else
                        {
                            Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                            Array.Copy(FinHrac1, 0, PoleHrac1, 0, FinHrac1.Length);
                            Console.WriteLine("Nyní útočí hráč číslo 2\n");
                        }
                        VypisPole(PoleHrac1, ZnakyPole, CislaPole);
                        int uzRadek = KolikRadek();
                        int uzSloupec = KolikSloupec();
                        if (PoleHrac1[uzSloupec, uzRadek] == (int)Typy.Trefa || PoleHrac1[uzSloupec, uzRadek] == (int)Typy.Vedle)
                        {
                            posledniTah = "Na toto pole jste již střílel!\n";
                        }
                        else
                        {
                            if (PoleHrac1[uzSloupec, uzRadek] == (int)Typy.Prazdno)
                            {
                                PoleHrac1[uzSloupec, uzRadek] = (int)Typy.Vedle;
                                posledniTah = "Vedle!\n";
                            }
                            else if (PoleHrac1[uzSloupec, uzRadek] == (int)Typy.Lod)
                            {
                                PoleHrac1[uzSloupec, uzRadek] = (int)Typy.Trefa;
                                zasah = 1;
                                for (int i = 0; i < 3; i++)
                                {
                                    int overeni1 = uzRadek - 1;
                                    int overeni2 = uzRadek - 1;
                                    int overeni3 = uzRadek - 1;

                                    if (PoleHrac1[uzSloupec - 1, overeni1] == 0)
                                    {
                                        overeni1++;
                                    }
                                    else
                                    {
                                        potopena = 1;
                                        break;
                                    }
                                    if (PoleHrac1[uzSloupec, overeni2] == 0)
                                    {
                                        overeni2++;
                                    }
                                    else
                                    {
                                        potopena = 1;
                                        break;
                                    }
                                    if (PoleHrac1[uzSloupec + 1, overeni3] == 0)
                                    {
                                        overeni3++;
                                    }
                                    else
                                    {
                                        potopena = 1;
                                        break;
                                    }

                                }
                                if (potopena == 1)
                                {
                                    posledniTah = "Loď potopena!\n";

                                }
                                else
                                {
                                    posledniTah = "Trefa!\n";
                                }
                            }



                            if (aktHrac == 0)
                            {
                                Array.Copy(PoleHrac1, 0, FinHrac2, 0, PoleHrac1.Length);
                                aktHrac = 1;
                                if (zasah == 1)
                                {
                                    ctrZasah1++;
                                    zasah = 0;
                                }
                                if (ctrZasah1 == 9)
                                {
                                    Console.WriteLine("GRATULUJEME vyhrál hráč číslo jedna!!!");
                                    break;
                                }
                            }
                            else
                            {
                                Array.Copy(PoleHrac1, 0, FinHrac1, 0, PoleHrac1.Length);
                                aktHrac = 0;
                                if (zasah == 1)
                                {
                                    ctrZasah2++;
                                    zasah = 0;
                                }
                                if (ctrZasah2 == 9)
                                {
                                    Console.WriteLine("GRATULUJEME vyhrál hráč číslo dva!!!");
                                    break;
                                }
                            }
                        }
                        

                    }
                    Console.WriteLine("Stiskněte klávesu pro návrat do menu.");
                    Console.ReadLine();
                }
                else if(moznost==1)
                {
                    Console.Clear();
                    Console.WriteLine("Na začátku hry si oba dva hráčí uloží lodě do svého pole.");
                    Console.WriteLine("Každý hráč ukládá tři lodě široké dvě políčka a tři lodě široké jedno políčko.");
                    Console.WriteLine("Od každé lodě musí být rozestup jedno políčko do všech stran.");
                    Console.WriteLine("Poté co si oba dva hráči uloží lodě bude se hrát.");
                    Console.WriteLine("Vyhrává hráč, který jako první zničí všechny lodě protivníka");
                    Console.WriteLine("\nLegenda:");
                    Console.WriteLine("[■] <- hráčem uložená loď");
                    Console.WriteLine("[O] <- Prázdné místo po střele");
                    Console.WriteLine("[X] <- zasažená loď");
                    Console.ReadLine();
                }
                else if(moznost==2)
                {
                    Console.Beep();
                    Environment.Exit(0);
                }
            }
            
        }

        public static void VypisPole(int [,] PoleHrac1 ,string [] ZnakyPole, string[] CislaPole)
        {
            for (int i = 0; i < PoleHrac1.GetLength(0) - 1; i++)
            {
                for (int f = 0; f < PoleHrac1.GetLength(1) - 1; f++)
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

                        if ((PoleHrac1[i, f] == (int)Typy.Prazdno) || (PoleHrac1[i, f] == (int)Typy.Lod))
                        {
                            Console.Write("[ ]");
                        }
                        else if (PoleHrac1[i, f] == (int)Typy.Vedle)
                        {
                            Console.Write("[O]");
                        }
                        else if (PoleHrac1[i, f] == (int)Typy.Trefa)
                        {
                            Console.Write("[X]");
                        }
                    }

                }
                Console.WriteLine();
            }
        }
        public static void PridejLod(int x, int radek, int sloupec,int velikost)
        {

            for (int i = 0; i < x-velikost; i++)
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
        public static int KolikSloupec()
        {
            bool rightznak = true;
            int zadRadek = 0;
            while(rightznak)
            {
                Console.WriteLine("Zadejte řádek:");
                string Radek = Console.ReadLine();
                bool allDigits = Radek.All(char.IsDigit);
                if(allDigits && Radek !="")
                {
                    
                    zadRadek = Convert.ToInt32(Radek);
                    if(zadRadek>0 && zadRadek<11)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Špatný vstup!");
                    }

                }
                else
                {
                    Console.WriteLine("Špatný vstup!");
                }
            }
            return zadRadek;
        }
        public static int Menu()
        {
            bool isTrue = true;
            int moznost = 0;
            
            while(isTrue)
            {
                if(moznost==0)
                {
                    Console.WriteLine("> Nová hra");
                    Console.WriteLine("Nápověda");
                    Console.WriteLine("Konec");
                }
                else if(moznost==1)
                {
                    Console.WriteLine("Nová hra");
                    Console.WriteLine("> Nápověda");
                    Console.WriteLine("Konec");
                }
                else
                {
                    Console.WriteLine("Nová hra");
                    Console.WriteLine("Nápověda");
                    Console.WriteLine("> Konec");
                }
                string name = Console.ReadKey().Key.ToString();
                if(name=="UpArrow")
                {
                    if (moznost > 0)
                    {
                        moznost = moznost - 1;
                    }
                }
                else if(name=="DownArrow")
                {
                    if (moznost >= 0 && moznost < 2)
                    {
                        moznost++;
                    }
                }
                else if(name=="Enter")
                {
                    break;
                }
                Console.Clear();
            }
            return moznost;
        }
    }
}