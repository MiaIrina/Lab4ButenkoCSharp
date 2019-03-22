using ButenkoLab4.Model;
using ButenkoLab4.Tools;
using ButenkoLab4.Tools.Managers;
using ButenkoLab4.Tools.Navigation;
using System.Collections.ObjectModel;
using System.Linq;


namespace ButenkoLab4.ViewModels
{
	internal class UserListViewModel : BaseViewModel
	{
		#region
		private ObservableCollection<Person> _users;
		private RelayCommand<object> _showAllCommand;
		private RelayCommand<object> _sortCommand;
		private RelayCommand<object> _deleteCommand;
		private RelayCommand<object> _returnCommand;
		private RelayCommand<object> _editCommand;

		private int _sortBy;
		private int _filterByWestHoroscope;
		private int _filterByChineseHoroscope;
		private int _sortByAnother;
		private Person _selectedPerson;
		private bool _isPersonSelected;
		#endregion
		public ObservableCollection<string> ZodiacContent { get; private set; }
		public ObservableCollection<string> ChineseContent { get; private set; }

		public Person SelectedPerson
		{
			get
			{
				return _selectedPerson;
			}
			set
			{
				_selectedPerson = value;
				if (_selectedPerson != null)
					IsPersonSelected = true;
				else
				{
					IsPersonSelected = false;
				}
				OnPropertyChanged();
			}
		}
		public string SelectedItemWest { get; set; }
		public string SelectedItemChinese { get; set; }

		public int SortBy
		{
			get
			{
				return _sortBy;
			}
			set
			{
				_sortBy = value;
				OnPropertyChanged();
			}
		}
		public int FilterByWestHoroscope
		{
			get
			{
				return _filterByWestHoroscope;
			}
			set
			{
				_filterByWestHoroscope = value;
				OnPropertyChanged();
			}
		}
		public int SortByAnother
		{
			get
			{
				return _sortByAnother;
			}
			set
			{
				_sortByAnother = value;
				OnPropertyChanged();
			}
		}
		public int FilterByChineseHoroscope
		{
			get
			{
				return _filterByChineseHoroscope;
			}
			set
			{
				_filterByChineseHoroscope = value;
				OnPropertyChanged();
			}
		}
		private void FilterByZodiac(int index)
		{

			if (index != 0)
			{

				Users = new ObservableCollection<Person>(Users.Where(user => user.WestHoroscope.Equals(ZodiacContent[index])));

			}

		}
		private void FilterByChineseYear(int index)
		{


			if (index != 0)
			{
				Users = new ObservableCollection<Person>(Users.Where(user => user.ChineseHoroscope.Equals(ChineseContent[index])));

			}


		}

		private void SortByOthers(int index)
		{

			switch (index)
			{
				case 1:
					Users = new ObservableCollection<Person>(Users.Where(user => user.IsAdult));
					break;
				case 2:
					Users = new ObservableCollection<Person>(Users.Where(user => user.IsBirthDay));
					break;
			}

		}
		public ObservableCollection<Person> Users
		{
			get => _users;
			private set
			{
				_users = value;
				OnPropertyChanged();
			}
		}
		internal UserListViewModel()
		{
			Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
			ZodiacContent = new ObservableCollection<string>(Person.Zodiac);
			ZodiacContent.Insert(0, "All");
			ChineseContent = new ObservableCollection<string>(Person.ChineseYear);
			ChineseContent.Insert(0, "All");
			SelectedItemWest = "All";
			SelectedItemChinese = "All";

		}
		private void SortByName()
		{
			Users = new ObservableCollection<Person>(Users.OrderBy(user => user.Name));


		}
		private void SortBySurname()
		{

			Users = new ObservableCollection<Person>(Users.OrderBy(user => user.Surname));



		}
		private void SortByEmail()
		{

			Users = new ObservableCollection<Person>(Users.OrderBy(user => user.Email));



		}
		private void SortByAge()
		{

			Users = new ObservableCollection<Person>(Users.OrderBy(user => user.Age));



		}
		public RelayCommand<object> SortCommand
		{
			get
			{
				return _sortCommand ?? (_sortCommand = new RelayCommand<object>(o => SortFunction()));
			}
		}
		public RelayCommand<object> EditCommand
		{
			get
			{
				return _editCommand ?? (_editCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.EditUser, SelectedPerson)));
			}
		}
		private void SortFunction()
		{
			ShowAllUsers();
			switch (SortBy)
			{

				case 1:
					SortByName();
					break;
				case 2:
					SortBySurname();
					break;
				case 3:
					SortByEmail();
					break;
				case 4:
					SortByAge();
					break;

			}
			FilterByChineseYear(FilterByChineseHoroscope);
			FilterByZodiac(FilterByWestHoroscope);
			SortByOthers(SortByAnother);
		}
		public RelayCommand<object> ShowAllCommand
		{
			get { return _showAllCommand ?? (_showAllCommand = new RelayCommand<object>(o => ShowAllUsers())); }
		}
		public RelayCommand<object> DeleteCommand
		{
			get { return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(o => DeleteUser(SelectedPerson))); }
		}
		public RelayCommand<object> ReturnCommand
		{
			get { return _returnCommand ?? (_returnCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Main))); }
		}
		private void ShowAllUsers()
		{

			Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);


		}
		public bool IsPersonSelected
		{
			get
			{
				return _isPersonSelected;
			}
			private set
			{
				_isPersonSelected = value;
				OnPropertyChanged();
			}
		}
		private void DeleteUser(Person user)
		{
			StationManager.DataStorage.RemovePerson(user);
			Users.Remove(user);

		}



	}
}
