using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    enum Typy
    {
        Prazdno, Lod, Trefa, Vedle
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
            int[] utokSipek = { 1, 1 };
            int[] vyberSipek = { 1, 1 };
            int hrajeZnovu = 0;
            string status = "";
            string status2 = "";



            while (celyProgram)
            {
                Console.Clear();
                int moznost = Menu();
                Console.Clear();
                if (moznost == 0)
                {
                    while (isTrue)
                    {
                        if (pocetLodi == 7 && pocetUlozenych == 1)
                        {
                            Array.Copy(PoleHrac1, 0, FinHrac2, 0, PoleHrac1.Length);
                            Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                            break;
                        }
                        else if (pocetLodi == 7 && pocetUlozenych == 0)
                        {
                            Array.Copy(PoleHrac1, 0, FinHrac1, 0, PoleHrac1.Length);
                            Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                            pocetUlozenych = 1;
                            pocetLodi = 0;
                            velikostLode = 0;
                            Console.WriteLine("Nyní ukládá lodě hráč číslo 2\n");
                        }


                        if (pocetLodi == 0)
                        {
                            status2 = "Umístěte loď o velikosti tří políček\n";
                        }
                        else if (pocetLodi < 4 && pocetLodi > 0)
                        {
                            status2 = "Umístěte loď o velikosti dvou políček\n";
                            velikostLode = 1;
                        }
                        else
                        {
                            status2 = "Umístěte loď o velikosti jednoho políčka:\n";
                            velikostLode = 2;
                        }
                        vyberSipek = SipkyUlozeni(PoleHrac1, ZnakyPole, CislaPole, velikostLode, status, status2);
                        int uzSloupec = vyberSipek[1];

                        int uzRadek = vyberSipek[0];
                        int overeni1 = uzSloupec - 1;
                        int overeni2 = uzSloupec - 1;
                        int overeni3 = uzSloupec - 1;
                        for (int i = 0; i < 4 - velikostLode; i++)
                        {

                            if (PoleHrac1[uzRadek - 1, overeni1] == 0)
                            {
                                overeni1++;
                            }
                            else
                            {
                                povoleno = 1;
                                break;
                            }
                            if (PoleHrac1[uzRadek, overeni2] == 0)
                            {
                                overeni2++;
                            }
                            else
                            {
                                povoleno = 1;
                                break;
                            }
                            if (PoleHrac1[uzRadek + 1, overeni3] == 0)
                            {
                                overeni3++;
                            }
                            else
                            {
                                povoleno = 1;
                                break;
                            }

                        }


                        if (povoleno == 1)
                        {
                            Console.Clear();
                            status = "      !!Sem nelze loď umístit!!\n";
                            povoleno = 0;
                        }
                        else
                        {
                            PridejLod(3, uzRadek, uzSloupec, velikostLode);
                            pocetLodi++;
                            status = "";
                            Console.Clear();
                        }

                    }

                    while (isTrueHra)
                    {

                        Console.Clear();

                        utokSipek = SipkyVyber(PoleHrac1, ZnakyPole, CislaPole, posledniTah, aktHrac);
                        int uzSloupec = utokSipek[1];
                        int uzRadek = utokSipek[0];
                        if (PoleHrac1[uzRadek, uzSloupec] == (int)Typy.Trefa || PoleHrac1[uzRadek, uzSloupec] == (int)Typy.Vedle)
                        {
                            posledniTah = "Na toto pole jste již střílel!\n";
                        }
                        else
                        {
                            if (PoleHrac1[uzRadek, uzSloupec] == (int)Typy.Prazdno)
                            {
                                PoleHrac1[uzRadek, uzSloupec] = (int)Typy.Vedle;
                                posledniTah = "Vedle!\n";
                            }
                            else if (PoleHrac1[uzRadek, uzSloupec] == (int)Typy.Lod)
                            {
                                hrajeZnovu = 1;
                                PoleHrac1[uzRadek, uzSloupec] = (int)Typy.Trefa;
                                zasah = 1;
                                int overeni1 = uzSloupec - 1;
                                int overeni2 = uzSloupec - 1;
                                int overeni3 = uzSloupec - 1;
                                for (int i = 0; i < 3; i++)
                                {


                                    if (PoleHrac1[uzRadek - 1, overeni1] != 1)
                                    {
                                        overeni1++;
                                    }
                                    else
                                    {
                                        potopena = 1;
                                        break;
                                    }
                                    if (PoleHrac1[uzRadek, overeni2] != 1)
                                    {
                                        overeni2++;
                                    }
                                    else
                                    {
                                        potopena = 1;
                                        break;
                                    }
                                    if (PoleHrac1[uzRadek + 1, overeni3] != 1)
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

                                    posledniTah = "Trefa!\n";

                                }
                                else
                                {
                                    posledniTah = "Loď potopena!\n";
                                    /*int overeni1 = uzSloupec - 1;
                                    int overeni2 = uzSloupec - 1;
                                    int overeni3 = uzSloupec - 1;
                                    for (int i = 0; i < 3; i++)
                                    {
                                        

                                        if (PoleHrac1[uzRadek - 1, overeni1] != 1)
                                        {
                                            Console.WriteLine(uzRadek - 1 + "" + overeni1);
                                            overeni1++;
                                            
                                        }
                                        else
                                        {
                                            potopena = 1;
                                            break;
                                        }
                                        if (PoleHrac1[uzRadek, overeni2] != 1)
                                        {
                                            Console.WriteLine(uzRadek + "" + overeni2);
                                            overeni2++;
                                            
                                        }
                                        else
                                        {
                                            potopena = 1;
                                            break;
                                        }
                                        if (PoleHrac1[uzRadek + 1, overeni3] != 1)
                                        {
                                            Console.WriteLine(uzRadek + 1 + "" + overeni3);
                                            overeni3++;
                                            
                                        }
                                        else
                                        {
                                            potopena = 1;

                                            break;
                                        }

                                    }
                                    if(potopena==1)
                                    {
                                        Console.WriteLine("jdi od pic");
                                    }
                                    Console.ReadLine();*/

                                }
                                potopena = 0;
                            }



                            if (aktHrac == 0)
                            {
                                Array.Copy(PoleHrac1, 0, FinHrac2, 0, PoleHrac1.Length);

                                if (hrajeZnovu == 1)
                                {

                                }
                                else
                                {
                                    aktHrac = 1;
                                }
                                if (zasah == 1)
                                {
                                    ctrZasah1++;
                                    zasah = 0;
                                }
                                if (ctrZasah1 == 12)
                                {
                                    Console.WriteLine("GRATULUJEME vyhrál hráč číslo jedna!!!");
                                    break;
                                }
                            }
                            else
                            {
                                Array.Copy(PoleHrac1, 0, FinHrac1, 0, PoleHrac1.Length);
                                if (hrajeZnovu == 1)
                                {

                                }
                                else
                                {
                                    aktHrac = 0;
                                }
                                if (zasah == 1)
                                {
                                    ctrZasah2++;
                                    zasah = 0;
                                }
                                if (ctrZasah2 == 12)
                                {
                                    Console.WriteLine("GRATULUJEME vyhrál hráč číslo dva!!!");
                                    break;
                                }
                            }
                            hrajeZnovu = 0;
                        }


                    }
                    Console.WriteLine("Stiskněte klávesu pro návrat do menu.");
                    Console.ReadLine();
                }
                else if (moznost == 1)
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
                else if (moznost == 2)
                {
                    Console.Beep();
                    Environment.Exit(0);
                }
            }

        }

        public static void VypisPole(int[,] PoleHrac1, string[] ZnakyPole, string[] CislaPole)
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
        public static void PridejLod(int x, int radek, int sloupec, int velikost)
        {

            for (int i = 0; i < x - velikost; i++)
            {
                PoleHrac1[radek, sloupec] = 1;
                sloupec = sloupec + 1;
            }
        }
        public static int FunSloupec()
        {
            bool rightznak = true;
            String[] pismenaPole = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            while (rightznak)
            {
                Console.WriteLine("Zadejte sloupec:");
                string uzSloupec = Console.ReadLine().ToUpper();

                if (pismenaPole.Contains(uzSloupec))
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (pismenaPole[i] == uzSloupec)
                        {
                            kolikatyRadek = i + 1;
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
        public static int FunRadek()
        {
            bool rightznak = true;
            int zadRadek = 0;
            while (rightznak)
            {
                Console.WriteLine("Zadejte řádek:");
                string Radek = Console.ReadLine();
                bool allDigits = Radek.All(char.IsDigit);
                if (allDigits && Radek != "")
                {

                    zadRadek = Convert.ToInt32(Radek);
                    if (zadRadek > 0 && zadRadek < 11)
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

            while (isTrue)
            {
                if (moznost == 0)
                {
                    Console.WriteLine("> Nová hra");
                    Console.WriteLine("Nápověda");
                    Console.WriteLine("Konec");
                }
                else if (moznost == 1)
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
                if (name == "UpArrow")
                {
                    if (moznost > 0)
                    {
                        moznost = moznost - 1;
                    }
                }
                else if (name == "DownArrow")
                {
                    if (moznost >= 0 && moznost < 2)
                    {
                        moznost++;
                    }
                }
                else if (name == "Enter")
                {
                    break;
                }
                Console.Clear();
            }
            return moznost;
        }
        public static int[] SipkyVyber(int[,] PoleHrac1, string[] ZnakyPole, string[] CislaPole, string posledniTah, int aktHrac)
        {
            bool isTrue = true;
            int historie = 0;

            int VyberRadek = 1;
            int VyberSloupec = 1;
            while (isTrue)
            {
                Console.Clear();



                if (aktHrac == 0)
                {
                    Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                    Array.Copy(FinHrac2, 0, PoleHrac1, 0, FinHrac2.Length);
                    Console.WriteLine("Pole hráče číslo 2:\n");
                }
                else
                {
                    Array.Clear(PoleHrac1, 0, PoleHrac1.Length);
                    Array.Copy(FinHrac1, 0, PoleHrac1, 0, FinHrac1.Length);
                    Console.WriteLine("Pole hráče číslo 1:\n");
                }
                historie = PoleHrac1[VyberRadek, VyberSloupec];
                PoleHrac1[VyberRadek, VyberSloupec] = 5;
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
                            else if (PoleHrac1[i, f] == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("[+]");
                                Console.ResetColor();
                            }
                        }

                    }
                    Console.WriteLine();
                }
                PoleHrac1[VyberRadek, VyberSloupec] = historie;
                if (aktHrac == 0)
                {
                    Console.WriteLine("\nPole hráče číslo 1:\n");
                    VypisPole(FinHrac1, ZnakyPole, CislaPole);
                }
                else
                {
                    Console.WriteLine("\nPole hráče číslo 2:\n");
                    VypisPole(FinHrac2, ZnakyPole, CislaPole);
                }

                if (posledniTah == "")
                {

                }
                else
                {
                    Console.WriteLine("\n" + posledniTah);
                }
                string name = Console.ReadKey().Key.ToString();

                if (name == "UpArrow")
                {
                    if (VyberRadek > 1)
                    {
                        VyberRadek--;
                    }
                }
                else if (name == "DownArrow")
                {
                    if (VyberRadek < 10)
                    {
                        VyberRadek++;
                    }
                }
                else if (name == "LeftArrow")
                {
                    if (VyberSloupec > 1)
                    {
                        VyberSloupec--;
                    }
                }
                else if (name == "RightArrow")
                {
                    if (VyberSloupec < 10)
                    {
                        VyberSloupec++;
                    }
                }
                else if (name == "Enter")
                {
                    break;
                }
            }
            int[] VyberLode = { VyberRadek, VyberSloupec };
            return VyberLode;
        }
        public static int[] SipkyUlozeni(int[,] PoleHrac1, string[] ZnakyPole, string[] CislaPole, int velikost, string status, string status2)
        {
            bool isTrue = true;
            int historie = 0;
            int historie2 = 0;
            int historie3 = 0;
            int VyberRadek = 1;
            int VyberSloupec = 1;
            while (isTrue)
            {
                Console.Clear();
                if (status != "")
                {
                    Console.WriteLine(status);
                }
                Console.WriteLine(status2);

                if (velikost == 0)
                {
                    historie = PoleHrac1[VyberRadek, VyberSloupec];
                    historie2 = PoleHrac1[VyberRadek, VyberSloupec + 1];
                    historie3 = PoleHrac1[VyberRadek, VyberSloupec + 2];
                    PoleHrac1[VyberRadek, VyberSloupec] = 5;
                    PoleHrac1[VyberRadek, VyberSloupec + 1] = 5;
                    PoleHrac1[VyberRadek, VyberSloupec + 2] = 5;
                }
                else if (velikost == 1)
                {
                    historie = PoleHrac1[VyberRadek, VyberSloupec];
                    historie2 = PoleHrac1[VyberRadek, VyberSloupec + 1];
                    PoleHrac1[VyberRadek, VyberSloupec] = 5;
                    PoleHrac1[VyberRadek, VyberSloupec + 1] = 5;
                }
                else
                {
                    historie = PoleHrac1[VyberRadek, VyberSloupec];
                    PoleHrac1[VyberRadek, VyberSloupec] = 5;
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
                            else if (PoleHrac1[i, f] == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("[■]");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write("[■]");
                            }
                        }

                    }
                    Console.WriteLine();
                }


                if (velikost == 0)
                {
                    PoleHrac1[VyberRadek, VyberSloupec] = historie;
                    PoleHrac1[VyberRadek, VyberSloupec + 1] = historie2;
                    PoleHrac1[VyberRadek, VyberSloupec + 2] = historie3;
                }
                else if (velikost == 1)
                {
                    PoleHrac1[VyberRadek, VyberSloupec] = historie;
                    PoleHrac1[VyberRadek, VyberSloupec + 1] = historie2;
                }
                else
                {
                    PoleHrac1[VyberRadek, VyberSloupec] = historie;
                }

                string name = Console.ReadKey().Key.ToString();

                if (name == "UpArrow")
                {
                    if (VyberRadek > 1)
                    {
                        VyberRadek--;
                    }
                }
                else if (name == "DownArrow")
                {
                    if (VyberRadek < 10)
                    {
                        VyberRadek++;
                    }
                }
                else if (name == "LeftArrow ")
                {
                    if (VyberSloupec > 1)
                    {
                        VyberSloupec--;
                    }
                }
                else if (name == "RightArrow")
                {
                    if (VyberSloupec < 8 + velikost)
                    {
                        VyberSloupec++;
                    }
                }
                else if (name == "Enter")
                {
                    break;
                }
            }
            int[] VyberLode = { VyberRadek, VyberSloupec };
            return VyberLode;
        }
    }
}