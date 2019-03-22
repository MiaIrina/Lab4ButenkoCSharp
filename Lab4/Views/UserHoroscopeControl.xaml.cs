
using System.Windows.Controls;
using ButenkoLab4.Tools.Navigation;
using ButenkoLab4.ViewModels;
namespace ButenkoLab4.Views
{
	/// <summary>
	/// Логика взаимодействия для UserHoroscopeControl.xaml
	/// </summary>
	public partial class UserHoroscopeControl : UserControl, INavigatable
	{
		internal UserHoroscopeControl()
		{
			InitializeComponent();
			DataContext = new HoroscopViewModel();
		}
	}
}
