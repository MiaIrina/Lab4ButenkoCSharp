using ButenkoLab4.Model;


namespace ButenkoLab4.Tools.Navigation
{
	internal enum ViewType
	{
		FormUser,
		Main,
		AddUser,
		ListUser,
		EditUser
	}

	interface INavigationModel
	{
		void Navigate(ViewType viewType);
		void Navigate(ViewType viewType, Person user);
	}
}
