using Cirrious.CrossCore.IoC;

namespace StackSnapMvvmCross.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
  //              .EndingWith("Service")
                .EndingWith("Dralle")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.FirstViewModel>();
       //     RegisterAppStart<ViewModels.LoginViewModel>();
        }
    }
}