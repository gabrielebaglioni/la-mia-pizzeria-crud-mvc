

using la_mia_pizzeria_crud_mvc.Controllers;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
//using AppContext = la_mia_pizzeria_crud_mvc.Context.AppContext;

namespace la_mia_pizzeria_post.Controllers;

public class PizzaController : Controller
{
    public  PizzaController()
    {

    }

    [HttpGet]
    public IActionResult Index()
    {

        //List<Pizza> pizzas = new();
        //using (var db = new AppContext())
        //{
        //    pizzas = db.Pizzas.ToList();
        //}
        //return View(pizzas);

        using (AppContext context = new AppContext())
        {
            List<Pizza> pizzas = context.Pizzas.Include("Category").ToList();

            return View("Index", pizzas);
        }
    }

    public IActionResult Show(int id)
    {
        //Pizza? pizza = new();
        //using (var db = new AppContext())
        //{
        //    pizza = db.Pizzas.FirstOrDefault(n => n.Id == id);
        //}

        //return View(pizza);
        using (AppContext context = new AppContext())
        {
            //Post postFound = context.Posts.Where(post => post.Id == id).Include("Category").FirstOrDefault();
#pragma warning disable CS8600 // Conversione del valore letterale Null o di un possibile valore Null in un tipo che non ammette i valori Null.
            Pizza pizzaFound = context.Pizzas.Where(post => post.Id == id)
                .Include(post => post.Category).FirstOrDefault();
#pragma warning restore CS8600 // Conversione del valore letterale Null o di un possibile valore Null in un tipo che non ammette i valori Null.

            if (pizzaFound == null)
            {
                return NotFound($"Il post con id {id} non è stato trovato");
            }
            else
            {
                return View("Details", pizzaFound);
            }
        }

    }

    public IActionResult Create()
    {
        PizzasCategories pizzasCategories = new PizzasCategories();

        //postsCategories.Post è già a posto? no ...
        //postsCategories.Post = new Post(); ...  dobbiamo inizializzarlo se non lo fa il costruttore

        pizzasCategories.Categories = new AppContext().Categories.ToList();

        return View(pizzasCategories);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PizzasCategories formData)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View("Create");
        //}

        //using (var db = new AppContext())
        //{
        //    db.Pizzas.Add(pizza);

        //    db.SaveChanges();
        //}
        //return RedirectToAction("Index");
        AppContext context = new AppContext();

        if (!ModelState.IsValid)
        {
            formData.Categories = context.Categories.ToList();
            return View("Create", formData);
        }

        context.Pizzas.Add(formData.Pizza);


        context.SaveChanges();

        return RedirectToAction("Index");

    }
    public IActionResult Update(int id)
    {
        //Pizza? pizza = new();
        //using (var db = new AppContext())
        //{
        //    pizza = db.Pizzas.FirstOrDefault(n => n.Id == id);
        //}
        //if(pizza is null)
        //{
        //    return View("Error");
        //}

        //return View(pizza);
        using (AppContext context = new AppContext())
        {
            Pizza pizzaToEdit = context.Pizzas.Where(post => post.Id == id).FirstOrDefault();

            if (pizzaToEdit == null)
            {
                return NotFound();
            }

            PizzasCategories pizzaCategories = new PizzasCategories();

            pizzaCategories.Pizza = pizzaToEdit; //model del db
            pizzaCategories.Categories = context.Categories.ToList(); //<select che serve alla vista

            return View(pizzaCategories);

        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, PizzasCategories formData)
    {
        //AppContext pizzaContext = new AppContext();

        //Pizza pizza = pizzaContext.Pizzas.Where(pizzaContext => pizzaContext.Id == id).FirstOrDefault();

        //pizza.Name = formData.Name;
        //pizza.Description = formData.Description;
        //pizza.Price = formData.Price;
        //pizza.Photo = formData.Photo;

        //pizzaContext.SaveChanges();

        //return RedirectToAction("index");
        using (AppContext context = new AppContext())
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = context.Categories.ToList();
                return View("Update", formData);
            }

            //Post postToEdit = context.Posts.Where(post => post.Id == id).FirstOrDefault();


            //aggiorniamo i campi con i nuovi valori
            //postToEdit.Title = formData.Post.Title;
            //postToEdit.Description = formData.Post.Description;
            //postToEdit.Image = formData.Post.Image;
            //postToEdit.CategoryId = formData.Post.CategoryId;

            formData.Pizza.Id = id;
            context.Pizzas.Update(formData.Pizza);

            context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        //AppContext pizzaContext = new AppContext();
        //Pizza pizza = pizzaContext.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

        //if (pizza == null)
        //{
        //    return NotFound("Non trovato");
        //}
        //pizzaContext.Pizzas.Remove(pizza);
        //pizzaContext.SaveChanges();

        //return RedirectToAction("Index");
        using (AppContext context = new AppContext())
        {
            Pizza postToDelete = context.Pizzas.Where(post => post.Id == id).FirstOrDefault();

            if (postToDelete != null)
            {
                context.Pizzas.Remove(postToDelete);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }


}