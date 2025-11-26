using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface ILibraryItem
    {
        int Id { get; }
        string Title { get; }
        int Year { get; }

        string GetDisplayInfo();
    }
}

