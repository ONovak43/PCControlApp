using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary.DataAccess
{
    public interface IDataConnection
    {
        ComputerModel AddComputer(ComputerModel model);

        void RemoveComputer(ComputerModel model);

        List<ComputerModel> GetComputers_All();        
    }
}
