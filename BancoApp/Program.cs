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

            Console.Write("Bem vindo ao Banco internacional, selecione uma das opções acima: ");
        }

        static void RegistrasUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.WriteLine("Digite o cpf: ");

            string cpfregistro = Console.ReadLine();

            if (cpfs.Contains(cpfregistro))
            {
                do
                {
                    Console.Write("CPF ja cadastrado, digite um válido: ");
                    cpfregistro = Console.ReadLine();
                }  while(cpfs.Contains(cpfregistro));         
                

            }
           
              cpfs.Add(cpfregistro);

           
            Console.WriteLine("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Crie sua senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }


        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titulares = {titulares[i]} | Saldo = {saldos[i]:f2}");
            }
        }

        static void NumeroDeusuariosBanco(List<string> cpfs, List<double> saldos)
        {
            int numerocpfs = cpfs.Count;
            Console.WriteLine($"A quantidade de usuários no banco é: {numerocpfs}");
            double saldototal = 0;

            for (int i = 0; i < cpfs.Count; i++)
            {
                saldototal += saldos[i];
            }
            Console.WriteLine($"Dinheiro total no banco = R${saldototal:f2}");

        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.WriteLine("Digite o cpf que deseja excluir: ");
            string cpfparaexcluir = Console.ReadLine();
            int u = cpfs.IndexOf(cpfparaexcluir);


            if (saldos[u]!=0) {

                Console.WriteLine("o saldo da conta precisa estar zerado pra realizar o cancelamento da conta.");
            
            }
            else
            {
                if (cpfs.Contains(cpfparaexcluir))
                {
                    Console.Write("Digite sua senha para confirmar a remoção da sua conta: ");
                    Console.WriteLine();

                    string confirmarsenha = Console.ReadLine();
                    if (senhas.Contains(confirmarsenha))
                    {

                        Console.WriteLine("Conta Cancelada Com Sucesso");
                        Console.WriteLine();
                        cpfs.Remove(cpfs[u]);
                        senhas.Remove(senhas[u]);
                        titulares.Remove(titulares[u]);
                        saldos.Remove(saldos[u]);

                    }
                    else
                    {
                        Console.WriteLine("Senha incorreta tente novamente");
                        do
                        {
                            Console.Write("Digite sua senha para confirmar a remoção da sua conta: ");
                            Console.WriteLine();

                            confirmarsenha = Console.ReadLine();
                        } while (!senhas.Contains(confirmarsenha));

                        cpfs.Remove(cpfs[u]);
                        senhas.Remove(senhas[u]);
                        titulares.Remove(titulares[u]);
                        saldos.Remove(saldos[u]);
                        Console.WriteLine("Conta Cancelada Com Sucesso");
                    }

                };

            }
            

        }

        static void DetalhesUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.Write("Digite o cpf que voce que consultar: ");
            string consulta = Console.ReadLine();

            if (cpfs.Contains(consulta))
            {
                Console.Write("Digite sua senha para confirmar o acesso aos detalhes: ");
                Console.WriteLine();

                string confirmarsenha = Console.ReadLine();
                if (senhas.Contains(confirmarsenha))
                {
                    int u = cpfs.IndexOf(consulta);

                    Console.WriteLine($"CPF = {cpfs[u]} | Titulares = {titulares[u]} | Saldo = {saldos[u]:f2} | Senha = {senhas[u]}");

                }
                else
                {
                    Console.WriteLine("Senha incorreta tente novamente");
                    do
                    {
                        Console.Write("Digite sua senha para confirmar o acesso aos detalhes: ");
                        Console.WriteLine();

                        confirmarsenha = Console.ReadLine();
                    } while (!senhas.Contains(confirmarsenha));
                    int u = cpfs.IndexOf(consulta);

                    Console.WriteLine($"CPF = {cpfs[u]} | Titulares = {titulares[u]} | Saldo = {saldos[u]:f2} | Senha = {senhas[u]}");

                }

            };

        }

        static void ManipularConta(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {

            Console.Write("Digite o cpf da sua conta para acessa-la: ");
            string acessocpf = Console.ReadLine();
            string senhaacesso;

            if (cpfs.Contains(acessocpf))
            {

                Console.Write("Digite sua senha para o acesso: ");
                senhaacesso = Console.ReadLine();



                while (!senhas.Contains(senhaacesso))
                {

                    Console.WriteLine("senha errada, digite novamente: ");
                    senhaacesso = Console.ReadLine();
                };

                int u = cpfs.IndexOf(acessocpf);

                Console.WriteLine($"CPF = {cpfs[u]} \nTitulares = {titulares[u]}\nSaldo = {saldos[u]:f2}\n");

                string escolhaoquefazer;
                do
                {
                    Console.WriteLine("1 - Depositar dinheiro");
                    Console.WriteLine("2 - Transferir Dinheiro");
                    Console.WriteLine("3 - Sacar Dinheiro");
                    Console.WriteLine("0 - Voltar");

                    escolhaoquefazer = Console.ReadLine();


                    switch (escolhaoquefazer)
                    {

                        case "1":
                            Depositar(saldos, cpfs, u);
                            break;
                        case "2":
                            TranferenciaDinheiro(saldos, cpfs, u);
                            break;
                        case "3": SacarDinheiro(saldos, cpfs, u);
                            break;
                        case "0":
                            ;
                            break;

                    }
                } while (escolhaoquefazer != "0");

            }

        }


        static void Depositar(List<double> saldos, List<string> cpfs, int u)
        {
            Console.WriteLine("Valor Minimo para depósito: R$ 50,00");

            double valordeposito = double.Parse(Console.ReadLine());

            if (valordeposito >= 50)
            {
                saldos[u] += valordeposito;
                Console.WriteLine($"Deposito de {valordeposito} feito com sucesso.");
            }
            else
            {
                while (valordeposito < 50)
                {
                    Console.WriteLine("Valor de deposito abaixo do permitido, deposite um valor acima de 50 Reais.");
                    valordeposito = double.Parse(Console.ReadLine());

                }
                Console.WriteLine($"Deposito de {valordeposito} feito com sucesso.");
                saldos[u] += valordeposito;
            }

        }

        static void SacarDinheiro(List<double> saldos, List<string> cpfs, int u)
        {
            
            Console.Write("Digite o valor que deseja sacar: ");

            double valorsaque = double.Parse(Console.ReadLine());

            while (valorsaque <= 0){

                Console.Write("Digite um valor válido: ");
                valorsaque = double.Parse(Console.ReadLine());
            }

            while (valorsaque > saldos[u])
            {
                Console.WriteLine("Valor acima do saldo disponível ");
                Console.Write("Insira um valor Disponível: ");
                valorsaque = double.Parse(Console.ReadLine());
            }

           
            saldos[u]-=valorsaque;
            Console.WriteLine("Saque efetuado com sucesso");
        }


        static void TranferenciaDinheiro(List<double> saldos, List<string> cpfs, int u)
        {


            Console.Write("Digite o valor que você deseja transferir: ");

            double valortransferido = double.Parse(Console.ReadLine());

            while (valortransferido > saldos[u])
            {
                Console.WriteLine("Saldo indisponível para operação.");
                Console.Write("Coloque um valor disponível: ");

                valortransferido = double.Parse(Console.ReadLine());

            }

            Console.Write("Digite o cpf da pessoa a qual deseja enviar o dinheiro: ");
            string pessoarecebedora = Console.ReadLine();

            while (!cpfs.Contains(pessoarecebedora))
            {

                Console.Write("Usuario não encontrado, digite novamente um cpf válido: ");
                pessoarecebedora = Console.ReadLine();
            }

            int j = cpfs.IndexOf(pessoarecebedora);


            saldos[u] -= valortransferido;
            saldos[j] += valortransferido;

            Console.WriteLine("Transferencia Feita com sucesso");




        }



        public static void Main(string[] args)
        {



            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();


            string opcaodesejada;

            do
            {
                MenuInicial();
                opcaodesejada = Console.ReadLine();

                switch (opcaodesejada)
                {
                    case "0":
                        Console.WriteLine();
                        Console.WriteLine("Encerrando programa.");
                        break;
                    case "1":
                        RegistrasUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case "2":
                        DeletarUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case "3":
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case "4":
                        DetalhesUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case "5":
                        NumeroDeusuariosBanco(cpfs,saldos);
                        break;
                    case "6":
                        ManipularConta(cpfs, titulares, saldos, senhas);
                        break;
                }

            } while (opcaodesejada != "0");










        }


    }
}