using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM_PRODUCT
{
    public class Product
    {
        //Declaring Variables(Required Attributes)
        public int ProductID {  get; set; }
        public string ProductName { get; set; }
        public decimal Price {  get; set; }
        public int Stock {  get; set; }
        public Product(int  productID, string productName, decimal price,int stock)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }
        //method to increase stock
        public void IncreaseStock(int quantity)
        {
            if(quantity<0)
            {
                throw new ArgumentException("Quantity cannot be Empty or Less than 0");
            }
            else
            {
                Stock += quantity;
            }
        }
        //method to decrease stock and verify quantity
        public void DecreaseStock(int quantity)
        {
            if(quantity<0)
            {
                throw new ArgumentException("Quantity cannot be Empty or Negative");
            }
            if(quantity>Stock)
            {
                throw new InvalidOperationException("Not enough stock available");
            }
            else
            {
                Stock -= quantity; 
            }
        }

    }
}
