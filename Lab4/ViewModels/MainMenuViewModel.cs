using ButenkoLab4.Tools;
using ButenkoLab4.Tools.Managers;
using ButenkoLab4.Tools.Navigation;
using System;

namespace ButenkoLab4.ViewModels
{
	class MainMenuViewModel : BaseViewModel
	{

		#region
		private RelayCommand<object> _exitCommand;
		private RelayCommand<object> _addUserCommand;
		private RelayCommand<object> _usersListCommand;

		#endregion
		public RelayCommand<Object> ExitCommand
		{
			get
			{
				return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0)));
			}
		}
		public RelayCommand<Object> AddUserCommand
		{
			get
			{
				return _exitCommand ?? (_addUserCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.AddUser)));
			}
		}
		public RelayCommand<Object> UsersListCommand
		{
			get
			{
				return _usersListCommand ?? (_usersListCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.ListUser)));
			}
		}
	}
}
