using Elgin.Entities.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Service
{
    public class ElginPrinterConnectionManager
    {
        public static ElginPrinterConnectionManager instance;

        public static ElginPrinterConnectionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ElginPrinterConnectionManager();
            }
            return instance;
        }

        private ElginPrinterConnection? currentConnection;

        private ElginPrinterConnectionManager()
        {
            
        }

        ~ElginPrinterConnectionManager()
        {
            CloseConnection();
        }

        public ElginPrinterConnection? GetCurrentConnection()
        {
            if (currentConnection == null)
            {
                throw new InvalidOperationException("There is no current connection");
            }
            return currentConnection;
        }

        public ElginPrinterConnection? CreateConnection(ElginPrinter printer)
        {
            CloseConnection();
            currentConnection = new ElginPrinterConnection(printer);
            return currentConnection;
        }

        public void CloseConnection()
        {
            if (currentConnection != null)
            {
                currentConnection.Dispose();
                currentConnection = null;
            }
        }
    }
}
