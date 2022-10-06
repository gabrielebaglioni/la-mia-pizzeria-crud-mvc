using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Models;

public class Pizza
{

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Is required")]
    public string? Description { get; set; }
    public string? Photo { get; set; }
    [Required(ErrorMessage = "Is required")]
    public decimal Price { get; set; }


    public Pizza()
    {
    }
}