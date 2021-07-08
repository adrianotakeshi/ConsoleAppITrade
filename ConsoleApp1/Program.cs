using System;
using System.Globalization;

namespace ConsoleApp1
{

    interface ITrade
    {
        double value { get; set; }
        string ClientSector { get; set; }
        DateTime NextPaymentDate { get; set; }

        string retornaCategoria(DateTime dataref);
    }

    public class Trade : ITrade
    {
        public double value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }

        public Trade(double valor, string setor, DateTime data)
        {
            this.value = valor;
            this.ClientSector = setor;
            this.NextPaymentDate = data;
        }

        public string retornaCategoria(DateTime dataref)
        {
            DateTime datalimite = this.NextPaymentDate.AddDays(30);

            if (datalimite < dataref)
            {
                return "EXPIRED";
            }
            else
            {
                if (value > 1000000 && ClientSector.ToUpper() == "PUBLIC")
                {
                    return "MEDIUMRISK";
                }
                else
                {
                    if (value > 1000000 && ClientSector.ToUpper() == "PRIVATE")
                    {
                        return "HIGHRISK";
                    }
                    else
                    {
                        return "OTHER";
                    }
                }
            }
        }
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
            DateTime data1, data2;
            Console.WriteLine("INPUT\n");
            data1 = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            n = Int32.Parse(Console.ReadLine());
            string[] categoria = new string[n];
            while (cont < n)
            {
                linhapar = Console.ReadLine();
                par = linhapar.Split(" ");
                valor = Int32.Parse(par[0]);
                setor = par[1];
                data2 = DateTime.ParseExact(par[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                Trade trade = new Trade(valor, setor, data2);                
                categoria[cont] = trade.retornaCategoria(data1);
                cont++;
            }

            cont = 0;
            Console.WriteLine("\nOUTPUT\n");
            while (cont < n)
            {
                Console.WriteLine(categoria[cont]);
                cont++;
            }
        }
    }

}
