# Dia 3 - Introdução ao ASP.NET Core

- O que é
- Arquitetura
- Injeção de Dependência (DI)
- Iniciar um Projeto (webapi)
---
- [ ] Prática - Criar projeto ASP.NET
---
### O que é
> É um framework da microsoft para construir aplicações usando C# .NET. ASP.NET é utilizado para criar sites, APIs e sistemas Web
> Seu maior uso é em empresas/sistemas de médio e grande porte.
--- 
### O que podemos fazer com ASP.NET?
- **APIs**
```csharp
// Exemplo simples de parte do processo de resposta de uma requisição
[HttpGet]
public IActionResult Get()
{
    return Ok("Olá Mundo");
}
```
- **Sites Dinâmicos (MVC/Razor)**
```csharp
// Retornar uma View
public IActionREsult Index()
{
    return View();
}
```
`Utilizado em ERPs, CRMs, E-commerces e sistemas administrativos`

---
### Arquitetura
> Sua arquitetura principal é MVC (Model - View - Controller)
 
#### Model
`Representa o estado da aplicação e manipula os registros. Conversa diretamente com o banco para salvar, editar ou excluir registros.`
```csharp
// Exemplo
public class Produto
{
    public string Nome {get; set;}
    public decimal Preco {get; set;}
}
```
#### Controller 
`Atua como um intermediário entre a View e o Model. Recebe as entradas do usuário, processa e retorna uma resposta. Ele é responsavel por Processar as solicitações do cliente, Conversar com a model para atualizar ou buscar dados e por fim, dicidir qual a tela(view) deve ser renderizada para o usuário após o processamento.`
```csharp
// Exemplo
public IActionRecult Index()
{
    var produto = new Produto();
    return view(produto);
}
```
#### View
`É a interface com o cliente. Ela recebe as informações fornecidas pelo Controller. Reponsavel por apresentar ao usuaior os resultados processados pela Model, Renderizar paginas Web (HTML, CSS e JS), enviar interações do usuário para o controller.`
```html
// Exemplo de view com razor
<h1>@Model.Nome</h1>
```
---
#### Estrutura de pastas
`Um projeto ASP.NET geralmente tem`
```markdown
|src
   |Controllers
   |Models
   |wwwroot
   |Services
   |Data
   |Program.cs
   |appsettings.json
```
 ---
### Injeção de Depêndencias (DI)
> Injeção de Dependências é um padrão de design de software que se refere à técnica de fornecer objetos ou componentes externamente a um objeto que depende deles. Emoutras palavras, em vez de criar ou instanciar objetos dentro de uma classe ou componente, esses objetos são passados para ele por meio de um contrutor ou método.

Um ponto positivo do .NET é que a injeção de dependencia é uma funcionalidade nativa suportada pelo framework. Ela é implementada por meio da interface IServiceCollection, que permite registrar e configurar os serviços e dependências da aplicação.

Para registrar os serviços, nós devemos utilizar as classes, AddSingleton, AddScoped e AddTransient para especificar como os objetos devem ser criados e gerenciados.
- **AddSingleton:** É usado quando precisamos registrar um objeto que deve ser criado apenas umas vez durante a vida útil da aplicação.
- **AddScoped:** É usado para registrar um objeto que deve ser criado uma vez por solicitação. Isso significa que o objeto e criado quando a solicitação é recebeida e descartado quando a solicitação é concluida. Ele é muito útil quando precisamos trablahr com escopos.
- **AddTransient:** Um dis mais utilizados pelos desenvolvedores .NET. O objeto é criado sempre que um componente o solicita e descartado assim que a operação é concluída.
- 
**Ná prática**
> Exemplo retirado de: https://programadriano.medium.com/net-inje%C3%A7%C3%A3o-de-depend%C3%AAncia-c7475a93b5cb

`Arquivo: Interfaces/ILifeciclesService.cs`
```csharp
namespace API.Interfaces
{
    public interface ILifecycleService
    {
        Datetime DataAtual();
    }
}
```
`Arquivo: Services/LifeciclesService.cs`
```csharp
namespace API.Interfaces
{
    public class LifecycleService : ILifecycleService
    {
        private readonly Datetime _date = DateTime.Now;
        public DateTime DataAtual() => _date;
    }
}
``` 
`Arquivo: Services/Lifecicles2Service.cs`
```csharp
public class Lifecycle2Service : ILifecycleService
{
    private readonly ILifecycleService _lifecycleService;

    public Lifecycle2Service(ILifecycleService lifecycleService)
    {
        _lifecycleService = lifecycleService;
    }

    public DateTime DataAtual() => _lifecycleService.DataAtual();

}
``` 
`Note que as duas classes, LifeCycleService e LifeCycle2Service implementam a interface ILifeCycleService`

O próximo passo para testar as classes é registrar os nossos serviços dentro do nosso Program.cs
```csharp
services.AddSingleton<ILifecycleService, LifecycleService>();
services.AddSingleton<Lifecycle2Service>();
```

Agora vamos criar um controller para testar o fluxo
```csharp
 [ApiController]
    [Route("[controller]")]
    public class LifeCycleServiceController : ControllerBase
    {   
        private readonly ILifecycleService _service;
        private readonly Lifecycle2Service _service2;

        public LifeCycleServiceController(ILifecycleService service, Lifecycle2Service service2)
        {
            _service = service;
            _service2 = service2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<DateTime>();
            result.Add(_service.DataAtual());
            result.Add(_service2.DataAtual());

            return Ok(result);
        }
    }
```
---
### Iniciar um Projeto (webapi)
> Projeto sem nenhuma validção, foi criado para entendermos como funcionam as requisições dentro do ASP.NET
#### O que será criado?
Faremos um CRUD API de produtos com as seguintes operações:

| API                         | Descrição                      |
|-----------------------------|--------------------------------|
| `GET /api/produtos`         | Pegar todos os produtos        |
| `GET /api/produtos/{id}`    | Filtrar por ID                 |
| `POST /api/produtos`        | Adicionar                      |
| `PUT /api/produtos/{id}`    | Atualizar um produto existente |
| `DELETE /api/produtos/{id}` | Deletar                        |

