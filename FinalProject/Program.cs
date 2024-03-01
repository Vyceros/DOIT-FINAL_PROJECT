namespace FinalProject
{
    using Newtonsoft.Json;
    internal class Program
    {
        static void Main(string[] args)
        {
            BookManager manager = new BookManager("C:\\Users\\user\\Desktop\\library.txt");
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Display all books");
                Console.WriteLine("3. Search for a book");
                Console.WriteLine("4. Clear Library");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter book info.");
                        Console.WriteLine("Name: ");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("Author");
                        string bookAuthor = Console.ReadLine();
                        Console.WriteLine("Date: ");
                        string bookDate = Console.ReadLine();
                        Book book = new Book(bookName, bookAuthor, bookDate);
                        manager.AddBook(book);
                        break;
                    case "2":
                        Console.WriteLine("Displaying all your books: \n");
                        manager.DisplayBooks();
                        break;
                    case "3":
                        Console.WriteLine("Enter the name of the book you want to search.");
                        string nameInput = Console.ReadLine();
                        manager.Search(nameInput);
                        break;
                    case "4":
                        manager.RemoveBook();
                        break;
                    case "5":
                        playAgain = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }

        public Book(string name, string author, string date)
        {
            Name = name;
            Author = author;
            Date = date;
        }

        public Book()
        {

        }

    }

    public class BookManager
    {
        public List<Book> books;
        public string filePath;
        public BookManager(string filePath)
        {
            this.filePath = filePath;
            books = new List<Book>(); //ინიციალირებას უკეთებს  "books" ლისტს.
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            SaveBooks();
        }


        public void DisplayBooks()
        {
            List<Book> loadedBooks = LoadBooks();
            if (loadedBooks != null)
            {
                Console.WriteLine("These are your books: \n");
                foreach (var item in loadedBooks)
                {
                    Console.WriteLine($"{item.Name} by {item.Author} written in {item.Date}");
                }
            }
        }
        public void SaveBooks()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(books);
            File.WriteAllText(filePath, json);
        }

        public List<Book> LoadBooks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
            return null;

        }

        public Book Search(string name)
        {
            List<Book> loadedBooks = LoadBooks();
            if (loadedBooks != null)
            {
                Book foundBook = loadedBooks.Find(book => book.Name == name);
                if (foundBook != null)
                {
                    Console.WriteLine($"Book found: {foundBook.Name} written by {foundBook.Author} in year {foundBook.Date}");
                }
                else
                {
                    Console.WriteLine($"Book '{name}' not found.");
                }

                return foundBook;
            }
            return null;
        }

        public void RemoveBook()
        {
            books.Clear();
            SaveBooks();
        }

    }


}


