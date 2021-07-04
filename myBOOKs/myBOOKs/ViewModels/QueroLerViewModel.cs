using myBOOKs.Models;
using myBOOKs.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myBOOKs.ViewModels
{
    public class QueroLerViewModel : BaseViewModel
    {
        private Livro _selectedLivro;

        public ObservableCollection<Livro> Livros { get; }
        public Command LoadLivrosCommand { get; }
        public Command AddLivroCommand { get; }
        public Command<Livro> ItemTapped { get; }

        public Command DeletaCommand { get; }
        public Command IniciarLeituraCommand { get; }

        public QueroLerViewModel()
        {
            Livros = new ObservableCollection<Livro>();

            LoadLivrosCommand = new Command(async () => await ExecuteLoadLivrosCommand());
            ItemTapped = new Command<Livro>(OnItemSelected);
            AddLivroCommand = new Command<Livro>(OnAddItem);
            DeletaCommand = new Command<Livro>(OnDelete);
            IniciarLeituraCommand = new Command<Livro>(IniciarLeitura);
        }

        //Popula a coleção de livros
        async Task ExecuteLoadLivrosCommand()
        {
            IsBusy = true;

            try
            {
                Livros.Clear();
                foreach (var livro in await LivroStore.GetItemsAsync(TipoLivro.QuerLer))
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

        //Função executada quando a view é apresentada
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        //Livro selecionado
        public Livro SelectedItem
        {
            get => _selectedLivro;
            set
            {
                SetProperty(ref _selectedLivro, value);
                OnItemSelected(value);
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

        //Função executada ao apertar o botão de adicionar registro
        private async void OnAddItem(Livro livro)
        {
            await Shell.Current.GoToAsync(nameof(CadastroQueroLerPage));
        }

        //Função executada ao selecionar um livro
        async void OnItemSelected(Livro livro)
        {
            if (livro == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CadastroQueroLerPage)}?{nameof(Livro.Id)}={livro.Id}");
        }

        async void IniciarLeitura(Livro livro)
        {
            if (livro == null)
                return;

            livro.TipoLivro = TipoLivro.Andamento;
            livro.DataInicio = DateTime.Now;
            await LivroStore.UpdateItemAsync(livro);
            await ExecuteLoadLivrosCommand();
        }
    }
}
