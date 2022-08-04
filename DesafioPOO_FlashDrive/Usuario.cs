using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //public Usuario Cadastrar()
        //{
            

        //    Console.Write("Insira seu nome: ");
        //}

    }
}
