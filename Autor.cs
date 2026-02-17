using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace BibliotecaApi
{
    public class Autor
    {
        public int Id { get; set; }
        public string ?Nome { get; set; }

        public string ?Nacionalidade { get; set; }   
        public DateTime DataNascimento { get; set; } 

        public string ?Livros { get; set; }
    }
}