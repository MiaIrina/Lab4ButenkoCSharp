using ButenkoLab4.Model;
using ButenkoLab4.Tools.DataStorage;
using System;
using System.Windows;

namespace ButenkoLab4.Tools.Managers
{
	internal static class StationManager
	{
		private static IDataStorage _dataStorage;

		//internal static Person CurrentUser { get; set; }

		internal static IDataStorage DataStorage
		{
			get { return _dataStorage; }
		}

		internal static void Initialize(IDataStorage dataStorage)
		{
			_dataStorage = dataStorage;
		}

		internal static void CloseApp()
		{
			MessageBox.Show("Close");
			Environment.Exit(1);
		}
	}
}
