using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop
{
    class ValidateInput
    {
 
        public string ValidName(string name)
        {
            if(name.Length > 0 && name.Length <= 64 && name != " ")
            {
                return name;
            }
            else
            {
                return "-1";
            }
        }

        public int ValidUPC(string sUpc)
        {
            if(Int32.TryParse(sUpc, out int upc) && sUpc.Length <= 64 && upc>0)
            {
                return upc;
            }
            else
            {
                return -1;
            }
        }

        public double ValidTax(string sTax)
        {
            if (sTax.EndsWith("%"))
            {
                sTax = sTax.Trim('%');
            }
            sTax.Trim();
            sTax = sTax.Replace('.', ',');
            if (Double.TryParse(sTax, out double tax) && tax >= 0 && sTax.Length <= 64)
            {
                return tax;
            }
            else
            {
                return -1;
            }
        }

        public double ValidRSD(string sRsd)
        {
            if (sRsd.EndsWith("RSD"))
            {
                sRsd = sRsd.Replace("RSD", "");
            }
            sRsd.Trim();
            sRsd = sRsd.Replace('.', ',');
            if (Double.TryParse(sRsd, out double rsd) && rsd >= 0 && sRsd.Length <= 64)
            {
                return rsd;
            }
            else
            {
                return -1;
            }
        }

        public double ValidatePrice(string sPrice)
        {
            sPrice = sPrice.Replace('.', ',');
            if (Double.TryParse(sPrice, out double price) && price >= 0 && sPrice.Length <= 64)
            {
                return price;
            }
            else
            {
                return -1;
            }
        }


    }
}

//porez: % , . -  64
//cena: , . -
//upc: ceo broj
//naziv: ne sme prazan, bez razmaka
