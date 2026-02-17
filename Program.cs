using BibliotecaApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//criação do banco de dados, aqui é onde a gente configura o Entity Framework, dizendo qual banco de dados vamos usar, nesse caso, o Sqlite. 
// O Entity Framework é um framework de mapeamento objeto-relacional (ORM) para .NET que facilita o acesso e manipulação de bancos de dados relacionais. Ele permite que os desenvolvedores trabalhem com dados usando objetos .NET, em vez de escrever consultas SQL diretamente. O Entity Framework suporta vários provedores de banco de dados, incluindo SQL Server, SQLite, MySQL, PostgreSQL e outros. Ele oferece recursos como mapeamento de classes para tabelas, consultas LINQ, migrações de banco de dados e muito mais.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

var app = builder.Build();

app.MapGet("/", () => "API da Biblioteca!");

app.Run();
