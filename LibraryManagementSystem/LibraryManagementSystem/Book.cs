using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book : LibraryItemBase
    {
        public string Author { get; }

        public Book(string title, int year, string author)
            : base(title, year)
        {
            Author = author;
        }

        public override string GetItemType() => "Book";

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Author: {Author}";
        }
    }
}
