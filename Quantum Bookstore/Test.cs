public class Test
{
    public static void Main(string[] args)
    {
        Book book1=new Book("131","Food Book",10,Book.enType.Paper);
        Book book2 = new Book("231", "Sport Book", 20, Book.enType.Paper);
        Book book3 = new Book("331", "Science Book", 30, Book.enType.Paper);
        Book book4 = new Book("431", "Novel Book", 20, Book.enType.EBook);
        Book book5 = new Book("531", "Physics Book", 50, Book.enType.EBook);
        Book book6 = new Book("631", "Math Book", 60, Book.enType.EBook);
        Book book7 = new Book("731", "Programming Book", 10, Book.enType.Paper);
        Book book8 = new Book("831", "ethics Book", 30, Book.enType.Paper);
        Book book9 = new Book("931", "history Book", 20, Book.enType.EBook);
        Book book10 = new Book("1031", "Story Book", 10, Book.enType.Demo);
        Inventory inv = new Inventory(10);
        inv.AddBook(book1, 10);
        inv.AddBook(book2, 10);
        inv.AddBook(book3, 10);
        inv.AddBook(book4, 10);
        inv.AddBook(book5, 10);
        inv.AddBook(book6, 10);
        inv.AddBook(book7, 10);
        inv.AddBook(book8, 10);
        inv.AddBook(book9, 10);
        inv.AddBook(book10, 10);
        Customer customer = new Customer(1000);
        Cart cart = new Cart(ref inv, customer.Balance);
        cart.BuyBook("131", 2, "a@gmail.com", "Egypt");
        cart.BuyBook("231", 1, "a@gmail.com", "Egypt");
        cart.BuyBook("331", 3, "a@gmail.com", "Egypt");
        cart.BuyBook("1031", 1, "a@gmail.com", "Egypt");
        cart.BuyBook("831", 4, "a@gmail.com", "Egypt");
        CheckOut checkOut = new CheckOut(ref customer, cart);
        checkOut.ConsoleOutput();
        inv.ConsoleOutput();
        // to remove the books that passed specific number of years , you will call this method.
        // you will  pass the number of years
        //inv.RemoveBook(1);
    }
}
