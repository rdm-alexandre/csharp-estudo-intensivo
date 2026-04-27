namespace dia2_c_Intermediario
{
	public class Linq
{
	public static void Demonstrar()
	{
		Console.WriteLine("\n\n" + new string('=', 50));
		Console.WriteLine("FILTROS COM LINQ");
		Console.WriteLine(new string('=', 50));
		var usuarios = new List<User>
		{
			new User("Lewis", 22, "73198444004", "Pradopolis", "Desenvolvedor"),
			new User("Jorge", 23, "92722634090", "Pradopolis", "Designer"),
			new User("Ana", 21, "12083212002", "Pradopolis", "Gerente"),
			new User("Camilo", 20, "82010651073", "Pradopolis", "Desenvolvedor"),
			new User("Junim", 18, "29006045080", "Pradopolis", "Estagiario"),
			new User("Maria", 25, "45678901234", "São Paulo", "Desenvolvedor"),
			new User("Carlos", 19, "56789012345", "Rio de Janeiro", "Designer"),
		};
		
		// ExemplosWhere(usuarios);
		// ExemplosSelect(usuarios);
		// ExemplosOrderBy(usuarios);
		// ExemplosFirst(usuarios);
		// ExemplosAgregacoes(usuarios);
		// ExemplosDistinct(usuarios);
		// ExemplosGroupBy(usuarios);
		// ExemplosPaginacao(usuarios);
		// ExemplosAnyAll(usuarios);
	}
	private static void ExemplosWhere(List<User> usuarios)
	{
		Console.WriteLine("\n=== WHERE - FILTRAR DADOS ===");

		// Exemplo 1: Filtrar desenvolvedores
		Console.WriteLine("\nTodos os desenvolvedores");
		var desenvolvedores = usuarios.Where(u => u.Cargo == "Desenvolvedor").ToList();
		ExibirUsuarios(desenvolvedores);

		// Exemplo 2: Filtrar maiores de 21 anos
		Console.WriteLine("\nUsuários maiores de 21 anos");
		var maioresDe21 = usuarios.Where(u => u.Idade > 21).ToList();
		ExibirUsuarios(maioresDe21);

		// Exemplo 3: Múltiplas condições (AND)
		Console.WriteLine("\nDesenvolvedores maiores de 20 anos");
		var desenvolvedoresVelhos = usuarios
			.Where(u => u.Cargo == "Desenvolvedor" && u.Idade > 20)
			.ToList();
		ExibirUsuarios(desenvolvedoresVelhos);
	}
	
	private static void ExemplosSelect(List<User> usuarios)
	{
		Console.WriteLine("\nSELECT - PROJETAR/TRANSFORMAR DADOS ===");

		// Exemplo 1: Selecionar apenas nomes
		Console.WriteLine("\nApenas nomes");
		var nomes = usuarios.Select(u => u.Nome).ToList();
		Console.WriteLine(string.Join(", ", nomes));

		// Exemplo 2: Selecionar tupla com nome e cargo
		Console.WriteLine("\nNome e Cargo");
		var nomesCaros = usuarios
			.Select(u => new { u.Nome, u.Cargo })
			.ToList();
		foreach (var item in nomesCaros)
		{
			Console.WriteLine($"  • {item.Nome} - {item.Cargo}");
		}

		// Exemplo 4: Select com enumeração (índice)
		Console.WriteLine("\nCom índice (posição)");
		var usuariosComIndice = usuarios
			.Select((u, indice) => $"{indice + 1}. {u.Nome}")
			.ToList();
		foreach (var item in usuariosComIndice)
		{
			Console.WriteLine($"  • {item}");
		}

		// Exemplo 5: Criar novo objeto
		Console.WriteLine("\nCriar objetos anônimos com transformação");
		var resumoUsuarios = usuarios
			.Select(u => new
			{
				NomeCompleto = u.Nome.ToUpper(),
				Categoria = u.Idade < 20 ? "Juniores" : "Plenos",
				PodeGerenciar = u.Cargo == "Gerente" || u.Cargo == "Designer"
			})
			.ToList();
		foreach (var resumo in resumoUsuarios)
		{
			Console.WriteLine($"  • {resumo.NomeCompleto} - {resumo.Categoria} - Gerencia: {resumo.PodeGerenciar}");
		}
	}
	
	private static void ExemplosOrderBy(List<User> usuarios)
	{
		Console.WriteLine("\n=== ORDERBY / ORDERBYDESCENDING - ORDENAR ===");

		//Ordenar por idade crescente
		Console.WriteLine("\nOrdenado por idade (crescente)");
		var porIdade = usuarios.OrderBy(u => u.Idade).ToList();
		ExibirUsuarios(porIdade);

		// Ordenar por idade decrescente
		Console.WriteLine("\nOrdenado por idade (decrescente)");
		var porIdadeDesc = usuarios.OrderByDescending(u => u.Idade).ToList();
		ExibirUsuarios(porIdadeDesc);

		// Ordenar por nome (alfabético)
		Console.WriteLine("\nOrdenado por nome (A-Z)");
		var porNome = usuarios.OrderBy(u => u.Nome).ToList();
		ExibirUsuarios(porNome);

		// Ordenação múltipla (ThenBy)
		Console.WriteLine("\n Ordenado por Cargo, depois por Idade");
		var ordenacaoMultipla = usuarios
			.OrderBy(u => u.Cargo)
			.ThenByDescending(u => u.Idade)
			.ToList();
		ExibirUsuarios(ordenacaoMultipla);

		// Ordenação com Where combinado
		Console.WriteLine("\n Desenvolvedores ordenados por idade (decrescente)");
		var desenvolvedoresOrdenados = usuarios
			.Where(u => u.Cargo == "Desenvolvedor")
			.OrderByDescending(u => u.Idade)
			.ToList();
		ExibirUsuarios(desenvolvedoresOrdenados);
	}
	
	private static void ExemplosFirst(List<User> usuarios)
	{
		Console.WriteLine("\n=== FIRST, LAST, FIRSTORDEFAULT, SINGLE ===");

		// Primeiro elemento
		Console.WriteLine("\n Primeiro usuário da lista");
		var primeiro = usuarios.First();
		Console.WriteLine($"  ✓ {primeiro.Nome}");

		// Último elemento
		Console.WriteLine("\n Último usuário da lista");
		var ultimo = usuarios.Last();
		Console.WriteLine($"  ✓ {ultimo.Nome}");

		// First com condição
		Console.WriteLine("\n Primeiro desenvolvedor");
		var primeiroDev = usuarios.First(u => u.Cargo == "Desenvolvedor");
		ExibirUsuario(primeiroDev);

		// FirstOrDefault (seguro - não lança exceção)
		Console.WriteLine("\n FirstOrDefault - usuário de 'Brasília' (seguro)");
		var usuarioBrasilia = usuarios.FirstOrDefault(u => u.Cidade == "Brasília");
		if (usuarioBrasilia != null)
			ExibirUsuario(usuarioBrasilia);
		else
			Console.WriteLine("  ⚠️ Nenhum usuário encontrado em Brasília");

		// Single (retorna apenas um, lança exceção se houver mais de um)
		Console.WriteLine("\n Single com condição específica");
		var usuariosComCPF = usuarios.Where(u => u.CPF == "45678901234").ToList();
		if (usuariosComCPF.Count == 1)
		{
			var unico = usuarios.Single(u => u.CPF == "45678901234");
			Console.WriteLine($"  ✓ Usuário único encontrado: {unico.Nome}");
		}
	}
	
	private static void ExemplosAgregacoes(List<User> usuarios)
	{
		Console.WriteLine("\n=== COUNT, SUM, AVERAGE, MIN, MAX - AGREGAÇÕES ===");

		// Count - contar elementos
		Console.WriteLine("\n Total de usuários");
		var total = usuarios.Count();
		Console.WriteLine($"  ✓ {total} usuários no total");

		// Count com condição
		Console.WriteLine("\n Total de desenvolvedores");
		var totalDevs = usuarios.Count(u => u.Cargo == "Desenvolvedor");
		Console.WriteLine($"  ✓ {totalDevs} desenvolvedores");

		// Average - média
		Console.WriteLine("\n Idade média dos usuários");
		var idadeMedia = usuarios.Average(u => u.Idade);
		Console.WriteLine($"  ✓ Idade média: {idadeMedia:F2} anos");

		// Average com condição
		Console.WriteLine("\n Idade média dos desenvolvedores");
		var idadeMediaDevs = usuarios
			.Where(u => u.Cargo == "Desenvolvedor")
			.Average(u => u.Idade);
		Console.WriteLine($"  ✓ Idade média dos devs: {idadeMediaDevs:F2} anos");

		// Min e Max
		Console.WriteLine("\n Idade mínima e máxima");
		var idadeMinima = usuarios.Min(u => u.Idade);
		var idadeMaxima = usuarios.Max(u => u.Idade);
		Console.WriteLine($"  ✓ Mínima: {idadeMinima} anos | Máxima: {idadeMaxima} anos");

		// Sum (somatória)
		Console.WriteLine("\n Soma de todas as idades");
		var somaIdades = usuarios.Sum(u => u.Idade);
		Console.WriteLine($"  ✓ Total de anos: {somaIdades}");
	}
	
	private static void ExemplosDistinct(List<User> usuarios)
	{
		Console.WriteLine("\n=== DISTINCT - REMOVER DUPLICATAS ===");

		// Cargos únicos
		Console.WriteLine("\n Todos os cargos únicos");
		var cargosUnicos = usuarios.Select(u => u.Cargo).Distinct().ToList();
		Console.WriteLine($"  ✓ Cargos: {string.Join(", ", cargosUnicos)}");

		// Cidades únicas
		Console.WriteLine("\n Todas as cidades únicas");
		var cidadesUnicas = usuarios.Select(u => u.Cidade).Distinct().ToList();
		Console.WriteLine($"  ✓ Cidades: {string.Join(", ", cidadesUnicas)}");

		// Contando valores distintos
		Console.WriteLine("\n Quantidade de cargos diferentes");
		var quantidadeCargos = usuarios.Select(u => u.Cargo).Distinct().Count();
		Console.WriteLine($"  ✓ {quantidadeCargos} tipos de cargo");
	}
	
	private static void ExemplosGroupBy(List<User> usuarios)
	{
		Console.WriteLine("\n=== GROUPBY - AGRUPAR DADOS ===");

		// Agrupar por cargo
		Console.WriteLine("\n Usuários agrupados por Cargo");
		var porCargo = usuarios.GroupBy(u => u.Cargo);
		foreach (var grupo in porCargo)
		{
			Console.WriteLine($"\n  📂 {grupo.Key} ({grupo.Count()} usuários):");
			foreach (var usuario in grupo)
			{
				Console.WriteLine($"    • {usuario.Nome} - {usuario.Idade} anos");
			}
		}

		// Agrupar por faixa etária
		Console.WriteLine("\n Usuários agrupados por faixa etária");
		var porFaixaEtaria = usuarios.GroupBy(u => 
			u.Idade < 20 ? "Menores de 20" : 
			u.Idade < 23 ? "20-22" : 
			"23+"
		);
		foreach (var grupo in porFaixaEtaria)
		{
			Console.WriteLine($"\n  📂 {grupo.Key}:");
			foreach (var usuario in grupo)
			{
				Console.WriteLine($"    • {usuario.Nome} - {usuario.Idade} anos");
			}
		}

		// Agrupar por cidade com estatísticas
		Console.WriteLine("\n Estatísticas por Cidade");
		var porCidade = usuarios.GroupBy(u => u.Cidade);
		foreach (var grupo in porCidade)
		{
			Console.WriteLine($"\n  📂 {grupo.Key}:");
			Console.WriteLine($"    • Total: {grupo.Count()}");
			Console.WriteLine($"    • Idade média: {grupo.Average(u => u.Idade):F2}");
			Console.WriteLine($"    • Idade mínima: {grupo.Min(u => u.Idade)}");
			Console.WriteLine($"    • Idade máxima: {grupo.Max(u => u.Idade)}");
		}
	}
	
	private static void ExemplosPaginacao(List<User> usuarios)
	{
		Console.WriteLine("\n=== SKIP E TAKE - PAGINAÇÃO ===");

		// Take - pegar os primeiros N
		Console.WriteLine("\n Primeiros 3 usuários");
		var primeiros3 = usuarios.Take(3).ToList();
		ExibirUsuarios(primeiros3);

		// Skip - pular N e pegar o resto
		Console.WriteLine("\n Pular os 2 primeiros e pegar o resto");
		var apartirDo3 = usuarios.Skip(2).ToList();
		ExibirUsuarios(apartirDo3);

		// Paginação (página 1 com 2 itens por página)
		Console.WriteLine("\n Paginação - Página 1 (2 itens por página)");
		int paginaAtual = 0;
		int itensPorPagina = 2;
		var pagina1 = usuarios
			.OrderBy(u => u.Nome)
			.Skip(paginaAtual * itensPorPagina)
			.Take(itensPorPagina)
			.ToList();
		ExibirUsuarios(pagina1);

		// Paginação - Página 2
		Console.WriteLine("\n Paginação - Página 2 (2 itens por página)");
		paginaAtual = 1;
		var pagina2 = usuarios
			.OrderBy(u => u.Nome)
			.Skip(paginaAtual * itensPorPagina)
			.Take(itensPorPagina)
			.ToList();
		ExibirUsuarios(pagina2);
	}
	
	private static void ExemplosAnyAll(List<User> usuarios)
	{
		Console.WriteLine("\n=== ANY E ALL - VERIFICAÇÕES BOOLEANAS ===");

		// Any - existe algum?
		Console.WriteLine("\n Existe algum desenvolvedor?");
		bool temDesenvolvedores = usuarios.Any(u => u.Cargo == "Desenvolvedor");
		Console.WriteLine($"  ✓ {(temDesenvolvedores ? "Sim" : "Não")}");

		// Any - lista está vazia?
		Console.WriteLine("\n A lista está vazia?");
		bool estaVazia = !usuarios.Any();
		Console.WriteLine($"  ✓ {(estaVazia ? "Sim" : "Não")}");

		// Any sem argumento
		Console.WriteLine("\n Lista contém elementos?");
		bool temElementos = usuarios.Any();
		Console.WriteLine($"  ✓ {(temElementos ? "Sim, contém" : "Não, está vazia")}");

		// All - todos satisfazem a condição?
		Console.WriteLine("\n Exemplo 4: Todos os usuários têm mais de 17 anos?");
		bool todosComMais17 = usuarios.All(u => u.Idade > 17);
		Console.WriteLine($"  ✓ {(todosComMais17 ? "Sim" : "Não")}");

		// All - todos são de Pradopolis?
		Console.WriteLine("\n Todos os usuários são de Pradopolis?");
		bool todosDepadopolis = usuarios.All(u => u.Cidade == "Pradopolis");
		Console.WriteLine($"  ✓ {(todosDepadopolis ? "Sim" : "Não")}");

		// Any com count
		Console.WriteLine("\n Existe algum usuário com mais de 24 anos?");
		bool existe24plus = usuarios.Any(u => u.Idade > 24);
		Console.WriteLine($"  ✓ {(existe24plus ? "Sim" : "Não")}");
	}
	
	private static void ExibirUsuario(User usuario)
	{
		Console.WriteLine($"  ✓ Nome: {usuario.Nome}");
		Console.WriteLine($"    Idade: {usuario.Idade}");
		Console.WriteLine($"    CPF: {usuario.CPF}");
		Console.WriteLine($"    Cidade: {usuario.Cidade}");
		Console.WriteLine($"    Cargo: {usuario.Cargo}");
	}
	
	private static void ExibirUsuarios(List<User> usuarios)
	{
		foreach (var usuario in usuarios)
		{
			Console.WriteLine($"  • {usuario.Nome} - {usuario.Idade} anos - {usuario.Cargo} ({usuario.Cidade})");
		}
	}
}
};

