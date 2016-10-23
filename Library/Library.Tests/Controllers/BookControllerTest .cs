using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using Library.Controllers;
using MyLibraryService;
using MyLibraryService.Interface;
using Moq;

namespace Library.Tests.Controllers
{
    [TestClass]
    public class BookControllerTest
    {
      /// <summary>
      /// to test addition of a book object
      /// </summary>
            [TestMethod]
        public void TestMethod1()
        {
            //arrange  
            var book = new BookInfo() { Id = 1, Name = "hello", Category_Id = 1 };



            //Arrange
            var mockRepository = new Mock<IBookStore>();
            mockRepository.Setup(x => x.AddBook(book));
            var controller = new BookController(mockRepository.Object);

            //Act
            controller.Create(book);

            //Assert
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// to test listing of  books
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            
            var book1 = new BookInfo() { Id = 1, Name = "hello", Category_Id = 1 };
            var book2 = new BookInfo() { Id = 1, Name = "hello", Category_Id = 1 };

            List<BookInfo> booklist = new List<BookInfo>();

            booklist.Add(book1);
            booklist.Add(book2);


            
            var category = new Category() { Cat_Id = 1, Cat_Name = "horror"};

            List<Category> categories = new List<Category>();

            categories.Add(category);
            
            //Arrange
            var mockRepository = new Mock<IBookStore>();
            mockRepository.Setup(x => x.GetAllBooks()).Returns(booklist);

            mockRepository.Setup(x => x.GetAllCategories()).Returns(categories);
            var controller = new BookController(mockRepository.Object);

            //Act
          var result =  controller.Index();

            //Assert
            Assert.AreEqual(booklist.Count, ((System.Web.Mvc.ViewResultBase)result).ViewEngineCollection.Count);
            //mockRepository.VerifyAll();
        }
    }
}

