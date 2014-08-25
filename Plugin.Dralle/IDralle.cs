using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Dralle
{
    public interface IDralle
    {
        void ping(string serverId, string username, string password);
    }
}
