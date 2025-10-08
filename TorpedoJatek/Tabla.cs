using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoJatek
{
    public class Tabla
    {
        private readonly byte Magassag;
        public readonly byte Szelesseg;
        public Hajo[,] Pontok;
        public List<Hajo> HajokLista { get; set; }

 
        public Tabla(byte m, byte sz)
        {
            Magassag = m;
            Szelesseg = sz;
            Pontok = new Hajo[Magassag, Szelesseg];
        }

        public void Megjelenites()
        {
            for (int m = 0; m <= Magassag+1; m++)
            {
                for (int sz = 0; sz <= Szelesseg+1; sz++)
                {
                    if (m == 0 || m == Magassag+1 || sz== 0 || sz == Szelesseg+1) 
                    { 
                        Console.Write("#");
                    }
                    else if (Pontok[m-1, sz-1 ] == null)
                        Console.Write(" ");
                    else
                        Console.Write(Pontok[m-1, sz-1].Meret);

                }
                

                Console.WriteLine();
            }
        }

        public void HajoLerakas()
        {

            byte[] HMeretek = [2, 2, 3, 4, 5];

            foreach (byte m in HMeretek) { 
                Megjelenites();
                HajoLetrehozas(m);
                Console.Clear();

            }


        }

        private byte BetubolSzam(char b)
        {
            return (byte)(b - 'a');
        }

        private void HajoLetrehozas(byte m)
        {
            string kordináta;
            string FvagyV;
            byte sor;
            byte oszlop;
            #region AdatokBeker
            do{
                Console.WriteLine($"Add meg a {m} méretü hajo kordinátát: ");
                kordináta = Console.ReadLine();

                Console.WriteLine("Add meg hogy Függöleges vagy Vizszintes f/v: ");
                FvagyV = Console.ReadLine();

                sor = BetubolSzam(kordináta[0]);

                oszlop = byte.Parse(kordináta.Substring(1));
                oszlop--;
                #endregion
            } while (!HajoLerakhato(oszlop, sor, FvagyV, m));


            List <(int, int)> HajoPontok = new List<(int, int)>();
            HajoPontok = HajoPontjai(oszlop,sor, m, FvagyV);

            Hajo H = new Hajo(m);
            foreach(var(x,y) in HajoPontok)
            {
                Pontok[y, x] = H;
            }
            
           
        }

        public List<(int,int)> HajoPontjai(byte s,byte o,byte m,string i)
        {
            List<(int,int)> p = new List<(int, int)>();

            if(i == "v") { 
                for (int x = 0; x<m;x++)
                {
                    p.Add((o + x, s ));
                }
            }
            else
            {
                for (int x = 0; x < m; x++)
                {
                    p.Add((o , s + x));
                }
            }

            return p;
        }

        public bool HajoLerakhato(byte s, byte o, string i, int m)
        {
            
            if (i == "f"&&s+m-1 >= Magassag)
            {
                return false;
            }
            if (i == "v" && o + m-1 >= Szelesseg)
            {
                return false;
            }

            
            for (int x = 0; x <= m-1; x++)
            {
                if (i == "f" && Pontok[s+x, o] != null)
                {
                   
                    return false;
                }
                else if (i == "v" && Pontok[s, o+x] != null)
                {
                  
                    return false;
                }
            }
            


            return true;
        }

        

    }
}
