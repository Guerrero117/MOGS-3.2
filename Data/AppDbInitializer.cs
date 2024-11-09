using Librerias_JUOO.Data;
using Librerias_JUOO.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using static System.Reflection.Metadata.BlobBuilder;
namespace Librerias_MOGS.Data
{
	public class AppDbInitialer
	{
		public static void Seed(IApplicationBuilder applicationBuilder )
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				if (!context.Books.Any())
				{
					context.Books.AddRange(new Book()
					{
						Title = "1st Book Title",
						Descripcion = "1st Book Description",
						IsRead = true,
						DataRead = DateTime.Now.AddDays(-10),
						Rate = 4,
						Genero = "Biography",
						Autor = "1st Autor",
						CoverUrl = "https...",
						DateAdded = DateTime.Now,

					},
					new Book()
					{
						Title = "2nd Book Title",
						Descripcion = "2nd Book Description",
						IsRead = true,
						Genero = "Biography",
						Autor = "2nd Autor",
						CoverUrl = "https...",
						DateAdded = DateTime.Now,

					});
					context.SaveChanges();
				}
			}
		}
	}
}
