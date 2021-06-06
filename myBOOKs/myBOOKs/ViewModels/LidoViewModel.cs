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
                var livros = await LivroStore.GetItemsAsync(true);
                foreach (var livro in livros)
                {
                    Livros.Add(livro);
                }
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
            //await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        //Função executada ao selecionar um livro
        async void OnItemSelected(Livro livro)
        {
            if (livro == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={livro.Id}");
        }
    }
}
