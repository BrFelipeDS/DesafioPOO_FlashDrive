using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class Credito : Cartao
    {
        public double Limite;


        public void ReduzirLimite(double valor)
        {
            Limite -= valor;
        }
    }
}
