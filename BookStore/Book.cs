using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public abstract class Book
    {
        private decimal price;
       public string ISBN { get; set; }
        public string Title { get; set; }
        public decimal Price { get => price; set => price = value > 0 ? value : 0; }
        public DateOnly PublishDate { get; set; }
        public abstract bool IsSellable { get; }
        protected Book(string ISBN, string title, decimal price, DateOnly puplish )
        {
            this.ISBN = ISBN;
            this.Title = title;
            this.Price = price;
            this.PublishDate = puplish;
        }
    }
}
