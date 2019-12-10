using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public SettingModel GetComputers(SettingModel model)
        {
            //model.Id = 1;

            return model;
        }
    }
}
