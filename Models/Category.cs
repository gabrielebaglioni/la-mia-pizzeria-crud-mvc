﻿using System;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_crud_mvc.Models;

    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }


        public List<Pizza> Pizzas { get; set; }

        public Category()
        {
            //ef e validation
        }
    }
