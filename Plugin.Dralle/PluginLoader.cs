using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using System;


namespace Plugin.Dralle
{
    public class PluginLoader
        : IMvxPluginLoader
    {
        public static readonly PluginLoader Instance = new PluginLoader();

        public void EnsureLoaded()
        {
            var manager = Mvx.Resolve<IMvxPluginManager>();
            try
            {
                manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
            }
            catch (Exception exc)
            {
                string t = exc.Message;
            }
        }
    }
}