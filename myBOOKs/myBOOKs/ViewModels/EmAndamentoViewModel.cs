using myBOOKs.Models;
using myBOOKs.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myBOOKs.ViewModels
{
    public class EmAndamentoViewModel : BaseViewModel
    {
        private Livro _selectedLivro;

        public ObservableCollection<Livro> Livros { get; }
        public Command LoadLivrosCommand { get; }
        public Command AddLivroCommand { get; }
        public Command<Livro> ItemTapped { get; }
        public Command DeletaCommand { get; }
        public Command FinalizaLeituraCommand { get; }

        public EmAndamentoViewModel()
        {
            Livros = new ObservableCollection<Livro>();

            LoadLivrosCommand = new Command(async () => await ExecuteLoadLivrosCommand());
            ItemTapped = new Command<Livro>(OnItemSelected);
            AddLivroCommand = new Command(OnAddItem);
            DeletaCommand = new Command<Livro>(OnDelete);
            FinalizaLeituraCommand = new Command<Livro>(FinalizaLeitura);
        }

        //Popula a coleção de livros
        async Task ExecuteLoadLivrosCommand()
        {
            IsBusy = true;

            try
            {
                Livros.Clear();
                foreach (var livro in await LivroStore.GetItemsAsync(TipoLivro.Andamento))
                    Livros.Add(livro);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //Função que deleta um livro
        private async void OnDelete(Livro livro)
        {
            try
            {
                if (livro.Id != 0)
                    await LivroStore.DeleteItemAsync(livro.Id);

                await ExecuteLoadLivrosCommand();
            }
            catch (Exception)
            {
                Debug.WriteLine("Falha ao excluir o livro");
            }
        }

        //Função executada quando a view é apresentada
        public async void OnAppearing()
        {
            IsBusy = true;
            SelectedLivro = null;
            await ExecuteLoadLivrosCommand();
        }

        //Livro selecionado
        public Livro SelectedLivro
        {
            get => _selectedLivro;
            set
            {
                SetProperty(ref _selectedLivro, value);
                OnItemSelected(value);
            }
        }

        //Função executada ao apertar o botão de adicionar registro
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CadastroEmAndamentoPage));
        }

        //Função executada ao selecionar um livro
        async void OnItemSelected(Livro livro)
        {
            if (livro == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CadastroEmAndamentoPage)}?{nameof(Livro.Id)}={livro.Id}");
        }

        async void FinalizaLeitura(Livro livro)
        {
            if (livro == null)
                return;

            livro.TipoLivro = TipoLivro.Lido;
            livro.DataFim = DateTime.Now;
            await LivroStore.UpdateItemAsync(livro);
            await ExecuteLoadLivrosCommand();
        }
    }
}
