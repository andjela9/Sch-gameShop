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
        private bool discountBefore { get; set; }

        public Dictionary<int, double> upcPopustPar = new Dictionary<int, double>();


        public Product(string name, int upc, double price, Dictionary<int, double> dict, bool discBefore)
        {
            this.Name = name;
            this.UPC = upc;
            this.price = price;
            this.upcPopustPar = dict;               //potencijalan bag, shallow copy
            this.discountBefore = discBefore;
        }


        public double TaxOrDiscountOnly(double tax, double price)
        {
            return Math.Round((tax / 100) * price, 2);
        }

        

        public double afterTaxAndDiscount(double tax, double discount)
        {
            return Math.Round(this.price + this.TaxOrDiscountOnly(tax, this.price) - this.TaxOrDiscountOnly(discount, this.price) - this.selectiveDiscount(),  2);
        }

        public double selectiveDiscount()
        {
            foreach (KeyValuePair<int, double> kvp in this.upcPopustPar)
            {
                if (kvp.Key == this.UPC)      //ima dodatni popust
                {
                    return Math.Round((kvp.Value / 100) * this.price, 2);
                }
            }
            return 0;
        }

        public double totalDiscount(Dictionary<int, double> dict, double disc)
        {
            if (discountBefore)
            {
                double prviPopust = selectiveDiscount();             //prvi popust
                double drugiPopust = TaxOrDiscountOnly(disc, price - prviPopust);        //drugi popust na novu, umanjenu cenu
                                                                                      //nova osnovica
                return prviPopust + drugiPopust;
            }
            else
            {
                return this.selectiveDiscount() + this.TaxOrDiscountOnly(disc, this.price);
            }
        }

        //dati i porezu tu novu cenu

        public string Ispis(double tax, double discount, Dictionary<int, double> dict)
        {
            //return $"\n\nIme = {Name}, UPC = {UPC}, cena = {price} rsd.\n" +
            //    //$"Cena {price} pre poreza i {this.fixedTax()} nakon 20% poreza. \n " +
            //    $"Porez = {tax}%, Popust = {discount}%\n" +
            //    $"Iznos poreza = {this.TaxOrDiscountOnly(tax)} rsd, Iznos ukupnog popusta = {this.totalDiscount(dict, discount)} rsd\n" +
            //    $"Osnovna cena = {price} rsd, Cena nakon popusta i poreza = {this.afterTaxAndDiscount(tax, discount, dict)} rsd\n\n";
            return $"\n\nIme = {Name}, UPC = {UPC}, Cena pre poreza i popusta = {price} rsd.\n" +
                $"Odbijeno je = {this.totalDiscount(dict, discount)}\n" +
                $"Krajnja cena: {this.afterTaxAndDiscount(tax, discount)}\n\n";

        }

        

  


    }
}
