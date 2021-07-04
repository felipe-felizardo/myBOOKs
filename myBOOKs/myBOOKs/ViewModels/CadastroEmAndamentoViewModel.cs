using myBOOKs.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace myBOOKs.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class CadastroEmAndamentoViewModel : BaseViewModel
    {
        private int id;
        private string titulo;
        private string autor;
        private string observacoes;
        private DateTime dataInicio = DateTime.Now;
        private int paginas;
        private int marcaPagina;

        public CadastroEmAndamentoViewModel()
        {
            SalvarCommand = new Command(OnSave, ValidaDados);
            this.PropertyChanged += (_, __) => SalvarCommand.ChangeCanExecute();
            Title = "Novo livro em andamento";
        }

        private bool ValidaDados()
        {
            return !string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(autor) && (paginas > 0);
        }

        public string Id
        {
            get { return id.ToString(); }
            set
            {
                id = int.Parse(value);
                LoadLivro(id);
            }
        }

        public string Titulo
        {
            get => titulo;
            set => SetProperty(ref titulo, value);
        }

        public string Autor
        {
            get => autor;
            set => SetProperty(ref autor, value);
        }

        public string Observacoes
        {
            get => observacoes;
            set => SetProperty(ref observacoes, value);
        }

        public DateTime DataInicio
        {
            get => dataInicio;
            set => SetProperty(ref dataInicio, value);
        }

        public int Paginas
        {
            get => paginas;
            set => SetProperty(ref paginas, value);
        }

        public int MarcaPagina
        {
            get => marcaPagina;
            set => SetProperty(ref marcaPagina, value);
        }

        public Command SalvarCommand { get; }
        public Command DeletaCommand { get; }

        private async void OnSave()
        {
            Livro livro = new Livro()
            {
                Id = id,
                Titulo = Titulo,
                Autor = Autor,
                Observacoes = Observacoes,
                DataInicio = DataInicio,
                Paginas = Paginas,
                MarcaPagina = MarcaPagina,
                TipoLivro = TipoLivro.Andamento,
            };

            if (id != 0)
                await LivroStore.UpdateItemAsync(livro);
            else
            {
                livro.Id = await LivroStore.GetNewId();
                await LivroStore.AddItemAsync(livro);
            }

            await Shell.Current.GoToAsync("..");
        }

        public async void LoadLivro(int livroId)
        {
            try
            {
                var livro = await LivroStore.GetItemAsync(livroId);
                Titulo = Title = livro.Titulo;
                Autor = livro.Autor;
                Observacoes = livro.Observacoes;
                DataInicio = livro.DataInicio;
                Paginas = livro.Paginas;
                MarcaPagina = livro.MarcaPagina;
            }
            catch (Exception)
            {
                Debug.WriteLine("Falha ao excluir o livro");
            }
        }
    }
}
