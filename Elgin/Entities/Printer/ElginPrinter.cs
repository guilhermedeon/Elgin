using Elgin.Driver;
using Elgin.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Entities.Printer
{
    public class ElginPrinter
    {
        public ElginConnectionType? ConnectionType { get; set; }

        public ElginModel? Model { get; set; }

        public string? ConnectionString { get; set; }

        public int? Parameter { get; set; }

        public ElginPrinter(ElginConnectionType? connectionType, ElginModel? model, string? connectionString, int? parameter)
        {
            ConnectionType = connectionType;
            Model = model;
            ConnectionString = connectionString;
            Parameter = parameter;
        }

        public void Validate()
        {
            if (ConnectionType == null)
            {
                throw new ArgumentNullException("ConnectionType is required");
            }
            if (Model == null)
            {
                throw new ArgumentNullException("Model is required");
            }
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new ArgumentNullException("ConnectionString is required");
            }
            if (Parameter == null)
            {
                throw new ArgumentNullException("Parameter is required");
            }
        }

        public int Corte(int avanco)
        {
            using (var connection = new ElginPrinterConnection(this))
            {
                return ElginDriver.Corte(avanco);
            }
        }

        public int SinalSonoro(int quantidade, int duracaoDoToque, int tempoEntreToques, out int duracaoTotalMs)
        {
            using (var connection = new ElginPrinterConnection(this))
            {
                duracaoTotalMs = (quantidade * duracaoDoToque) + ((quantidade - 1) * tempoEntreToques) * 1000;
                return ElginDriver.SinalSonoro(quantidade, duracaoDoToque, tempoEntreToques);
            }
        }

        public int ImprimeImagem(string path)
        {
            using (var connection = new ElginPrinterConnection(this))
            {
                return ElginDriver.ImprimeImagem(path);
            }
        }

        public int ImprimeImagemWithCuts(string path)
        {
            using (var connection = new ElginPrinterConnection(this))
            {
                return ElginDriver.ImprimeImagemWithCuts(path);
            }
        }

        public int ImprimeXMLSAT(string path)
        {
            using (var connection = new ElginPrinterConnection(this))
            {
                return ElginDriver.ImprimeXMLSAT(path,0);
            }
        }

        public int ImprimeXMLSATWithCuts(string path)
        {
            using (var connection = new ElginPrinterConnection(this))
            {
                return ElginDriver.ImprimeXMLSATWithCutsFromPath(path);
            }
        }
    }
}
