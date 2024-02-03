using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Shared.Settings;

namespace Server.DataLayer.Repositories.BookStore.Models;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        var configuration = Shared.Settings.SharedConfigurationProvider.GetConfiguration();
        var connectionString = configuration.GetValue<string>("ConnectionStrings:BookStore");
        optionsBuilder.UseSqlServer(connectionString);
    }

    public BookStoreContext(){}
    public BookStoreContext(DbContextOptions options) : base(options){}
}