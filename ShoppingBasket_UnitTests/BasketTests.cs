using ShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingBasket_UnitTests
{
    public class BasketTests
    {
        [Theory]
        [InlineData(new int[0], 0)]
        [InlineData(new int[] { 1 }, 8)]
        [InlineData(new int[] { 1, 1 }, 16)]
        [InlineData(new int[] { 1, 2 }, 15.20)]
        [InlineData(new int[] { 1, 2, 3 }, 21.6)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 25.6)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 30)]
        [InlineData(new int[] { 1, 1, 2 }, 23.2)]
        [InlineData(new int[] { 1, 1, 2, 2 }, 30.4)]
        [InlineData(new int[] { 1, 1, 2, 2, 3, 3, 4, 5 }, 51.2)]
        public void TotalCost_ValidBookSequences_CalculatesCorrectly(IEnumerable<int> books, decimal expectedCost)
        {
            //Arrange
            IBasket basket = new Basket();
            List<Book> bookList = books.Select(x => new Book
            {
                VolumeNo = x
            }).ToList();

            basket.Add(bookList);

            //Act
            var actual = basket.TotalCost();

            //Assert
            Assert.Equal(expectedCost, actual);
        }

        [Theory]
        [InlineData(1, 8)]
        [InlineData(2, 8)]
        [InlineData(3, 8)]
        [InlineData(4, 8)]
        [InlineData(5, 8)]

        public void TotalCost_SingleBook_ReturnsExpectedPrice(int volumeNo, decimal expectedCost)
        {
            //Arrange
            IBasket basket = new Basket();
            basket.Add(new Book
            {
                VolumeNo = volumeNo
            });

            //Act
            var actual = basket.TotalCost();

            //Assert
            Assert.Equal(expectedCost, actual);
        }
    }
}
