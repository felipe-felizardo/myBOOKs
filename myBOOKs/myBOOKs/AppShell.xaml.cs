using myBOOKs.ViewModels;
using myBOOKs.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace myBOOKs
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CadastroEmAndamentoPage), typeof(CadastroEmAndamentoPage));
            Routing.RegisterRoute(nameof(CadastroQueroLerPage), typeof(CadastroQueroLerPage));
            Routing.RegisterRoute(nameof(CadastroLidoPage), typeof(CadastroLidoPage));
        }

    }
}
