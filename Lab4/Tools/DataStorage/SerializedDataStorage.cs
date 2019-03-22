

using ButenkoLab4.Model;
using ButenkoLab4.Tools.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace ButenkoLab4.Tools.DataStorage
{

	internal class SerializedDataStorage : IDataStorage
	{
		private readonly List<Person> _users;

		internal SerializedDataStorage()
		{
			try
			{
				_users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
			}
			catch (FileNotFoundException)
			{
				_users = new List<Person>();
				for (int i = 0; i < 50; i++)
				{
					_users.Add(Randomizer.RandomUser());
				}
				SaveChanges();
			}
		}


		public bool UserExists(string mail)
		{
			return _users.Exists(u => u.Email == mail);
		}

		public Person GetUserByMail(string mail)
		{
			return _users.FirstOrDefault(u => u.Email == mail);
		}

		public void AddPerson(Person user)
		{
			_users.Add(user);
			SaveChanges();
		}
		public List<Person> UsersList
		{
			get { return _users.ToList(); }
		}
		private void SaveChanges()
		{
			SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
		}

		public void RemovePerson(Person user)
		{
			try
			{
				if (_users.Contains(user))
				{
					_users.Remove(user);
				}
				SaveChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void EditPerson(Person previous, Person current)
		{
			int index = _users.FindIndex(i => i.Email.Equals(previous.Email));
			_users[index] = current;
			SaveChanges();
		}
	}
}


