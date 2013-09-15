using Cirrious.MvvmCross.ViewModels;

namespace MvvmDemo.Core.ViewModels
{
	public class UserViewModel : MvxViewModel
	{
		private string _firstName = "";
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; RaisePropertyChanged(() => FirstName); RaisePropertyChanged(() => FullName); }
		}

		private string _lastName = "";
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; RaisePropertyChanged(() => LastName); RaisePropertyChanged(() => FullName); }
		}

		public string FullName { get { return FirstName + " " + LastName; } }
	}
}
