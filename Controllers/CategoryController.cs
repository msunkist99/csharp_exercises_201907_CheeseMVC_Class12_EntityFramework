using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Data;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        // constructor
        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<CheeseCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();

            return View(addCategoryViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryeViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory category = new CheeseCategory()
                {
                    Name = addCategoryeViewModel.Name,
                };

                context.Categories.Add(category);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryeViewModel);
        }

    }
}