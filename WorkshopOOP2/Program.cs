namespace WorkshopOOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library("Bibblan");

            Book book1 = new Book("Clean Code", "Robert C. Martin");
            Book book2 = new Book("Harry Potter and the Philosopher's stone", "J.K Rowling");
            
            myLibrary.AddBook(book1);
            myLibrary.AddBook(book2);

            myLibrary.PrintBooks();
        }
    }
}
