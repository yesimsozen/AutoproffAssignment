using AutoproffAssignment1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1
{
    public class Book : GeneralFeatures
    {
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }

        private static List<Book> books = new List<Book>();

        // Represents a read-only list of all books
        public static IReadOnlyList<Book> Books => books.AsReadOnly();

        public Book()
        {

        }

        public Book(List<string> authors, int publicationYear, string publisher, int numberOfPages, string title, string isbn)
        {
            Authors = authors;
            PublicationYear = publicationYear;
            Publisher = publisher;
            NumberOfPages = numberOfPages;
            Title = title;
            ISBN = isbn;
            books.Add(this);
        }

    }

}
