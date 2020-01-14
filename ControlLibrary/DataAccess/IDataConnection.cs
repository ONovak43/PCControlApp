using System.Collections.Generic;

namespace ControlLibrary.DataAccess
{
    /// <summary>
    /// Poskytuje metody pro ukládání a načítání počítačů z úložiště.
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// Přidá počítač do úložiště.
        /// </summary>
        /// <param name="model">Počítač k uložení.</param>
        /// <returns>Počítač s id.</returns>
        ComputerModel AddComputer(ComputerModel model);

        /// <summary>
        /// Odstraní počítač z úložiště.
        /// </summary>
        /// <param name="model">Počítač k odstranění.</param>
        void RemoveComputer(ComputerModel model);

        /// <summary>
        /// Vrátí všechny počítače z úložiště.
        /// </summary>
        /// <returns>Instance třídy List s typem ComputerModel, které jsou načtené z úložiště.</returns>
        List<ComputerModel> GetComputers_All();
    }
}
