using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public class Passageiro : Usuario
    {

        
        public List<Pagamento> pagamentos = new List<Pagamento>();      
       

        public Passageiro()
        {

        }

        public Passageiro(string _nome, string _email, string _senha, string _contato)
        {
            Nome = _nome;
            Email = _email;
            Senha = _senha;
            Contato = _contato;            
        }

        public Viagem ViagemAtiva = new Viagem();
        

        public void SolicitarViagem(Passageiro passageiro, List<Motorista> motoristas, List<Pagamento> pagamentos)
        {
            bool sair = false;

            CabecalhoDivisorias cabecalho = new CabecalhoDivisorias();

            do
            {
                Console.Clear();

                cabecalho.Cabecalho("Nova Viagem");
                

                ViagemAtiva.Passageiro = passageiro;

                Console.Write("Por favor, informe sua localização: ");
                string origem = Console.ReadLine();
                ViagemAtiva.Origem = origem;

                Console.Write("\nInsira o endereço de destino: ");
                string destino = Console.ReadLine();
                ViagemAtiva.Origem = destino;


                Console.Write($"\nO valor da viagem custará {ViagemAtiva.Valor} reais. Confirmar viagem?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                string escolha = Console.ReadLine();

                while (escolha != "1" && escolha != "2")
                {
                    Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                    escolha = Console.ReadLine();
                }

                if (escolha == "2") { break; }
                else
                {
                    List<Debito> debito = new List<Debito>();
                    List<Credito> credito = new List<Credito>();

                    Dinheiro dinheiro = new Dinheiro();
                    dinheiro = (Dinheiro)pagamentos[0];



                    for (int i = 0; i < pagamentos.Count; i++)
                    {
                        if (pagamentos[i] is Debito)
                        {
                            debito.Add((Debito)pagamentos[i]);
                        }
                        else if (pagamentos[i] is Credito)
                        {
                            credito.Add((Credito)pagamentos[i]);
                        }
                        else { }
                    }  
                    

                    do
                    {
                        Console.Clear();

                        cabecalho.Cabecalho("Nova Viagem");

                        Console.WriteLine($"Valor da Viagem: {ViagemAtiva.Valor} reais.\n\nEscolha o método de pagamento: ");


                        Console.Write("\n\n1 - Débito\n2 - Crédito\n3 - Dinheiro\n4 - Pix\n\nSua escolha: ");
                        escolha = Console.ReadLine();
                        

                        switch (escolha)
                        {
                            case "1":
                                Console.Write("\n\nEscolha um dos cartões de débito cadastrados: \n\n");

                                for (int i = 0; i < debito.Count; i++)
                                {
                                    Console.Write($"{i + 1} - {debito[i].NomeMetodo}\n");
                                }

                                Console.Write($"{debito.Count + 1} - Sair\n");

                                Console.Write("\nSua escolha: ");
                                escolha = Console.ReadLine();
                                bool valido = int.TryParse(escolha, out int escolhaInt);


                                while (escolhaInt > debito.Count + 1 || escolhaInt <= 0 || !valido)
                                {

                                    Console.Clear();
                                    cabecalho.Cabecalho("Nova Viagem");
                                    Console.WriteLine("Opção inválida, tente novamente.");
                                    Console.Write("\n\nEscolha um dos cartões de débito cadastrados: \n\n");

                                    for (int i = 0; i < debito.Count; i++)
                                    {
                                        Console.Write($"{i + 1} - {debito[i].NomeMetodo}\n");
                                    }

                                    Console.Write($"{debito.Count + 1} - Sair\n");

                                    Console.Write("\nSua escolha: ");
                                    escolha = Console.ReadLine();
                                    valido = int.TryParse(escolha, out escolhaInt);
                                }

                                if (int.Parse(escolha) == debito.Count + 1)
                                {
                                    sair = false;
                                    continue;
                                }
                                else
                                {
                                    if (debito[int.Parse(escolha) - 1].Saldo < ViagemAtiva.Valor)
                                    {
                                        Console.Clear();
                                        cabecalho.Cabecalho("Nova Viagem");
                                        Console.Write("\nSaldo insuficiente para o pagamento. Selecione outro método.");
                                        Thread.Sleep(3000);
                                        sair = false;
                                        continue;
                                    }
                                    else
                                    {
                                        debito[int.Parse(escolha) - 1].DebitarValor(ViagemAtiva.Valor);
                                        sair = true;
                                    }
                                    break;
                                }
                                

                            case "2":
                                Console.Write("\n\nEscolha um dos cartões de crédito cadastrados: \n\n");

                                for (int i = 0; i < credito.Count; i++)
                                {
                                    Console.Write($"{i + 1} - {credito[i].NomeMetodo}\n");
                                }

                                Console.Write($"{credito.Count + 1} - Sair\n");

                                Console.Write("\nSua escolha: ");
                                escolha = Console.ReadLine();
                                valido = int.TryParse(escolha, out escolhaInt);

                                while (escolhaInt > credito.Count + 1 || escolhaInt <= 0 || !valido)
                                {
                                    Console.Clear();
                                    cabecalho.Cabecalho("Nova Viagem");
                                    Console.WriteLine("Opção inválida, tente novamente.");
                                    Console.Write("\n\nEscolha um dos cartões de crédito cadastrados: \n\n");

                                    for (int i = 0; i < credito.Count; i++)
                                    {
                                        Console.Write($"{i + 1} - {credito[i].NomeMetodo}\n");
                                    }

                                    Console.Write($"{credito.Count + 1} - Sair\n");

                                    Console.Write("\nSua escolha: ");
                                    escolha = Console.ReadLine();
                                    valido = int.TryParse(escolha, out escolhaInt);
                                }
                                if (int.Parse(escolha) == credito.Count + 1)
                                {
                                    sair = false;
                                    continue;
                                }
                                else
                                {
                                    if (credito[escolhaInt - 1].Limite < ViagemAtiva.Valor)
                                    {
                                        Console.Clear();
                                        cabecalho.Cabecalho("Nova Viagem");
                                        Console.Write("\nLimite insuficiente para o pagamento. Selecione outro método.");
                                        Thread.Sleep(3000);
                                        sair = false;
                                        continue;
                                    }
                                    else
                                    {
                                        credito[escolhaInt - 1].ReduzirLimite(ViagemAtiva.Valor);
                                        sair = true;
                                        break;
                                    }
                                }
                                

                            case "3":
                                dinheiro.Tipo = Dinheiro.TipoPagamento.Especie;
                                sair = true;
                                break;

                            case "4":                                                         

                                dinheiro.Tipo = Dinheiro.TipoPagamento.Pix;
                                Console.Clear();
                                cabecalho.Cabecalho("Nova Viagem");
                                Console.Write("Aqui está o seu código Pix - Copia e Cola: " + dinheiro.GerarChaveSePix() + "\n\n");
                                Thread.Sleep(3000);
                                Console.WriteLine("Após realizar o pagamento, pressione qualquer tecla para dar início à viagem!");
                                Console.ReadKey();

                                sair = true;
                                break;

                            default:

                                Console.WriteLine("\n\nOpção inválida. Tente novamente.");
                                Thread.Sleep(2000);
                                sair = false;
                                break;

                        }
                    } while (!sair);

                    ViagemAtiva.StatusViagem = EStatusViagem.BuscandoMotorista;
                    Console.WriteLine("\n");

                    Console.Clear();
                    cabecalho.Cabecalho("Viagem Atual");
                    Console.Write("Buscando motorista.");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);


                    ViagemAtiva.StatusViagem = EStatusViagem.MotoristaEncontrado;
                    Console.WriteLine("\n\nMotorista encontrado!\n");
                    Thread.Sleep(2000);


                    Random rnd = new Random();
                    int rndMotorista = rnd.Next(0, motoristas.Count);
                    ViagemAtiva.Motorista = motoristas[rndMotorista];
                    Console.Write($"Seu motorista será: {motoristas[rndMotorista].Nome}\nCarro: {motoristas[rndMotorista].Carro.Modelo}\nPlaca: {motoristas[rndMotorista].Carro.Placa}\nCor: {motoristas[rndMotorista].Carro.Cor}\n\n");
                    Thread.Sleep(2000);

                    ViagemAtiva.StatusViagem = EStatusViagem.MotoristaACaminho;
                    Console.Write("Motorista a caminho.");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);


                    ViagemAtiva.StatusViagem = EStatusViagem.MotoristaChegouAOrigem;
                    Console.Write("\n\nO motorista chegou ao destino!");
                    Thread.Sleep(5000);

                    ViagemAtiva.StatusViagem = EStatusViagem.ViagemEmProgresso;
                    Console.Write("\n\nViagem em progresso.");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);

                    ViagemAtiva.StatusViagem = EStatusViagem.PassageiroChegouAoDestino;
                    Console.Write("\n\nVocê chegou ao seu destino!");
                    Thread.Sleep(2000);

                    Console.Write("\n\nAvalie seu motorista!\n\n1 - Muito insatisfeito\n2 - Insatisfeito\n3 - Neutro\n4 - Satisfeito\n5 - Muito satisfeito\n\nSua escolha: ");
                    string avaliacao = Console.ReadLine();

                    while (avaliacao != "1" && avaliacao != "2" && avaliacao != "3" && avaliacao != "4" && avaliacao != "5")
                    {
                        Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Muito insatisfeito\n2 - Insatisfeito\n3 - Neutro\n4 - Satisfeito\n5 - Muito satisfeito\n\nSua escolha: ");
                        avaliacao = Console.ReadLine();
                    }
                    Console.Clear();
                    cabecalho.Cabecalho("Flash Drive");
                    Console.Write("Obrigado por viajar conosco!\n\n");

                    sair = true;
                                        
                }

            } while (!sair);
            
        }

        public void AdicionarMetodoPagamento()
        {
            
            bool sair = false;
            CabecalhoDivisorias cabecalho = new CabecalhoDivisorias();  

            do
            {
                Console.Clear();
                cabecalho.Cabecalho("Método de Pagamento");
                Console.Write("Qual método de pagamento gostaria de adicionar?\n\n1 - Débito\n2 - Crédito\n\nSua escolha: ");
                string escolha = Console.ReadLine();

                while (escolha != "1" && escolha != "2")
                {
                    Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Débito\n2 - Crédito\n\nSua escolha: ");
                    escolha = Console.ReadLine();
                }

                
                if (escolha == "1")
                {
                    Console.Clear();
                    cabecalho.Cabecalho("Método de Pagamento");
                    Console.WriteLine("Método selecionado: Débito.\n\n");

                    Debito debito = new Debito();

                    Console.Write("Insira o nome do titular do cartão: ");
                    debito.NomeTitular = Console.ReadLine();

                    while (String.IsNullOrWhiteSpace(debito.NomeTitular))
                    {
                        Console.Write("Nome inválido. Tente novamente: ");
                        debito.NomeTitular = Console.ReadLine();
                    }


                    Console.Write("Insira o número do cartão: ");
                    debito.Numero = Console.ReadLine();

                    while (!double.TryParse(debito.Numero, out double aux))
                    {
                        Console.Write("Número inválido. Tente novamente: ");
                        debito.Numero = Console.ReadLine();
                    }


                    Console.Write("Insira o ano de validade do cartão: ");
                    debito.Validade = Console.ReadLine();

                    while (!int.TryParse(debito.Validade, out int aux))
                    {
                        Console.Write("Ano inválido. Tente novamente: ");
                        debito.Validade = Console.ReadLine();
                    }

                    Console.Write("Insira o CVV do cartão: ");
                    debito.CVV = Console.ReadLine();

                    while (!int.TryParse(debito.CVV, out int aux) || debito.CVV.Length > 3)
                    {
                        Console.Write("CVV inválido. Tente novamente: ");
                        debito.CVV = Console.ReadLine();
                    }


                    Console.Write("Informe o saldo do cartão: ");
                    bool valido = double.TryParse(Console.ReadLine(), out debito.Saldo);

                    while (!valido)
                    {
                        Console.Write("Saldo inválido. Tente novamente: ");
                        valido = double.TryParse(Console.ReadLine(), out debito.Saldo);
                    }   

                    Console.Write("Informe um nome para o método de pagamento: ");
                    debito.NomeMetodo = Console.ReadLine();

                    while (String.IsNullOrWhiteSpace(debito.NomeMetodo))
                    {
                        Console.Write("Nome inválido. Tente novamente: ");
                        debito.NomeMetodo = Console.ReadLine();
                    }

                    Console.Clear();
                    cabecalho.Cabecalho("Método de Pagamento");
                    Console.Write($"DADOS:\n\n" +
                                  $"Nome do Titular: {debito.NomeTitular}\n" +
                                  $"Número do Cartão: {debito.Numero}\n" +
                                  $"Validade do Cartão: {debito.Validade}\n" +
                                  $"CVV: {debito.CVV}\n" +
                                  $"Saldo disponível: {debito.Saldo}\n" +
                                  $"Nome do método: {debito.NomeMetodo}\n\n");

                    Console.Write("Confirmar dados?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                    escolha = Console.ReadLine();

                    while (escolha != "1" && escolha != "2")
                    {
                        Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Débito\n2 - Crédito\n\nSua escolha: ");
                        escolha = Console.ReadLine();
                    }

                    if (escolha == "1")
                    {
                        pagamentos.Add(debito);
                        sair = true;
                    }
                    else
                    {
                        Console.Write("\n\nCancelar adição do método de pagamento?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                        escolha = Console.ReadLine();

                        while (escolha != "1" && escolha != "2")
                        {
                            Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                            escolha = Console.ReadLine();
                        }

                        if(escolha == "1") 
                        {
                            Console.Clear();
                            cabecalho.Cabecalho("Flash Drive");                            
                            break; 
                        } 
                        
                        else
                        {
                            sair = false;
                        }


                    }

                }
                else
                {
                    Console.Clear();
                    cabecalho.Cabecalho("Método de Pagamento");
                    Console.WriteLine("Método selecionado: Crédito.\n\n");

                    Credito credito = new Credito();

                    Console.Write("Insira o nome do titular do cartão: ");
                    credito.NomeTitular = Console.ReadLine();

                    while (String.IsNullOrWhiteSpace(credito.NomeTitular))
                    {
                        Console.Write("Nome inválido. Tente novamente: ");
                        credito.NomeTitular = Console.ReadLine();
                    }


                    Console.Write("Insira o número do cartão: ");
                    credito.Numero = Console.ReadLine();

                    while (!double.TryParse(credito.Numero, out double aux))
                    {
                        Console.Write("Número inválido. Tente novamente: ");
                        credito.Numero = Console.ReadLine();
                    }


                    Console.Write("Insira o ano de validade do cartão: ");
                    credito.Validade = Console.ReadLine();

                    while (!int.TryParse(credito.Validade, out int aux))
                    {
                        Console.Write("Ano inválido. Tente novamente: ");
                        credito.Validade = Console.ReadLine();
                    }

                    Console.Write("Insira o CVV do cartão: ");
                    credito.CVV = Console.ReadLine();

                    while (!int.TryParse(credito.CVV, out int aux) || credito.CVV.Length > 3)
                    {
                        Console.Write("CVV inválido. Tente novamente: ");
                        credito.CVV = Console.ReadLine();
                    }


                    Console.Write("Informe o limite do cartão: ");
                    bool valido = double.TryParse(Console.ReadLine(), out credito.Limite);

                    while (!valido)
                    {
                        Console.Write("Saldo inválido. Tente novamente: ");
                        valido = double.TryParse(Console.ReadLine(), out credito.Limite);
                    }   

                    Console.Write("Informe um nome para o método de pagamento: ");
                    credito.NomeMetodo = Console.ReadLine();

                    while (String.IsNullOrWhiteSpace(credito.NomeMetodo))
                    {
                        Console.Write("Nome inválido. Tente novamente: ");
                        credito.NomeMetodo = Console.ReadLine();
                    }

                    Console.Clear();
                    cabecalho.Cabecalho("Método de Pagamento");
                    Console.Write($"DADOS:\n\n" +
                                  $"Nome do Titular: {credito.NomeTitular}\n" +
                                  $"Número do Cartão: {credito.Numero}\n" +
                                  $"Validade do Cartão: {credito.Validade}\n" +
                                  $"CVV: {credito.CVV}\n" +
                                  $"Limite disponível: {credito.Limite}\n" +
                                  $"Nome do método: {credito.NomeMetodo}\n\n");

                    Console.Write("Confirmar dados?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                    escolha = Console.ReadLine();

                    while (escolha != "1" && escolha != "2")
                    {
                        Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Débito\n2 - Crédito\n\nSua escolha: ");
                        escolha = Console.ReadLine();
                    }

                    if (escolha == "1")
                    {
                        pagamentos.Add(credito);
                        sair = true;
                    }
                    else
                    {
                        Console.Write("\n\nCancelar adição do método de pagamento?\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                        escolha = Console.ReadLine();

                        while (escolha != "1" && escolha != "2")
                        {
                            Console.Write("\nOpção inválida. Tente novamente:\n\n1 - Sim\n2 - Não\n\nSua escolha: ");
                            escolha = Console.ReadLine();
                        }

                        if (escolha == "1") 
                        {
                            Console.Clear();
                            cabecalho.Cabecalho("Flash Drive");
                            break; 
                        }

                        else
                        {
                            sair = false;
                        }


                    }
                }

                Console.Clear();
                cabecalho.Cabecalho("Flash Drive");
            } while(!sair);
        }
    }
}
