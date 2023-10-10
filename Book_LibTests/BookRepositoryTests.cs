using Microsoft.VisualStudio.TestTools.UnitTesting;
using Book_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Lib.Tests
{
    [TestClass()]
    public class BookRepositoryTests
    {
        private static BookRepository? _repo = null;

        [TestInitialize]
        public void InitRepo()
        {
            if (_repo == null)
            {
                _repo = new BookRepository();
            }

            _repo.Add(new Book(1, "Ammerican Psycho", 499));
            _repo.Add(new Book(2, "The Great Gatsby", 149));
            _repo.Add(new Book(3, "The Lord of the Rings", 349));
            _repo.Add(new Book(4, "Computer Networking", 789));
            _repo.Add(new Book(5, "Hamlet", 99));
        }

        [TestMethod()]
        public void BookRepositoryTest()
        {
            IEnumerable<Book> books = _repo.Get();

            Assert.IsNotNull(books);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            IEnumerable<Book> books = _repo.Get();

            Assert.IsNotNull(books);
            Assert.AreEqual<bool>(true, books.Count<Book>() > 0);


            Book testbook = books.First<Book>();
            Book updateTestBook = new Book()
            {
                Id = testbook.Id,
                Title = testbook.Title + "(Updated)",
                Price = testbook.Price + 100
            };


            Book updatedBook = _repo.Update(testbook.Id, updateTestBook);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(testbook.Id, updatedBook.Id);
            Assert.AreEqual(testbook.Title, updatedBook.Title);
            Assert.AreEqual(testbook.Price, updatedBook.Price);
        }

        [TestMethod()]
        [DataRow(500, 600)]
        public void FilterPriceTest(int priceLower, int priceHigher)
        {
            IEnumerable<Book> books = _repo.Get(priceLower, priceHigher);

            Assert.IsNotNull(books);

            foreach (Book b in books)
            {
                if (b.Price >= priceLower)
                {
                    Assert.Fail($"The price {b.Price} exceeds {priceLower}");
                }
                if (b.Price <= priceHigher)
                {
                    Assert.Fail($"The price {b.Price} does not exceed {priceHigher}");
                }
            }
        }



    }
}