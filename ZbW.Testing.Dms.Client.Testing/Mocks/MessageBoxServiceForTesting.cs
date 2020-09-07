using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Mocks
{
    class MessageBoxServiceForTesting : IMessageBoxService
    {
        public void Show(string message)
        {
            //Do nothing
        }
    }
}
