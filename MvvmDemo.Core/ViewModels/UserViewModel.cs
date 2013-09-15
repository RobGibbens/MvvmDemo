using Cirrious.MvvmCross.ViewModels;

namespace MvvmDemo.Core.ViewModels
{
	public class UserViewModel : MvxViewModel
	{
		private string _hello = "Hello MvvmCross";
		public string Hello
		{
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
	}
}
