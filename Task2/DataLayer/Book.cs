using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal partial class Book
    {
        public Book(int bookId, string title, int state, float fee)
        {
            BookId = bookId;
            Title = title;
            State = state;
            Fee = fee;
        }
    }
}
