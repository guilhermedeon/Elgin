using Elgin.Entities.Printer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Driver
{
    public static partial class ElginDriver
    {
        public static int AbreConexaoImpressora(ElginPrinter printer)
        {
            return AbreConexaoImpressora((int)printer.ConnectionType!, printer.Model.ToString()!, printer.ConnectionString!, (int)printer.Parameter!);
        }

        public static int ImprimeImagemWithCuts(string path)
        {
            int result = ImprimeImagem(path);
            Corte(5);

            return result;
        }

        public static int ImprimeXMLSATWithCutsFromPath(string path)
        {
            int result = ImprimeXMLSAT($"path={path}", 0);

            Corte(5);

            return result;
        }
    }
}
