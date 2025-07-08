namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                IMaleService maleService = new EmailService();
                Store store = new Store(maleService);

                Book paperBook = new PaperBook("ISBN-001", "Clean Code", 50.0M, new DateOnly(2019, 4, 11), 10);
                Book eBook = new EBook("ISBN-002", "Effective C#", 40.0M, new DateOnly(2020, 4, 11), FileType.PDF);
                Book demoBook = new DemoBook("ISBN-003", " Demo", 0.0M, new DateOnly(2023, 3, 22));

                store.AddBook(paperBook);
                store.AddBook(eBook);
                store.AddBook(demoBook);

                Console.WriteLine("\n--- Buy Paper Book ---");
                store.BuyBook("ISBN-001", 2, "user@email.com", "Cairo, Egypt");

                Console.WriteLine("\n--- Buy EBook ---");
                store.BuyBook("ISBN-002", 1, "user@email.com", "");

                Console.WriteLine("\n--- Try to Buy Showcase Book ---");
                try
                {
                    store.BuyBook("ISBN-003", 1, "user@email.com", "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Quantum book store: " + ex.Message);
                }

                Console.WriteLine("\n--- Remove outdated books ---");
                store.RemoveOutDatedBooks(10);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            } 
    }
}
