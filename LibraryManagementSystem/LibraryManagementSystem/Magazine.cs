using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Magazine : LibraryItemBase
    {
        public int IssueNumber { get; }

        public Magazine(string title, int year, int issueNumber)
            : base(title, year)
        {
            IssueNumber = issueNumber;
        }

        public override string GetItemType() => "Magazine";

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Issue: {IssueNumber}";
        }
    }
}

