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
    public partial class QueroLerPage : ContentPage
    {
        QueroLerViewModel _viewModel;

        public QueroLerPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new QueroLerViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}