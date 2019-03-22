
using ButenkoLab4.Model;
using ButenkoLab4.Tools;
using ButenkoLab4.Tools.Managers;
using ButenkoLab4.Tools.Navigation;
using System;

namespace ButenkoLab4.ViewModels
{
	internal class UserInfoViewModel : BaseViewModel
	{
		private Person _user;

		#region Fields
		private RelayCommand<object> _exitCommand;
		private RelayCommand<object> _returnCommand;
		#endregion

		public UserInfoViewModel(Person _user)
		{
			this._user = _user;
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
				return _returnCommand ?? (_returnCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.AddUser)));
			}
		}

		public string Name => "Name:" + _user.Name;
		public string Surname => "Surname:" + _user.Surname;
		public string DateOfBirth => "Birthday: " + _user.BirthDay.ToShortDateString();
		public string Email => "Email:" + _user.Email;
		public string IsAdult => _user.IsAdult ? "You are adult" : "You are not adult";
		public string Age => "Age:" + _user.Age.ToString();
		public string SunSign => "Your sun sign:" + _user.WestHoroscope;
		public string ChineseSign => "Your chinese sign:" + _user.ChineseHoroscope;
	}
}
