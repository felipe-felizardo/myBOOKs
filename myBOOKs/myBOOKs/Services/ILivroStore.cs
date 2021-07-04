using myBOOKs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBOOKs.Services
{
    public interface ILivroStore<T>
    {
        Task<bool> AddItemAsync(T livro);
        Task<bool> UpdateItemAsync(T livro);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(TipoLivro tipoLivro);
        Task<int> GetNewId();

    }
}
