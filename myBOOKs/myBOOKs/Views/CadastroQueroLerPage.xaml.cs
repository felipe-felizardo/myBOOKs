using myBOOKs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBOOKs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroQueroLerPage : ContentPage
    {
        CadastroQueroLerViewModel _viewModel;

        public CadastroQueroLerPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CadastroQueroLerViewModel();
        }
    }
}