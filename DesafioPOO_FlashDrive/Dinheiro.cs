using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class Dinheiro : Pagamento
    {
        public enum TipoPagamento
        {
            Especie,
            Pix
        }

        public TipoPagamento Tipo;


        public string GerarChaveSePix()
        {
            Random random = new Random();

            string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&.";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            return RandomString(64);
        }
    }
}
