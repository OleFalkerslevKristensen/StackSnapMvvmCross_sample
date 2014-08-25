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
using Dralle.sScale.Api;


namespace Plugin.Dralle.Droid
{
        public class MvxDroidDralle: IDralle
        {
            APIAccess api;

            public void ping(string serverId, string username, string password) 
            {
                api = new APIAccess(serverId, username, password);
                string t = serverId;
            }
        }

}