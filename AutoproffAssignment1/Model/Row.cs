using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1.Model
{
    public class Row
    {

        public int RowId { get; set; }
        public List<Bookshelf> Bookshelves { get; set; }

        private static List<Row> rows = new List<Row>();

        // Represents a read-only list of all rows
        public static IReadOnlyList<Row> AllRows => rows; 

        static Row()
        {
            InitializeRows();
        }

        private static void InitializeRows()
        {
            var allBookshelves = Bookshelf.AllBookshelves.ToList();

            Row row1 = new Row(1);
            row1.Bookshelves.Add(allBookshelves.Where(x => x.BookshelfId == 4).FirstOrDefault());
            row1.Bookshelves.Add(allBookshelves.Where(x => x.BookshelfId == 6).FirstOrDefault());

            Row row2 = new Row(2);
            row2.Bookshelves.Add(allBookshelves.Where(x => x.BookshelfId == 3).FirstOrDefault());
            row2.Bookshelves.Add(allBookshelves.Where(x => x.BookshelfId == 5).FirstOrDefault());

            Row row3 = new Row(3);
            row3.Bookshelves.Add(allBookshelves.Where(x => x.BookshelfId == 1).FirstOrDefault());
            row3.Bookshelves.Add(allBookshelves.Where(x => x.BookshelfId == 2).FirstOrDefault());
        }

        public Row(int rowId)
        {
            RowId = rowId;
            Bookshelves = new List<Bookshelf>();
            rows.Add(this);
        }

    }
}
