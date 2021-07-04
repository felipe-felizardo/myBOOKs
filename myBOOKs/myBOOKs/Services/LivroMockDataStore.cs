using myBOOKs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBOOKs.Services
{
    public class LivroMockDataStore : ILivroStore<Livro>
    {
        readonly List<Livro> livros;

        public LivroMockDataStore()
        {
            livros = new List<Livro>()
            {
                new Livro 
                { 
                    Id = 1,
                    TipoLivro = TipoLivro.QuerLer,
                    Titulo = "A Revolução Dos Bichos", 
                    Autor = "George Orwell",
                    Paginas = 300,
                    Observacoes = "Observação." 
                },
                new Livro 
                { 
                    Id = 2,
                    TipoLivro = TipoLivro.Andamento,
                    Paginas = 350,
                    MarcaPagina = 200,
                    DataInicio = new DateTime(2021, 01, 29),
                    Titulo = "Como As Democracias Morrem", 
                    Autor = "Steven Levitsky, Daniel Ziblatt",
                    Observacoes = "Observação." 
                },
                new Livro
                {
                    Id = 3,
                    TipoLivro = TipoLivro.Lido,
                    Paginas = 400,
                    MarcaPagina = 400,
                    DataInicio = new DateTime(2021, 01, 29),
                    DataFim = new DateTime(2021, 02, 15),
                    Titulo = "Neuromance",
                    Autor = "William Gibson",
                    Observacoes = "Observação."
                },
            };
        }

        public async Task<bool> AddItemAsync(Livro livro)
        {
            livros.Add(livro);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Livro livro)
        {
            var oldLivro = livros.Where((Livro arg) => arg.Id == livro.Id).FirstOrDefault();
            livros.Remove(oldLivro);
            livros.Add(livro);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldLivro = livros.Where((Livro arg) => arg.Id == id).FirstOrDefault();
            livros.Remove(oldLivro);

            return await Task.FromResult(true);
        }

        public async Task<Livro> GetItemAsync(int id)
        {
            return await Task.FromResult(livros.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Livro>> GetItemsAsync(TipoLivro tipoLivro)
        {
            return await Task.FromResult(livros.Where((livro) => livro.TipoLivro == tipoLivro));
        }

        public async Task<int> GetNewId()
        {
            return await Task.FromResult(livros.OrderByDescending((x) => x.Id).FirstOrDefault().Id + 1);
        }
    }
}