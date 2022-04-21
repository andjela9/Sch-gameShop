using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop
{
    class Product
    {
        private string Name { get; set; }
        private int UPC { get; set; }
        private double price { get; set; }

        public Product(string name, int upc, double price)
        {
            this.Name = name;
            this.UPC = upc;
            this.price = price;
        }

        public double fixedTax(double price) {
            return Math.Round(0.8 * price, 2);
        }

        public double customTax(double price, double tax)
        {
            return Math.Round(((100 - tax) / 100) * price, 2);
        }

        public string Ispis(double price, double tax)
        {
            return $"{Name}, UPC = {UPC}, cena = {price}.\n " +
                $"Cena {price} pre poreza i {this.fixedTax(price)} nakon 20% poreza. \n " +
                $"Cena {price} pre poreza i {this.customTax(price, tax)} nakon {tax}% poreza";
        }
        //      dodati unos naziva, upc, cene, zastite za to (validacija)
        //      upc mora biti celobrojan, bez specijalnih karaktera itd
        //      naziv ne sme prazan i da nema razmak
        //      decimala da prihvata i . i , i za cenu i za procenat
        //      ogranicen br karaktera po polju, npr 64
        // ne mora da ispise posle 20% nego zadatog
        //      exit na dugme
        //      da moze da racuna sa 20% (unet na kraju %)
        //      negativan broj


    }
}
