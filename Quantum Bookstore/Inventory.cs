using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Inventory
    {
    private Dictionary<Book, int> _Books = new Dictionary<Book, int>();
    private int _ShippingFees;// it is public value for each book
    public int ShippingFees
    {
        get => this._ShippingFees;
        set
        {
            if (value < 0)
                return;
            else this._ShippingFees = value;
        }
    }
    public Inventory(int ShippingFees)
    {
        if(ShippingFees<0)
            ShippingFees = 0;
        else 
            this.ShippingFees= ShippingFees;
    }
    public void AddBook(Book book,int Quantity) 
    {
        if(book == null || Quantity <= 0)
            return;
        _Books[book] = Quantity;
    }
    // call it when the customer buy some books
    public void RemoveBook(string ISBN, int Quantity)
    {
        if (string.IsNullOrEmpty(ISBN) || Quantity <= 0)
            return;

        foreach (KeyValuePair<Book, int> item in _Books)
        {
            Book book = item.Key;
            int quantity = item.Value;
            if(book.ISBN == ISBN && quantity >= Quantity)
            {
                if (quantity == Quantity)
                    _Books.Remove(book);
                else
                    _Books[book] -= Quantity;
                return;
            }
        }
    }
    // call it to Remove and return outdated books that passed 
    //specific number of years
    public void RemoveBook(int NYear)
    {
        if (NYear <= 0)
            return;

        foreach (KeyValuePair<Book, int> item in _Books)
        {
            Book book = item.Key;
            
            if (DateTime.Now.Year-book.Year==NYear)
            {
                    _Books.Remove(book);
            }
        }
    }
    public int CountBook(string ISBN)
    {
        if (string.IsNullOrEmpty(ISBN))
            return 0;
        foreach (KeyValuePair<Book, int> item in _Books)
        {
            Book book = item.Key;

            if (book.ISBN==ISBN.Trim())
            {
                return item.Value;
            }
        }
        return 0;
    }
    public int PriceBook(string ISBN)
    {
        if (string.IsNullOrEmpty(ISBN))
            return 0;
        foreach (KeyValuePair<Book, int> item in _Books)
        {
            Book book = item.Key;

            if (book.ISBN == ISBN.Trim())
            {
                return (int)book.Price;
            }
        }
        return 0;
    }
    public Book SelectBook(string ISBN)
    {
        if (string.IsNullOrEmpty(ISBN))
            return null;
        
        foreach (KeyValuePair<Book, int> item in _Books)
        {
            Book book = item.Key;

            if (book.ISBN == ISBN.Trim())
            {
                return book;
            }
        }
        return null;
    }
    public void ConsoleOutput()
    {
        Console.WriteLine();
        Console.WriteLine("** Inventory Details ** ");
        Console.WriteLine();
        foreach (KeyValuePair<Book, int> item in _Books)
        {
            Book book = item.Key;
            int quantity = item.Value;
            Console.WriteLine($"{quantity}x  {book.ISBN}  ISBN       his title: {book.Title}           his price: {book.Price} as a single unit  his type:        {book.Type.ToString()}");
        }
        Console.WriteLine();
    }
}

