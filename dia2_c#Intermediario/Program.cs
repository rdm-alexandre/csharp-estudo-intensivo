using System;
using System.Collections.Generic;
using System.Linq;
using dia2_c_Intermediario;

namespace dia2_csharp_Intermediario
{
	class Program
	{
		static void Main(string[] args)
		{
			// ============================================
			// EXEMPLOS DE LINQ - ESTUDO INTENSIVO
			// ============================================
			// LINQ = Language Integrated Query (Consulta Integrada à Linguagem)
			// É uma forma poderosa de consultear e transformar coleções de dados

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

			// ============================================
			// 1. WHERE - FILTRAR DADOS
			// ============================================
			// ExemplosWhere(usuarios);

			// ============================================
			// 2. SELECT - PROJETAR/TRANSFORMAR DADOS
			// ============================================
			// ExemplosSelect(usuarios);

			// ============================================
			// 3. ORDERBY/ORDERBYDESCENDING - ORDENAR
			// ============================================
			// ExemplosOrderBy(usuarios);

			// ============================================
			// 4. FIRST, LAST, SINGLE - OBTER ELEMENTO
			// ============================================
			// ExemplosFirst(usuarios);

			// ============================================
			// 5. COUNT, SUM, AVERAGE - AGREGAÇÕES
			// ============================================
			// ExemplosAgregacoes(usuarios);

			// ============================================
			// 6. DISTINCT - REMOVER DUPLICATAS
			// ============================================
			// ExemplosDistinct(usuarios);

			// ============================================
			// 7. GROUPBY - AGRUPAR DADOS
			// ============================================
			// ExemplosGroupBy(usuarios);

			// ============================================
			// 8. SKIP E TAKE - PAGINAÇÃO
			// ============================================
			// ExemplosPaginacao(usuarios);

			// ============================================
			// 9. ANY E ALL - VERIFICAÇÕES
			// ============================================
			// ExemplosAnyAll(usuarios);

			// ============================================
			// 10. QUERIES COMPLEXAS
			// ============================================
			// ExemplosCompostos(usuarios);

			// Console.WriteLine("\n\n" + new string('=', 50));
			// Console.WriteLine("EXEMPLOS DE NULLABLE TYPES");
			// Console.WriteLine(new string('=', 50));
			// Nullable.Demonstrar();

			Console.WriteLine("\n\n" + new string('=', 50));
			Console.WriteLine("EXEMPLOS DE TRY CATCH");
			Console.WriteLine(new string('=', 50));
			TryCatch.Demonstrar();
		}

		/// <summary>
		/// 1. WHERE - Filtra elementos baseado em uma condição (predicado)
		/// </summary>
		static void ExemplosWhere(List<User> usuarios)
		{
			Console.WriteLine("\n=== 1. WHERE - FILTRAR DADOS ===");

			// Exemplo 1: Filtrar desenvolvedores
			Console.WriteLine("\n📌 Exemplo 1: Todos os desenvolvedores");
			var desenvolvedores = usuarios.Where(u => u.Cargo == "Desenvolvedor").ToList();
			ExibirUsuarios(desenvolvedores);

			// Exemplo 2: Filtrar maiores de 21 anos
			Console.WriteLine("\n📌 Exemplo 2: Usuários maiores de 21 anos");
			var maioresDe21 = usuarios.Where(u => u.Idade > 21).ToList();
			ExibirUsuarios(maioresDe21);

			// Exemplo 3: Múltiplas condições (AND)
			Console.WriteLine("\n📌 Exemplo 3: Desenvolvedores maiores de 20 anos");
			var desenvolvedoresVelhos = usuarios
				.Where(u => u.Cargo == "Desenvolvedor" && u.Idade > 20)
				.ToList();
			ExibirUsuarios(desenvolvedoresVelhos);

			// Exemplo 4: Usando negação (NOT)
			Console.WriteLine("\n📌 Exemplo 4: Usuários que NÃO são Estagiários");
			var naoEstagiarios = usuarios
				.Where(u => u.Cargo != "Estagiario")
				.ToList();
			ExibirUsuarios(naoEstagiarios);

			// Exemplo 5: Filtrar por cidade
			Console.WriteLine("\n📌 Exemplo 5: Usuários de Pradopolis");
			var depradopolis = usuarios
				.Where(u => u.Cidade == "Pradopolis")
				.ToList();
			ExibirUsuarios(depradopolis);
		}

		/// <summary>
		/// 2. SELECT - Transforma/Projeta os dados em um novo formato
		/// </summary>
		static void ExemplosSelect(List<User> usuarios)
		{
			Console.WriteLine("\n=== 2. SELECT - PROJETAR/TRANSFORMAR DADOS ===");

			// Exemplo 1: Selecionar apenas nomes
			Console.WriteLine("\n📌 Exemplo 1: Apenas nomes");
			var nomes = usuarios.Select(u => u.Nome).ToList();
			Console.WriteLine(string.Join(", ", nomes));

			// Exemplo 2: Selecionar tupla com nome e cargo
			Console.WriteLine("\n📌 Exemplo 2: Nome e Cargo");
			var nomesCaros = usuarios
				.Select(u => new { u.Nome, u.Cargo })
				.ToList();
			foreach (var item in nomesCaros)
			{
				Console.WriteLine($"  • {item.Nome} - {item.Cargo}");
			}

			// Exemplo 3: Transformar em strings formatadas
			Console.WriteLine("\n📌 Exemplo 3: Informações formatadas");
			var usuariosFormatados = usuarios
				.Select(u => $"{u.Nome} ({u.Idade} anos) - {u.Cargo}")
				.ToList();
			foreach (var info in usuariosFormatados)
			{
				Console.WriteLine($"  • {info}");
			}

			// Exemplo 4: Select com enumeração (índice)
			Console.WriteLine("\n📌 Exemplo 4: Com índice (posição)");
			var usuariosComIndice = usuarios
				.Select((u, indice) => $"{indice + 1}. {u.Nome}")
				.ToList();
			foreach (var item in usuariosComIndice)
			{
				Console.WriteLine($"  • {item}");
			}

			// Exemplo 5: Criar novo objeto
			Console.WriteLine("\n📌 Exemplo 5: Criar objetos anônimos com transformação");
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

		/// <summary>
		/// 3. ORDERBY / ORDERBYDESCENDING - Ordena elementos
		/// </summary>
		static void ExemplosOrderBy(List<User> usuarios)
		{
			Console.WriteLine("\n=== 3. ORDERBY / ORDERBYDESCENDING - ORDENAR ===");

			// Exemplo 1: Ordenar por idade crescente
			Console.WriteLine("\n📌 Exemplo 1: Ordenado por idade (crescente)");
			var porIdade = usuarios.OrderBy(u => u.Idade).ToList();
			ExibirUsuarios(porIdade);

			// Exemplo 2: Ordenar por idade decrescente
			Console.WriteLine("\n📌 Exemplo 2: Ordenado por idade (decrescente)");
			var porIdadeDesc = usuarios.OrderByDescending(u => u.Idade).ToList();
			ExibirUsuarios(porIdadeDesc);

			// Exemplo 3: Ordenar por nome (alfabético)
			Console.WriteLine("\n📌 Exemplo 3: Ordenado por nome (A-Z)");
			var porNome = usuarios.OrderBy(u => u.Nome).ToList();
			ExibirUsuarios(porNome);

			// Exemplo 4: Ordenação múltipla (ThenBy)
			Console.WriteLine("\n📌 Exemplo 4: Ordenado por Cargo, depois por Idade");
			var ordenacaoMultipla = usuarios
				.OrderBy(u => u.Cargo)
				.ThenByDescending(u => u.Idade)
				.ToList();
			ExibirUsuarios(ordenacaoMultipla);

			// Exemplo 5: Ordenação com Where combinado
			Console.WriteLine("\n📌 Exemplo 5: Desenvolvedores ordenados por idade (decrescente)");
			var desenvolvedoresOrdenados = usuarios
				.Where(u => u.Cargo == "Desenvolvedor")
				.OrderByDescending(u => u.Idade)
				.ToList();
			ExibirUsuarios(desenvolvedoresOrdenados);
		}

		/// <summary>
		/// 4. FIRST, LAST, FIRSTORDEFAULT, SINGLE - Obter elemento específico
		/// </summary>
		static void ExemplosFirst(List<User> usuarios)
		{
			Console.WriteLine("\n=== 4. FIRST, LAST, FIRSTORDEFAULT, SINGLE ===");

			// Exemplo 1: Primeiro elemento
			Console.WriteLine("\n📌 Exemplo 1: Primeiro usuário da lista");
			var primeiro = usuarios.First();
			Console.WriteLine($"  ✓ {primeiro.Nome}");

			// Exemplo 2: Último elemento
			Console.WriteLine("\n📌 Exemplo 2: Último usuário da lista");
			var ultimo = usuarios.Last();
			Console.WriteLine($"  ✓ {ultimo.Nome}");

			// Exemplo 3: First com condição
			Console.WriteLine("\n📌 Exemplo 3: Primeiro desenvolvedor");
			var primeiroDev = usuarios.First(u => u.Cargo == "Desenvolvedor");
			ExibirUsuario(primeiroDev);

			// Exemplo 4: FirstOrDefault (seguro - não lança exceção)
			Console.WriteLine("\n📌 Exemplo 4: FirstOrDefault - usuário de 'Brasília' (seguro)");
			var usuarioBrasilia = usuarios.FirstOrDefault(u => u.Cidade == "Brasília");
			if (usuarioBrasilia != null)
				ExibirUsuario(usuarioBrasilia);
			else
				Console.WriteLine("  ⚠️ Nenhum usuário encontrado em Brasília");

			// Exemplo 5: Single (retorna apenas um, lança exceção se houver mais de um)
			Console.WriteLine("\n📌 Exemplo 5: Single com condição específica");
			var usuariosComCPF = usuarios.Where(u => u.CPF == "45678901234").ToList();
			if (usuariosComCPF.Count == 1)
			{
				var unico = usuarios.Single(u => u.CPF == "45678901234");
				Console.WriteLine($"  ✓ Usuário único encontrado: {unico.Nome}");
			}
		}

		/// <summary>
		/// 5. COUNT, SUM, AVERAGE, MIN, MAX - Agregações
		/// </summary>
		static void ExemplosAgregacoes(List<User> usuarios)
		{
			Console.WriteLine("\n=== 5. COUNT, SUM, AVERAGE, MIN, MAX - AGREGAÇÕES ===");

			// Exemplo 1: Count - contar elementos
			Console.WriteLine("\n📌 Exemplo 1: Total de usuários");
			var total = usuarios.Count();
			Console.WriteLine($"  ✓ {total} usuários no total");

			// Exemplo 2: Count com condição
			Console.WriteLine("\n📌 Exemplo 2: Total de desenvolvedores");
			var totalDevs = usuarios.Count(u => u.Cargo == "Desenvolvedor");
			Console.WriteLine($"  ✓ {totalDevs} desenvolvedores");

			// Exemplo 3: Average - média
			Console.WriteLine("\n📌 Exemplo 3: Idade média dos usuários");
			var idadeMedia = usuarios.Average(u => u.Idade);
			Console.WriteLine($"  ✓ Idade média: {idadeMedia:F2} anos");

			// Exemplo 4: Average com condição
			Console.WriteLine("\n📌 Exemplo 4: Idade média dos desenvolvedores");
			var idadeMediaDevs = usuarios
				.Where(u => u.Cargo == "Desenvolvedor")
				.Average(u => u.Idade);
			Console.WriteLine($"  ✓ Idade média dos devs: {idadeMediaDevs:F2} anos");

			// Exemplo 5: Min e Max
			Console.WriteLine("\n📌 Exemplo 5: Idade mínima e máxima");
			var idadeMinima = usuarios.Min(u => u.Idade);
			var idadeMaxima = usuarios.Max(u => u.Idade);
			Console.WriteLine($"  ✓ Mínima: {idadeMinima} anos | Máxima: {idadeMaxima} anos");

			// Exemplo 6: Sum (somatória)
			Console.WriteLine("\n📌 Exemplo 6: Soma de todas as idades");
			var somaIdades = usuarios.Sum(u => u.Idade);
			Console.WriteLine($"  ✓ Total de anos: {somaIdades}");
		}

		/// <summary>
		/// 6. DISTINCT - Remove elementos duplicados
		/// </summary>
		static void ExemplosDistinct(List<User> usuarios)
		{
			Console.WriteLine("\n=== 6. DISTINCT - REMOVER DUPLICATAS ===");

			// Exemplo 1: Cargos únicos
			Console.WriteLine("\n📌 Exemplo 1: Todos os cargos únicos");
			var cargosUnicos = usuarios.Select(u => u.Cargo).Distinct().ToList();
			Console.WriteLine($"  ✓ Cargos: {string.Join(", ", cargosUnicos)}");

			// Exemplo 2: Cidades únicas
			Console.WriteLine("\n📌 Exemplo 2: Todas as cidades únicas");
			var cidadesUnicas = usuarios.Select(u => u.Cidade).Distinct().ToList();
			Console.WriteLine($"  ✓ Cidades: {string.Join(", ", cidadesUnicas)}");

			// Exemplo 3: Contando valores distintos
			Console.WriteLine("\n📌 Exemplo 3: Quantidade de cargos diferentes");
			var quantidadeCargos = usuarios.Select(u => u.Cargo).Distinct().Count();
			Console.WriteLine($"  ✓ {quantidadeCargos} tipos de cargo");
		}

		/// <summary>
		/// 7. GROUPBY - Agrupa elementos por uma chave
		/// </summary>
		static void ExemplosGroupBy(List<User> usuarios)
		{
			Console.WriteLine("\n=== 7. GROUPBY - AGRUPAR DADOS ===");

			// Exemplo 1: Agrupar por cargo
			Console.WriteLine("\n📌 Exemplo 1: Usuários agrupados por Cargo");
			var porCargo = usuarios.GroupBy(u => u.Cargo);
			foreach (var grupo in porCargo)
			{
				Console.WriteLine($"\n  📂 {grupo.Key} ({grupo.Count()} usuários):");
				foreach (var usuario in grupo)
				{
					Console.WriteLine($"    • {usuario.Nome} - {usuario.Idade} anos");
				}
			}

			// Exemplo 2: Agrupar por faixa etária
			Console.WriteLine("\n📌 Exemplo 2: Usuários agrupados por faixa etária");
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

			// Exemplo 3: Agrupar por cidade com estatísticas
			Console.WriteLine("\n📌 Exemplo 3: Estatísticas por Cidade");
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

		/// <summary>
		/// 8. SKIP E TAKE - Paginação de dados
		/// </summary>
		static void ExemplosPaginacao(List<User> usuarios)
		{
			Console.WriteLine("\n=== 8. SKIP E TAKE - PAGINAÇÃO ===");

			// Exemplo 1: Take - pegar os primeiros N
			Console.WriteLine("\n📌 Exemplo 1: Primeiros 3 usuários");
			var primeiros3 = usuarios.Take(3).ToList();
			ExibirUsuarios(primeiros3);

			// Exemplo 2: Skip - pular N e pegar o resto
			Console.WriteLine("\n📌 Exemplo 2: Pular os 2 primeiros e pegar o resto");
			var apartirDo3 = usuarios.Skip(2).ToList();
			ExibirUsuarios(apartirDo3);

			// Exemplo 3: Paginação (página 1 com 2 itens por página)
			Console.WriteLine("\n📌 Exemplo 3: Paginação - Página 1 (2 itens por página)");
			int paginaAtual = 0;
			int itensPorPagina = 2;
			var pagina1 = usuarios
				.OrderBy(u => u.Nome)
				.Skip(paginaAtual * itensPorPagina)
				.Take(itensPorPagina)
				.ToList();
			ExibirUsuarios(pagina1);

			// Exemplo 4: Paginação - Página 2
			Console.WriteLine("\n📌 Exemplo 4: Paginação - Página 2 (2 itens por página)");
			paginaAtual = 1;
			var pagina2 = usuarios
				.OrderBy(u => u.Nome)
				.Skip(paginaAtual * itensPorPagina)
				.Take(itensPorPagina)
				.ToList();
			ExibirUsuarios(pagina2);
		}

		/// <summary>
		/// 9. ANY E ALL - Verificações booleanas
		/// </summary>
		static void ExemplosAnyAll(List<User> usuarios)
		{
			Console.WriteLine("\n=== 9. ANY E ALL - VERIFICAÇÕES BOOLEANAS ===");

			// Exemplo 1: Any - existe algum?
			Console.WriteLine("\n📌 Exemplo 1: Existe algum desenvolvedor?");
			bool temDesenvolvedores = usuarios.Any(u => u.Cargo == "Desenvolvedor");
			Console.WriteLine($"  ✓ {(temDesenvolvedores ? "Sim" : "Não")}");

			// Exemplo 2: Any - lista está vazia?
			Console.WriteLine("\n📌 Exemplo 2: A lista está vazia?");
			bool estaVazia = !usuarios.Any();
			Console.WriteLine($"  ✓ {(estaVazia ? "Sim" : "Não")}");

			// Exemplo 3: Any sem argumento
			Console.WriteLine("\n📌 Exemplo 3: Lista contém elementos?");
			bool temElementos = usuarios.Any();
			Console.WriteLine($"  ✓ {(temElementos ? "Sim, contém" : "Não, está vazia")}");

			// Exemplo 4: All - todos satisfazem a condição?
			Console.WriteLine("\n📌 Exemplo 4: Todos os usuários têm mais de 17 anos?");
			bool todosComMais17 = usuarios.All(u => u.Idade > 17);
			Console.WriteLine($"  ✓ {(todosComMais17 ? "Sim" : "Não")}");

			// Exemplo 5: All - todos são de Pradopolis?
			Console.WriteLine("\n📌 Exemplo 5: Todos os usuários são de Pradopolis?");
			bool todosDepadopolis = usuarios.All(u => u.Cidade == "Pradopolis");
			Console.WriteLine($"  ✓ {(todosDepadopolis ? "Sim" : "Não")}");

			// Exemplo 6: Any com count
			Console.WriteLine("\n📌 Exemplo 6: Existe algum usuário com mais de 24 anos?");
			bool existe24plus = usuarios.Any(u => u.Idade > 24);
			Console.WriteLine($"  ✓ {(existe24plus ? "Sim" : "Não")}");
		}

		/// <summary>
		/// 10. Queries complexas e combinações
		/// </summary>
		static void ExemplosCompostos(List<User> usuarios)
		{
			Console.WriteLine("\n=== 10. QUERIES COMPLEXAS E COMBINAÇÕES ===");

			// Exemplo 1: Select + Where + OrderBy
			Console.WriteLine("\n📌 Exemplo 1: Nomes dos desenvolvedores ordenados por idade DESC");
			var resultado1 = usuarios
				.Where(u => u.Cargo == "Desenvolvedor")
				.OrderByDescending(u => u.Idade)
				.Select(u => $"{u.Nome} ({u.Idade} anos)")
				.ToList();
			foreach (var item in resultado1)
				Console.WriteLine($"  • {item}");

			// Exemplo 2: GroupBy + Select + OrderBy
			Console.WriteLine("\n📌 Exemplo 2: Cargo e quantidade de pessoas");
			var resultado2 = usuarios
				.GroupBy(u => u.Cargo)
				.Select(g => new { Cargo = g.Key, Quantidade = g.Count() })
				.OrderByDescending(g => g.Quantidade)
				.ToList();
			foreach (var item in resultado2)
				Console.WriteLine($"  • {item.Cargo}: {item.Quantidade}");

			// Exemplo 3: Encontrar o usuário mais velho de cada cargo
			Console.WriteLine("\n📌 Exemplo 3: Usuário mais velho por cargo");
			var resultado3 = usuarios
				.GroupBy(u => u.Cargo)
				.Select(g => new
				{
					Cargo = g.Key,
					Usuario = g.OrderByDescending(u => u.Idade).First().Nome,
					Idade = g.OrderByDescending(u => u.Idade).First().Idade
				})
				.ToList();
			foreach (var item in resultado3)
				Console.WriteLine($"  • {item.Cargo}: {item.Usuario} ({item.Idade} anos)");

			// Exemplo 4: Listar usuários com estatísticas agregadas
			Console.WriteLine("\n📌 Exemplo 4: Informações de cada usuário com posição");
			var resultado4 = usuarios
				.OrderBy(u => u.Nome)
				.Select((u, indice) => new
				{
					Posicao = indice + 1,
					Nome = u.Nome,
					IdadeComParidade = u.Idade % 2 == 0 ? "Par" : "Ímpar",
					EhDev = u.Cargo == "Desenvolvedor"
				})
				.ToList();
			foreach (var item in resultado4)
			{
				Console.WriteLine($"  {item.Posicao}. {item.Nome} - {item.IdadeComParidade} - Dev: {item.EhDev}");
			}

			// Exemplo 5: Filtro múltiplo com transformação
			Console.WriteLine("\n📌 Exemplo 5: Usuários 20-23 anos (exceto estagiários)");
			var resultado5 = usuarios
				.Where(u => u.Idade >= 20 && u.Idade <= 23 && u.Cargo != "Estagiario")
				.Select(u => $"{u.Nome.ToUpper()} - {u.Cidade} - {u.Cargo}")
				.OrderBy(s => s)
				.ToList();
			foreach (var item in resultado5)
				Console.WriteLine($"  • {item}");
		}
		
		// ============================================
		// MÉTODOS AUXILIARES
		// ============================================

		/// <summary>
		/// Exibe um usuário formatado
		/// </summary>
		static void ExibirUsuario(User usuario)
		{
			Console.WriteLine($"  ✓ Nome: {usuario.Nome}");
			Console.WriteLine($"    Idade: {usuario.Idade}");
			Console.WriteLine($"    CPF: {usuario.CPF}");
			Console.WriteLine($"    Cidade: {usuario.Cidade}");
			Console.WriteLine($"    Cargo: {usuario.Cargo}");
		}

		/// <summary>
		/// Exibe uma lista de usuários formatada
		/// </summary>
		static void ExibirUsuarios(List<User> usuarios)
		{
			foreach (var usuario in usuarios)
			{
				Console.WriteLine($"  • {usuario.Nome} - {usuario.Idade} anos - {usuario.Cargo} ({usuario.Cidade})");
			}
		}
	}
	// No final do seu Program.cs, após os exemplos de LINQ:
}

