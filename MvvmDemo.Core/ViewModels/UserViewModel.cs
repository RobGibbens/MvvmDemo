using Cirrious.MvvmCross.ViewModels;

namespace MvvmDemo.Core.ViewModels
{
	public class UserViewModel : MvxViewModel
	{
		private string _firstName = "";
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; RaisePropertyChanged(() => FirstName); }
		}
	}
}
