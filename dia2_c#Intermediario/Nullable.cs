using System;

namespace dia2_csharp_Intermediario
{
	/// <summary>
	/// NULLABLE TYPES EM C#
	/// 
	/// Nullable = Tipo que pode ser NULL (nulo/vazio/sem valor)
	/// Por padrão, tipos de valor (int, decimal, bool) NÃO podem ser null
	/// Mas às vezes precisamos representar "sem valor" ou "desconhecido"
	/// 
	/// Sintaxe: tipo?
	/// Exemplos: int?, decimal?, bool?, DateTime?
	/// 
	/// COMO USAR: Chame NullableExemplos.Demonstrar() do seu Program.cs ou outro lugar
	/// </summary>

	public class Nullable
	{
		/// <summary>
		/// Demonstra todos os conceitos de Nullable Types
		/// </summary>
		public static void Demonstrar()
		{
			Console.WriteLine("\n========== NULLABLE TYPES ==========\n");

			// ========== 1. PROBLEMA SEM NULLABLE ==========
			Console.WriteLine("❌ SEM NULLABLE (Problema):");
			int idade = 25;
			Console.WriteLine($"Idade: {idade}");
			// int idade = null;  // ← ERRO! int não pode ser null
			Console.WriteLine("⚠️ Não consigo representar 'sem valor' com int\n");

			// ========== 2. SOLUÇÃO COM NULLABLE ==========
			Console.WriteLine("✅ COM NULLABLE (Solução):");
			int? idadeNula = null;  // ← Agora pode ser null!
			int? idadeValida = 30;
			Console.WriteLine($"Idade nula: {idadeNula}");
			Console.WriteLine($"Idade válida: {idadeValida}\n");

			// ========== 3. OUTROS TIPOS NULLABLE ==========
			Console.WriteLine("📌 Outros tipos Nullable:");
			decimal? salario = null;
			bool? ativo = true;
			DateTime? dataNascimento = null;
			double? temperatura = 36.5;

			Console.WriteLine($"  • Salário: {(salario == null ? "Não definido" : salario)}");
			Console.WriteLine($"  • Ativo: {ativo}");
			Console.WriteLine($"  • Data de nascimento: {(dataNascimento == null ? "Não definido" : dataNascimento.ToString())}");
			Console.WriteLine($"  • Temperatura: {temperatura}°C\n");

			// ========== 4. VERIFICANDO SE É NULL ==========
			Console.WriteLine("🔍 Verificando se é NULL:");
			int? valor = null;

			// Forma 1: Comparação direta
			if (valor == null)
				Console.WriteLine("  • Valor é null");

			// Forma 2: HasValue
			if (!valor.HasValue)
				Console.WriteLine("  • valor.HasValue = false (não tem valor)\n");

			// ========== 5. OBTENDO O VALOR ==========
			Console.WriteLine("📤 Obtendo o valor:");
			int? numero = 42;

			if (numero.HasValue)
			{
				int valor_extraido = numero.Value;  // .Value extrai o valor
				Console.WriteLine($"  • Valor extraído: {valor_extraido}\n");
			}

			// ========== 6. NULL COALESCING (??) ==========
			Console.WriteLine("⚡ Null Coalescing Operator (??):");
			int? maiordenidade = null;
			int idade_padrao = maiordenidade ?? 18;  // Se null, usa 18
			Console.WriteLine($"  • Idade: {idade_padrao}");

			int? menordenidade = 25;
			int idade_padrao2 = menordenidade ?? 18;  // Se tiver valor, usa ele
			Console.WriteLine($"  • Idade: {idade_padrao2}\n");

			// ========== 7. NULLABLE WITH OBJECTS ==========
			Console.WriteLine("👤 Nullable com objetos:");
			User? usuario = null;
			Console.WriteLine($"  • Usuário: {(usuario == null ? "Sem usuário" : usuario.Nome)}\n");

			usuario = new User("João", 25, "12345678901", "São Paulo", "Desenvolvedor");
			if (usuario != null)
				Console.WriteLine($"  • Usuário encontrado: {usuario.Nome}\n");

			// ========== 8. CONVERSÃO ENTRE TIPOS ==========
			Console.WriteLine("🔄 Conversão entre tipos:");
			int? nullable_int = 100;
			int regular_int = nullable_int ?? 0;  // Converte para int comum
			Console.WriteLine($"  • int? para int: {regular_int}");

			int? nulo = null;
			int regular_default = nulo ?? -1;  // Usa valor padrão se for null
			Console.WriteLine($"  • null para int com padrão: {regular_default}\n");

			// ========== 9. MÉTODOS ÚTEIS ==========
			Console.WriteLine("🛠️ Métodos úteis:");
			int? x = 50;
			Console.WriteLine($"  • x.HasValue: {x.HasValue}");
			Console.WriteLine($"  • x.Value: {x.Value}");
			Console.WriteLine($"  • x.GetValueOrDefault(): {x.GetValueOrDefault()}");
			Console.WriteLine($"  • x.GetValueOrDefault(999): {x.GetValueOrDefault(999)}\n");

			int? y = null;
			Console.WriteLine($"  • y.GetValueOrDefault(): {y.GetValueOrDefault()}");
			Console.WriteLine($"  • y.GetValueOrDefault(999): {y.GetValueOrDefault(999)}\n");

			// ========== 10. CASOS DE USO PRÁTICO ==========
			Console.WriteLine("💡 Casos de uso prático:");
			ProcessarDados(25);     // Com valor
			ProcessarDados(null);   // Sem valor
		}

		private static void ProcessarDados(int? idade)
		{
			if (idade.HasValue)
				Console.WriteLine($"  ✓ Processando usuário com {idade} anos");
			else
				Console.WriteLine("  ⚠️ Idade não informada - usando padrão (18 anos)");
		}
	}
}
