using System.Collections.Generic;

namespace ShoppingBasket
{
    public interface IBasket
    {
        void Add(Book book);
        void Add(List<Book> books);
        decimal TotalCost();
    }
}