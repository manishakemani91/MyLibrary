using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryService.Interface
{
    public interface IBookStore
    {
        List<BookInfo> GetAllBooks();
        BookInfo GetBookById(int id);
        void AddBook(BookInfo book);
        void UpdateBook(BookInfo book);
        void DeleteBook(BookInfo book);
        List<BookInfo> GetBooksByCategoryId(int id);
        List<Category> GetAllCategories();
    }
}
