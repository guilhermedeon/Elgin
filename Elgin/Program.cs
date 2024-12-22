using Elgin.Driver;
using Elgin.Entities.Enums;
using Elgin.Entities.Printer;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using NReco.PdfRenderer;
using System.Reflection.PortableExecutable;

public static class Program
{
    static void Main(string[] args)
    {
        ElginPrinter printer = ElginPrinterFactory.CreateUsbPrinter(ElginModel.i9);
        //MainFlow(args, printer);
        TestFlow(args, printer);
    }

    private static void MainFlow(string[] args, ElginPrinter printer)
    {
        foreach (var argRaw in args)
        {
            string arg = argRaw.Replace("\\", "/");
            Console.WriteLine($"Imprimindo arquivo: {arg}");
            if (arg.EndsWith(".jpg") || arg.EndsWith(".png"))
            {
                printer.ImprimeImagemWithCuts(argRaw);
                continue;
            }

            if (arg.EndsWith(".pdf"))
            {
                int count = ConvertPdfToPng(arg);
                for (int i = 1; i <= count; i++)
                {
                    printer.ImprimeImagemWithCuts(arg.Replace(".pdf", $"{i.ToString()}.png"));
                    File.Delete(arg.Replace(".pdf", $"{i.ToString()}.png"));
                }
                continue;
            }

            if (arg.EndsWith(".xml"))
            {
                printer.ImprimeXMLSATWithCuts(arg);
                continue;
            }

            if (arg.EndsWith(".txt"))
            {
                var linhas = File.ReadAllLines(arg).ToList();

                linhas.Insert(0, arg);
                linhas.Insert(1, "----------------------------------------------");
                linhas.Insert(2, string.Empty);
                linhas.Add(string.Empty);
                linhas.Add("----------------------------------------------");

                printer.ImprimeTexto(linhas);

                printer.Corte(5);

                continue;
            }

            Console.WriteLine($"Arquivo não suportado: {arg}");
        }
    }

    private static void TestFlow(string[] args, ElginPrinter printer)
    {
        using (var connection = new ElginPrinterConnection(printer))
        {

            ElginDriver.ImpressaoTexto("asdasd", 1, 0, 1);
            ElginDriver.AvancaPapel(5);
            ElginDriver.Corte(5);

            ElginDriver.ImpressaoQRCode
            Task.Delay(10000).Wait();
        }
    }

    public static int ConvertPdfToPng(string pdfFilePath)
    {
        // Get the directory and filename without extension
        string? directory = Path.GetDirectoryName(pdfFilePath);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pdfFilePath);

        // Define the output image path by replacing the .pdf extension with .png
        string outputImagePath = Path.Combine(directory!, fileNameWithoutExtension);


        var pdfInfo = new PdfInfo();

        var info = pdfInfo.GetPdfInfo(pdfFilePath);

        var converter = new PdfToImageConverter();

        for (int i = 1; i <= info.Pages; i++)
        {
            converter.GenerateImage(pdfFilePath, i, ImageFormat.Png, outputImagePath + i.ToString() + ".png");
        }

        return info.Pages;
    }
}
