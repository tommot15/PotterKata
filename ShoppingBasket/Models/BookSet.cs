using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket
{
    public class BookSet
    {
        private List<Book> Books;
        private DiscountInformation discountInformation;
        public BookSet()
        {
            Books = new List<Book>();
            discountInformation = new DiscountInformation();
        }

        public bool Add(Book book)
        {
            if (Contains(book))
            {
                return false;
            }
            Books.Add(book);
            return true;
        }

        public void Remove(Book book)
        {
            Books.Remove(book);
        }

        public bool Contains(Book book)
        {
            return Books.Any(x => x.VolumeNo == book.VolumeNo);
        }

        public decimal Total()
        {
            decimal discount;
            discountInformation.AvailableDiscounts.TryGetValue(Books.Count, out discount);
            
            return Books.Sum(x => x.Price) * (1 - discount);
        }
    }
}
