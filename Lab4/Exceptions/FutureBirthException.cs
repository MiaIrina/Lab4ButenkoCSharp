using System;

namespace ButenkoLab4.Exceptions
{
	internal class FutureBirthException : ArgumentException
	{
		public FutureBirthException() : base()
		{

		}
		public FutureBirthException(string date)
			: base($"The day of your birthday can be in future!{date}")
		{

		}
	}
}
