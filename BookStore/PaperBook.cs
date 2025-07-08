namespace BookStore
{
   public class PaperBook : Book
    {
        private int quantity;
        public int Quantity { get => quantity; set => quantity = value > 0 ? value : 0; }
        public override bool IsSellable { get => true; }

        public PaperBook(string ISBN, string title, decimal price, DateOnly puplish, int quantity)
            : base(ISBN, title, price, puplish)
        {
            this.Quantity = quantity;
        }

        public void ReduceQuantity(int quantity)
        {
            Quantity -= quantity;
        }
    }
}
