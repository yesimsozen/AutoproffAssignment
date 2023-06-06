using AutoproffAssignment1.Controller;
using AutoproffAssignment1.Model;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace AutoproffAssignment1.Tests
{
    [TestFixture]
    public class LibraryControllerTests
    {
        private LibraryController libraryController;

        [SetUp]
        public void SetUp()
        {
            libraryController = new LibraryController();
        }

        [Test]
        public void TestGetInventoryLists()
        {
            LibraryController libraryController = new LibraryController();

            // Act
            List<Book> inventoryList1 = libraryController.GetInventoryLists(2, 1); // For Room 2
            List<Book> inventoryList2 = libraryController.GetInventoryLists(2, 2); // For Row 3
            List<Book> inventoryList3 = libraryController.GetInventoryLists(6, 3); // For Bookshelf 7


            Assert.IsTrue(inventoryList1.Any(b =>
                b.Title.Contains("Our Life") &&
                b.Authors.Contains("Yesim Sozen") &&
                b.Authors.Contains("Ugur Efe Sozen") &&
                b.Publisher.Contains("Publisher Company") &&
                b.PublicationYear == 2023 &&
                b.NumberOfPages == 200
            ));

            Assert.IsTrue(inventoryList1.Any(b =>
                b.Title.Contains("Book 1") &&
                b.Authors.Contains("Kim Kirsten") &&
                b.Publisher.Contains("Publisher Company") &&
                b.PublicationYear == 2022 &&
                b.NumberOfPages == 240
            ));

            Assert.IsTrue(inventoryList1.Any(b =>
                b.Title.Contains("Book 2") &&
                b.Authors.Contains("Jens Bjerne") &&
                b.Publisher.Contains("Publisher Company1") &&
                b.PublicationYear == 2021 &&
                b.NumberOfPages == 150
            ));

            Assert.IsTrue(inventoryList1.Any(b =>
                b.Title.Contains("Book 3") &&
                b.Authors.Contains("Svend Kolegia") &&
                b.Publisher.Contains("Publisher Company2") &&
                b.PublicationYear == 2020 &&
                b.NumberOfPages == 312
            ));


            Assert.IsTrue(inventoryList2.Any(b =>
                b.Title.Contains("Book 4") &&
                b.Authors.Contains("John Maleria") &&
                b.Publisher.Contains("Publisher Company3") &&
                b.PublicationYear == 1995 &&
                b.NumberOfPages == 420
            ));

            Assert.IsTrue(inventoryList2.Any(b =>
                b.Title.Contains("Book 7") &&
                b.Authors.Contains("Arthur Rasmussen") &&
                b.Publisher.Contains("Publisher Company4") &&
                b.PublicationYear == 2022 &&
                b.NumberOfPages == 154
            ));

            Assert.IsTrue(inventoryList2.Any(b =>
                b.Title.Contains("Book 8") &&
                b.Authors.Contains("Taylor Larsen") &&
                b.Publisher.Contains("Publisher Company5") &&
                b.PublicationYear == 2023 &&
                b.NumberOfPages == 216
            ));

            Assert.IsTrue(inventoryList3.Any(b =>
                b.Title.Contains("Book 9") &&
                b.Authors.Contains("Toni Nielsen") &&
                b.Publisher.Contains("Publisher Company6") &&
                b.PublicationYear == 2009 &&
                b.NumberOfPages == 380
            ));

            Assert.IsTrue(inventoryList3.Any(b =>
                b.Title.Contains("Book 10") &&
                b.Authors.Contains("Ida Olsen") &&
                b.Publisher.Contains("Publisher Company7") &&
                b.PublicationYear == 2015 &&
                b.NumberOfPages == 290
            ));

        }
    }

}