using BookStore.Dal.Models;
using BookStore.Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Dal.IRepositories
{
    public interface IBookRepository
    {
        Book GetById(int id);
        List<Book> GetBooks();
        void DeleteById(int id);
        Book AddBook(Book book);
        List<Book> GetBooksByDate(DateTime dateTime);
        Book GetBookByISBN(string isbn);
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetBooksByName(string name);
        List<Book> GetBooksByPriceRange(int min, int max);
        IQueryable<Book> SearchBooks(SearchViewModel model);


    }
}
