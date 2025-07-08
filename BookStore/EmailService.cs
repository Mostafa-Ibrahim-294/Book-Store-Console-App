using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class EmailService : IMaleService
    {
        public void SendService(EBook book ,string email )
        {
            Console.WriteLine("Email service is sending an email notification.");
        }
    }
}
