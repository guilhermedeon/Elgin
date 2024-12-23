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
        private bool disposedValue;

        public bool IsOpen { get; private set; } = false;

        public ElginPrinterConnection(ElginPrinter printer)
        {
            printer.Validate();
            ElginDriver.AbreConexaoImpressora(printer);
            IsOpen = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                ElginDriver.FechaConexaoImpressora();
                IsOpen = false;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
