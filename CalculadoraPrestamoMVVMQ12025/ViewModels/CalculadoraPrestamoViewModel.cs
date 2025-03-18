
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculadoraPrestamoMVVMQ12025.ViewModels
{
    public partial class CalculadoraPrestamoViewModel : ObservableObject
    {
        [ObservableProperty]
        private double monto;

        [ObservableProperty]
        private double tasaAnual;

        [ObservableProperty]
        private double anios;

        [ObservableProperty]
        private string montoPagar;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                if (Monto <= 0)
                {
                    Alerta("ADVERTENCIA", "Ingrese un monto válido");
                } else if (TasaAnual <= 0)
                {
                    Alerta("ADVERTENCIA", "Ingrese una tasa anual válida");
                } else if (Anios <= 0)
                {
                    Alerta("ADVERTENCIA", "Ingrese la cantidad de años válido");
                } else
                {
                    double tasaMensual = (TasaAnual / 100) / 12;
                    double meses = Anios * 12;
                    double pagoMensual = Monto * ((tasaMensual * Math.Pow(1 + tasaMensual, meses)) / (Math.Pow(1 + tasaMensual, meses) - 1));
                    MontoPagar = $"L.{pagoMensual.ToString("F2")}";
                }
            }
            catch (Exception ex) { 
                Alerta("ERROR", ex.Message);
            }            
        }

        [RelayCommand]
        private void Limpiar() {
            Monto = 0;
            TasaAnual = 0;
            Anios = 0;
            MontoPagar = "";
        }
    }
}
