using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using StackSnapMvvmCross.Droid.Storage;
using StackSnapMvvmCross.Core.Data;
using StackSnapMvvmCross.Core.ViewModels;
using Cirrious.MvvmCross.Plugins.Network.Droid;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using StackSnapMvvmCross.Core.Services;

//using Dralle.sScale.Api;

namespace StackSnapMvvmCross.Droid.Views
{
    [Activity(Label = "Login", Theme = "@android:style/Theme.Holo", NoHistory = true, Icon = "@drawable/sScaleLogo")]
    public class LoginView : MvxActivity
    {

 //       private APIAccess api;
        
        LoginViewModel vm;
        
        StorageHandler storageHandler = new StorageHandler();
        UserData user = new UserData();

        CheckBox checkbox;
        TextView checkBoxText;
        EditText userNameText;
        EditText passwordText;
        EditText serverIdText;

        Button loginButton;
        Button aboutButton;

        ProgressBar ProgressSpinner;
        TextView Processing;

        private MvxSubscriptionToken _tokenPing;

        private IMvxMessenger _messenger;
        protected IMvxMessenger Messenger
        {
            get
            {
                _messenger = _messenger ?? Mvx.Resolve<IMvxMessenger>();
                return _messenger;
            }
        }
        

        
        protected override void OnCreate(Bundle bundle)
        {

            try
            {

                base.OnCreate(bundle);
            }
            catch (Exception exc)
            {
                string t = exc.Message;
            }
          

            // Create your application here

            SetContentView(Resource.Layout.LoginView);

            checkBoxText = FindViewById<TextView>(Resource.Id.checkBoxText);

            checkbox = FindViewById<CheckBox>(Resource.Id.passwordcheckbox);
            checkbox.Click += checkbox_Click;
            checkbox.Enabled = true;

            serverIdText = FindViewById<EditText>(Resource.Id.serverIdText);
            userNameText = FindViewById<EditText>(Resource.Id.userNameText);
            passwordText = FindViewById<EditText>(Resource.Id.passwordText);

            serverIdText.AfterTextChanged += serverIdText_AfterTextChanged;
            userNameText.AfterTextChanged += serverIdText_AfterTextChanged;
            passwordText.AfterTextChanged += serverIdText_AfterTextChanged;

            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.SetTextColor(Android.Graphics.Color.Gray);
            loginButton.Enabled = false;
            loginButton.Click += loginButton_Click;

            ProgressSpinner = FindViewById<ProgressBar>(Resource.Id.ProgressSpinner);
            Processing = FindViewById<TextView>(Resource.Id.Processing);

            Console.WriteLine("********OnCreate loginview************");

        }


        protected override void OnResume()
        {
            base.OnResume();
          
        }

        protected override void OnPause()
        {
            if (_tokenPing != null)
            {

                Messenger.Unsubscribe<PingMessage>(_tokenPing);
                _tokenPing = null;
            }
            base.OnPause();
        }

        private int _i = 0;
        private void OnPing(PingMessage obj)
        {
            Mvx.Trace("Tick received {0}", ++_i);
        }


        void loginButton_Click(object sender, EventArgs e)
        {
            if ((serverIdText.Text != "") && (userNameText.Text != "") && (passwordText.Text != ""))
            {
                user.ServerId = serverIdText.Text;
                user.UserName = userNameText.Text;
                user.Password = passwordText.Text;

                storageHandler.StoreUser(user);

                MvxReachability task = new MvxReachability();


           //     if (!check_connection())
                if (!task.IsHostPingReachable("dummy"))
                {

                    if ((storageHandler.GetStringList("species.xml") == null) || (storageHandler.GetStringList("kind.xml") == null) ||
                        (storageHandler.GetStringList("source.xml") == null) || (storageHandler.GetStringList("destination.xml") == null))
                    {

                    }
                    else
                    {
                        Statics.species = (storageHandler.GetStringList("species.xml"));
                        Statics.kind = (storageHandler.GetStringList("kind.xml"));
                        Statics.source = (storageHandler.GetStringList("source.xml"));
                        Statics.destination = (storageHandler.GetStringList("destination.xml"));
                    }

                    Toast.MakeText(this, GetString(Resource.String.NoConnectionText), ToastLength.Long).Show();

          //          var intent = new Intent(this, typeof(StackList));
         //           StartActivity(intent);


          //          Finish();
                }
                else
                {
                    ProgressSpinner.Visibility = ViewStates.Visible;
                    Processing.Visibility = ViewStates.Visible;

                    ProgressSpinner.RequestFocus();

                    _tokenPing = Messenger.SubscribeOnMainThread<PingMessage>(OnPing);

                    vm.ExecuteLogin();
                }
            }
        }
/*
        private bool check_connection()
        {
            var connectivityManager = (Android.Net.ConnectivityManager)this.GetSystemService(Android.Content.Context.ConnectivityService);
            var activeConnection = connectivityManager.ActiveNetworkInfo;
            if ((activeConnection != null) && activeConnection.IsConnected)
            {
                return true;
            }
   
            return false;
        }
*/
        protected override void OnViewModelSet()
        {

            vm = (LoginViewModel)this.ViewModel;

            Console.WriteLine("*******(LoginViewModel)this.ViewModel;*****");
        }

        void serverIdText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            if ((serverIdText.Text != "") && (userNameText.Text != "") && (passwordText.Text != ""))
            {
                loginButton.SetTextColor(Android.Graphics.Color.Black);
                loginButton.Enabled = true;
                ProgressSpinner.Visibility = ViewStates.Invisible;
                Processing.Visibility = ViewStates.Invisible;

            }
            else
            {
                loginButton.SetTextColor(Android.Graphics.Color.Gray);
                loginButton.Enabled = false;
            }

            if ((checkbox.Enabled == false) && (passwordText.Text == ""))
            {
                checkbox.Enabled = true;
                checkbox.Visibility = ViewStates.Visible;
                checkBoxText.Visibility = ViewStates.Visible;
            }

            Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);

            if (Statics.SCREENINCHES < Statics.SCREENLIMIT)
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            }

        }


        void checkbox_Click(object sender, EventArgs e)
        {
            if (checkbox.Checked)
            {
                passwordText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationVisiblePassword;
            }
            else
            {
                passwordText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
            }

            vm.Password = passwordText.Text;
        }


     

        protected override void OnStart()
        {
            base.OnStart();

            if (vm == null) return;

            if (storageHandler.GetUser() != null)
            {
                user = storageHandler.GetUser();
                vm.ServerId = user.ServerId;
                vm.UserName = user.UserName;
                vm.Password = user.Password;
            }
            else
            {
                vm.ServerId = "t3";
                vm.UserName = "hjhkhk";
                vm.Password = "v6-x15!.";
            }



            if (passwordText.Text != "")
            {
                checkbox.Checked = false;
                checkbox.Enabled = false;
                checkbox.Visibility = ViewStates.Invisible;
                checkBoxText.Visibility = ViewStates.Invisible;
                passwordText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
            }

            ProgressSpinner.Visibility = ViewStates.Invisible;
            Processing.Visibility = ViewStates.Invisible;

        }
    }
}