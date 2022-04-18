using System;
using System.Globalization;

namespace GameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("LEGO blokovi = Friends Forest House", 41679, 20.25);
            Console.WriteLine("Unesite zeljeni procenat poreza: ");
            string sTax = Console.ReadLine();
            if(!(Double.TryParse(sTax, out double tax)))
            {
                Console.WriteLine("Pogresan unos. Procenat mora biti u formatu broja.");
            }
            else
            {
                Console.WriteLine(product1.Ispis(52.34, tax));
            }
            
        }
    }
}
