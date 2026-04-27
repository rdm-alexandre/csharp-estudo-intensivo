using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace dia2_c_Intermediario
{
	public class TryCatch
	{
		public static void Demonstrar()
		{

			Console.WriteLine("\n\n" + new string('=', 50));
			Console.WriteLine("EXEMPLOS DE TRY CATCH");
			Console.WriteLine(new string('=', 50));

			DividsaoPorZero();
			IndiceForaDoLimite();
			ConversaoStringParaNumero();
			PersonalizarMensagemErro();
		}
		private static void DividsaoPorZero()
		{
			Console.WriteLine("\n=== ERRO DE DIVISÃO POR ZERO ===");
			try
			{
				int a = 10;
				int b = 0;
				int resultado = a / b;
				Console.WriteLine($"Resultado: {resultado}");
			}catch (DivideByZeroException ex)
			{
				Console.WriteLine($"Erro: Não é possível dividor po zero. Detalhes? {ex.Message}");
			}
		}

		private static void IndiceForaDoLimite()
		{
			Console.WriteLine("\n=== ERRO ÍNDICE FORA DO LIMITE ===");
			try
			{
				int[] numeros = { 1, 2, 3 };
				Console.WriteLine(numeros[4]);
			}catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine($"Erro: Índice fora do limite buscado. Detalhes: {ex.Message}");
			}
		}

		private static void ConversaoStringParaNumero()
		{
			Console.WriteLine("\n=== ERRO DE CONVERSÃO DE VALORES ===");
			try
			{
				string valor = "Ronnie";
				int numero = int.Parse(valor);
				Console.WriteLine($"Número convertido: {numero}");
			}
			catch(FormatException ex)
			{
				Console.WriteLine($"Erro: Valor inválido para conversão. Detalhes: {ex.Message}");
			}
		}

		private static void PersonalizarMensagemErro()
		{
			Console.WriteLine("\n=== MENSAGEM DE ERRO PERSONALIZADA ===");
			Console.WriteLine("\nObs. Para provocar o erro, coloque uma string");
			try
			{
				Console.WriteLine("Digite um numero ao meu amigo");
				string input = Console.ReadLine();
				int numero = int.Parse(input);
				if (numero < 0)
				{
					throw new ArgumentException("Só tem que digitar um número e ainda digita negativo? Digita um positivo ai caba");
				}
			}catch (FormatException ex)
			{
				Console.WriteLine($"Falei para digitar um número jumento, olha ai o erro: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro inesperado: {ex.Message}");
			}
		}
	}
}