using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoJatek
{

    public class Jatek
    {
        Tabla tenger;

        public Jatek() {
            tenger = new Tabla(10,10);
            tenger.HajoLerakas();
        }
    }
}
