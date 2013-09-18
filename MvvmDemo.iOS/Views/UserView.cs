using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MvvmDemo.iOS.Views
{
	[Register("UserView")]
	public class UserView : MvxViewController
	{
		public override void ViewDidLoad()
		{
			View = new UIView() { BackgroundColor = UIColor.White };
			base.ViewDidLoad();

			var fullNameLabel = new UILabel(new RectangleF(10, 80, 300, 40));
			Add(fullNameLabel);

			var firstNameTextBox = new UITextField(new RectangleF(10, 120, 300, 40));
			firstNameTextBox.BorderStyle = UITextBorderStyle.Line;
			Add(firstNameTextBox);


			var lastNameTextBox = new UITextField(new RectangleF(10, 180, 300, 40));
			lastNameTextBox.BorderStyle = UITextBorderStyle.Line;
			Add(lastNameTextBox);


			var set = this.CreateBindingSet<UserView, Core.ViewModels.UserViewModel>();
			set.Bind(fullNameLabel).To(vm => vm.FullName);
			set.Bind(firstNameTextBox).To(vm => vm.FirstName);
			set.Bind(lastNameTextBox).To(vm => vm.LastName);


			set.Apply();
		}
	}
}
