using System;
using System.Collections.Generic;

namespace DesafioPOO_FlashDrive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Passageiro user1 = new Passageiro("Geralt", "bruxao@gmail.com", "amoYennefer", "40028922");

            List<Motorista> motoristas = new List<Motorista>();

            Veiculo carro = new Veiculo("ABC1234", "Onix", "Branco");
            ContaBancaria conta = new ContaBancaria("Vesemir",ContaBancaria.ETipoConta.Corrente, "12345", "456", "987654321");
            Motorista user2 = new Motorista("Vesemir", "mestrebruxo@gmail.com", "melhoralunoGeralt", "1542451",carro,conta);
            motoristas.Add(user2);
            carro = new Veiculo("DEF4567", "Celta", "Preto");
            conta = new ContaBancaria("Triss", ContaBancaria.ETipoConta.Poupanca, "67890", "789", "123456788");
            Motorista user3 = new Motorista("Triss", "ruivinha@gmail.com", "melhorqueaYen", "08009090",carro,conta);
            motoristas.Add(user3);
            
            Dinheiro dinheiro = new Dinheiro();            
            user1.pagamentos.Add(dinheiro);
           

            bool sair = false;

            CabecalhoDivisorias cabecalho = new CabecalhoDivisorias();
            cabecalho.Cabecalho("Flash Drive");

            Console.Write($"Bem-Vindo(a) {user1.Nome}!"); 

            do
            {
                
                
                Console.Write($"\n\nO que gostaria de fazer?\n\n1 - Solicitar viagem\n2 - Adicionar método de pagamento\n3 - Sair\n\nSua Escolha: ");
                string escolha = Console.ReadLine();

                while (escolha != "1" && escolha != "2" && escolha != "3")
                {
                    Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Solicitar viagem\n2 - Adicionar método de pagamento\n3 - Sair\n\nSua escolha: ");
                    escolha = Console.ReadLine();
                }

                if (escolha == "3") { break; }
                else if (escolha == "2")
                {
                    user1.AdicionarMetodoPagamento();
                    continue;
                }
                else
                {
                    user1.SolicitarViagem(user1, motoristas, user1.pagamentos);
                }

                
                Console.Write("\nDeseja sair da aplicação?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                escolha = Console.ReadLine();
                while (escolha != "1" && escolha != "2")
                {
                    Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                    escolha = Console.ReadLine();
                }
                if (escolha == "1")
                {
                    Console.Write("\n\nTem certeza?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                    escolha = Console.ReadLine();
                    while (escolha != "1" && escolha != "2")
                    {
                        Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                        escolha = Console.ReadLine();
                    }
                    if (escolha == "1") { break; }
                    if (escolha == "2") { sair = false; }
                }
                else { sair = false; }
                Console.Clear();
            } while (!sair);

            Console.Clear();
            cabecalho.Cabecalho("Flash Drive");
            Console.WriteLine("Obrigado pela preferência! Até mais!");
        }

       

    }
}