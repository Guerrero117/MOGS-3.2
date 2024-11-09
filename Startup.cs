using Librerias_JUOO.Data;
using Librerias_JUOO.Data.Models;
using Librerias_MOGS.Data;
using Librerias_MOGS.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librerias_MOGS
{
	public class Startup
	{
		public string ConnectionString { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
		}

		public IConfiguration Configuration { get; }
		public object AppDbInitializer { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

			//Configura el servicio
			services.AddTransient<BoocksService>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Librerias_MOGS", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Librerias_MOGS v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			AppDbInitialer.Seed(app);
		}
	}
}
