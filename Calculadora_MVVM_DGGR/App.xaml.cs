using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Calculadora_MVVM_DGGR.Vista;

namespace Calculadora_MVVM_DGGR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Vcalculadora();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
