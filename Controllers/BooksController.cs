using Librerias_MOGS.Data.Services;
using Librerias_MOGS.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Librerias_MOGS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		public BoocksService _boocksService;

		public BooksController(BoocksService boocksService)
		{
			_boocksService = boocksService;
		}

		[HttpGet("get-book-by-id")]
		public IActionResult GetBook()
		{
			var allbooks = _boocksService.GetAllBks();
			return Ok(allbooks);
		}

		[HttpGet("get-book-by-id/{id}")]
		public IActionResult GetBookById(int id)
		{
			var book = _boocksService.GetBookById(id);
			return Ok(book);
		}

		[HttpPost("add-book")]
		public IActionResult AddBook([FromBody] BookVM book)
		{
			_boocksService.AddBook(book);
			return Ok();
		}
		[HttpPost("update-book-by-id/{id}")]
		public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
		{
			var updateBook = _boocksService.UpdateBookBiID(id, book);
			return Ok(updateBook);
		}
		[HttpDelete("delete-book-by-id/{id}")]
		public IActionResult DeleteBookById(int id)
		{
			_boocksService.DeleteBookById(id);
			return Ok();
		}
	}
}
 