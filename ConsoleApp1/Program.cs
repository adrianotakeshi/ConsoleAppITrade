using System;
using System.Globalization;

namespace ConsoleApp1
{
    interface ITrade
    {
        double value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double valor;
            string setor;
            int n, cont = 0;
            string linhapar;
            string[] par;
            DateTime data1, data2, datalimite;
            data1 = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            n = Int32.Parse(Console.ReadLine());
            while (cont < n)
            {
                linhapar = Console.ReadLine();
                par = linhapar.Split(" ");
                valor = Int32.Parse(par[0]);
                setor = par[1];
                data2 = DateTime.ParseExact(par[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                cont++;
                datalimite = data2.AddDays(30);
                if (datalimite < data1)
                {
                    Console.WriteLine("EXPIRED");
                }
                else
                {
                    if (valor > 1000000 && setor.ToUpper() == "PUBLIC")
                    {
                        Console.WriteLine("MEDIUMRISK");
                    }
                    else
                    {
                        if (valor > 1000000 && setor.ToUpper() == "PRIVATE")
                        {
                            Console.WriteLine("HIGHRISK");
                        }
                    }
                }
            }
        }
    }
}
