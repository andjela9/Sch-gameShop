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


        public double Discount(double discount, double price)
        {
            return Math.Round((discount / 100) * price, 2);
        }

        public double Tax(double tax, double price)
        {
            if (discountBefore)
            {
                return Math.Round((tax / 100) * (price - selectiveDiscount()), 2);
                
            }
            else
            {
                return Math.Round((tax / 100) * price, 2);
            }
        }

        public double TotalPrice(double discount, double tax)
        {
            return Math.Round(price - totalDiscount(upcPopustPar, discount) + Tax(tax, price), 2);
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
                double drugiPopust = Discount(disc, price - prviPopust);        //drugi popust na novu, umanjenu cenu
                                                                                      //nova osnovica
                return prviPopust + drugiPopust;
            }
            else
            {
                return this.selectiveDiscount() + this.Discount(disc, this.price);
            }
        }

        
        public string Ispis(double tax, double discount, Dictionary<int, double> dict)
        {
            return $"\n\nIme = {Name}, UPC = {UPC}, Cena pre poreza i popusta = {price} rsd.\n" +
                $"Odbijeno je = {this.totalDiscount(dict, discount)}\n" +
                $"Krajnja cena: {this.TotalPrice(discount, tax)}\n\n";

        }

        
    }
}
