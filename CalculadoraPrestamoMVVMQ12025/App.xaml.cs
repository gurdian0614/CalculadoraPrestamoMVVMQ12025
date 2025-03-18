using CalculadoraPrestamoMVVMQ12025.Views;

namespace CalculadoraPrestamoMVVMQ12025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CalculadoraPrestamoView();
        }
    }
}
