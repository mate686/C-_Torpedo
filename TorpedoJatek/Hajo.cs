using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoJatek
{
    public class Hajo
    {
        public byte Meret { get; set; }
        public bool Aktiv { get; set;} = true;

        public Hajo(byte m) { 
            Meret = m;
        }


    }
}
