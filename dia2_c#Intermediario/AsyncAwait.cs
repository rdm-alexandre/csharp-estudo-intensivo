using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dia2_c_Intermediario
{
    public class AsyncAwait
    {
        public static async Task Demonstrar()
        {
            Helpers.ImprimirHeader("Exemplos de Asyn/Await");
            

            //await TaskDelay();
            //await TratamentoDeErro();
            await MultiplasOperacoes();

        } 
        
        private static async Task TaskDelay()
        {
            Helpers.ImprimirSubtitulo("Task Delay");
            Console.WriteLine("Iniciando Operação...");

            await Task.Delay(2000);
            
            Console.WriteLine("Operação concluida com sucesso!\n");
        }

        private static async Task TratamentoDeErro()
        {
            Helpers.ImprimirSubtitulo("Tratamento de Erro");
            try
            {
                var resultado = await SimularOperacaoExemploFalha();
                Console.WriteLine(resultado);
            }
            catch (Exception ex)
            {
                Helpers.ImprimirErro(ex.Message);
            }
        }

        private static async Task MultiplasOperacoes()
        {
            Helpers.ImprimirSubtitulo("Multiplas Operações Paralelas");

            var tarefas = new[]
            {
                SimularBuscarDadosAPI("API 1"),
                SimularBuscarDadosAPI("API 2"),
                SimularBuscarDadosAPI("API 3")
            };
            
            var resultados = await Task.WhenAll(tarefas);

            Helpers.ImprimirSucesso("Resultados recebidos:");
            foreach (var resultado in resultados)
            {
                Helpers.ImprimirResultado("->", resultado);
            }
        }

        // Metodos para simulção de contextos
        private static async Task<string> SimularOperacaoExemploFalha()
        {
            await Task.Delay(1000);
            throw new InvalidOperationException("Operação falhou propositalmente!");
        }

        private static async Task<string> SimularBuscarDadosAPI(string nomeDaAPI)
        {
            Helpers.ImprimirInfo($"Iniciando Requisição para {nomeDaAPI}");
            return $"{nomeDaAPI} retornou dados";
        }
        
        
    }
}