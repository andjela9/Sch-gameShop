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


    }
}
