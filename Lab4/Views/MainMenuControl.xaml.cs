
using ButenkoLab4.Tools.Navigation;
using ButenkoLab4.ViewModels;
using System.Windows.Controls;


namespace ButenkoLab4.Views
{

	public partial class MainMenuControl : UserControl, INavigatable
	{
		internal MainMenuControl()
		{
			InitializeComponent();
			DataContext = new MainMenuViewModel();
		}
	}
}
