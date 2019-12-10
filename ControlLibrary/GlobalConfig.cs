using ControlLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Set of connections. You can edit this to have another data sources (database)
        /// </summary>
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections() // You can change this method to set config data source. Just change parameters e.g. bool textFile, bool database.
        {
            TextConnector text = new TextConnector();
            Connections.Add(text);
        }
    }
}
