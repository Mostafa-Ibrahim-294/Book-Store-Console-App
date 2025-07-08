namespace BookStore
{
    public class DemoBook : Book
    {
        public DemoBook(string ISBN, string title, decimal price, DateOnly puplish) 
            : base(ISBN, title, price, puplish)
        {
        }

        public override bool IsSellable => false;
    }
}
