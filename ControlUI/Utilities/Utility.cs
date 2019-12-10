using System;
using System.Collections.Generic;
using System.IO;

namespace ControlUI.Utilities
{
    static class Utility
    {
        public static List<string[]> GetSetting()
        {
            const string compFile = "computers.txt";

            if(!File.Exists(compFile))
            {
                throw new FileNotFoundException("File computers.txt doesn't exist.");
            }
     
            var termsList = new List<string[]>();

            using (StreamReader sr = File.OpenText(compFile))
            {
                string inputLine;

                while ((inputLine = sr.ReadLine()) != null)
                {
                    termsList.Add(inputLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            if (termsList.Count < 1)
            {
                throw new InvalidDataException("You must add computers to computers.txt.");
            }

            return termsList;
        }
    }
}
