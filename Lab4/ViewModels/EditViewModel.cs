using ButenkoLab4.Model;
using ButenkoLab4.Tools;
using ButenkoLab4.Tools.Managers;
using ButenkoLab4.Tools.Navigation;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ButenkoLab4.ViewModels
{
	internal class EditViewModel : BaseViewModel
	{
		#region
		private string _name;
		private string _surname;
		private string _email;
		private DateTime _birthday;
		private Person _toEdit;
		private Person _user;
		private RelayCommand<object> _exitCommand;
		private RelayCommand<object> _returnCommand;
		private RelayCommand<object> _saveCommand;

		#endregion
		public Person ToEdit
		{
			get
			{
				return _toEdit;
			}
			private set
			{
				_toEdit = value;
			}
		}
		public RelayCommand<Object> ExitCommand
		{
			get
			{
				return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0)));
			}
		}
		public RelayCommand<Object> ReturnCommand
		{
			get
			{
				return _returnCommand ?? (_returnCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.ListUser)));
			}
		}
		private async void Edit(object obj)
		{
			LoaderManager.Instance.ShowLoader();

			bool result = await Task.Run(() => {
				try
				{
					Thread.Sleep(1000);

					_user = new Person(Name, Surname, Birthday, Email);
                                       
				       if (!ToEdit.Email.Equals(Email) && StationManager.DataStorage.UserExists(Email))
					{
						throw new Exception("User with such email already exists!");
					}

					if (_user.IsBirthDay)
					{
						MessageBox.Show("Happy birthday!");
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return false;
				}
				if (_user == null)
				{
					return false;
				}
				return true;
			});
			LoaderManager.Instance.HideLoader();

			if (result)
			{
				StationManager.DataStorage.EditPerson(ToEdit, _user);
				NavigationManager.Instance.Navigate(ViewType.ListUser);
			}

		}
		public string Name
		{

			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged();
			}
		}
		public string Surname
		{

			get
			{
				return _surname;
			}
			set
			{
				_surname = value;
				OnPropertyChanged();
			}
		}
		public string Email
		{

			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnPropertyChanged();
			}
		}
		public DateTime Birthday
		{

			get
			{
				return _birthday;
			}
			set
			{
				_birthday = value;
				OnPropertyChanged();
			}
		}

		public EditViewModel(Person user)
		{
			Name = user.Name;
			Surname = user.Surname;
			Email = user.Email;
			Birthday = user.BirthDay;
			ToEdit = user;
		}
		public RelayCommand<Object> BeginCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new RelayCommand<object>(
						  Edit, o => CanExecuteCommand()));
			}
		}



		private bool CanExecuteCommand() => !string.IsNullOrEmpty(_email)
				&& !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname)

				;
	}
}
