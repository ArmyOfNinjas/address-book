using AddressBook.db;
using AddressBook.db.Options;
using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddSingleton<ICurrentUserRepository, CurrentUserRepository>();
			services.AddScoped<IContactsRepository, ContactsRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			services.Configure<Database>(Configuration.GetSection("database"));

			var databaseSettings = new Database();
			Configuration.GetSection("database").Bind(databaseSettings);

			services.AddDbContext<AddressBookContext>(
				options => options
					.UseLazyLoadingProxies()
					.UseSqlServer(
					databaseSettings.ConnectionString,
					b => b.MigrationsAssembly("AddressBook")
				)
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Contacts}/{action=Index}/{id?}");
			});

		}
	}
}
