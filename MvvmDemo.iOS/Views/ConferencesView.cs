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
	public class ConferencesView : MvxViewController
	{
		public override void ViewDidLoad()
		{
			View = new UIView() { BackgroundColor = UIColor.White };
			base.ViewDidLoad();

			var showDetailButton = new UIButton {};
			showDetailButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showDetailButton.Frame = new RectangleF(10,200, 300,100);
			showDetailButton.SetTitle("Show Detail", UIControlState.Normal);
			Add(showDetailButton);

			var set = this.CreateBindingSet<ConferencesView, ConferencesViewModel>();
			set.Bind(showDetailButton).To(vm => vm.ShowDetailCommand);
			set.Apply();
		}
	}
}
