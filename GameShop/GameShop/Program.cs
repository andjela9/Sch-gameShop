using System;
using System.Globalization;

namespace GameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            while (true)
            {
                ValidateInput validator1 = new ValidateInput();
                Product product1 = new Product("LEGO blokovi = Friends Forest House", 41679, 20.25);
                string sName, name, sTax, sUpc, sDiscount;
                Console.WriteLine("Unesite naziv proizvoda. Za izlazak unesite exit");
                sName = Console.ReadLine();
                if (sName.ToLower() == "exit") break;
                name = "-1";
                if (validator1.ValidName(sName) != "-1")
                {
                    name = validator1.ValidName(sName);
                }
                else
                {
                    Console.WriteLine("Pogresen unos. Naziv ne sme biti prazan ili duzi od 64 karaktera.");
                }
                //Console.WriteLine($"{name}\n");


                Console.WriteLine("Unesite zeljeni procenat poreza: Za izlazak unesite exit");
                sTax = Console.ReadLine();
                if (sTax.ToLower() == "exit") break;
                double tax = -1;
                if (validator1.ValidTax(sTax) != -1)
                {
                    tax = validator1.ValidTax(sTax);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Porez mora biti pozitivan broj do 64 karaktera");
                }
                //Console.WriteLine($"{tax}\n");

                Console.WriteLine("Unesite zeljeni procenat popusta: Za izlazak unesite exit");
                sDiscount = Console.ReadLine();
                if (sDiscount.ToLower() == "exit") break;
                double discount = -1;
                if (validator1.ValidTax(sDiscount) != -1)
                {
                    discount = validator1.ValidTax(sDiscount);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Popust mora biti pozitivan broj do 64 karaktera");
                }


                Console.WriteLine("Unesite upc: Za izlazak unesite exit");
                sUpc = Console.ReadLine();
                if (sUpc.ToLower() == "exit") break;
                int upc = -1;
                if (validator1.ValidUPC(sUpc) != -1)
                {
                    upc = validator1.ValidUPC(sUpc);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. UPC mora biti pozitivan celobrojan broj do 64 karaktera");
                }
                //Console.WriteLine($"{upc}\n");


                Console.WriteLine("Unesite cenu: Za izlazak unesite exit");
                string sPrice = Console.ReadLine();
                if (sPrice.ToLower() == "exit") break;
                double price = -1;
                if (validator1.ValidatePrice(sPrice) != -1)
                {
                    price = validator1.ValidatePrice(sPrice);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Cena mora biti pozitivan broj do 64 karaktera");
                }
                //Console.WriteLine($"{price}\n");

                if (name != "-1" && tax != -1 && upc != -1 && price != -1 && discount != -1)
                {
                    Product product = new Product(name, upc, price);
                    //product.withTax(tax);
                    //product.withDiscount(discount);
                    Console.WriteLine(product.Ispis(tax, discount));
                }
                else
                {
                    Console.WriteLine("\n******U unosu postoji greska!*******\n");
                }
            }
         

        }
    }
}


