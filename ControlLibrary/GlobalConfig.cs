using ControlLibrary.DataAccess;

namespace ControlLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Typ datového připojení (lze implementovat například databázi). 
        /// </summary>
        public static IDataConnection Connections { get; private set; }

        public static void InitializeConnections() // V této metodě lze nastavit typ připojení (resp. úložiště)
        {
            TextConnector text = new TextConnector();
            Connections = text;
        }
    }
}
