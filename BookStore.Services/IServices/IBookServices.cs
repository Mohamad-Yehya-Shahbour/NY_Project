using BookStore.Dal.Models;
using BookStore.Dal.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.IServices
{
    public interface IBookServices
    {
        IQueryable<Book> SearchBooks(SearchViewModel model);
        Book AddBook(Book book);
        void DeleteBook(int id);
        List<Book> GetBooks();
        Book GetBookByIsbn(string isbn);
        Book GetBookById(int id);
    }
}
