using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options) {} //isso é documentação do Entity Framework, precisa colocar para o código rodar.

        public DbSet<Autor> Autores => Set<Autor>(); //aqui pega a classe autor e tranforma na tabela chamada autores, o nome da tabela é o nome da classe no plural. 
        //O DbSet é um recurso do Entity Framework que representa uma coleção de entidades do tipo especificado, nesse caso, Autor. 
        // Ele permite realizar operações de consulta e manipulação de dados na tabela correspondente no banco de dados.

        

        
    }
}