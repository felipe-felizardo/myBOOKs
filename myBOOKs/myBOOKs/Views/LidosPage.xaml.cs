using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using myBOOKs.ViewModels;

namespace myBOOKs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LidosPage : ContentPage
    {
        LidoViewModel _viewModel;

        public LidosPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LidoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}