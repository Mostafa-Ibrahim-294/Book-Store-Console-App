namespace BookStore
{
    public class EBook : Book 
    {
        public FileType fileType { get; set; }

        public override bool IsSellable => true;

        public EBook(string ISBN, string title, decimal price, DateOnly puplish , FileType fileType)
            : base(ISBN, title, price, puplish)
        {
            this.fileType = fileType;
        }


    }
   

}
