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

        public Dictionary<int, double> upcPopustPar = new Dictionary<int, double>();


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

        public double afterTaxAndDiscount(double tax, double discount, Dictionary<int, double> dict)
        {
            return Math.Round(this.price + this.TaxOrDiscountOnly(tax) - this.TaxOrDiscountOnly(discount) - this.selectiveDiscount(dict), 2);
        }

        public string Ispis(double tax, double discount, Dictionary<int, double> dict)
        {
            //return $"\n\nIme = {Name}, UPC = {UPC}, cena = {price} rsd.\n" +
            //    //$"Cena {price} pre poreza i {this.fixedTax()} nakon 20% poreza. \n " +
            //    $"Porez = {tax}%, Popust = {discount}%\n" +
            //    $"Iznos poreza = {this.TaxOrDiscountOnly(tax)} rsd, Iznos ukupnog popusta = {this.totalDiscount(dict, discount)} rsd\n" +
            //    $"Osnovna cena = {price} rsd, Cena nakon popusta i poreza = {this.afterTaxAndDiscount(tax, discount, dict)} rsd\n\n";
            return $"\n\nIme = {Name}, UPC = {UPC}, Cena pre poreza i popusta = {price} rsd.\n" +
                $"Odbijeno je = {this.totalDiscount(dict, discount)}\n" +
                $"Krajnja cena: {this.afterTaxAndDiscount(tax, discount, dict)}\n\n";

        }

        public double selectiveDiscount(Dictionary<int, double> dict)
        {
            foreach(KeyValuePair<int, double> kvp in dict)
            {
                if(kvp.Key == this.UPC)      //ima dodatni popust
                {
                    return Math.Round((kvp.Value / 100) * this.price, 2);
                }
            }
            return 0;
        }

        public double totalDiscount(Dictionary<int, double> dict, double disc)
        {
            return this.selectiveDiscount(dict) + this.TaxOrDiscountOnly(disc);
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
