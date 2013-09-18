using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MvvmDemo.Core.ViewModels;

namespace MvvmDemo.iOS.Views
{
	[Register("ConferencesView")]
	public class ConferencesView : MvxTableViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var source = new MvxStandardTableViewSource(TableView, "TitleText name;ImageUrl imageUrl");
			TableView.Source = source;

			var set = this.CreateBindingSet<ConferencesView, ConferencesViewModel>();
			set.Bind(source).To(vm => vm.Conferences);
			set.Apply();

			TableView.ReloadData();
		}
	}
}
