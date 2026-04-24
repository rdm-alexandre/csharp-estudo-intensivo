# 🎓 Guia Rápido de LINQ - Referência

> Um guia de bolso para você consultar rapidamente quando estiver programando

---

## 📌 O que é LINQ?

**LINQ** = **L**anguage **IN**tegrated **Q**uery

É uma forma poderosa e elegante de consultear, filtrar, transformar e agregar dados em C#, usando uma sintaxe similar à de bancos de dados.

### Vantagens:
- ✅ Sintaxe clara e legível
- ✅ Type-safe (verificação de tipos em tempo de compilação)
- ✅ Funciona com qualquer coleção (List, Array, Dictionary, etc)
- ✅ Integrado à linguagem (não precisa de bibliotecas externas)

---

## 🔧 Métodos de LINQ - Referência Rápida

### 1️⃣ **WHERE** - Filtrar
```csharp
// Sintaxe básica
usuarios.Where(u => u.Cargo == "Desenvolvedor")

// Múltiplas condições
usuarios.Where(u => u.Idade > 20 && u.Cargo == "Dev")

// Negação
usuarios.Where(u => u.Cargo != "Estagiario")
```

---

### 2️⃣ **SELECT** - Transformar/Projetar
```csharp
// Selecionar apenas uma propriedade
usuarios.Select(u => u.Nome)

// Criar objeto anônimo
usuarios.Select(u => new { u.Nome, u.Idade })

// Transformar valores
usuarios.Select(u => u.Nome.ToUpper())

// Com índice
usuarios.Select((u, indice) => new { Posicao = indice + 1, u.Nome })
```

---

### 3️⃣ **ORDERBY / ORDERBYDESCENDING** - Ordenar
```csharp
// Ordem crescente
usuarios.OrderBy(u => u.Idade)

// Ordem decrescente
usuarios.OrderByDescending(u => u.Idade)

// Múltiplas ordenações
usuarios.OrderBy(u => u.Cargo).ThenByDescending(u => u.Idade)
```

---

### 4️⃣ **FIRST / LAST** - Obter Elemento
```csharp
// Primeiro (lança exceção se não encontrar)
usuarios.First()
usuarios.First(u => u.Cargo == "Gerente")

// Último
usuarios.Last()

// Primeiro com segurança (retorna null se não encontrar)
usuarios.FirstOrDefault()
usuarios.FirstOrDefault(u => u.CPF == "123")

// Último com segurança
usuarios.LastOrDefault()

// Um único (lança exceção se houver 0 ou mais de 1)
usuarios.Single(u => u.CPF == "123")
usuarios.SingleOrDefault(u => u.CPF == "123")
```

---

### 5️⃣ **COUNT / LENGTH** - Contar
```csharp
// Total de elementos
usuarios.Count()  // int

// Com condição
usuarios.Count(u => u.Cargo == "Desenvolvedor")

// Verificar se está vazio
usuarios.Count() == 0  // ou  !usuarios.Any()
```

---

### 6️⃣ **AGGREGATE METHODS** - Agregações
```csharp
// Média
usuarios.Average(u => u.Idade)  // double

// Soma
usuarios.Sum(u => u.Idade)  // int

// Mínimo
usuarios.Min(u => u.Idade)  // int

// Máximo
usuarios.Max(u => u.Idade)  // int

// Combinando com Where
usuarios.Where(u => u.Cargo == "Dev").Average(u => u.Idade)
```

---

### 7️⃣ **DISTINCT** - Valores Únicos
```csharp
// Remover duplicatas
usuarios.Select(u => u.Cargo).Distinct()  // ["Dev", "Designer", "Gerente"]

// Contar únicos
usuarios.Select(u => u.Cidade).Distinct().Count()
```

---

### 8️⃣ **GROUPBY** - Agrupar
```csharp
// Agrupar por cargo
var grupos = usuarios.GroupBy(u => u.Cargo);
foreach (var grupo in grupos)
{
    Console.WriteLine($"{grupo.Key}: {grupo.Count()}");  // "Dev: 5"
}

// Agrupar com agregação
usuarios
    .GroupBy(u => u.Cargo)
    .Select(g => new { Cargo = g.Key, Total = g.Count() })
```

---

### 9️⃣ **SKIP / TAKE** - Paginação
```csharp
// Pular 5 e pegar o resto
usuarios.Skip(5)

// Pegar apenas 3
usuarios.Take(3)

// Paginação: página 2 com 5 itens por página
int pagina = 1;  // 0-based
int itensPorPagina = 5;
usuarios.Skip(pagina * itensPorPagina).Take(itensPorPagina)
```

---

### 🔟 **ANY / ALL** - Verificações Booleanas
```csharp
// Existe algum desenvolvedor?
usuarios.Any(u => u.Cargo == "Desenvolvedor")  // bool

// Lista está vazia?
!usuarios.Any()  // bool

// Todos têm mais de 18?
usuarios.All(u => u.Idade >= 18)  // bool

// Todos são de SP?
usuarios.All(u => u.Cidade == "São Paulo")  // bool
```

---

### 1️⃣1️⃣ **CONTAINS / IN** - Verificar Pertencimento
```csharp
// Verificar se está em lista
var cargos = new[] { "Dev", "Designer" };
usuarios.Where(u => cargos.Contains(u.Cargo))

// Ou mais explícito
usuarios.Where(u => u.Cargo == "Dev" || u.Cargo == "Designer")
```

---

### 1️⃣2️⃣ **TOLIST / TOARRAY** - Converter
```csharp
// Converter para List<T>
var lista = usuarios.Where(u => u.Idade > 20).ToList()

// Converter para Array
var array = usuarios.ToArray()

// Converter para Dictionary
var dict = usuarios.ToDictionary(u => u.CPF, u => u.Nome)
```

---

## 🎯 Padrões Comuns

### Padrão 1: Filtrar → Ordenar → Transformar
```csharp
usuarios
    .Where(u => u.Cargo == "Dev")
    .OrderByDescending(u => u.Idade)
    .Select(u => u.Nome)
    .ToList()
```

### Padrão 2: Agrupar com Estatísticas
```csharp
usuarios
    .GroupBy(u => u.Cargo)
    .Select(g => new
    {
        Cargo = g.Key,
        Total = g.Count(),
        IdadeMedia = g.Average(u => u.Idade),
        MaisVelho = g.Max(u => u.Idade)
    })
    .ToList()
```

### Padrão 3: Paginação
```csharp
int pagina = 0;
int tamanho = 10;
usuarios
    .OrderBy(u => u.Nome)
    .Skip(pagina * tamanho)
    .Take(tamanho)
    .ToList()
```

### Padrão 4: Ranking com Posição
```csharp
usuarios
    .OrderByDescending(u => u.Idade)
    .Select((u, idx) => new { Posicao = idx + 1, u.Nome, u.Idade })
    .ToList()
```

### Padrão 5: Encontrar Max/Min com Contexto
```csharp
// Usuário mais velho
var maisVelho = usuarios.OrderByDescending(u => u.Idade).First();

// Usuário mais jovem
var maisJovem = usuarios.OrderBy(u => u.Idade).First();
```

---

## 🔄 Sintaxe Query vs Method Chaining

LINQ pode ser escrito de duas formas:

### Method Chaining (recomendado para a maioria)
```csharp
usuarios
    .Where(u => u.Idade > 20)
    .OrderBy(u => u.Nome)
    .Select(u => u.Nome)
    .ToList()
```

### Query Syntax (SQL-like)
```csharp
from u in usuarios
where u.Idade > 20
orderby u.Nome
select u.Nome
```

---

## 📋 Checklist de Tipos de Retorno

| Método | Retorna | Precisa `.ToList()`? |
|--------|---------|----------------------|
| `Where()` | IEnumerable | Sim (se quer List) |
| `Select()` | IEnumerable | Sim (se quer List) |
| `First()` | T | Não |
| `Count()` | int | Não |
| `Any()` | bool | Não |
| `Average()` | double | Não |
| `GroupBy()` | IEnumerable<IGrouping> | Sim |

---

## ⚠️ Armadilhas Comuns

### ❌ Armadilha 1: Esquecer .ToList()
```csharp
// Errado - não vai iterar
var resultado = usuarios.Where(u => u.Idade > 20);
foreach (var u in resultado) { }  // Executa a query aqui

// Certo - materializa imediatamente
var resultado = usuarios.Where(u => u.Idade > 20).ToList();
foreach (var u in resultado) { }  // Já tem os dados
```

### ❌ Armadilha 2: Usar First() sem verificar
```csharp
// Pode lançar exceção se não encontrar
var usuario = usuarios.First(u => u.CPF == "999");

// Melhor
var usuario = usuarios.FirstOrDefault(u => u.CPF == "999");
if (usuario != null) { ... }
```

### ❌ Armadilha 3: Ordenação em memoria vs banco de dados
```csharp
// Se fosse Entity Framework, isso seria caro
usuarios
    .ToList()  // ← Traz tudo para memória AQUI
    .OrderBy(u => u.Nome)  // ← Ordena em memória
    
// Melhor
usuarios
    .OrderBy(u => u.Nome)  // ← Ordena no banco
    .ToList()  // ← Traz ordenado
```

---

## 🚀 Performance Tips

1. **Filtrar antes de transformar**
   ```csharp
   usuarios.Where(...).Select(...)  // ✅ Melhor
   usuarios.Select(...).Where(...)  // ❌ Mais lento
   ```

2. **Usar IEnumerable até o final**
   ```csharp
   usuarios
       .Where(...)
       .OrderBy(...)
       .Select(...)
       // Apenas materialize agora:
       .ToList()
   ```

3. **Count() vs Any()**
   ```csharp
   if (usuarios.Count() > 0) { }  // ❌ Conta tudo
   if (usuarios.Any()) { }  // ✅ Para no primeiro
   ```

---

## 🎓 Exemplo Completo (Tudo Junto)

```csharp
// Obter TOP 5 desenvolvedores mais jovens, ordenados por nome
var top5 = usuarios
    .Where(u => u.Cargo == "Desenvolvedor")           // Filtrar
    .OrderBy(u => u.Idade)                           // Ordenar por idade
    .Take(5)                                         // Pegar 5
    .OrderBy(u => u.Nome)                            // Re-ordenar por nome
    .Select(u => new {                               // Transformar
        u.Nome,
        u.Idade,
        Categoria = u.Idade < 22 ? "Júnior" : "Pleno"
    })
    .ToList();                                        // Materializar

foreach (var dev in top5)
    Console.WriteLine($"{dev.Nome} ({dev.Idade}) - {dev.Categoria}");
```

---

## 📖 Referências

- [Microsoft Docs - LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/linq/)
- [LINQ Method Reference](https://www.linqpad.net/)
- [101 LINQ Samples](https://docs.microsoft.com/en-us/samples/dotnet/samples/101-linq-samples-csharp/)

---

**Made with ❤️ for C# Learners**
