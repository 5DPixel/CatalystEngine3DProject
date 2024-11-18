using $safeprojectname$.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.ScriptsCore
{
    internal interface IScript
    {
        void Start();
        void ExecuteUpdate(GameObject currentInstance);
    }
}
