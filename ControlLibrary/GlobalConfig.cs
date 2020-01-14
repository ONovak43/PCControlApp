using ControlLibrary.DataAccess;

namespace ControlLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Typ datového připojení (lze implementovat například databázi). 
        /// </summary>
        public static IDataConnection Connections { get; private set; }

        /// <summary>
        /// Incilaizuje připojení k datovému úložišti.
        /// </summary>
        public static void InitializeConnections()
        {
            TextConnector text = new TextConnector(); // Zde lze nastavit typ připojení (resp. úložiště).
            Connections = text;
        }
    }
}
