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

namespace StackSnapMvvmCross.Droid.Views
{
    [Activity(Label = "Login", Theme = "@android:style/Theme.Holo", NoHistory = true, Icon = "@drawable/sScaleLogo")]
    public class NewStackView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        

            // Create your application here

            SetContentView(Resource.Layout.LoginView);

        }
    }
}