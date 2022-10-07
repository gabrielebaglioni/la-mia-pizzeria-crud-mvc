﻿using System;
namespace la_mia_pizzeria_crud_mvc.Controllers;
using la_mia_pizzeria_crud_mvc.Models;
public class PizzasCategories
{

    public Pizza Pizza { get; set; }

    public List<Category> Categories { get; set; }


    public PizzasCategories()
    {
        Pizza = new Pizza();
        Categories = new List<Category>();
    }
}

