using System;
using System.Collections.Generic;
using System.Text;

namespace myBOOKs.Models
{
    public enum TipoLivro
    {
        Lido,
        Andamento,
        QuerLer
    }
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Paginas { get; set; }
        public int MarcaPagina { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Observacoes { get; set; }
        public TipoLivro TipoLivro { get; set; }

        public string DataInicioStr { get => DataInicio.ToString("dd/MM/yyyy"); }
        public string DataFimStr { get => DataFim.ToString("dd/MM/yyyy"); }

    }
}
