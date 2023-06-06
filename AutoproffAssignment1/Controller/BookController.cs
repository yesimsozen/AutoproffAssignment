using AutoproffAssignment1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1.Controller
{
    public class BookController
    {
        IReadOnlyList<Book> allBooks = Book.Books;

        //For 1.2
        public List<Book> ReadBooks(string input)
        {

            // Define delimiters to split the input string
            string[] startDelimiters = { "Author:", "Title:", "Publisher:", "Published:", "NumberOfPages:" };
            string[] endDelimiters = { "Book:" };

            // Create a dictionary to store the parsed book data
            var bookDictionary = new Dictionary<string, Dictionary<string, string>>();

            // Split the input string into book entries
            string[] bookEntries = input.Split(endDelimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string bookEntry in bookEntries)
            {
                // Create a dictionary to store the data for each book
                Dictionary<string, string> bookData = new Dictionary<string, string>();

                int startIndex = -1;

                // Iterate over the start delimiters to extract book data fields
                for (int i = 0; i < startDelimiters.Length; i++)
                {
                    // Find the start index of the current field
                    startIndex = bookEntry.IndexOf(startDelimiters[i]);
                    int endIndex = i + 1 < startDelimiters.Length ? bookEntry.IndexOf(startDelimiters[i + 1]) : bookEntry.Length;

                    if (startIndex != -1)
                    {
                        // Extract the key-value pairs for the current field
                        string keyValuePairs = bookEntry.Substring(startIndex, endIndex - startIndex).Trim();

                        // Split the pairs into individual key-value strings
                        string[] pairs = keyValuePairs.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        var authorValues = String.Empty;
                        foreach (string pair in pairs)
                        {
                            int separatorIndex = pair.IndexOf(':');
                            if (separatorIndex != -1)
                            {
                                // Extract the key and value from each pair
                                string key = pair.Substring(0, separatorIndex).Trim();
                                string value = pair.Substring(separatorIndex + 1).Trim();

                                if (value.Contains(key))
                                {
                                    // Split and store multiple authors if the value contains the key
                                    separatorIndex = value.IndexOf(':');
                                    var authorNames = value.Split(new string[] { key + ":" }, StringSplitOptions.RemoveEmptyEntries);
                                    value = String.Empty;

                                    foreach (string authorName in authorNames)
                                    {
                                        value += value == String.Empty ? authorName : "," + authorName;
                                    }
                                }
                                else if (key == "Author" && pairs.Count() > 1)
                                {
                                    // Concatenate multiple author values
                                    authorValues += authorValues == String.Empty ? value : ", " + value;
                                }

                                if (!String.IsNullOrEmpty(authorValues))
                                {
                                    // Use concatenated author values as the final value
                                    value = authorValues;
                                }

                                // Store the key-value pair in the bookData dictionary
                                bookData[key] = value;
                            }
                        }
                    }

                    // Store the book data in the bookDictionary using the Author as the key
                    if (bookData.ContainsKey("Author"))
                    {
                        string author = bookData["Author"];
                        bookDictionary[author] = bookData;
                    }
                }
            }

            // Create a list to store the parsed Book objects
            var books = new List<Book>();

            // Iterate over the bookDictionary to create Book objects
            foreach (var pair in bookDictionary)
            {
                var authors = new List<string>();
                string[] authorNames = pair.Value["Author"].Split(new string[] { ", '" }, StringSplitOptions.RemoveEmptyEntries);

                authors.AddRange(authorNames);
                var publisher = pair.Value["Publisher"];
                var publicationYear = Convert.ToInt32(pair.Value["Published"]);
                var numberOfPages = Convert.ToInt32(pair.Value["NumberOfPages"]);
                var title = pair.Value["Title"];
                var isbn = "978-3-" + (new Random()).Next(100, 999).ToString() + "-" + (new Random()).Next(10, 99).ToString() + "-0";

                // Create a new Book object and add it to the list of books
                var book = new Book(authors, publicationYear, publisher, numberOfPages, title, isbn);
                books.Add(book);
            }

            // Return the list of parsed Book objects
            return books;
        }


        //For 1.2
        public List<Book> FindBooks(string searchString)
        {
            // Create a list to store the found books
            var foundBooks = new List<Book>();

            // Create a list to store the intermediate search results
            var findBooks = new List<Book>();

            // Split the search string into individual search texts
            var searchTexts = searchString.Split('&');
            foreach (var searchText in searchTexts)
            {
                // Clean and convert the search text to lowercase
                var text = searchText.Trim(new Char[] { ' ', '*' }).ToLower();

                // If findBooks is null or empty, initialize it with allBooks list
                if (findBooks == null || findBooks.Count() == 0)
                {
                    findBooks = allBooks.ToList();
                }

                // Filter the findBooks list based on the search text
                findBooks = findBooks.Where(x =>
                    (x.ISBN != null ? x.ISBN.ToLower().Contains(text) : false) || // for 1.3
                    x.Title.ToLower().Contains(text) || 
                    x.Authors.Select(item => item.ToLower()).Any(y => y.Contains(text)) ||
                    x.Publisher.ToLower().Contains(text) || 
                    x.PublicationYear.ToString().Contains(text) 
                ).ToList();
            }

            // If findBooks is not null and not empty, add the search results to foundBooks list
            if ((findBooks != null) && (findBooks.Count() != 0))
                foundBooks.AddRange(findBooks);

            // Return the list of found books
            return foundBooks;
        }


        //For 1.3
        public void RegisterBook(string isbn, string authors, string title, int publicationYear, string publisher, int numberOfPages)
        {
            try
            {
                // Create a list to store the authors of the book
                var authorList = new List<string>();

                // Split the authors string into individual author names
                var authorNames = authors.Split(',');

                // Iterate over each author name
                foreach (var authorName in authorNames)
                {
                    // Trim the author name and add it to the authorList
                    var author = authorName.Trim();
                    authorList.Add(author);
                }

                // Create a new Book object with the provided parameters
                var book = new Book(authorList, publicationYear, publisher, numberOfPages, title, isbn);

                Console.WriteLine("The book is registered successfully!");
            }
            catch (Exception ex)
            {
                // If an exception occurs, print the exception details
                Console.WriteLine(ex.ToString());
            }
        }



    }
}
