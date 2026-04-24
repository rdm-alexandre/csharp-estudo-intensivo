using System.Globalization;

public class User
{
        public string Nome{get; set;}
        public int Idade{get; set;}
        public string CPF{get; set;}
        public string Cidade {get; set;}
        public string Cargo {get; set;}

        public User(string nome, int idade, string cpf, string cidade, string cargo)
        {
            Nome = nome;
            Idade = idade;
            CPF = cpf;
            Cidade = cidade;
            Cargo = cargo;
        }
    
}