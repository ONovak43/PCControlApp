using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary.DataAccess
{
    public interface IDataConnection
    {
        SettingModel GetComputers(SettingModel model);
    }
}
