using Librerias_JUOO.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Librerias_JUOO.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<Book> Books { get; set; }
	}
}
