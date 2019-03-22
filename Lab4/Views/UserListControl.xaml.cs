using ButenkoLab4.Tools.Navigation;
using ButenkoLab4.ViewModels;
using System.Windows.Controls;


namespace ButenkoLab4.Views
{
	/// <summary>
	/// Логика взаимодействия для UserListControl.xaml
	/// </summary>
	public partial class UserListControl : UserControl, INavigatable
	{
		internal UserListControl()
		{
			InitializeComponent();
			DataContext = new UserListViewModel();
		}


	}
}
