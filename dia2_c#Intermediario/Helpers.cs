using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dia2_c_Intermediario
{
    public static class Helpers
    {
        /// <summary>
        /// Imprime um header formatado com título
        /// 
        /// ANTES (repetitivo):
        /// Console.WriteLine("\n\n" + new string('=', 50));
        /// Console.WriteLine("TÍTULO");
        /// Console.WriteLine(new string('=', 50));
        /// 
        /// DEPOIS (usando Helper):
        /// Helpers.ImprimirHeader("TÍTULO");
        /// </summary>
        public static void ImprimirHeader(string titulo)
        {
            Console.WriteLine("\n\n" + new string('=', 50));
            Console.WriteLine(titulo);
            Console.WriteLine(new string('=', 50));
        }

        /// <summary>
        /// Imprime um subtítulo com formatação
        /// </summary>
        public static void ImprimirSubtitulo(string subtitulo)
        {
            Console.WriteLine($"\n=== {subtitulo} ===");
        }

        /// <summary>
        /// Imprime uma linha de separação
        /// </summary>
        public static void ImprimirSeparador(int tamanho = 50)
        {
            Console.WriteLine(new string('=', tamanho));
        }

        /// <summary>
        /// Imprime um resultado com formatação
        /// Exemplo: ImprimirResultado("Nome", "João Silva")
        /// Output: Nome: João Silva
        /// </summary>
        public static void ImprimirResultado(string rotulo, object valor)
        {
            Console.WriteLine($"{rotulo}: {valor}");
        }

        /// <summary>
        /// Imprime um erro formatado
        /// </summary>
        public static void ImprimirErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERRO: {mensagem}");
            Console.ResetColor();
        }

        /// <summary>
        /// Imprime um aviso formatado
        /// </summary>
        public static void ImprimirAviso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠️ AVISO: {mensagem}");
            Console.ResetColor();
        }

        /// <summary>
        /// Imprime um sucesso formatado
        /// </summary>
        public static void ImprimirSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ SUCESSO: {mensagem}");
            Console.ResetColor();
        }

        /// <summary>
        /// Imprime informação formatada
        /// </summary>
        public static void ImprimirInfo(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ℹ️ INFO: {mensagem}");
            Console.ResetColor();
        }

        /// <summary>
        /// Lê um inteiro do console com validação
        /// Retorna null se não conseguir converter
        /// </summary>
        public static int? LerInteiro(string mensagem)
        {
            Console.WriteLine(mensagem);
            if (int.TryParse(Console.ReadLine(), out int resultado))
            {
                return resultado;
            }
            return null;
        }

        /// <summary>
        /// Lê uma string do console
        /// </summary>
        public static string? LerString(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine();
        }

        /// <summary>
        /// Cria uma pausa com mensagem (press any key)
        /// </summary>
        public static void Pausa(string mensagem = "Pressione qualquer tecla para continuar...")
        {
            Console.WriteLine(mensagem);
            Console.ReadKey();
        }

        /// <summary>
        /// Imprime uma tabela simples
        /// Exemplo: ImprimirTabela(new[] {"Nome", "Idade"}, 
        ///                         new[] {"João", "25"},
        ///                         new[] {"Maria", "30"})
        /// </summary>
        public static void ImprimirTabela(string[] cabecalhos, params string[][] linhas)
        {
            // Calcula largura das colunas
            int[] larguras = new int[cabecalhos.Length];
            for (int i = 0; i < cabecalhos.Length; i++)
            {
                larguras[i] = cabecalhos[i].Length;
            }

            foreach (var linha in linhas)
            {
                for (int i = 0; i < linha.Length; i++)
                {
                    larguras[i] = Math.Max(larguras[i], linha[i].Length);
                }
            }

            // Imprime cabeçalho
            for (int i = 0; i < cabecalhos.Length; i++)
            {
                Console.Write(cabecalhos[i].PadRight(larguras[i] + 2));
            }
            Console.WriteLine();

            // Imprime linha separadora
            for (int i = 0; i < cabecalhos.Length; i++)
            {
                Console.Write(new string('-', larguras[i] + 2));
            }
            Console.WriteLine();

            // Imprime linhas
            foreach (var linha in linhas)
            {
                for (int i = 0; i < linha.Length; i++)
                {
                    Console.Write(linha[i].PadRight(larguras[i] + 2));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Formata um tempo em milissegundos para uma string legível
        /// Exemplo: 2500 → "2,5 segundos"
        /// </summary>
        public static string FormatarTempo(long milissegundos)
        {
            if (milissegundos < 1000)
                return $"{milissegundos}ms";
            
            double segundos = milissegundos / 1000.0;
            return $"{segundos:F2}s";
        }

        /// <summary>
        /// Simula uma operação com barra de progresso
        /// </summary>
        public static async Task SimularProgresso(int etapas = 10, int delayMs = 200)
        {
            Console.Write("[");
            for (int i = 0; i < etapas; i++)
            {
                Console.Write("█");
                await Task.Delay(delayMs);
            }
            Console.WriteLine("] 100%");
        }

        /// <summary>
        /// Cria um menu simples
        /// Exemplo: MenuSimples("Escolha uma opção", new[] {"Opção 1", "Opção 2", "Sair"})
        /// </summary>
        public static int MenuSimples(string titulo, string[] opcoes)
        {
            ImprimirHeader(titulo);
            
            for (int i = 0; i < opcoes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {opcoes[i]}");
            }

            Console.Write("\nDigite a opção: ");
            if (int.TryParse(Console.ReadLine(), out int opcao) && opcao > 0 && opcao <= opcoes.Length)
            {
                return opcao - 1;
            }

            return -1; // Opção inválida
        }

        /// <summary>
        /// Repete uma ação N vezes (útil para testes)
        /// Exemplo: Helpers.Repetir(3, () => Console.WriteLine("Teste"));
        /// </summary>
        public static void Repetir(int vezes, Action acao)
        {
            for (int i = 0; i < vezes; i++)
            {
                acao?.Invoke();
            }
        }

        /// <summary>
        /// Repete uma ação N vezes com índice
        /// Exemplo: Helpers.Repetir(3, (i) => Console.WriteLine($"Iteração {i}"));
        /// </summary>
        public static void Repetir(int vezes, Action<int> acao)
        {
            for (int i = 0; i < vezes; i++)
            {
                acao?.Invoke(i);
            }
        }
    }
}
