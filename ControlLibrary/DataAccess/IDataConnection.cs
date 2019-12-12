using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary.DataAccess
{
    public interface IDataConnection
    {
        ComputerModel AddComputer(ComputerModel model);
        ComputerModel GetComputers(ComputerModel model);        
    }
}
