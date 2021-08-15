using System;

namespace DIO.Catalogos
{
    class Program
    {
        static CatalogoRepositorio repositorio = new CatalogoRepositorio();
		static bool opcaoFilme = false;
        static void Main(string[] args)
        {
			Console.WriteLine("Digite F para FILMES ou S para SÉRIES!");
			// string opcaoFilme = Console.ReadLine().ToUpper();
			
			if (Console.ReadLine().ToUpper() == "F"){
				opcaoFilme = true;
			}
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			if(!opcaoFilme){
				Console.Write("Digite o id da série: ");
			}else
			{
				Console.Write("Digite o id do filme: ");
			}
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			if(!opcaoFilme){
				Console.Write("Digite o id da série: ");
			}else
			{
				Console.Write("Digite o id do filme: ");
			}
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			if(!opcaoFilme){
				Console.Write("Digite o id da série: ");
			}else
			{
				Console.Write("Digite o id do filme: ");
			}
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			// foreach (int i in Enum.GetValues(typeof(Genero)))
			// {
			// 	Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			// }
			// Console.Write("Digite o gênero entre as opções acima: ");
			// int entradaGenero = int.Parse(Console.ReadLine());

			// Console.Write("Digite o Título da Série: ");
			// string entradaTitulo = Console.ReadLine();

			// Console.Write("Digite o Ano de Início da Série: ");
			// int entradaAno = int.Parse(Console.ReadLine());

			// Console.Write("Digite a Descrição da Série: ");
			// string entradaDescricao = Console.ReadLine();

			Catalogo atualizaSerie = InsereAtualiza(indiceSerie, opcaoFilme);
			// Serie atualizaSerie = new Serie(id: indiceSerie,
			// 							genero: (Genero)entradaGenero,
			// 							titulo: entradaTitulo,
			// 							ano: entradaAno,
			// 							descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			if (!opcaoFilme){
				Console.WriteLine("Listar séries");
			}
			else
			{
				Console.WriteLine("Listar filmes");
			}

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nada Cadastrado.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			if(!opcaoFilme){
				Console.WriteLine("Inserir nova série");
			}else{
				Console.WriteLine("Inserir novo Filme");
			}

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			// foreach (int i in Enum.GetValues(typeof(Genero)))
			// {
			// 	Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			// }
			// Console.Write("Digite o gênero entre as opções acima: ");
			// int entradaGenero = int.Parse(Console.ReadLine());

			// Console.Write("Digite o Título da Série: ");
			// string entradaTitulo = Console.ReadLine();

			// Console.Write("Digite o Ano de Início da Série: ");
			// int entradaAno = int.Parse(Console.ReadLine());

			// Console.Write("Digite a Descrição da Série: ");
			// string entradaDescricao = Console.ReadLine();

			Catalogo novaSerie = InsereAtualiza(repositorio.ProximoId(), opcaoFilme);	
			// Serie novaSerie = new Serie(id: repositorio.ProximoId(),
			// 							genero: (Genero)entradaGenero,
			// 							titulo: entradaTitulo,
			// 							ano: entradaAno,
			// 							descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar");
			Console.WriteLine("2- Inserir");
			Console.WriteLine("3- Atualizar");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static Catalogo InsereAtualiza(int id, bool opcaoFilme){
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			if (!opcaoFilme)
			{
				Console.Write("Digite o Título da Série: ");
			}else{
				Console.Write("Digite o Título do Filme: ");	
			}
			string entradaTitulo = Console.ReadLine();

			if (!opcaoFilme)
			{
				Console.Write("Digite o Ano de Início da Série: ");
			}else{
				Console.Write("Digite o Ano de Início do Filme: ");
			}
			int entradaAno = int.Parse(Console.ReadLine());

			if (!opcaoFilme)
			{
				Console.Write("Digite a Descrição da Série: ");
			}else{
				Console.Write("Digite a Descrição do Filme: ");
			}
			string entradaDescricao = Console.ReadLine();

			return new Catalogo(id: id,
							genero: (Genero)entradaGenero,
							titulo: entradaTitulo,
							ano: entradaAno,
							descricao: entradaDescricao,
							filme: opcaoFilme);
		}
    }
}
