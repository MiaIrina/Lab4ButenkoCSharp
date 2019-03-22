

using ButenkoLab4.Model;
using System.Collections.Generic;

namespace ButenkoLab4.Tools.DataStorage
{
	internal interface IDataStorage
	{
		bool UserExists(string mail);

		Person GetUserByMail(string mail);

		void AddPerson(Person user);
		void RemovePerson(Person user);
		void EditPerson(Person previous, Person current);
		List<Person> UsersList { get; }
	}
}