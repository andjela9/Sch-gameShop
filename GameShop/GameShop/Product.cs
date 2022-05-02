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

        public double fixedTax() {
            return Math.Round(1.2 * this.price, 2);
        }

        public double TaxOrDiscountOnly(double tax)
        {
            return Math.Round((tax / 100) * this.price, 2);
        }

        public double withTax(double tax)
        {
            return Math.Round(((100 + tax) / 100) * this.price, 2);
        }

        public double withDiscount(double discount)
        {
            return Math.Round(((100 - discount)/100) * this.price, 2);
        }

        public double afterTaxAndDiscount(double tax, double discount)
        {
            return Math.Round(this.price + this.TaxOrDiscountOnly(tax) - this.TaxOrDiscountOnly(discount), 2);
        }

        public string Ispis(double tax, double discount)
        {
            return $"\n\nIme = {Name}, UPC = {UPC}, cena = {price} rsd.\n" +
                //$"Cena {price} pre poreza i {this.fixedTax()} nakon 20% poreza. \n " +
                $"Porez = {tax}%, Popust = {discount}%\n" +
                $"Iznos poreza = {this.TaxOrDiscountOnly(tax)} rsd, Iznos popusta = {this.TaxOrDiscountOnly(discount)} rsd\n" +
                $"Osnovna cena = {price} rsd, Cena nakon popusta i poreza = {this.afterTaxAndDiscount(tax, discount)} rsd\n\n";
        }
        //      dodati unos naziva, upc, cene, zastite za to (validacija)
        //      upc mora biti celobrojan, bez specijalnih karaktera itd
        //      naziv ne sme prazan ili samo razmak
        //      decimala treba da prihvata i . i , i za cenu i za procenat
        //      ogranicen br karaktera po polju, npr 64
        //      ne mora da ispise posle 20% nego zadatog
        //      exit na dugme
        //      da moze da racuna sa 20% (unet na kraju %)
        //      negativan broj
        //      DONE


    }
}
