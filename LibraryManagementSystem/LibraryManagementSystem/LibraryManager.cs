using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class LibraryManager
    {
        private LibraryCatalog<Book> _bookCatalog;
        private LibraryCatalog<Magazine> _magazineCatalog;

        public LibraryManager()
        {
            _bookCatalog = new LibraryCatalog<Book>();
            _magazineCatalog = new LibraryCatalog<Magazine>();
        }

        public void AddItem(ILibraryItem item)
        {
            if (item is Book book)
            {
                _bookCatalog.AddItem(book);
            }
            else if (item is Magazine magazine)
            {
                _magazineCatalog.AddItem(magazine);
            }
        }

        public List<ILibraryItem> GetAllItems()
        {
            var result = new List<ILibraryItem>();
            result.AddRange(_bookCatalog.GetAllItems());
            result.AddRange(_magazineCatalog.GetAllItems());
            return result;
        }

        public ILibraryItem GetItemById(int id)
        {
            var book = _bookCatalog.GetItemById(id);
            if (book != null) return book;

            var magazine = _magazineCatalog.GetItemById(id);
            if (magazine != null) return magazine;

            return null;
        }
    }
}
