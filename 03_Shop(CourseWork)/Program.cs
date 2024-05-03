using _03_Shop_CourseWork_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _03_Shop_CourseWork_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopDbContext context = new ShopDbContext();
            for (int i=1;i<=context.Shops.Count();i++)
            {
                var info = context.Shops.Find(i);
                Console.WriteLine($"---------------Shop----------------------\nShop : {info.Name} Address : {info.Address}");
                context.Entry(info).Collection(s => s.Workers).Load();
                Console.WriteLine("----------------Workers-------------------");
                foreach (var worker in info.Workers)
                {
                    Console.WriteLine($"Name : {worker.Name} Surname : {worker.Surname} Email : {worker.Email}");
                }
                context.Entry(info).Collection(s => s.Products).Load();
                Console.WriteLine("----------------Products-------------------");
                foreach (var prod in info.Products)
                {
                    Console.WriteLine($"Name : {prod.Name} Price : {prod.Price} Quantity : {prod.Quantity}");
                }
            }
        }
    }
}
