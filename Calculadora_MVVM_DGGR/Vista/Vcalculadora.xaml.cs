using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Calculadora_MVVM_DGGR.ViewModel;

namespace Calculadora_MVVM_DGGR.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vcalculadora : ContentPage
    {
        public Vcalculadora()
        {
            InitializeComponent();
        }
    }
}