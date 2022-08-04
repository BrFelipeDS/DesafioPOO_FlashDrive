using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class ContaBancaria
    {

        public string NomeTitular { get; set; }

        public ETipoConta Tipo;
        public string Conta { get; set; }
        public string Agencia { get; set; }
        public string CPFTitular { get; set; }

        public enum ETipoConta
        {
            Corrente,
            Poupanca
        }

        public ContaBancaria()
        {
            
        }

        public ContaBancaria(string nomeTitular, ETipoConta tipo, string conta, string agencia, string cPFTitular)
        {
            NomeTitular = nomeTitular;
            Tipo = tipo;
            Conta = conta;
            Agencia = agencia;
            CPFTitular = cPFTitular;
        }
    }
}
