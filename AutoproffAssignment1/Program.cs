using AutoproffAssignment1.Controller;
using AutoproffAssignment1.Model;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1
{

    internal class Program
    {

        static BookController bookController = new BookController();
        static LibraryController libraryController = new LibraryController();
        
        static void Main(string[] args)
        {
            Book book = new Book();

            var booksString = "Book:" +
            "Author: Brian Jensen" +
            "Title: Texts from Denmark" +
            "Publisher: Gyldendal" +
            "Published: 2001" +
            "NumberOfPages: 253" +
            "Book:" +
            "Author: Brian Jensen" +
            "Author: Hans Andersen" +
            "Title: Stories from abroad" +
            "Publisher: Borgen" +
            "Published: 2012" +
            "NumberOfPages: 156";

            var readBooks = bookController.ReadBooks(booksString);
            
            var findBooks = bookController.FindBooks("*peter* & *20*");
            
            var findBookByISBN = bookController.FindBooks("978-4-324-23423-9").FirstOrDefault();
            if(findBookByISBN == null)
            {
                Console.WriteLine("The book can not found!");
            }
            else
            {
                Console.WriteLine("Title of the found book:{0}", findBookByISBN.Title);
            }

            RegisterNewBook();

            Console.WriteLine();
            Console.Write("Please enter the type for the inventory list(1 for Room, 2 for Row and 3 for Bookshelf): ");
            string typeForInventoryListInput = Console.ReadLine();

            var typeForInventoryList = !String.IsNullOrEmpty(typeForInventoryListInput) ? Convert.ToInt32(typeForInventoryListInput) : 0;

            var getInventoryList = libraryController.GetInventoryLists(1, typeForInventoryList);

            Console.ReadLine();
        }

        //For 1.3
        public static void RegisterNewBook()
        {
            Console.WriteLine("Welcome to the Book Register System!");
            Console.WriteLine("---------------------------------\n\n");

            Console.WriteLine("Please enter the following information for a new book:\n\n");

            // Prompt the user to enter the ISBN of the book
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            // Prompt the user to enter the title of the book
            Console.Write("Title: ");
            string title = Console.ReadLine();

            // Prompt the user to enter the author(s) of the book (comma-separated if multiple)
            Console.Write("Author(s) (comma-separated if multiple): ");
            var authors = Console.ReadLine();

            // Prompt the user to enter the publication year of the book
            Console.Write("Publication Year: ");
            string publicationYearInput = Console.ReadLine();
            var publicationYear = !String.IsNullOrEmpty(publicationYearInput) ? Convert.ToInt32(publicationYearInput) : 0;

            // Prompt the user to enter the publisher of the book
            Console.Write("Publisher: ");
            string publisher = Console.ReadLine();

            // Prompt the user to enter the number of pages of the book
            Console.Write("Number Of Pages: ");
            string numberOfPagesInput = Console.ReadLine();
            var numberOfPages = !String.IsNullOrEmpty(numberOfPagesInput) ? Convert.ToInt32(numberOfPagesInput) : 0;

            // Call the RegisterBook method of the bookController object with the provided information
            bookController.RegisterBook(isbn, authors, title, publicationYear, publisher, numberOfPages);
        }

    }
}
