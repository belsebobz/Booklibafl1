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
    public class BookTests
    {
        //Valid Data
        const int validId = 1;
        const string validTitleMin = "xxx";
        const string validTitle = "xxxxxxxx";
        const int validPrice = 500;
        const int validPriceMin = 1;
        const int validPriceMax = 1200;

        //Invalid Data
        const string nullTitle = null;
        const string belowMinTitle = "x";
        const int zeroPrice = 0;
        const int exceedMaxPrice = 1201;



        [TestMethod]
        public void ToStringTest()
        {
            Book b = new Book(validId, validTitle, validPrice);

            Assert.AreEqual<string>("{Id=1, Title=xxxxxxxx, Price=500}", b.ToString());
        }

        [TestMethod]
        [DataRow(validPriceMin)]
        [DataRow(validPrice)]
        [DataRow(validPriceMax)]
        public void ValidatePrice(int price)
        {
            Book b = new Book(validId, validTitle, price);

            b.ValidatePrice();
        }

        [TestMethod]
        [DataRow(zeroPrice)]
        [DataRow(exceedMaxPrice)]
        public void ValidatePriceException(int price)
        {
            Book b = new Book(validId, validTitle, price);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => b.ValidatePrice());
        }

        [TestMethod]
        [DataRow(validTitle)]
        [DataRow(validTitleMin)]
        public void ValidateTitle(string title)
        {
            Book b = new Book(validId, title, validPrice);

            b.ValidateTitle();
        }

        [TestMethod]
        public void ValidateTitleException()
        {
            Book nullTitleBook = new Book(validId, nullTitle, validPrice);
            Assert.ThrowsException<ArgumentNullException>(() => nullTitleBook.ValidateTitle());

            Book belowMinBook = new Book(validId, belowMinTitle, validPrice);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => belowMinBook.ValidateTitle());
        }

        [TestMethod]
        [DataRow(validTitle, validPrice)]
        [DataRow(validTitleMin, validPriceMin)]
        [DataRow(validTitle, validPriceMax)]
        public void ValidateTest(string title, int price)
        {
            Book b = new Book(validId, title, price);
            b.Validate();
        }

    }
}