using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Basket : IBasket
    {
        private List<BookSet> bookSets;
        private DiscountInformation discountInformation;

        public Basket()
        {
            discountInformation = new DiscountInformation();
            bookSets = new List<BookSet>();
        }
        /// <summary>
        /// Add a single book to a bookset
        /// </summary>
        /// <param name="book"></param>
        public void Add(Book book)
        {
            AddBookToNewOrExistingBookSet(book);
        }

        /// <summary>
        /// Add a list of books to a bookset
        /// </summary>
        /// <param name="books"></param>
        public void Add(List<Book> books)
        {
            books.ForEach(
                book => AddBookToNewOrExistingBookSet(book)
            );
        }

        /// <summary>
        /// Adds a book to a set that doesn't contain this volume
        /// </summary>
        /// <param name="book"></param>
        private void AddBookToNewOrExistingBookSet(Book book)
        {
            bool added = false;

            var bookSetsNotContainingBook = bookSets.Where(x => !x.Contains(book));
            if (bookSetsNotContainingBook.Count() == 0)
            {
                var newBookSet = new BookSet();
                added = newBookSet.Add(book);
                bookSets.Add(newBookSet);
            }

            if (!added)
            {
                AddToBestPriceBookSet(bookSetsNotContainingBook, book);
            }
        }

        private void AddToBestPriceBookSet(IEnumerable<BookSet> bookSets, Book book)
        {
            decimal bestPrice = 0;
            BookSet currentBookSet = null;

            if (bookSets.Count() == 1)
            {
                bookSets.First()
                    .Add(book);
            }
            else
            {
                bookSets.ToList()
                    .ForEach(x =>
                {
                    x.Add(book);
                    var potentialBestPrice = x.Total();
                    if (bestPrice == 0)
                    {
                        bestPrice = potentialBestPrice;
                        currentBookSet = x;
                    }
                    else if (bestPrice > x.Total())
                    {
                        currentBookSet = x;
                        bestPrice = potentialBestPrice;
                    }
                    x.Remove(book);
                });
                currentBookSet.Add(book);
            }
        }

        public decimal TotalCost()
        {
            return bookSets.Sum(x => x.Total());
        }
    }
}
