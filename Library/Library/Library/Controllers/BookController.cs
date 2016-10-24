using MyLibraryService;
using MyLibraryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        IBookStore _bookStore;

        public BookController(IBookStore bookstore)
        {
            _bookStore = bookstore;
        }

        /// <summary>
        /// shows list of books
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.categorydd1 = new SelectList(_bookStore.GetAllCategories(), "Cat_Id", "Cat_Name", "select");
            var bookList = _bookStore.GetAllBooks();
            return View(bookList);
        }

        /// <summary>
        /// Add a new book based on category
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.categorydd1 = new SelectList(_bookStore.GetAllCategories(), "Cat_Id", "Cat_Name", "select");
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookInfo book)
        {
            _bookStore.AddBook(book);
            return RedirectToAction("Index", "Book");
        }

        /// <summary>
        /// Get List of books based on category selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            ViewBag.categorydd1 = new SelectList(_bookStore.GetAllCategories(), "Cat_Id", "Cat_Name", "select");
            List<BookInfo> bookList = new List<BookInfo>();
            bookList = _bookStore.GetBooksByCategoryId(Convert.ToInt32(id));
            return View(bookList);
        }

        /// <summary>
        /// update book details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.categorydd1 = new SelectList(_bookStore.GetAllCategories(), "Cat_Id", "Cat_Name", "select");
            var bookDetails = _bookStore.GetBookById(id);
            return View(bookDetails);
        }

        [HttpPost]
        public ActionResult Edit(BookInfo book)
        {
            
             _bookStore.UpdateBook(book);
            return RedirectToAction("Index", "Book");
        }

        /// <summary>
        /// delete a book from list of books
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            
            var bookDetails = _bookStore.GetBookById(id);
            _bookStore.DeleteBook(bookDetails);
            return RedirectToAction("Index", "Book");
        }

    }
}