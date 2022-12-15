using System.Reflection.Metadata.Ecma335;

namespace BancoApp
{

    public class Program
    {

        static void MenuInicial()
        {

            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Sair Do Programa");
        }

        static void RegistrasUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string>senhas)
        {
            Console.WriteLine("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.WriteLine("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Crie sua senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }


        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for(int i=0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titulares = {titulares[i]} | Saldo = {saldos[i]}");
            }
        }


        public static void Main(string[] args)
        {

            Console.WriteLine("antes de começar a usar, vamos configurar alguns valores: ");
            Console.Write("Digite a quantidade de usuários: ");
            int qtdeUsuarios = int.Parse(Console.ReadLine());


            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();


            int opcaodesejada;

            do
            {
                MenuInicial();
                opcaodesejada = int.Parse(Console.ReadLine());

                switch (opcaodesejada)
                {

                    case 0:
                        Console.WriteLine("Encerrando programa.");
                        break;

                    case 1:
                        RegistrasUsuario(cpfs, titulares, saldos,senhas);
                        break;
                    case 3: ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                }

            } while (opcaodesejada != 0);








            /*
            Console.WriteLine("Olá, Bem vindo ao BancoApp.");
            MenuInicial();
            Console.WriteLine();
            Console.Write("Insira a opção desejada: ");
            string opcaoDesejada = Console.ReadLine();

            while (opcaoDesejada != "1" && opcaoDesejada != "2" && opcaoDesejada != "3" && opcaoDesejada != "4" && opcaoDesejada != "5"
                && opcaoDesejada != "6" && opcaoDesejada != "0")
            {

                Console.WriteLine();
                Console.WriteLine("Parece que você digitou um valor inválido ");
                Console.WriteLine();
                MenuInicial();
                Console.Write("Insira um dos valores acima: ");
                opcaoDesejada = Console.ReadLine();

            };

            if(opcaoDesejada == "1")
            {




            }*/

        }

        
    }
}