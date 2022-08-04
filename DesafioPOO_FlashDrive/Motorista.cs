using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class Motorista : Usuario
    {
        public Veiculo Carro = new Veiculo();
        private ContaBancaria DadosBancarios = new ContaBancaria();

        public Motorista()
        {

        }

        public Motorista(string _nome, string _email, string _senha, string _contato, Veiculo _carro, ContaBancaria _dadosBancarios)
        {
            Nome = _nome;
            Email = _email;
            Senha = _senha;
            Contato = _contato;
            Carro = _carro;
            DadosBancarios = _dadosBancarios;
        }


        public void CadastrarDadosBancarios()
        {
            Console.Write("\nInsira o nome do Titular da Conta: ");
            DadosBancarios.NomeTitular = Console.ReadLine();
            
            Console.Write("\nEscolha o tipo da conta:\n\n1 - Corrente\n2 - Poupança\n\nSua escolha: ");
            string escolha = Console.ReadLine();
            while(escolha != "1" && escolha != "2")
            {
                Console.Write("Opção Inválida. Tente novamente:\n\n1 - Corrente\n 2 - Poupança\n\nSua escolha: ");
            }
            if(escolha == "1") { DadosBancarios.Tipo = ContaBancaria.ETipoConta.Corrente; }
            else { DadosBancarios.Tipo = ContaBancaria.ETipoConta.Poupanca; }

            Console.Write("\nInsira o número da conta: ");
            DadosBancarios.Conta = Console.ReadLine();

            Console.Write("\nInsira a agência da conta: ");
            DadosBancarios.Agencia = Console.ReadLine();

            Console.Write("\nInsira a agência da conta: ");
            DadosBancarios.CPFTitular = Console.ReadLine();

            Console.WriteLine("Dados Bancários cadastrados com sucesso!");
        }

        public void CadastrarVeiculo()
        {
            Console.Write("\nInsira a placa do veículo: ");
            Carro.Placa = Console.ReadLine();

            Console.Write("\nInsira o modelo do veículo: ");
            Carro.Modelo = Console.ReadLine();

            Console.Write("\nInsira a cor do veículo: ");
            Carro.Cor = Console.ReadLine();


            Console.WriteLine("Carro cadastrado com sucesso!");

        }

    }
}
