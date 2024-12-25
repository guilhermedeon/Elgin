using Elgin.Driver;
using Elgin.Entities.Enums;
using Elgin.Entities.Printer;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using NReco.PdfRenderer;
using System.Reflection.PortableExecutable;
using System.Drawing.Printing;
using Elgin.Service;

public static class Program
{
    static void Main(string[] args)
    {

        // mock
        /*
         var auxArgs = args.ToList();

        auxArgs.Add("C:\\Users\\guiby\\OneDrive\\Desktop\\XMLS\\Impressao teste\\prog.txt");

        args = auxArgs.ToArray();
        */
        


        ElginPrinter printer = ElginPrinterFactory.CreateUsbPrinter(ElginModel.i9);
        ElginPrinterService service = new ElginPrinterService();
        ElginPrinterConnectionManager manager = ElginPrinterConnectionManager.GetInstance();
        try
        {
            MainFlow(args, printer, service, manager);
            //MainFlowFancy(args, printer, service, manager);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadLine();
        }
        //TestFlow(args, printer, service, manager);
    }

    private static void MainFlow(string[] args, ElginPrinter printer, ElginPrinterService service, ElginPrinterConnectionManager manager)
    {
        printer.Validate();

        using var connection = manager.CreateConnection(printer);

        if (connection == null)
            throw new ArgumentException("Connection is null");

        foreach (var argRaw in args)
        {
            string arg = argRaw.Replace("\\", "/");
            Console.WriteLine($"Imprimindo arquivo: {arg}");
            if (arg.EndsWith(".jpg") || arg.EndsWith(".png"))
            {
                service.ImprimeImagemWithCuts(argRaw, connection);
                continue;
            }

            if (arg.EndsWith(".pdf"))
            {
                int count = ConvertPdfToPng(arg);
                for (int i = 1; i <= count; i++)
                {
                    service.ImprimeImagemWithCuts(arg.Replace(".pdf", $"{i.ToString()}.png"), connection);
                    File.Delete(arg.Replace(".pdf", $"{i.ToString()}.png"));
                }
                continue;
            }

            if (arg.EndsWith(".xml"))
            {
                service.ImprimeXMLSATWithCuts(arg, connection);
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

                service.ImprimeTextoWithCuts(linhas, connection);


                continue;
            }

            Console.WriteLine($"Arquivo não suportado: {arg}");
        }
    }

    private static void MainFlowFancy(string[] args, ElginPrinter printer, ElginPrinterService service, ElginPrinterConnectionManager manager)
    {
        printer.Validate();

        List<Delegate> delegates = new List<Delegate>();

        using var connection = manager.CreateConnection(printer);

        if (connection == null)
            throw new ArgumentException("Connection is null");

        foreach (var argRaw in args)
        {
            string arg = argRaw.Replace("\\", "/");
            Console.WriteLine($"Imprimindo arquivo: {arg}");
            if (arg.EndsWith(".jpg") || arg.EndsWith(".png"))
            {
                delegates.Add(() => service.ImprimeImagem(argRaw, connection));
                continue;
            }

            if (arg.EndsWith(".pdf"))
            {
                int count = ConvertPdfToPng(arg);
                for (int i = 1; i <= count; i++)
                {
                    delegates.Add(() => service.ImprimeImagemWithDelete(arg.Replace(".pdf", $"{i.ToString()}.png"), connection));
                }
                continue;
            }

            if (arg.EndsWith(".xml"))
            {
                delegates.Add(() => service.ImprimeXMLSAT(arg, connection));
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

                delegates.Add(() => service.ImprimeTexto(linhas, connection));
                continue;
            }
            Console.WriteLine($"Arquivo não suportado: {arg}");
        }

        service.GenericWithCuts(delegates, connection);
    }


    private static void TestFlow(string[] args, ElginPrinter printer, ElginPrinterService service, ElginPrinterConnectionManager manager)
    {
        using var connection = manager.CreateConnection(printer);

        if (connection == null)
            throw new ArgumentException("Connection is null");


        for (int i = 0; i < 200; i++)
        {
            service.Corte(1, connection);
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
