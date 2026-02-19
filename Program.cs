using BibliotecaApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//criação do banco de dados, aqui é onde a gente configura o Entity Framework, dizendo qual banco de dados vamos usar, nesse caso, o Sqlite. 
// O Entity Framework é um framework de mapeamento objeto-relacional (ORM) para .NET que facilita o acesso e manipulação de bancos de dados relacionais. Ele permite que os desenvolvedores trabalhem com dados usando objetos .NET, em vez de escrever consultas SQL diretamente. O Entity Framework suporta vários provedores de banco de dados, incluindo SQL Server, SQLite, MySQL, PostgreSQL e outros. Ele oferece recursos como mapeamento de classes para tabelas, consultas LINQ, migrações de banco de dados e muito mais.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

var app = builder.Build();



//GET AUTORES - VAI NO BANCO DE DADOS E PEGA TODOS OS AUTORES
app.MapGet("/", async (AppDbContext db ) =>
{
    return "Bem-vindo à API da Biblioteca!";
});


// explicação da linha de código: 30
// AppDbContext é o contexto do banco de dados, que é a classe que representa a conexão com o banco de dados e as tabelas.
// O método ToList() é usado para converter o resultado da consulta em uma lista de objetos, que pode ser retornada como resposta da API.
// O método ToList() é parte do LINQ (Language Integrated Query) e é usado para executar a consulta e obter os resultados em forma de lista.
// Nesse caso, ele está sendo usado para obter todos os autores do banco de dados e retornar essa lista como resposta da API.
// AppDbContext é a classe e o db é o nome do objeto (como se fosse a criação de uma variavel) que eu to criando, 
// usamos db por padrao, mas poderia ser qualquer nome, o importante é que ele seja do tipo AppDbContext. 

//GET AUTORES - VAI NO BANCO DE DADOS E PEGA TODOS OS AUTORES
app.MapGet("/autores", async (AppDbContext db ) => {
    return await db.Autores.ToListAsync();
    // caminho do return: vou no banco de dados, ai vou na tabela autores e pega todos os registros, ai o tolist transforma em lista e retorna para mim.
});

// GET AUTORES POR ID - VAI NO BANCO DE DADOS E PEGA O AUTOR COM O ID ESPECIFICADO
app.MapGet("/autores/{id}", async (int id, AppDbContext db) => {
    var autor = await db.Autores.FindAsync(id);
    // Crio a variavel autor, que espera a o banco ir na tabela autores, ai o findasync procura na tabela times o elemento id. 

    return autor is not null ? Results.Ok(autor) : Results.NotFound("Time não encontrado."); //codigo ternario, se o autor for diferente de null, ou seja, se ele existir, retorna ok com o autor, se não existir, retorna not found.
    // caminho do return: vou no banco de dados, ai vou na tabela autores e procura o registro com o id especificado, se encontrar retorna o autor, se não encontrar retorna not found.
});


//POST AUTORES - ADICIONA UM NOVO AUTOR NO BANCO DE DADOS
app.MapPost("/autores", async (AppDbContext db, Autor novoAutor) => {
    db.Autores.Add(novoAutor); // vou no banco de dados, ai vou na tabela autores e adiciono o autor que foi enviado no corpo da requisição.
    await db.SaveChangesAsync(); // salvo as mudanças no banco de dados, ou seja, efetivo a adição do autor.

    return Results.Created($"O autor: {novoAutor.Nome} foi incluido no banco de dados com sucesso.", novoAutor); // retorno o status code 201 Created, com o caminho do novo recurso criado e o objeto do autor criado.
    // results - classe que representa o resultado de uma operação, ela tem vários métodos estáticos para retornar diferentes tipos de respostas HTTP, como Ok, NotFound, Created, etc.

}); 

app.Run();
