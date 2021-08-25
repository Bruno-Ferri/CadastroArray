using System;


namespace CadastroEmVetor
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listar();
						break;
					case "2":
						Inserir();
						break;
					case "3":
						Atualizar();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			Console.ReadLine();
        }

        private static void Excluir()
		{
			Console.Write("Digite o id do carro: ");
			int id = int.Parse(Console.ReadLine());

			repositorio.Exclui(id);
		}

        private static void Visualizar()
		{
			Console.Write("Digite o id do carro: ");
			int id = int.Parse(Console.ReadLine());

			var carro = repositorio.RetornaPorId(id);

			Console.WriteLine(carro);
		}

        private static void Atualizar()
		{
			Console.Write("Digite o id do carro: ");
			int id = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo do carro: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o ano: ");
			int entradaAno = int.Parse(Console.ReadLine());


			Carro carro = new Carro(id: id,
										marca: (Marca)entradaMarca,
										titulo: entradaModelo,
										ano: entradaAno);

			repositorio.Atualiza(id, carro);
		}
        private static void Listar()
		{
			Console.WriteLine("Listar carros");

			var lista = repositorio.Listar();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum cadastro.");
				return;
			}

			foreach (var carro in lista)
			{
                var excluido = carro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", carro.retornaId(), carro.retornaModelo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inserir()
		{
			Console.WriteLine("Inserir um novo carro");
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o modelo do carro: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o ano do carro: ");
			int entradaAno = int.Parse(Console.ReadLine());

	

			Carro carro = new Carro(id: repositorio.ProximoId(),
										marca: (Marca)entradaMarca,
										titulo: entradaModelo,
										ano: entradaAno);

			repositorio.Insere(carro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar carros");
			Console.WriteLine("2- Inserir");
			Console.WriteLine("3- Atualizar");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar carro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
        }
    }
}
