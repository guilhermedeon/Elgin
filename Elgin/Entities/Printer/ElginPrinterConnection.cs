using Elgin.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Entities.Printer
{
    public class ElginPrinterConnection : IDisposable
    {
        public ElginPrinterConnection(ElginPrinter printer)
        {
            printer.Validate();
            ElginDriver.AbreConexaoImpressora(printer);
        }
        public void Dispose()
        {
            ElginDriver.FechaConexaoImpressora();
        }
    }
}
