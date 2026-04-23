using System;
using System.Globalization;

namespace dia1_fundamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(TiposDeDados());*/
            Console.WriteLine(Condicionais());
        }
        static string TiposDeDados()
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            int year, age;
            double weight, height, salary;
            char gender;
            string name, city, message;

            year = 2005;
            age = 22;
            weight = 94;
            height = 1.75;
            salary = 123.4545;
            gender = 'm';
            name = "Ruan";
            city = "Ribeirão preto";
            message = $"""
                       Year: {year}
                       age: {age}
                       weight: {weight}
                       height: {height}
                       salary: {salary}
                       gender: {gender}
                       name: {name}
                       city: {city}
                       """;
            
            return message;
        }

        static string Condicionais()
        {
            string message;
            int contadorFor = ContarFor();
            int contadorWhile = ContarWhile();
            int contadorDoWhile =  ContarDoWhile();
            string contadorForeach = ContarForeach();
            
            message = $"""
                      Contador For: {contadorFor}
                      Contador While: {contadorWhile}
                      Contador DoWhile: {contadorDoWhile}
                      Nomes Foreach: {contadorForeach}
                      """;
            
            return message;
        }
        
        static int ContarFor()
        {
            int contador = 0;
            for (int i = 0; i < 5; i++)
            {
                contador++;
            }
            return contador;
        }

        static int ContarWhile()
        {
            int contador = 0;
            while (contador<5)
            {
                contador++;
            }
            return contador;
        }

        static int ContarDoWhile()
        {
            int contador = 0;
            do
            {
                contador++;
            } while (contador < 5);
            return  contador;
        }
        
        static string ContarForeach()
        {
            string messageNomes = "";
            var nomes = new List<string>{"Ana", "Carlos", "joão"};
            foreach (var nome in nomes)
            {
                if (messageNomes != "")
                {
                    messageNomes += ", ";
                }
                messageNomes +=  nome;
            }
            
            return messageNomes;
        }
    }
}

