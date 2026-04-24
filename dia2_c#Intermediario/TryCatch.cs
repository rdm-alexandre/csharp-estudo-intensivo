using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dia2_c_Intermediario
{
    public class TryCatch
    {
        public static void Demonstrar()
        {
            Console.WriteLine("\n========== TRY CATCH ==========\n");

            // Exemplo 1: Divisão por zero
            try
            {
                int a = 10;
                int b = 0;
                int resultado = a / b; // Isso vai lançar uma exceção
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Erro: Não é possível dividir por zero. Detalhes: {ex.Message}");
            }

            // Exemplo 2: Acesso a índice fora do limite
            try
            {
                int[] numeros = { 1, 2, 3 };
                Console.WriteLine(numeros[5]); // Isso vai lançar uma exceção
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Erro: Índice fora do limite. Detalhes: {ex.Message}");
            }

            // Exemplo 3: Conversão de string para número
            try
            {
                string texto = "abc";
                int numero = int.Parse(texto); // Isso vai lançar uma exceção
                Console.WriteLine($"Número: {numero}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro: Formato inválido. Detalhes: {ex.Message}");
            }

            Console.WriteLine("\nFim da demonstração de Try Catch.\n");
        }
    }
}