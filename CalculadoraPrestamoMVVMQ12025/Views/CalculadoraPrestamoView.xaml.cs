using CalculadoraPrestamoMVVMQ12025.ViewModels;

namespace CalculadoraPrestamoMVVMQ12025.Views;

public partial class CalculadoraPrestamoView : ContentPage
{
	CalculadoraPrestamoViewModel viewModel;
	public CalculadoraPrestamoView()
	{
		InitializeComponent();
		viewModel = new CalculadoraPrestamoViewModel();
		BindingContext = viewModel;
	}
}