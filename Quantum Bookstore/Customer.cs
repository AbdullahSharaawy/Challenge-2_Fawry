using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Customer
    {
    private decimal _balance;
    public Customer(decimal Balance)
    {
        this._balance = Balance;
    }
    public decimal Balance
    {
        get => this._balance;
        set
        {
            if (value < 0)
                return;
            else this._balance = value;

        }
    }
}

