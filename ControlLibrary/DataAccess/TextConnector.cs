using ControlLibrary.DataAccess.TextHelpers;
using System.Collections.Generic;
using System.Linq;

namespace ControlLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// Represents "database" of computers.
        /// </summary>
        private const string ComputersFile = "ComputerModel.csv";

        public ComputerModel AddComputer(ComputerModel model)
        {
            List<ComputerModel> computers = ComputersFile.FullFilePath().LoadFile().ConvertToComputerModels();

            int currentId = 1;

            if (computers.Count > 0)
            {
                currentId = computers.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            computers.Add(model);

            computers.SaveToComputerFile(ComputersFile);

            return model;
        }

        public void RemoveComputer(ComputerModel model)
        {
            List<ComputerModel> computers = ComputersFile.FullFilePath().LoadFile().ConvertToComputerModels();

            computers.RemoveAll(m => m.Id == model.Id);

            computers.SaveToComputerFile(ComputersFile);
        }

        public List<ComputerModel> GetComputers_All()
        {
            return ComputersFile.FullFilePath().LoadFile().ConvertToComputerModels();
        }
    }
}
