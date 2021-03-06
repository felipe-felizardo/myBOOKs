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
    public class LidoViewModel : BaseViewModel
    {
        private Livro _selectedLivro;

        public ObservableCollection<Livro> Livros { get; }
        public Command LoadLivrosCommand { get; }
        public Command AddLivroCommand { get; }
        public Command<Livro> ItemTapped { get; }

        public LidoViewModel()
        {
            Livros = new ObservableCollection<Livro>();

            LoadLivrosCommand = new Command(async () => await ExecuteLoadLivrosCommand());
            ItemTapped = new Command<Livro>(OnItemSelected);
            AddLivroCommand = new Command(OnAddItem);
        }

        //Popula a coleção de livros
        async Task ExecuteLoadLivrosCommand()
        {
            IsBusy = true;

            try
            {
                Livros.Clear();
                foreach (var livro in await LivroStore.GetItemsAsync(TipoLivro.Lido))
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
            SelectedLivro = null;
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
            await Shell.Current.GoToAsync(nameof(CadastroLidoPage));
        }

        //Função executada ao selecionar um livro
        async void OnItemSelected(Livro livro)
        {
            if (livro == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CadastroLidoPage)}?{nameof(Livro.Id)}={livro.Id}");
        }
    }
}
