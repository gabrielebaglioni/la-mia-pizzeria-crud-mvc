using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;


public class AppContext : DbContext
{
    

    public DbSet<Pizza>? Pizzas { get; set; }

    public DbSet<Category>? Categories { get; set; }


    private const string ConnectionString = "Server=localhost;Database=db_pizzeria_categories;User=sa;Password=Scheggia12$;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);

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
                    Price = 4.00M,
                    CategoryId = 1
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Diavola",
                    Description = "Il Sud",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 5.50M,
                    CategoryId = 2
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Boscaiola",
                    Description = "Il Nord",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 6.00M,
                    CategoryId = 3
                },
                new Pizza
                {
                    Id = 4,
                    Name = "Nostrana",
                    Description = "La Pizza Della Casa",
                    Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                    Price = 8.50M,
                    CategoryId = 4
                });

    }


}
