using AutoproffAssignment1.Controller;
using AutoproffAssignment1.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoproffAssignment1.Tests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController bookController;

        [SetUp]
        public void SetUp()
        {
            bookController = new BookController();
        }

        [Test]
        public void TestReadBooks()
        {
            // Arrange
            string input = @"
                Book:
                Author: J.K. Rowling
                Title: Harry Potter and the Philosopher's Stone
                Publisher: Bloomsbury Publishing
                Published: 1997
                NumberOfPages: 223
                
                Book: 
                Author: J.R.R. Tolkien
                Title: The Hobbit
                Publisher: Houghton Mifflin
                Published: 1937
                NumberOfPages: 310
                
                Book:
                Author: Terry Pratchett
                Author:Neil Gaiman
                Title: Good Omens
                Publisher: Workman Publishing Company
                Published: 1990
                NumberOfPages: 412
            ";

            // Act
            List<Book> books = bookController.ReadBooks(input);

            // Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(3, books.Count);
            Assert.AreEqual("J.K. Rowling", string.Join(", ", books[0].Authors));
            Assert.AreEqual("Harry Potter and the Philosopher's Stone", books[0].Title);
            Assert.AreEqual("Bloomsbury Publishing", books[0].Publisher);
            Assert.AreEqual(1997, books[0].PublicationYear);
            Assert.AreEqual(223, books[0].NumberOfPages);
            Assert.AreEqual("J.R.R. Tolkien", string.Join(", ", books[1].Authors));
            Assert.AreEqual("The Hobbit", books[1].Title);
            Assert.AreEqual("Houghton Mifflin", books[1].Publisher);
            Assert.AreEqual(1937, books[1].PublicationYear);
            Assert.AreEqual(310, books[1].NumberOfPages);
            Assert.AreEqual("Terry Pratchett, Neil Gaiman", string.Join(", ", books[2].Authors));
            Assert.AreEqual("Good Omens", books[2].Title);
            Assert.AreEqual("Workman Publishing Company", books[2].Publisher);
            Assert.AreEqual(1990, books[2].PublicationYear);
            Assert.AreEqual(412, books[2].NumberOfPages);
        }

        [Test]
        public void TestFindBooks()
        {
            // Arrange
            List<Book> allBooks = new List<Book>
            {
                new Book(new List<string>{"J.K. Rowling"}, 1997, "Bloomsbury Publishing", 223, "Harry Potter and the Philosopher's Stone", "978-1-4088-0348-9"),
                new Book(new List<string>{"J.R.R. Tolkien"}, 1937, "Houghton Mifflin", 310, "The Hobbit", "978-0-618-00221-1"),
                new Book(new List<string>{"George Orwell"}, 1949, "Secker & Warburg", 328, "Nineteen Eighty-Four", "978-0-14-103614-4"),
            };

            string searchString = "*J.*";

            // Act
            List<Book> foundBooks = bookController.FindBooks(searchString);

            // Assert
            Assert.AreEqual(2, foundBooks.Count);
            Assert.IsTrue(foundBooks.Any(b => b.Title.Contains("J.") ||
                                         b.Authors.Any(a => a.Contains("J.")) ||
                                         b.Publisher.Contains("J.") ||
                                         b.PublicationYear.ToString().Contains("J.") ||
                                         b.ISBN.Contains("J.")));

            string searchString1 = "*J.* & *19* & *Hobbit*";

            // Act
            List<Book> foundBooks1 = bookController.FindBooks(searchString1);

            // Assert
            Assert.AreEqual(1, foundBooks1.Count);
            Assert.IsTrue(foundBooks1.Any(b => (b.Title.Contains("J.") ||
                                        b.Authors.Any(a => a.Contains("J.")) ||
                                        b.Publisher.Contains("J.") ||
                                        b.PublicationYear.ToString().Contains("J.") ||
                                        b.ISBN.Contains("J.")) 
                                        &&
                                        (b.Title.Contains("19") ||
                                        b.Authors.Any(a => a.Contains("19")) ||
                                        b.Publisher.Contains("19") ||
                                        b.PublicationYear.ToString().Contains("19") ||
                                        b.ISBN.Contains("19")) 
                                        &&
                                        (b.Title.Contains("Hobbit") ||
                                        b.Authors.Any(a => a.Contains("Hobbit")) ||
                                        b.Publisher.Contains("Hobbit") ||
                                        b.PublicationYear.ToString().Contains("Hobbit") ||
                                        b.ISBN.Contains("Hobbit"))
                                        ));

        }

        [Test]
        public void TestRegisterBook()
        {
            // Arrange
            string isbn = "978-1-3154-2587-9";
            string authors = "Margaret Atwood, Bernardine Evaristo";
            string title = "The Testaments";
            int publicationYear = 2019;
            string publisher = "Vintage Books";
            int numberOfPages = 432;

            // Act & Assert
            Assert.DoesNotThrow(() => bookController.RegisterBook(isbn, authors, title, publicationYear, publisher, numberOfPages));

        }
    }
}
