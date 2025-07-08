using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Store
    {
        private readonly Dictionary<string, Book> inventory = new();
        IMaleService maleService;
        public Store(IMaleService maleService)
        {
            this.maleService = maleService;
        }
        public void AddBook(Book book)
        {
            if (book == null || string.IsNullOrEmpty(book.ISBN))
            {
                throw new ArgumentException("Invalid book.");
            }
            if (inventory.ContainsKey(book.ISBN))
            {
                throw new InvalidOperationException("Book with the same ISBN already exists.");
            }
            inventory[book.ISBN] = book;
        }
        public void RemoveOutDatedBooks(int maxYears)
        {
            if (maxYears <= 0)
            {
                throw new ArgumentException("Max years must be greater than zero.");
            }
            var thresholdDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-maxYears));
            var outdatedBooks = inventory.Values
                .Where(b => b.PublishDate < thresholdDate)
                .Select(b => b.ISBN)
                .ToList();
            foreach (var isbn in outdatedBooks)
            {
                inventory.Remove(isbn);
            }
        }
        public decimal BuyBook(string isbn, int quantity, string email, string address)
        {
            if (!inventory.ContainsKey(isbn))
                throw new Exception("book store: Book not found.");

            var book = inventory[isbn];
            if (!book.IsSellable)
                throw new Exception(" book store: Book not for sale.");

            if (book is PaperBook paperBook)
            {
                paperBook.ReduceQuantity(quantity);
                ShippingService.ShipBook(paperBook, address);
            }
            else
            {
                var ebook = book as EBook;
                maleService.SendService(ebook, email);
            }

            decimal total = book.Price * quantity;

            return total;
        }
    }
}
