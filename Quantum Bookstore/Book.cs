using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Book
    {
     public enum enType { Paper, EBook, Demo}
      
     private string _ISBN ;
     private decimal _Price;
     private string _Title ;
     private int _Year;
    private enType _Type;  
     
    public enType Type
    {
        get => this._Type;
        set
        {
            if (value == enType.Demo || value==enType.Paper || value==enType.EBook )
                this._Type = value;
            else return;

        }
    }
    public decimal Price
    {
        get => this._Price;
        set
        {
            if (value < 0)
                return;
            else this._Price = value;
        }

    }
    public string Title
    {
        get => this._Title;
        set
        {
            if (value == null) return;
            this._Title = value;
        }
    }
    public string ISBN
    {
        get=>this._ISBN; 
    }
    public int Year
    {
        get => this._Year;
        
    }
    public Book(string ISBN,string Title, decimal Price,enType Type)
    {
        this.Title=Title;
        this._ISBN = ISBN.Trim();
        this.Price = Price;
        this.Type=Type;
        this._Year = DateTime.Now.Year;
    }

    }

