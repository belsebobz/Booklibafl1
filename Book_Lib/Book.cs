using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Lib
{
    public class Book
    {
        

        public int Id { get; set; }
        
        public string Title { get; set; }

        public int Price { get; set; }

        public Book()
        {
        }

        public Book(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Title cannot be less than 3 characters");
            }
        }

        public void ValidatePrice()
        {
            if ((Price <= 0) || (Price > 1200))
            {
                throw new ArgumentOutOfRangeException("Price cannot be less than 0 or more than 1200");
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(Price)}={Price.ToString()}}}";
        }


        public void Validate()
        {
            ValidatePrice();
            ValidateTitle();
        }







    }
}
