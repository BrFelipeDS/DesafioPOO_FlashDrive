using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class Debito : Cartao
    {
        public double Saldo;

        public void DebitarValor(double valor)
        {
            Saldo -= valor;
        }
    }
}
