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
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace Plugin.Dralle.Droid
{
    public class Plugin: IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IDralle>(new MvxDroidDralle());
        }
    }
   
}