using ButenkoLab4.Model;

using ButenkoLab4.Views;
using System;


namespace ButenkoLab4.Tools.Navigation
{
	internal class InitializationNavigationModel : BaseNavigationModel
	{
		public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
		{

		}

		protected override void InitializeView(ViewType viewType)
		{
			switch (viewType)
			{



				case ViewType.Main:
					ViewsDictionary.Add(viewType, new MainMenuControl());
					break;
				case ViewType.AddUser:
					ViewsDictionary.Add(viewType, new UserHoroscopeControl());
					break;
				case ViewType.ListUser:
					ViewsDictionary.Add(viewType, new UserListControl());
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
			}
		}
		protected override void InitializeView(ViewType viewType, Person user)
		{
			switch (viewType)
			{


				case ViewType.FormUser:
					ViewsDictionary.Add(viewType, new UserInfoView(user));
					break;
				case ViewType.EditUser:
					ViewsDictionary.Add(viewType, new EditView(user));
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
			}
		}
	}
}
