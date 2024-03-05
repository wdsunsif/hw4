class Book 
{ 
    public string Title { get; set; }
    public string Author { get; set; }
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    } 
    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}
class ReadingList
{
    private List<Book> books = new List<Book>();

    public int Count => books.Count;

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public bool Contains(Book book)
    {
        return books.Contains(book);
    }

    public Book this[int index]
    {
        get
        {
            if (index < 0 || index >= books.Count)
                throw new IndexOutOfRangeException("нету такого индекса");
            
            return books[index];
        }
    }
    

    public Book this[string title]
    {
        get
        {
            foreach (var book in books)
            {
                if (book.Title == title)
                    return book;
            }
            return null;
        }
    }

    public static ReadingList operator +(ReadingList readingList, Book book)
    {
        readingList.AddBook(book);
        return readingList;
    }

    public static ReadingList operator -(ReadingList readingList, Book book)
    {
        readingList.RemoveBook(book);
        return readingList;
    }

    public void Display()
    {
        Console.WriteLine("Reading List:");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

class Programm
{
  static void Main(string[] args)
      {
          ReadingList readingList = new ReadingList();
          readingList += new Book("Harry Potter", "J.Rowling");
          readingList += new Book("The Catcher in the Rye", "J.D.Salinger");
          Book bookToFind = new Book("Harry Potter", "Joan Rowling");
          Console.WriteLine($"Contains \"{bookToFind.Title}\" by {bookToFind.Author}: {readingList.Contains(bookToFind)}");
          readingList -= bookToFind;
          Console.WriteLine($"Contains \"{bookToFind.Title}\" by {bookToFind.Author}: {readingList.Contains(bookToFind)}");
          readingList.Display();
          Console.WriteLine("Нахождение по индексу:");
          for (int i = 0; i < readingList.Count; i++)
          {
              Console.WriteLine($"{i + 1}. {readingList[i]}");
          }
          Console.WriteLine("Нахождение по названию:");
          Book foundBook = readingList["Harry Potter"];
          if (foundBook != null)
          {
              Console.WriteLine($"Найдена: {foundBook}");
          }
          else
          {
              Console.WriteLine("Книга не найдена.");
          }
      }  
}