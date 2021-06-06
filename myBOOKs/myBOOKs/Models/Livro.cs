using System;
using System.Collections.Generic;
using System.Text;

namespace myBOOKs.Models
{
    public class Livro
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Paginas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Observacao { get; set; }
        public bool Finalizado { get; set; }
        public enum Tipo
        {
            Lido,
            Andamento,
            QuerLer
        }
    }
}
