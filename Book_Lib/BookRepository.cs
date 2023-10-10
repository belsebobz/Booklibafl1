using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Lib
{
    public class BookRepository
    {
        private int _nextId = 0;

        private List<Book> _books = new List<Book>();
        
           
        

        public IEnumerable<Book> Get(int? priceLower = null, int? priceHigher = null, string? sortBy = null, bool desc = false)
        {
            IEnumerable<Book> result = new List<Book>(_books);

            if (priceLower != null)
            {
                result = result.Where( b => b.Price < priceLower );
            }
            if (priceHigher != null)
            {
                result = result.Where( b => b.Price > priceHigher );
            }

            if (sortBy != null)
            {
                if (desc)
                {
                    switch (sortBy.ToLower())
                    {
                        case "title":
                            result = result.OrderByDescending( b => b.Title ); break;
                        case "price":
                            result = result.OrderByDescending ( b => b.Price ); break;
                        default:
                            throw new ArgumentOutOfRangeException($"Invalid sorting specifier: {sortBy.ToLower()}");
                    }
                }
                else
                {
                    switch (sortBy.ToLower())
                    {
                        case "title":
                            result = result.OrderBy(b => b.Title); break;
                        case "price":
                            result = result.OrderBy(b => b.Price); break;
                        default:
                            throw new ArgumentOutOfRangeException($"Invalid sorting specifier: {sortBy.ToLower()}");

                    }
                }
            }
            return result;

        }


        public Book? Add(Book b)
        {
            b.Validate();
            _nextId++;
            b.Id = _nextId;
            _books.Add(b);
            return b;
        }


        public Book? Delete(int id)
        {
            Book? deleteBook = _books.Find( b => b.Id == id);
            if (deleteBook != null)
            {
                _books.Remove(deleteBook);
            }
            return deleteBook;
        }

        public Book? Update(int id, Book b)
        {
            Book? updateBook = null;

            b.Validate();
            updateBook = _books.Find( b => b.Id == id);
            if (updateBook != null)
            {
                updateBook.Title = b.Title;
                updateBook.Price = b.Price;
            }
            return updateBook;
        }

    }
}
