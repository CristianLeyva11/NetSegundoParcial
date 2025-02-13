﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovies.Models;
using MVCMovies.Data;
using MVCMovies.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCMoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCMoviesContext") ?? throw new InvalidOperationException("Connection string 'MVCMoviesContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Invocamos al metodo para insertar el seedData
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
