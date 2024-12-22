using Elgin.Driver;
using Elgin.Entities.Enums;
using Elgin.Entities.Printer;

public static class Program
{
    static void Main(string[] args)
    {
        ElginPrinter printer = ElginPrinterFactory.CreateUsbPrinter(ElginModel.i9);

        foreach (var argRaw in args)
        {
            string arg = argRaw.Replace("\\", "/");
            Console.WriteLine($"Imprimindo arquivo: {arg}");
            if (arg.EndsWith(".jpg") || arg.EndsWith(".png"))
            {
                printer.ImprimeImagemWithCuts(argRaw);
                continue;
            }

            if(arg.EndsWith(".xml"))
            {
                printer.ImprimeXMLSATWithCuts(arg);
                continue;
            }

            Console.WriteLine($"Arquivo não suportado: {arg}");
        }

        Console.ReadLine();
    }
}


