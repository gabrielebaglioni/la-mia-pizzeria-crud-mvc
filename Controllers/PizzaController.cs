//using la_mia_pizzeria_post.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace la_mia_pizzeria_post.Controllers;



//    // GET
//    public IActionResult Index()
//    {
//        return View(pizze);
//    }

//    public IActionResult Show(int id)
//    {
//        Pizza? pizza = pizze.Find(x => x.Id == id);

//        if (pizza == null)
//        {
//            return View("Error");
//        }

//        return View(pizza);
//    }
//}



//public class PizzaController : Controller
//{

//    //GET
//    public IActionResult Index()
//    {
//        List<Pizza> pizzas = new();
//        using (AppContext db = new AppContext())
//        {
//            pizzas = db.Pizzas.ToList();
//        }
//        return View(pizzas);
//    }

//    public IActionResult Show(int id)
//    {
//        Pizza? pizza = _context.Pizzas.First(x => x.Id == id);

//        if (pizza == null)
//        {
//            return View("Error");
//        }

//        return View(pizza);
//    }

//    public IActionResult Create()
//    {
//        return View();
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult Create(Pizza pizza)
//    {
//        if (!ModelState.IsValid)
//        {
//            return View(pizza);
//        }

//        _context.Pizzas.Add(pizza);
//        _context.SaveChanges();

//        return RedirectToAction("Id");
//    }


//}

using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AppContext = la_mia_pizzeria_post.Context.AppContext;

namespace la_mia_pizzeria_post.Controllers;

public class PizzaController : Controller
{
    public IActionResult Index()
    {
        List<Pizza> pizzas = new();
        using (var db = new AppContext())
        {
            pizzas = db.Pizzas.ToList();
        }
        return View(pizzas);
    }

    public IActionResult Show(int id)
    {
        Pizza? pizza = new();
        using (var db = new AppContext())
        {
            pizza = db.Pizzas.FirstOrDefault(n => n.Id == id);
        }

        return View(pizza);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Pizza pizza)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }

        using (var db = new AppContext())
        {
            db.Pizzas.Add(pizza);

            db.SaveChanges();
        }
        return RedirectToAction("Index");

    }
    public IActionResult Update(int id)
    {
        Pizza? pizza = new();
        using (var db = new AppContext())
        {
            pizza = db.Pizzas.FirstOrDefault(n => n.Id == id);
        }
        if(pizza is null)
        {
            return View("Error");
        }

        return View(pizza);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, Pizza formData)
    {
        AppContext pizzaContext = new AppContext();

        Pizza pizza = pizzaContext.Pizzas.Where(pizzaContext => pizzaContext.Id == id).FirstOrDefault();

        pizza.Name = formData.Name;
        pizza.Description = formData.Description;
        pizza.Price = formData.Price;
        pizza.Photo = formData.Photo;

        pizzaContext.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        AppContext pizzaContext = new AppContext();
        Pizza pizza = pizzaContext.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

        if (pizza == null)
        {
            return NotFound("Non trovato");
        }
        pizzaContext.Pizzas.Remove(pizza);
        pizzaContext.SaveChanges();

        return RedirectToAction("Index");
    }


}