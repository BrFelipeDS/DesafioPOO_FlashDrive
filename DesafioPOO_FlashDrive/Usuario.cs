using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioPOO_FlashDrive
{
    public abstract class Usuario
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Contato { get; set; }


        public string Logar(string email, string senha)
        {
            if(email == Email && senha == Senha)
            {
                return "Usuário logado com sucesso!";
            }
            else
            {
                return "Usuário ou senha inválidos";
            }
        }

        public void Cadastrar()
        {
            Console.Write("Insira seu nome: ");
            Nome = Console.ReadLine();
            
            Console.Write("Insira seu email: ");
            Email = Console.ReadLine();
            
            Console.Write("Insira seu contato ((xx) xxxxx-xxxx): ");
            Contato = Console.ReadLine();


            Console.Write("Insira uma senha: ");
            Senha = Console.ReadLine();


            Console.Write("Usuário cadastrado com sucesso!");
            Thread.Sleep(3000);


        }

    }
}
