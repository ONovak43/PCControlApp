using ControlLibrary.Factory;
using ControlLibrary.Service;
using ControlLibrary.Wrapper;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ControlLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName) => $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";


        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<ComputerModel> ConvertToComputerModels(this List<string> lines)
        {
            List<ComputerModel> output = new List<ComputerModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MacAddress macAddress = new MacAddress(cols[3]);
                IComputerService computerService = ComputerServiceFactory.GetComputerService(cols[2], macAddress);

                ComputerModel c = new ComputerModel((IComputerService) computerService, cols[1], cols[2], macAddress)
                {
                    Id = int.Parse(cols[0]),
                };
                output.Add(c);
            }

            return output;
        }

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
