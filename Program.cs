using System;
using console_library.Models;

namespace console_library
{
    class Program
    {

        static void Main(string[] args)
        {
            bool inLibrary = true;
            Library myLibrary = new Library("SteveO Library", "TreasureValley, ID");

            Book Bible = new Book("The Holy Bible", "God");
            Book RRTI = new Book("A River Runs Through It", "Norman Maclean");
            Book Success7 = new Book("7 Habits of Highly Effective People", "Stephen R. Covey");
            Book WaterShip = new Book("Watership Down", "Richard Adams");

            myLibrary.AddBook(Bible);
            myLibrary.AddBook(RRTI);
            myLibrary.AddBook(Success7);
            myLibrary.AddBook(WaterShip);

            Enum activeMenu = Menus.CheckedoutBook;

            while (inLibrary)
            {
                switch (activeMenu)
                {
                    case Menus.CheckedoutBook:
                        myLibrary.PrintBooks();
                        break;
                    case Menus.ReturnBook:
                        myLibrary.PrintCheckedOut();
                        break;
                }

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "return":
                        Console.Clear();
                        activeMenu = Menus.ReturnBook;
                        break;
                    case "available":
                        Console.Clear();
                        activeMenu = Menus.CheckedoutBook;
                        break;
                    default:
                        if (activeMenu.Equals(Menus.CheckedoutBook))
                        {
                            myLibrary.Checkout(selection);
                        }
                        else
                        {
                            myLibrary.ReturnBook(selection);
                        }
                        break;

                }

  
            }
        }
        
        public enum Menus
        {
            CheckedoutBook,
            ReturnBook
        }
    }
}
