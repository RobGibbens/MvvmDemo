using Cirrious.CrossCore.IoC;

namespace MvvmDemo.Core
{
<<<<<<< HEAD
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.ConferencesViewModel>();
        }
    }
=======
	public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
					.EndingWith("Service")
					.AsInterfaces()
					.RegisterAsLazySingleton();

			RegisterAppStart<ViewModels.ConferencesViewModel>();
		}
	}
>>>>>>> b3256fe8e5e0b7e4938975d4c2ac3a5fd79ad1ac
}