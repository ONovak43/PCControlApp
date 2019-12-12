using System;
using System.Collections.Generic;
using System.Text;
using ControlLibrary.DataAccess.TextHelpers;

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

            computers.Add(model);

            computers.SaveToComputerFile(ComputersFile);

            return model;
        }

        public ComputerModel GetComputers(ComputerModel model)
        {
            // Load the text file
            // Convert the text to List<ComputerModel>
            return model;
        }
    }
}
