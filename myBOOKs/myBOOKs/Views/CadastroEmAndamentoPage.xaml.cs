using myBOOKs.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBOOKs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroEmAndamentoPage : ContentPage
    {
        CadastroEmAndamentoViewModel _viewModel;

        public CadastroEmAndamentoPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CadastroEmAndamentoViewModel();
        }
    }
}