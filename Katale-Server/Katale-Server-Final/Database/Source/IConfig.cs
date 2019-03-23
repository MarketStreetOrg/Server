using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database.Source
{
    public interface IConfig
    {
        string GetConnectionString();
        void LoadConfigurations();

    }
}
