using ControlLibrary.DataAccess.TextHelpers;
using System.Collections.Generic;
using System.Linq;

namespace ControlLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// Reprezentuje databázi počítačů.
        /// </summary>
        private const string ComputersFile = "ComputerModel.csv";

        /// <summary>
        /// Přidá počítač do databáze.
        /// </summary>
        /// <param name="model">Počítač</param>
        /// <returns>Počítač včetně jeho id v databázi.</returns>
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

        /// <summary>
        /// Odstraní počítač z databáze.
        /// </summary>
        /// <param name="model">Počítač k odstranění.</param>
        public void RemoveComputer(ComputerModel model)
        {
            List<ComputerModel> computers = ComputersFile.FullFilePath().LoadFile().ConvertToComputerModels();

            computers.RemoveAll(m => m.Id == model.Id);

            computers.SaveToComputerFile(ComputersFile);
        }

        /// <summary>
        /// Vrátí všechny počíateče z databáze.
        /// </summary>
        /// <returns>Počítače z databáze převedené do ComputerModelů.</returns>
        public List<ComputerModel> GetComputers_All()
        {
            return ComputersFile.FullFilePath().LoadFile().ConvertToComputerModels();
        }
    }
}
