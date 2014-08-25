using Cirrious.MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackSnapMvvmCross.Core.Services.DralleService
{
    public class RegisterMessage : MvxMessage
    {

        public RegisterMessage(object sender)
            : base(sender)
        {
        }
    }
}
