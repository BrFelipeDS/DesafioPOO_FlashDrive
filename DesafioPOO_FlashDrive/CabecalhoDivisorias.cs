using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class CabecalhoDivisorias
    {
        public void Cabecalho(string titulo)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.Write("\n\n");
            Console.Write("\t\t\t\t\t\t    " + titulo);
            Console.Write("\n\n");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }

            Console.Write("\n\n");

        }
    }
}
