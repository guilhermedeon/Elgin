using Elgin.Driver;
using Elgin.Entities.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Service
{
    public class ElginPrinterService
    {
        public int Corte(int avanco, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            return ElginDriver.Corte(avanco);
        }

        public int SinalSonoro(int quantidade, int duracaoDoToque, int tempoEntreToques, ElginPrinterConnection connection, out int duracaoTotalMs)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }

            duracaoTotalMs = (quantidade * duracaoDoToque * 100) + ((quantidade - 1) * tempoEntreToques * 100);
            return ElginDriver.SinalSonoro(quantidade, duracaoDoToque, tempoEntreToques);
        }

        public int ImprimeImagem(string path, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            return ElginDriver.ImprimeImagem(path);
        }

        public int ImprimeImagemWithCuts(string path, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            return ElginDriver.ImprimeImagemWithCuts(path);
        }

        public int ImprimeXMLSAT(string path, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            return ElginDriver.ImprimeXMLSAT(path, 0);
        }

        public int ImprimeXMLSATWithCuts(string path, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            return ElginDriver.ImprimeXMLSATWithCutsFromPath(path);
        }

        public void ImprimeTexto(List<string> linhas, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            foreach (var linha in linhas)
            {
                ElginDriver.ImpressaoTexto(linha, 1, 0, 0);
                ElginDriver.AvancaPapel(1);
            }
        }

        public void Generic(Delegate @delegate, ElginPrinterConnection connection)
        {
            if (!connection.IsOpen)
            {
                throw new InvalidOperationException("Connection is not open");
            }
            @delegate.DynamicInvoke();
        }
    }
}
