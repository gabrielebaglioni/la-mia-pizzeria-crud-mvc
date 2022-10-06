using System.Collections.Generic;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
namespace la_mia_pizzeria_post.Context;

public class AppContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=db_pizzeria;User=sa;Password=Scheggia12$;");
        //"myCustomConnString": "Server=localhost,1433\\Catalog=myDatabase;Database=myDatabase;User=username;Password=MYSecurePWD;"

    }
    //DATA SEEDING
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>()
            .HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Margherita",
                    Description = "La classica",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 4.00M
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Diavola",
                    Description = "Il Sud",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 5.50M
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Boscaiola",
                    Description = "Il Nord",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 6.00M
                },
                new Pizza
                {
                    Id = 4,
                    Name = "Nostrana",
                    Description = "La Pizza Della Casa",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 8.50M
                });
    }


}
