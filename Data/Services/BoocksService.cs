using Librerias_JUOO.Data;
using Librerias_JUOO.Data.Models;
using Librerias_MOGS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Librerias_MOGS.Data.Services
{
    public class BoocksService
    {
        private AppDbContext _context;
        public BoocksService(AppDbContext context)
        {
            _context = context;

        }
        //Metodo de agregar un nuevo libro a la BD


        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DataRead = book.DataRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,

            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
		//Metodo que nos permite obtener  un nuevo libro a la BD
		public List<Book> GetAllBks() => _context.Books.ToList();
		//Metodo que nos permite obtener el libro que estamos pidiendo a la BD
		public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);
		//Metodo que nos permite modificar un libro que se encuente en la BD
        public Book UpdateBookBiID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DataRead = book.DataRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBookById(int bookid)
        {
			var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();

            }
		}
	}
}
