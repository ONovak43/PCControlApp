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

                ComputerModel c = new ComputerModel(cols[2], cols[3]);
                c.Id = int.Parse(cols[0]);
                c.Name = cols[1];
                output.Add(c);
            }

            return output;
        }

        public static void SaveToComputerFile(this List<ComputerModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (ComputerModel c in models)
            {
                lines.Add($"{ c.Id },{c.Name},{ c.Domain },{ c.MacAddress }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
