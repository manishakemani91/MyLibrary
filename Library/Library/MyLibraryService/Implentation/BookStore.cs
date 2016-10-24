using MyLibraryService.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace MyLibraryService.Implentation
{
    /// <summary>
    /// class with implemenation of bookStore interface to perform CRUD operation on book library
    /// </summary>
    public class BookStore : IBookStore
    {
        BookReposEntities entities = null;

        public BookStore(BookReposEntities entities)
        {
            this.entities = entities;
        }

        /// <summary>
        /// get list of books
        /// </summary>
        /// <returns>list of books</returns>
        public List<BookInfo> GetAllBooks()
        {
            return entities.BookInfoes.ToList();
        }

        /// <summary>
        /// get list of categories
        /// </summary>
        /// <returns>list of categories</returns>
        public List<Category> GetAllCategories()
        {
            return entities.Categories.ToList();
        }

        /// <summary>
        /// get book details based on book id
        /// </summary>
        /// <param name="id">book id</param>
        /// <returns>book info</returns>
        public BookInfo GetBookById(int id)
        {
            return entities.BookInfoes.SingleOrDefault(book => book.Id == id);
        }

        /// <summary>
        /// get list of books based on category selected
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>book list</returns>
        public List<BookInfo> GetBooksByCategoryId(int id)
        {
            return entities.BookInfoes.Where(book => book.Category_Id == id).ToList();
        }

        /// <summary>
        /// add a new book
        /// </summary>
        /// <param name="book">book info</param>
        public void AddBook(BookInfo book)
        {
            entities.BookInfoes.Add(book);
            entities.SaveChanges();
        }

        /// <summary>
        /// update book info
        /// </summary>
        /// <param name="book">book info</param>
        public void UpdateBook(BookInfo book)
        {
            entities.BookInfoes.Attach(book);
            entities.Entry(book).State = EntityState.Modified;
            entities.SaveChanges();
        }

        /// <summary>
        /// remove a book
        /// </summary>
        /// <param name="book">book info</param>
        public void DeleteBook(BookInfo book)
        {
            entities.BookInfoes.Remove(book);
            entities.SaveChanges();
        }
    }
}