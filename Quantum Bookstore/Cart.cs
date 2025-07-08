using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Cart
    {
    private Inventory _inventory;
    private decimal _ShippingFees;
    public decimal ShippingFees
    {
        get => this._ShippingFees;
        
    }
    private Dictionary<Book, int> _BooksBorrowed = new Dictionary<Book, int>();
    public Dictionary<Book, int> BooksBorrowed { get => _BooksBorrowed; }

    public Cart(ref Inventory inventory, decimal Balance)
    {
        this._inventory = inventory;
        this._balance = Balance;
        this._ShippingFees = inventory.ShippingFees;
    }
    private decimal _balance;
    public decimal Balance { get => _balance; }
     public void BuyBook(string ISBN, int Quantity, string Email, string Address)
    {
        Book book = this._inventory.SelectBook(ISBN);
        if(book == null)
        {
            Console.WriteLine($"Book with ISBN {ISBN} not found in inventory.");
            return;
        }

        decimal ShippingFees = 0;
        if (book.Type == Book.enType.Paper)
            ShippingFees = this._inventory.ShippingFees;
        
        if (Quantity < 0 || Quantity >this._inventory.CountBook(ISBN) )
        {
            Console.WriteLine($"your quantity  more than a vailable quantity  to buy {ISBN} ISBN.");
            return;
        }
        if (book.Price * Quantity +ShippingFees > _balance)
        {
            Console.WriteLine($"Insufficient balance to  buy {ISBN} ISBN.");
            return;
        }
        else
        {
           

            _BooksBorrowed[book] = Quantity;
            
            _balance -= book.Price * Quantity + ShippingFees * Quantity;
            _inventory.RemoveBook(ISBN, Quantity);
        }
    }
    
    
    
}

