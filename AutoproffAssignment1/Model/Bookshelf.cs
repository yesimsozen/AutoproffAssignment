using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1.Model
{
    public class Bookshelf
    {
        public int BookshelfId { get; set; }
        public List<Book> Books { get; set; }

        private static List<Bookshelf> bookshelves = new List<Bookshelf>();

        // Represents a read-only list of all bookshelves
        public static IReadOnlyList<Bookshelf> AllBookshelves => bookshelves;

        static Bookshelf()
        {
            InitializeBookshelves();
        }

        private static void InitializeBookshelves()
        {
            Bookshelf bookshelf1 = new Bookshelf(1);
            bookshelf1.Books = new List<Book>();
            bookshelf1.Books.Add(new Book(new List<string> { "Yesim Sozen", "Ugur Efe Sozen" }, 2023, "Publisher Company", 200, "Our Life", "978-0-133-01561-2"));
            bookshelf1.Books.Add(new Book(new List<string> { "Kim Kirsten" }, 2022, "Publisher Company", 240, "Book 1", "978-0-324-01385-6"));

            Bookshelf bookshelf2 = new Bookshelf(2);
            bookshelf2.Books = new List<Book>();
            bookshelf2.Books.Add(new Book(new List<string> { "Jens Bjerne" }, 2021, "Publisher Company1", 150, "Book 2", "978-4-324-23423-9"));
            bookshelf2.Books.Add(new Book(new List<string> { "Svend Kolegia" }, 2020, "Publisher Company2", 312, "Book 3", "978-6-9878-9878-7"));

            Bookshelf bookshelf3 = new Bookshelf(3);
            bookshelf3.Books = new List<Book>();
            bookshelf3.Books.Add(new Book(new List<string> { "John Maleria" }, 1995, "Publisher Company3", 420, "Book 4", "978-0-3654-9852-2"));

            Bookshelf bookshelf4 = new Bookshelf(4);
            bookshelf4.Books = new List<Book>();
            bookshelf4.Books.Add(new Book(new List<string> { "Thomas William" }, 1999, "Publisher Company4", 852, "Book 5", "978-2-08-147169-0"));
            bookshelf4.Books.Add(new Book(new List<string> { "Sanne Ksenia" }, 2010, "Publisher Company5", 116, "Book 6", "978-1-908-09745-1"));

            Bookshelf bookshelf5 = new Bookshelf(5);
            bookshelf5.Books = new List<Book>();
            bookshelf5.Books.Add(new Book(new List<string> { "Arthur Rasmussen" }, 2022, "Publisher Company4", 154, "Book 7", "978-1-00-357159-9"));
            bookshelf5.Books.Add(new Book(new List<string> { "Taylor Larsen" }, 2023, "Publisher Company5", 216, "Book 8", "978-7-794613-12-8"));

            Bookshelf bookshelf6 = new Bookshelf(6);
            bookshelf6.Books = new List<Book>();
            bookshelf6.Books.Add(new Book(new List<string> { "Toni Nielsen" }, 2009, "Publisher Company6", 380, "Book 9", "978-5-7971-8293-4"));
            bookshelf6.Books.Add(new Book(new List<string> { "Ida Olsen" }, 2015, "Publisher Company7", 290, "Book 10", "978-3-6958-5047-3"));
        }

        public Bookshelf(int bookshelfId)
        {
            BookshelfId = bookshelfId;
            Books = new List<Book>();
            bookshelves.Add(this);
        }

    }

}
