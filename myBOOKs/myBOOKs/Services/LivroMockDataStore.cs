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
                new Livro { Id = Guid.NewGuid().ToString(), Titulo = "A Revolução Dos Bichos", Autor = "George Orwell", Observacao = "Observação." },
                new Livro { Id = Guid.NewGuid().ToString(), Titulo = "Como As Democracias Morrem", Autor = "Steven Levitsky, Daniel Ziblatt", Observacao = "Observação." },
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

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldLivro = livros.Where((Livro arg) => arg.Id == id).FirstOrDefault();
            livros.Remove(oldLivro);

            return await Task.FromResult(true);
        }

        public async Task<Livro> GetItemAsync(string id)
        {
            return await Task.FromResult(livros.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Livro>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(livros);
        }
    }
}