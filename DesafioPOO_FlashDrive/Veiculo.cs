using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

        public Veiculo()
        {

        }
        public Veiculo(string _placa, string _modelo, string _cor)
        {
            Placa = _placa;
            Modelo = _modelo;
            Cor = _cor;
        }
    }
}
