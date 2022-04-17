using System;

namespace GameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("LEGO blokovi = Friends Forest House", 41679, 20.25);
            Console.WriteLine(product1.Ispis(52.34, 26));
        }
    }
}
