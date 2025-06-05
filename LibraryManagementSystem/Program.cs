/**
 * Library Management System
 * This program allows users to manage a library by adding, removing, searching, borrowing, and returning books.
 * It maintains a list of available books and tracks borrowed books with limits on the number of books.
 * Programmer: Daniel Nguyen
 * Date: 2023-10-01
 */

using System;
using System.Collections.Generic;

class LibraryManager
{
    static List<string> books = new List<string>();
    static List<string> borrowedBooks = new List<string>();
    const int maxBooks = 5; // Maximum books in the library
    const int maxBorrowedBooks = 3; // Maximum books a user can borrow

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Would you like to add, remove, search, borrow, return, or exit? (add/remove/search/borrow/return/exit)");
            string action = Console.ReadLine()?.Trim().ToLower();

            switch (action)
            {
                case "add":
                    AddBook();
                    break;
                case "remove":
                    RemoveBook();
                    break;
                case "search":
                    SearchBook();
                    break;
                case "borrow":
                    BorrowBook();
                    break;
                case "return":
                    ReturnBook();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }

            DisplayBooks();
        }
    }

    /**
     * Adds a book to the library if it is not already present and the library is not full.
     */
    static void AddBook()
    {
        if (books.Count >= maxBooks)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }

        Console.WriteLine("Enter the title of the book to add:");
        string newBook = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(newBook) && !books.Contains(newBook, StringComparer.OrdinalIgnoreCase))
        {
            books.Add(newBook);
            Console.WriteLine($"'{newBook}' has been added.");
        }
        else
        {
            Console.WriteLine("Invalid or duplicate book title.");
        }
    }

    /**
     * Removes a book from the library if it exists.
     */
    static void RemoveBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = Console.ReadLine()?.Trim();

        var bookToRemove = books.Find(b => string.Equals(b, removeBook, StringComparison.OrdinalIgnoreCase));

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"'{bookToRemove}' has been removed.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    /**
     * Searches for a book in the library and checks if it is available or borrowed.
     */
    static void SearchBook()
    {
        Console.WriteLine("Enter the title of the book to search:");
        string searchBook = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(searchBook))
        {
            var foundBook = books.Find(b => string.Equals(b, searchBook, StringComparison.OrdinalIgnoreCase));

            if (foundBook != null)
            {
                // Checks if the book is borrowed
                if (borrowedBooks.Contains(foundBook))
                    Console.WriteLine($"'{searchBook}' is currently borrowed and not available.");
                else
                    Console.WriteLine($"'{searchBook}' is available in the library.");
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
    }

    /**
     * Borrows a book from the library if it is available and the user has not exceeded the borrowing limit.
     */
    static void BorrowBook()
    {
        if (borrowedBooks.Count >= maxBorrowedBooks)
        {
            Console.WriteLine($"You have already borrowed {maxBorrowedBooks} books. Return one before borrowing another.");
            return;
        }

        Console.WriteLine("Enter the title of the book to borrow:");
        string borrowBook = Console.ReadLine()?.Trim();

        var bookToBorrow = books.Find(b => string.Equals(b, borrowBook, StringComparison.OrdinalIgnoreCase));

        if (bookToBorrow != null && !borrowedBooks.Contains(bookToBorrow))
        {
            borrowedBooks.Add(bookToBorrow);
            Console.WriteLine($"'{bookToBorrow}' has been borrowed.");
        }
        else
        {
            Console.WriteLine("Book not found or already borrowed.");
        }
        Console.WriteLine($"You have borrowed {borrowedBooks.Count}/{maxBorrowedBooks} books.");
    }

    /**
     * Returns a borrowed book to the library.
     */
    static void ReturnBook()
    {
        if (borrowedBooks.Count == 0)
        {
            Console.WriteLine("You haven't borrowed any books.");
            return;
        }

        Console.WriteLine("Enter the title of the book to return:");
        string returnBook = Console.ReadLine()?.Trim();

        var bookToReturn = borrowedBooks.Find(b => string.Equals(b, returnBook, StringComparison.OrdinalIgnoreCase));

        if (bookToReturn != null)
        {
            borrowedBooks.Remove(bookToReturn);
            Console.WriteLine($"'{bookToReturn}' has been returned.");
        }
        else
        {
            Console.WriteLine("Book not found in borrowed books.");
        }
        Console.WriteLine($"You have {borrowedBooks.Count} books remaining.");
    }

    /**
     * Displays the list of available books in the library.
     */
    static void DisplayBooks()
    {
        Console.WriteLine("Available books:");
        var availableBooks = books.FindAll(book => !borrowedBooks.Contains(book));

        if (availableBooks.Count > 0)
        {
            availableBooks.ForEach(book => Console.WriteLine(book));
        }
        else
        {
            Console.WriteLine("No books in the library.");
        }
    }
}