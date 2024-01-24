using Calculadora_MVVM_DGGR.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculadora_MVVM_DGGR.ViewModel
{
    public class VMcalculadora : INotifyPropertyChanged
    {
        private Mcalculadora calculatorModel = new Mcalculadora();
        private bool clickedOperator;
        private string selectedOperator;
        private string _result;

        private bool _isOperatorSelected;
        public bool IsOperatorSelected
        {
            get { return _isOperatorSelected; }
            set
            {
                if (_isOperatorSelected != value)
                {
                    _isOperatorSelected = value;
                    OnPropertyChanged(nameof(IsOperatorSelected));
                }
            }
        }

        private void HandleOperator(string oper)
        {
            clickedOperator = true;
            selectedOperator = oper;
            calculatorModel.PrimerNumero = Convert.ToDecimal(Result);
            IsOperatorSelected = true;
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public ICommand NumberCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand OperatorCommand { get; private set; }
        public ICommand PercentageCommand { get; private set; }
        public ICommand EqualCommand { get; private set; }
        public ICommand PuntoCommmand { get; private set; }


        public VMcalculadora()
        {
            NumberCommand = new Command<string>(HandleNumber);
            ClearCommand = new Command(HandleClear);
            DeleteCommand = new Command(HandleDelete);
            OperatorCommand = new Command<string>(HandleOperator);
            PercentageCommand = new Command(HandlePercentage);
            EqualCommand = new Command(HandleEqual);
            PuntoCommmand = new Command<string>(puntoNumber);
            Result = "0";
        }
        private void puntoNumber(string number)
        {
            if (Result == "0" || clickedOperator)
            {
                Result = (number == ".") ? "0." : number;
                clickedOperator = false;
            }
            else
            {
                if (number == "." && !Result.Contains("."))
                {
                    Result += number;
                }
                else if (number != ".")
                {
                    Result += number;
                }
            }
        }
        private void HandleNumber(string number)
        {
            IsOperatorSelected = false;
            if (Result == "0" || clickedOperator)
            {
                Result = number;
                clickedOperator = false;
            }
            else
            {
                Result += number;
            }
        }

        private void HandleClear()
        {
            IsOperatorSelected = false;
            Result = "0";
            clickedOperator = false;
            calculatorModel.PrimerNumero = 0;
        }

        private void HandleDelete()
        {
            IsOperatorSelected = false;
            string currentResult = Result;
            if (currentResult.Length > 0)
            {
                Result = currentResult.Substring(0, currentResult.Length - 1);
                if (Result.Length == 0 || Result == "-")
                {
                    Result = "0";
                }
            }
        }
        private void HandlePercentage()
        {
            try
            {
                decimal percentValue = Convert.ToDecimal(Result);
                Result = (percentValue / 100).ToString("0.##");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void HandleEqual()
        {
            IsOperatorSelected = false;
            try
            {
                decimal segundoNumero = Convert.ToDecimal(Result);
                string finalResult = calculatorModel.Calcular(calculatorModel.PrimerNumero, segundoNumero, selectedOperator).ToString("0.##");
                Result = finalResult;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void DisplayAlert(string title, string message, string button)
        {
            await App.Current.MainPage.DisplayAlert(title, message, button);
        }
    }
}
