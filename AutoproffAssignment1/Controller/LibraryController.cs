using AutoproffAssignment1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1.Controller
{
    internal class LibraryController
    {
        IReadOnlyList<Room> allRooms = Room.AllRooms;
        IReadOnlyList<Row> allRows = Row.AllRows;
        IReadOnlyList<Bookshelf> allBookshelves = Bookshelf.AllBookshelves;

        public List<Book> GetInventoryLists(int id, int type)
        {
            // Create a new list to store the inventory of books
            List<Book> inventoryList = new List<Book>();

            // Based on the provided 'type' parameter, retrieve the inventory list
            switch (type)
            {
                case 1: // For Room
                    {
                        // Get the list of all rooms
                        var roomList = allRooms.ToList();

                        // Find the room with the provided 'id'
                        var room = roomList.Where(x => x.RoomID == id).FirstOrDefault();

                        if (room != null)
                        {
                            // Iterate over each row in the room and add all books from the bookshelves to the inventoryList
                            foreach (var row in room.Rows)
                            {
                                foreach (var bookshelf in row.Bookshelves)
                                {
                                    inventoryList.AddRange(bookshelf.Books);
                                }
                            }
                        }
                        break;
                    }

                case 2: // For Row
                    {
                        // Get the list of all rows
                        var rowList = allRows.ToList();

                        // Find the row with the provided 'id'
                        var row = rowList.Where(x => x.RowId == id).FirstOrDefault();
                        if (row != null)
                        {
                            // Add all books from the bookshelves in the row to the inventoryList
                            foreach (var bookshelf in row.Bookshelves)
                            {
                                inventoryList.AddRange(bookshelf.Books);
                            }
                        }

                        break;
                    }
                case 3: // For BookShelf
                    {
                        // Get the list of all bookshelves
                        var bookshelfList = allBookshelves.ToList();

                        // Find the bookshelf with the provided 'id'
                        var bookshelf = bookshelfList.Find(x => x.BookshelfId == id);
                        if (bookshelf != null)
                        {
                            // Add all books from the bookshelf to the inventoryList
                            inventoryList.AddRange(bookshelf.Books);
                        }

                        break;
                    }
            }

            // Remove any duplicate books from the inventoryList
            inventoryList = inventoryList.Distinct().ToList();

            // Print the information of each book in the inventoryList
            foreach (var book in inventoryList)
            {
                // Format the book information
                string authors = string.Join(", ", book.Authors);
                string bookInfo = $"Book:\nAuthor: {authors}\nTitle: {book.Title}\nPublisher: {book.Publisher}\nPublished: {book.PublicationYear}\nNumberOfPages: {book.NumberOfPages}\n";

                // Print the book information to the console
                Console.WriteLine();
                Console.WriteLine(bookInfo);
            }

            // Return the inventoryList
            return inventoryList;
        }


    }
}
