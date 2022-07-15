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
        private Dictionary<string, double> costsRSD = new Dictionary<string, double>();
        private Dictionary<string, double> costsPercent = new Dictionary<string, double>();

        private ValidateInput Validator = new ValidateInput();

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
            return Math.Round(price - totalDiscount(upcPopustPar, discount) + Tax(tax, price) + AdditionalCosts(price), 2);
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
                return Math.Round(this.selectiveDiscount() + this.Discount(disc, this.price), 2);
            }
        }

        
        public string Ispis(double tax, double discount, Dictionary<int, double> dict)
        {
            return $"\n\nIme = {Name}, UPC = {UPC}, Osnovna cena = {price} rsd.\n" +
                $"Porez = {this.Tax(tax, price)}\n" +
                $"Popusti = {this.totalDiscount(dict, discount)}\n" +
                $"{this.AdditionalCostsPrint(price)}\n" +
                $"UKUPNO: {this.TotalPrice(discount, tax)}\n\n";
                
        }

        public bool IsRSDCost(string s)
        {
            s.Trim();
            if (s.EndsWith("RSD") || s.EndsWith("rsd"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPercentCost(string s)
        {
            s.Trim();
            if (s.EndsWith("%"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InputAdditionalCosts()
        {
            bool badInput = false;
            while(true)
            {
                Console.WriteLine("Unesite naziv troska");
                string naziv = Console.ReadLine();
                if (naziv.ToUpper() == "STOP") break;
                Console.WriteLine("Unesite iznos RSD ili %");
                string iznos = Console.ReadLine();
                if (iznos.ToUpper() == "STOP") break;
                //Console.WriteLine("***PRE IF");
                if (IsRSDCost(iznos) && !IsPercentCost(iznos))          //u dinarima popust
                {
                    //Console.WriteLine("USAO U IF");
                    double rsd = Validator.ValidRSD(iznos);
                    //Console.WriteLine($"RSD = {rsd}");
                    if(rsd != -1)
                    {
                        costsRSD.Add(naziv, rsd);
                    }
                    else
                    {
                        badInput = true;
                    }

                }
                else if(!IsRSDCost(iznos) && IsPercentCost(iznos))      //u procentima popust
                {
                    double percent = Validator.ValidTax(iznos);
                    //Console.WriteLine($"% = {percent}");
                    if(percent != -1)
                    {
                        costsPercent.Add(naziv, percent);
                    }
                    else
                    {
                        badInput = true;
                    }
                }
                else                    // nisu ni procenti ni dinari, los unos
                {
                    badInput = true;
                    break;
                }
            }
            if (badInput)
            {
                Console.WriteLine("Neuspesan unos");
            }
        }

        public string AdditionalCostsPrint(double price)
        {
            //Console.WriteLine("Dinarski troskovi: \n");
            string s = "";
            foreach (KeyValuePair<string, double> kvp in costsRSD)
            {
                //Console.WriteLine($"{kvp.Key} = {kvp.Value} RSD");
                //s += $"{kvp.Key} = {kvp.Value} RSD\n";
                s = string.Concat(s, $"{kvp.Key} = {kvp.Value} RSD\n");
            }
            //Console.WriteLine("Troskovi u procentima: \n");
            foreach (KeyValuePair<string, double> kvp in costsPercent)
            {
                //Console.WriteLine($"{kvp.Key} = {(kvp.Value/100) * price} RSD");
                //s += $"{kvp.Key} = {(kvp.Value / 100) * price} RSD\n";
                s = string.Concat(s, $"{kvp.Key} = {Math.Round((kvp.Value / 100) * price, 2)} RSD\n");
            }
            return s;
        }

        public double AdditionalCosts(double price)
        {
            double RSDCosts = 0;
            double percentCosts = 0;
            double totalCosts = 0;
            foreach(KeyValuePair<string, double> kvp in costsRSD)
            {
                RSDCosts += kvp.Value;
            }
            foreach (KeyValuePair<string, double> kvp in costsPercent)
            {
                percentCosts += (kvp.Value/100) * price;
            }
            totalCosts = percentCosts + RSDCosts;
            return Math.Round(totalCosts, 2);
        }






    }
}
