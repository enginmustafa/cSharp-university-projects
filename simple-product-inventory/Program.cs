//Course assignment "Product inventory"
// Written by Engin Mustafa, SE-1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    //Base class Product that will be inherited from 
    public class Product {
        public string title { get; set; }
        public double price { get; set; }
        public string colour { get; set; }
        public int quantity { get; set; }

        //Constructor of base class
        public Product(string newTitle, string newColour, double newPrice, int newQuantity)
        {
            title = newTitle;
            colour = newColour;
            price = newPrice;
            quantity = newQuantity;
        }
    }

    public class Shirt : Product
    {
        public Shirt(string newTitle, string newColour, double newPrice,int newQuantity) : base(newTitle, newColour, newPrice,newQuantity)
        {
            title = newTitle;
            colour = newColour;
            price = newPrice;
            quantity = newQuantity;
        }
    }
    public class Trousers : Product
    {
        public Trousers(string newTitle, string newColour, double newPrice,int newQuantity) : base(newTitle, newColour, newPrice, newQuantity)
        {
            title = newTitle;
            colour = newColour;
            price = newPrice;
            quantity = newQuantity;
        }
    }
    public class sunGlasses : Product
    {
        string protection { get; set; }
        string type { get; set; }
        public sunGlasses(string newTitle, string newColour, double newPrice, string newProtection, string newType,int newQuantity) : base(newTitle, newColour, newPrice,newQuantity)
        {
            title = newTitle;
            colour = newColour;
            price = newPrice;
            quantity = newQuantity;
            protection = newProtection;
            type = newType;
        }

    }
    public class Hat : Product
    {
        public string type { get; set; }
        public Hat(string newTitle, string newColour, double newPrice, string newType,int newQuantity) : base(newTitle, newColour, newPrice,newQuantity)
        {
            title = newTitle;
            colour = newColour;
            price = newPrice;
            quantity = newQuantity;
            type = newType;
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Inventory.printChoices();
            Console.ReadKey();
        }
    }
}
