using ButenkoLab4.Model;
using ButenkoLab4.Tools.Navigation;
using ButenkoLab4.ViewModels;
using System.Windows.Controls;

namespace ButenkoLab4.Views
{
	/// <summary>
	/// Логика взаимодействия для EditView.xaml
	/// </summary>
	public partial class EditView : UserControl, INavigatable
	{
		internal EditView(Person user)
		{
			InitializeComponent();
			DataContext = new EditViewModel(user);
		}
	}
}
