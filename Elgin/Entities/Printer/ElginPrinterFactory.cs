using Elgin.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Entities.Printer
{
    public class ElginPrinterFactory
    {
        public static ElginPrinter CreateUsbPrinter(ElginModel model)
        {
            return new ElginPrinter(ElginConnectionType.USB, model, "USB", 0);
        }
    }
}
