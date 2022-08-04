using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public abstract class Cartao : Pagamento
    {
        public string Numero;
        public string Validade;
        public string CVV;
    }
}
