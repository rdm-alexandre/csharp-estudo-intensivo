using System;

namespace dia2_csharp_Intermediario
{
	public class Nullable
	{
		/// <summary>
		/// Demonstra todos os conceitos de Nullable Types
		/// </summary>
		public static void Demonstrar()
		{
			Console.WriteLine("\n\n" + new string('=', 50));
			Console.WriteLine("NULLABLE TYPES");
			Console.WriteLine(new string('=', 50));

			// ProblemaSemNullable();
			// SolucaoSemNullable();
			// OutrosTiposNullable();
			// VerificarIfNull();
			// NullCoalescing();
			// NullableComObjetos();

		}

		private static void ProblemaSemNullable()
		{
			Console.WriteLine("❌ SEM NULLABLE (Problema):");
			int idade = 25;
			Console.WriteLine($"Idade: {idade}");
			// int idade = null;  // ← ERRO! int não pode ser null
			Console.WriteLine("⚠️ Não consigo representar 'sem valor' com int\n");
		}
		
		private static void SolucaoSemNullable()
		{
			Console.WriteLine("✅ COM NULLABLE (Solução):");
			int? idadeNula = null;  // ← Agora pode ser null!
			int? idadeValida = 30;
			Console.WriteLine($"Idade nula: {idadeNula}");
			Console.WriteLine($"Idade válida: {idadeValida}\n");
		}

		private static void OutrosTiposNullable()
		{
			Console.WriteLine("📌 Outros tipos Nullable:");
			decimal? salario = null;
			bool? ativo = true;
			DateTime? dataNascimento = null;
			double? temperatura = 36.5;

			Console.WriteLine($"  • Salário: {(salario == null ? "Não definido" : salario)}");
			Console.WriteLine($"  • Ativo: {ativo}");
			Console.WriteLine($"  • Data de nascimento: {(dataNascimento == null ? "Não definido" : dataNascimento.ToString())}");
			Console.WriteLine($"  • Temperatura: {temperatura}°C\n");
			
		}

		private static void VerificarIfNull()
		{
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
		}

		private static void NullCoalescing()
		{
			Console.WriteLine("⚡ Null Coalescing Operator (??):");
			int? maiordenidade = null;
			int idade_padrao = maiordenidade ?? 18;  // Se null, usa 18
			Console.WriteLine($"  • Idade: {idade_padrao}");
			
			int? menordenidade = 25;
			int idade_padrao2 = menordenidade ?? 18;  // Se tiver valor, usa ele
			Console.WriteLine($"  • Idade: {idade_padrao2}\n");
		}

		private static void NullableComObjetos()
		{
			Console.WriteLine("👤 Nullable com objetos:");
			User? usuario = null;
			Console.WriteLine($"  • Usuário: {(usuario == null ? "Sem usuário" : usuario.Nome)}\n");

			usuario = new User("João", 25, "12345678901", "São Paulo", "Desenvolvedor");
			if (usuario != null)
				Console.WriteLine($"  • Usuário encontrado: {usuario.Nome}\n");
		}

	}
}
