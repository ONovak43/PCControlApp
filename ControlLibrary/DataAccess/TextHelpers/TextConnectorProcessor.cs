using ControlLibrary.Wrapper;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ControlLibrary.DataAccess.TextHelpers
{
    /// <summary>
    /// Poskytuje statické metody pro ukládání a načítání počítačů pomocí souborového formátu csv.
    /// </summary>
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Reprezentuje cestu k požadovanému souboru.
        /// </summary>
        /// <param name="fileName">Název požadovaného souboru.</param>
        /// <returns>Cesta k požadovanému souboru.</returns>
        public static string FullFilePath(this string fileName)
        {
           // return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
            return $"{ fileName }";
        }

        /// <summary>
        /// Načte požadovaný soubor a převede jeho řádky na instanci třídy List.
        /// </summary>
        /// <param name="file">Cesta k souboru včetně jeho názvu.</param>
        /// <returns>Instnce třídy List s řádky souboru.</returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Vyparsuje obsah jednotlivých řádků z instnace třídy List a vrátí inststanci třídy List s 
        ///     načtenými daty o počítačích
        /// </summary>
        /// <param name="lines">Instance třídy List s daty v požadovaném formátu.</param>
        /// <returns>Instance třídy List s typem ComputerModel.</returns>
        public static List<ComputerModel> ConvertToComputerModels(this List<string> lines)
        {
            List<ComputerModel> output = new List<ComputerModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MacAddress macAddress = new MacAddress(cols[3]);

                ComputerModel c = new ComputerModel(cols[1], cols[2], macAddress)
                {
                    Id = int.Parse(cols[0]),
                };
                output.Add(c);
            }

            return output;
        }

        /// <summary>
        /// Uloží instanci třídy List s typem ComputerModel do zadaného souboru.
        /// </summary>
        /// <param name="models">Instance třídy List typu ComputerModel.</param>
        /// <param name="fileName">Název souboru k uložení modelů.</param>
        public static void SaveToComputerFile(this List<ComputerModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (ComputerModel c in models)
            {
                lines.Add($"{ c.Id },{c.Name},{ c.Hostname },{ c.MacAddress.Address }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
