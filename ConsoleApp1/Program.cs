using System;
using System.Globalization;

namespace ConsoleApp1
{
    interface ITrade
    {
        double value { get; set;  }
        string ClientSector { get; set;  }
        DateTime NextPaymentDate { get; set;  }
    }

    class Trade : ITrade
    {
        double ITrade.value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ITrade.ClientSector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime ITrade.NextPaymentDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
            Console.WriteLine("INPUT\n");
            data1 = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            n = Int32.Parse(Console.ReadLine());
            string[] tipo = new string[n];
            while (cont < n)
            {
                linhapar = Console.ReadLine();
                par = linhapar.Split(" ");
                valor = Int32.Parse(par[0]);
                setor = par[1];
                data2 = DateTime.ParseExact(par[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                datalimite = data2.AddDays(30);
                if (datalimite < data1)
                {
                    tipo[cont] = "EXPIRED";
                }
                else
                {
                    if (valor > 1000000 && setor.ToUpper() == "PUBLIC")
                    {
                        tipo[cont] = "MEDIUMRISK";
                    }
                    else
                    {
                        if (valor > 1000000 && setor.ToUpper() == "PRIVATE")
                        {
                            tipo[cont] = "HIGHRISK";
                        }
                    }
                }
                cont++;
            }

            cont = 0;
            Console.WriteLine("\nOUTPUT\n");
            while (cont < n)
            {
                Console.WriteLine(tipo[cont]);
                cont++;
            }
        }
    }
}
