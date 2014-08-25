using Cirrious.MvvmCross.Plugins.Messenger;

namespace StackSnapMvvmCross.Core.Services
{
    public class PingMessage
        : MvxMessage
    {

        public PingMessage(object sender)
            : base(sender)
        {
        }
    }
}