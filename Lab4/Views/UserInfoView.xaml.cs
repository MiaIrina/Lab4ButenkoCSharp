using ButenkoLab4.Model;
using ButenkoLab4.Tools.Navigation;
using ButenkoLab4.ViewModels;

using System.Windows.Controls;


namespace ButenkoLab4.Views
{
	/// <summary>
	/// Логика взаимодействия для UserInfoView.xaml
	/// </summary>
	public partial class UserInfoView : UserControl, INavigatable

	{
		internal UserInfoView(Person user)
		{
			InitializeComponent();
			DataContext = new UserInfoViewModel(user);
		}
	}
}
