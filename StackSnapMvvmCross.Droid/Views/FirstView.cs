using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using StackSnapMvvmCross.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using StackSnapMvvmCross.Core.Services;
using Android.Views.Animations;
using Android.Views;
using System;
using System.Timers;

namespace StackSnapMvvmCross.Droid.Views
{
    [Activity(MainLauncher = true, Label = "StackSnapMvvmCross", Theme = "@android:style/Theme.Holo", NoHistory = true, Icon = "@drawable/sScaleLogo")]
    public class FirstView : MvxActivity
    {
        FirstViewModel vm;

        TextView tv;

        int screenwidth;

        Timer timer = new Timer(4000);


        public string Update
        {
            set { tv.Text = value; }
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
          
            Display d = WindowManager.DefaultDisplay;

            Android.Util.DisplayMetrics m = new Android.Util.DisplayMetrics();
            d.GetMetrics(m);

            screenwidth = d.Width;
          

            OverridePendingTransition(Resource.Animation.fadein, Resource.Animation.fadeout);

            SetContentView(Resource.Layout.FirstView);

            tv = FindViewById<TextView>(Resource.Id.textViewWelcome);

            try
            {
                tv.SetMaxWidth(3 * screenwidth / 4);
                tv.SetSingleLine(false);
            }

            catch (Exception exc)
            {
                string t = exc.Message;
            }


            Animation a = AnimationUtils.LoadAnimation(this, Resource.Animation.scalewelcometext);
            a.Reset();
            tv.ClearAnimation();
            tv.StartAnimation(a);



            timer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            timer.Enabled = true;
            timer.Start();
          

      
        }

        protected override void OnViewModelSet()
        {
          
            vm = (FirstViewModel)this.ViewModel;


            System.DateTime time = System.DateTime.Now.ToUniversalTime();

            string welcometxt = "";

            double hour = time.TimeOfDay.TotalHours;
            if (hour > 6 && hour < 18)
            {
                welcometxt = GetString(Resource.String.HelloText) + "\n";
            }
            else if ((hour >= 18) || (hour > 0 && hour < 2))
            {
                welcometxt = GetString(Resource.String.GoodEveningText) + "\n";
            }
            else
            {
                welcometxt = GetString(Resource.String.GoodMorningText) + "\n";
            }

        
            vm.Welcome = welcometxt + " " + "Ole";

            vm.ApplicationId = GetString(Resource.String.AppName);

          
        }


        protected override void OnStart()
        {
            base.OnStart();

        }

        protected override void OnStop()
        {
            base.OnStop();

            timer.Stop();
            timer.Enabled = false;

        }

        protected void OnTimeEvent(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;

            Console.WriteLine("********OnTimeEvent************");

           
            vm.DoLogin();

            Finish();

       //     ShowViewModel<LoginViewModel>();

    

        }




    }
}