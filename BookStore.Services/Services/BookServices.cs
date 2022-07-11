using BookStore.Dal.IRepositories;
using BookStore.Dal.Models;
using BookStore.Dal.ViewModels;
using BookStore.Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.Services
{
    public class BookServices : IBookServices
    {

        private readonly IBookRepository _bookRepository;

        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book AddBook(Book book)
        {
            _bookRepository.AddBook(book);
            return book;
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteById(id);
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _bookRepository.GetBookByISBN(isbn);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public IQueryable<Book> SearchBooks(SearchViewModel model)
        {
            return _bookRepository.SearchBooks(model);
        }
    }
}
