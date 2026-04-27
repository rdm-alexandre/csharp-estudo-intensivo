# Dia 1 - Fundamentos de C#

- Tipos (int, string, bool, var...)
- Condicionais(if, switch);
- Estruturas de repetição;
- Métodos, Classes e objetos;
---
- [ ] Prática - Criar um console simples de cadastro de produtos
---
### Tipos De Dados
**Dados Primitivos (Int, Decimal, bool, Float...)**
`São dados com seus tipos definidos pela linguagem, sem possibilidade de alteração`

**Derivados (String, Arrays Ponteiros, Delegates...)**
`São conjuntos contruidos com dados primitivos. Eles não criam o dado do zero,
mas organizam, agrupam ou estendem os tipos básicos para representar
estruturas mais complexas.`

**Definidos pelo Usuario (Classes, Structs, Interfaces e Enums)**
`Criados pelo desenvolvedor para modelar entidades complexas do domínio da aplicação,
utilizando os tipos primitivos e Derivados como base.`

---

### Condicionais(if, switch case)
> Permitem ao sistema tomar decisões com base em condições
> Em outra palavras Se isso acontecer -> faça isso

`Estrutura if, else if, else`
```c#
if (condicao)
{
    // Executa se for verdadeiro
}

Na Prática
int idade = 18;
if(idade >= 18) //Se for maior ou igual a 18
{
    Console.WriteLine("Adulto");
}else if(idade <= 12) //Se for maior ou igual a 12
{
    Console.WriteLine("Adolescente");
}else //Se não for nenhuma das duas
{
    Console.WriteLine("Criança");
}
```
`Estrutura Switch Case`
```c#
switch (variavel)
{
    case valor1:
        // código
        break;

    case valor2:
        // código
        break;

    default:
        // padrão
        break;
}

Na Prática
int dia = 3
switch (dia)
{
    case 1:
        return "Domingo";

    case 2:
        return "Segunda";

    case 3:
        return "Terça";
    
    default:
        return "Fim de semana papai";
}
```
#### Quando é recomendado usar um ou outro?
O if é recomendado quando existe uma variação muito grande entre valores, 
já o switch quando existem valores fixos.

---
### Estruturas de repetição
#### For
`Quando sabemos quantas vezes vai repetir`
```c#
for (inicialização; condição; incremento)
{
    // código
}

Na Prática:
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```
---
#### While
`Quando não sabemos por quantas vezes o conteudo vai se repetir`
```c#
while (Condição)
{
    // código
}

Na Prática:
int i = 0;

while (i < 5)
{
    Console.WriteLine(i);
    i++;
}
```
---
#### Do While
`Executa no minimo uma vez, mesmo se a condição for verdadeira, pois neste contexto
a validação é feita ao fim do escopo`
```c#
do
{
    // código
} while (condição);

Na Prática:
int i = 0;

do
{
    Console.WriteLine(i);
    i++;
} while (i < 5);
```
----
#### Foreach
`Percorre pelos itens dentro de um objeto`
```c#
foreach (var item in coleção)
{
    // código
}

Na Prática:
var nomes = new List<string> {"Ruan", "Jorge", "joão"};

foreach(var nome in nomes)
{
    Console.WriteLine(nome)
}
```
---
### 
### Métodos, Classes e objetos
> Na orientação a objetos, ela define o que algo tem(propriedades) e o que 
> algo faz (metodos)

```c#
/*Exemplo Classe*/
public class Produto
{
    public string Nome{get; set;}
    public decimal Preco{get; set;}

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
    
    public decimal CalcularDesconto(decimal porcentagem)
    {
        return Preco * (1-porcentagem);
    }
}
No exemplo acima temos o objeto Produto, suas propriedades são Nome e Preco e o
metodo CalcularDesconto(). O metodo construtor foi adicionado, para facilitar
a criação de novos objetos
```

```c#
/*Exemplo Objetos*/
Produto produto1 = new Produto("Mouse", 29.90);

var desconto = produto1.CalcularDesconto(5)

Aqui temos o exemplo da criação de um produto criado a partir do objeto Produto
e logo em seguida chamamos o metodo CalcularDesconto para aplicar o valor ao 
produto
```