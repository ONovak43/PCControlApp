﻿using ControlLibrary.DataAccess;

namespace ControlLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Type of connection. You can edit this to another data sources (e.g. database)
        /// </summary>
        public static IDataConnection Connections { get; private set; }

        public static void InitializeConnections() // You can change this method to set config data. 
        {
            TextConnector text = new TextConnector();
            Connections = text;
        }
    }
}
