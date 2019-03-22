
using ButenkoLab4.Tools.DataStorage;
using ButenkoLab4.Tools.Managers;
using ButenkoLab4.Tools.Navigation;
using ButenkoLab4.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace Lab4
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IContentOwner
	{


		public ContentControl ContentControl => _contentControl;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainViewModel();
			InitializeApplication();
		}
		private void InitializeApplication()
		{
			StationManager.Initialize(new SerializedDataStorage());
			NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
			NavigationManager.Instance.Navigate(ViewType.Main);
		}
	}
}
