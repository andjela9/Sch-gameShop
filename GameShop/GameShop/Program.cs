using System;
using System.Globalization;

namespace GameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateInput validator1 = new ValidateInput();
            Product product1 = new Product("LEGO blokovi = Friends Forest House", 41679, 20.25);

            Console.WriteLine("Unesite naziv proizvoda");
            string sName = Console.ReadLine();
            string name = "-1";
            if(validator1.ValidName(sName) != "-1")
            {
                name = validator1.ValidName(sName);
            }
            else
            {
                Console.WriteLine("Pogresen unos. Naziv ne sme biti prazan");
            }
            Console.WriteLine($"{name}\n");


            Console.WriteLine("Unesite zeljeni procenat poreza: ");
            string sTax = Console.ReadLine();
            double tax = -1;
            if (validator1.ValidTax(sTax) != -1)
            {
                tax = validator1.ValidTax(sTax);
            }
            else
            {
                Console.WriteLine("Pogresan unos. Porez mora biti pozitivan broj do 64 karaktera");
            }
            Console.WriteLine($"{tax}\n");


            Console.WriteLine("Unesite upc: ");
            string sUpc = Console.ReadLine();
            int upc = -1;
            if (validator1.ValidUPC(sUpc) != -1)
            {
                upc = validator1.ValidUPC(sUpc);
            }
            else
            {
                Console.WriteLine("Pogresan unos. UPC mora biti pozitivan celobrojan broj do 64 karaktera");
            }
            Console.WriteLine($"{upc}\n");


            Console.WriteLine("Unesite cenu: ");
            string sPrice = Console.ReadLine();
            double price = 0;
            if (validator1.ValidatePrice(sPrice) != -1)
            {
                price = validator1.ValidatePrice(sPrice);
            }
            else
            {
                Console.WriteLine("Pogresan unos. Cena mora biti pozitivan broj do 64 karaktera");
            }
            Console.WriteLine($"{price}\n");


        }
    }
}


