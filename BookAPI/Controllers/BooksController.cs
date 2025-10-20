using BookAPI.Data.Entities;
using BookAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/v1/books")]
    public class BooksController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            List<Book> books = await _bookRepository.GetByNameAsync(name);           

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book bookDTO)
        {
            List<Book> books = await _bookRepository.GetByNameAsync(bookDTO.Name);
            if (books.Count != 0) return Conflict("Book already exists!");

            Book result = await _bookRepository.AddAsync(bookDTO);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book bookDTO)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            await _bookRepository.UpdateAsync(id, bookDTO);

            return Ok(bookDTO);
        }

        [HttpPut("{id}/rent")]
        public async Task<IActionResult> Rent(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();
            if (book.IsBooked) return Conflict("Book already rented!");

            book.IsBooked = true;

            await _bookRepository.UpdateAsync(book.Id, book);

            return Ok(book);
        }

        [HttpPut("{id}/book-return")]
        public async Task<IActionResult> BookReturn(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();
            if (!book.IsBooked) return Conflict("Book is for rent!");

            book.IsBooked = false;

            await _bookRepository.UpdateAsync(book.Id, book);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            await _bookRepository.RemoveAsync(book);

            return Ok();
        }
    }
}
