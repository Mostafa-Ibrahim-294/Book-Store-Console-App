using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class ShippingService
    {
        public static void ShipBook(PaperBook paperBook, string address)
        {
           
            Console.WriteLine($"Shipping book with ISBN {paperBook.ISBN} to address: {address}");
        }
        
    }
}
