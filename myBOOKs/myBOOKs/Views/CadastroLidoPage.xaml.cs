using myBOOKs.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBOOKs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroLidoPage : ContentPage
    {
        CadastroLidoViewModel _viewModel;

        public CadastroLidoPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CadastroLidoViewModel();
        }
    }
}