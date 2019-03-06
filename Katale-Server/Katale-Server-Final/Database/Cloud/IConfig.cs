using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database.Cloud
{
    public interface IConfig
    {
        String GetConnectionString();
        void LoadConfigurations();

    }
}
