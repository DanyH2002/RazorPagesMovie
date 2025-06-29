using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Model;
using RazorPagesMovie.Validators;
using RazorPagesMovie.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection"));
});

builder.Services.AddScoped<IValidator<MovieInsert>, MovieInsertValidator>();
builder.Services.AddScoped<IValidator<MovieUpdate>, MovieUpdateValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
