using BookStore.Dal.Models;
using BookStore.Dal.ViewModels;
using BookStore.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        
        public IActionResult Get()
        {
            return  Ok(_bookServices.GetBooks());
        }

        [HttpPost]
        public IActionResult Search([FromBody] SearchViewModel searchViewModel)
        {
            return Ok(_bookServices.SearchBooks(searchViewModel));
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            var temp = _bookServices.GetBookByIsbn(addBookViewModel.ISBN);
            if (temp is not null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ISBN already exists");

            }
            var book = new Book
            {
                ISBN = addBookViewModel.ISBN,
                Name = addBookViewModel.Name,
                Author = addBookViewModel.Author,
                Price = addBookViewModel.Price,
                Date = addBookViewModel.Date,
            };
            _bookServices.AddBook(book);
            return Ok();
        }


        [HttpPost]
        public IActionResult DeleteBook(DeleteBookViewModel deleteBookViewModel)
        {
            var book = _bookServices.GetBookById(deleteBookViewModel.Id);
            if(book is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Can not find Book with such ID");
            }
            _bookServices.DeleteBook(deleteBookViewModel.Id);
            return Ok();
        }
    }
}
