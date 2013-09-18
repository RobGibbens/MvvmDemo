using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace MvvmDemo.Droid.Views
{
	using global::Android.Views;

	[Activity(Label = "Conferences")]
	public class ConferencesView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.ActionBar);

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ConferencesView);
		}


	}

}