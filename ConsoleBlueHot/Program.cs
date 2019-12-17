using System;
using System.Linq;
using Dal;
namespace ConsoleBlueHot
{
    public class Program
    {
        static void Main(string[] args)
           
        {
            using (BlueContext context = new BlueContext())
            {
                context.Database.EnsureCreated();
                
                var bookings = context.Bookings.ToList();
            }
                Console.WriteLine("Hello !");
        }
    }
}
