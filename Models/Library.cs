using System;
using System.Collections.Generic;

namespace console_library.Models
{
    public class Library
    {
        public string Name { get; set; }
        public string Location { get; set; }
        private List<Book> Books{ get; set; }
        private List<Book> CheckedOut { get; set; }

        public void AddBook (Book book)
        {
            Books.Add(book);
        }

        public void Checkout (string selection)
        {
            Book selectedBook = ValidateUserSelection(selection, Books);
            if (selectedBook == null)
            {
                Console.Clear();
                Console.WriteLine(@"Invalid Selection
                    ");
                return;
            }
            selectedBook.Available = false;
            CheckedOut.Add(selectedBook);
            Books.Remove(selectedBook);
            Console.Clear();
            Console.WriteLine(@"Book checked out: Enjoy the book!
                ");
        }

        public void ReturnBook(string selection)
        {
            Book selectedBook = ValidateUserSelection(selection, CheckedOut);

            if (selectedBook == null)
            {
                Console.WriteLine(@"Invalid Selection, please make a valid selection: 1
                    ");
                return;
            }
            selectedBook.Available = true;
            Books.Add(selectedBook);
            CheckedOut.Remove(selectedBook);
            Console.Clear();
            Console.WriteLine("Succefully Returned Book, Thank you!");

        }

        private Book ValidateUserSelection(string selection, List<Book> bookList)
        {
            int bookIndex;
            bool valid = Int32.TryParse(selection, out bookIndex);
            if (!valid || bookIndex < 0 || bookIndex > bookList.Count)
            {
                Console.Clear();
                Console.WriteLine("Please make a VALID selection");
                return null;
            }
            return bookList[bookIndex - 1];
        }

        public void PrintBooks()
        {
                Console.WriteLine(@"Welcome to the Library!
            ");
                Console.WriteLine("Available Books: ");
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Books[i].Title} - {Books[i].Author}");
            }
                Console.WriteLine(@"
                Or type 'return' to return a book");
        }

        public void PrintCheckedOut()
        {
            Console.WriteLine(@"Welcome to the Library! Choose from the following options:
            ");
            Console.WriteLine("Books Checked Out: ");
            for (int i = 0; i < CheckedOut.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {CheckedOut[i].Title} - {CheckedOut[i].Author}");
            }
            Console.WriteLine(@"
                Or type 'available' to return a book");
        }

        public Library(string name, string location)
        {
            Name = name;
            Location = location;
            Books = new List<Book>();
            CheckedOut = new List<Book>();
        }



    }
}
