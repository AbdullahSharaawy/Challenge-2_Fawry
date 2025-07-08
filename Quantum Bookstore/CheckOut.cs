using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CheckOut
    {
    private decimal _SubTotal = 0;
    private decimal _Amount = 0;
    private decimal _TotalFees = 0;
    private decimal _CurrentBalance = 0;
    private decimal _ShippingFees ;
    private Dictionary<Book, int> _BooksBorrowed = new Dictionary<Book, int>();
    public Dictionary<Book, int> BooksBorrowed { get => _BooksBorrowed; }
    public CheckOut(ref Customer _customer, Cart _cart)
    {
        _BooksBorrowed = _cart.BooksBorrowed;
        _customer.Balance = _cart.Balance;
        _CurrentBalance = _cart.Balance;
        this._ShippingFees = _cart.ShippingFees;
    }

    public void ConsoleOutput()
    {
        Console.WriteLine();
        Console.WriteLine("** Order Details ** ");
        Console.WriteLine();

        Console.WriteLine($"Please note that a shipping fee of {this._ShippingFees} has been applied to each paper book.");
        Console.WriteLine();
        foreach (KeyValuePair<Book, int> item in _BooksBorrowed)
        {
            Book book = item.Key;
            int quantity = item.Value;
            Console.WriteLine($"{quantity}x  {book.ISBN} ISBN     his title: {book.Title}      his price: {book.Price * quantity}      his type: {book.Type.ToString()}");
            _SubTotal += book.Price * quantity;
            if(book.Type==Book.enType.Paper)
                this._TotalFees+=this._ShippingFees * quantity;
        }
       
        Console.WriteLine();
        
        _Amount = _TotalFees + _SubTotal;
        Console.WriteLine("----------------------");
        Console.WriteLine();
        Console.WriteLine($"Subtotal: {_SubTotal}");
        Console.WriteLine($"Shipping : {_TotalFees}");
        Console.WriteLine($"Amount: {_Amount}");
        Console.WriteLine($"Current Balance of the customer: {_CurrentBalance}");
        
        
    }
}

