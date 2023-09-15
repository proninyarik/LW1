// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Year: {Year}, ISBN: {ISBN}";
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public List<Book> SearchByAuthor(string author)
    {
        return books.FindAll(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
    }

    public List<Book> SearchByTitle(string title)
    {
        return books.FindAll(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Search by Author");
            Console.WriteLine("4. Search by Title");
            Console.WriteLine("5. List All Books");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();

                    Book newBook = new Book
                    {
                        Title = title,
                        Author = author,
                        Year = year,
                        ISBN = isbn
                    };

                    library.AddBook(newBook);
                    Console.WriteLine("Book added successfully.");
                    break;

                case 2:
                    Console.Write("Enter ISBN of the book to remove: ");
                    string isbnToRemove = Console.ReadLine();
                    Book bookToRemove = library.GetAllBooks().Find(book => book.ISBN == isbnToRemove);

                    if (bookToRemove != null)
                    {
                        library.RemoveBook(bookToRemove);
                        Console.WriteLine("Book removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;

                case 3:
                    Console.Write("Enter Author to search for: ");
                    string authorToSearch = Console.ReadLine();
                    List<Book> authorBooks = library.SearchByAuthor(authorToSearch);

                    if (authorBooks.Count > 0)
                    {
                        Console.WriteLine("Books by author:");
                        foreach (var book in authorBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No books found by the author.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Title to search for: ");
                    string titleToSearch = Console.ReadLine();
                    List<Book> titleBooks = library.SearchByTitle(titleToSearch);

                    if (titleBooks.Count > 0)
                    {
                        Console.WriteLine("Books with matching title:");
                        foreach (var book in titleBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No books found with matching title.");
                    }
                    break;

                case 5:
                    List<Book> allBooks = library.GetAllBooks();

                    if (allBooks.Count > 0)
                    {
                        Console.WriteLine("All Books in the Library:");
                        foreach (var book in allBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Library is empty.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
