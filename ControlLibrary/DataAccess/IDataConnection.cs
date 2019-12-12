using System.Collections.Generic;

namespace ControlLibrary.DataAccess
{
    public interface IDataConnection
    {
        ComputerModel AddComputer(ComputerModel model);

        void RemoveComputer(ComputerModel model);

        List<ComputerModel> GetComputers_All();
    }
}
