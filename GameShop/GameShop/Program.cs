using System;
using System.Collections.Generic;
using System.Globalization;

namespace GameShop
{
    class Program
    {
        static void Main(string[] args)
        {
           while (true)
            {
                ValidateInput validator = new ValidateInput();
                Product product = new Product("LEGO blokovi = Friends Forest House", 41679, 20.25);
                string sName, name, sTax, sUpc, sDiscount, sPrice;
                double discount, price, tax;
                int upc;

                /////UNOS PARA UPC-POPUST
                Console.WriteLine("Unesite upc i popust za proizvod s tim upc");
                bool ispisBaze = true;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"UPC {i + 1}:");
                    sUpc = Console.ReadLine();
                    upc = -1;
                    if (validator.ValidUPC(sUpc) != -1)
                    {
                        upc = validator.ValidUPC(sUpc);
                    }
                    else
                    {
                        Console.WriteLine("Pogresan unos. UPC mora biti pozitivan celobrojan broj do 64 karaktera");

                        break;
                    }

                    Console.WriteLine($"Popust {i + 1}:");
                    sDiscount = Console.ReadLine();
                    discount = -1;
                    if (validator.ValidTax(sDiscount) != -1)
                    {
                        discount = validator.ValidTax(sDiscount);
                    }
                    else
                    {
                        Console.WriteLine("Pogresan unos. Popust mora biti pozitivan broj do 64 karaktera");

                        break;
                    }

                    if (upc != -1 && discount != -1)
                    {
                        try
                        {
                            product.upcPopustPar.Add(upc, discount);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("****Neuspesan unos baze. Postoje dva artikla sa istim UPC!");
                            ispisBaze = false;
                            break;
                        }
                    }
                }





                if (ispisBaze)
                {
                    Console.WriteLine("\nBaza: ");
                    foreach (KeyValuePair<int, double> kvp in product.upcPopustPar)
                    {
                        Console.WriteLine($"UPC: {kvp.Key}, selektivni popust: {kvp.Value}");
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Nema dostupne baze za selektivni popust.");
                }

                
                
                
                //////UNOS OSTALIH PARAMETARA
                Console.WriteLine("Unesite naziv proizvoda. Za izlazak unesite exit");
                sName = Console.ReadLine();
                if (sName.ToLower() == "exit") break;
                name = "-1";
                if (validator.ValidName(sName) != "-1")
                {
                    name = validator.ValidName(sName);
                }
                else
                {
                    Console.WriteLine("Pogresen unos. Naziv ne sme biti prazan ili duzi od 64 karaktera.");
                }
                //Console.WriteLine($"{name}\n");


                Console.WriteLine("Unesite zeljeni procenat poreza: Za izlazak unesite exit");
                sTax = Console.ReadLine();
                if (sTax.ToLower() == "exit") break;
                tax = -1;
                if (validator.ValidTax(sTax) != -1)
                {
                    tax = validator.ValidTax(sTax);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Porez mora biti pozitivan broj do 64 karaktera");
                }
                //Console.WriteLine($"{tax}\n");

                Console.WriteLine("Unesite zeljeni procenat popusta: Za izlazak unesite exit");
                sDiscount = Console.ReadLine();
                if (sDiscount.ToLower() == "exit") break;
                discount = -1;
                if (validator.ValidTax(sDiscount) != -1)
                {
                    discount = validator.ValidTax(sDiscount);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Popust mora biti pozitivan broj do 64 karaktera");
                }


                Console.WriteLine("Unesite upc: Za izlazak unesite exit");
                sUpc = Console.ReadLine();
                if (sUpc.ToLower() == "exit") break;
                upc = -1;
                if (validator.ValidUPC(sUpc) != -1)
                {
                    upc = validator.ValidUPC(sUpc);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. UPC mora biti pozitivan celobrojan broj do 64 karaktera");
                }
                //Console.WriteLine($"{upc}\n");


                Console.WriteLine("Unesite cenu: Za izlazak unesite exit");
                sPrice = Console.ReadLine();
                if (sPrice.ToLower() == "exit") break;
                price = -1;
                if (validator.ValidatePrice(sPrice) != -1)
                {
                    price = validator.ValidatePrice(sPrice);
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Cena mora biti pozitivan broj do 64 karaktera");
                }
                //Console.WriteLine($"{price}\n");

                if (name != "-1" && tax != -1 && upc != -1 && price != -1 && discount != -1)
                {
                    product = new Product(name, upc, price);
                    Console.WriteLine(product.Ispis(tax, discount, product.upcPopustPar));
                }
                else
                {
                    Console.WriteLine("\n******U unosu postoji greska!*******\n");
                }
            }
         

        }
    }
}


