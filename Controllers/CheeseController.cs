using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        // constructor
        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IList<Cheese> cheeses = context.Cheeses.Include(c=> c.Category).ToList();

            return View(cheeses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // this will pass a list of Categories to the AddCheeseViewModel constructor
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());

            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory cheeseCategory = context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);

                Cheese cheese = new Cheese()
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    CategoryID = cheeseCategory.ID,
                    Category = cheeseCategory,
                    Rating = addCheeseViewModel.Rating
                };

                context.Cheeses.Add(cheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        [HttpGet]
        public IActionResult DeleteCheckbox()
        {
            ViewBag.title = "Remove Cheeses with Checkboxes";
            ViewBag.cheeses = context.Cheeses.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult DeleteDropdownList()
        {
            ViewBag.title = "Remove Cheeses with Dropdown List";
            ViewBag.cheeses = context.Cheeses.ToList();

            return View();
        }

        [HttpPost]
        [Route("Cheese/DeleteDropdownList")]
        [Route("Cheese/DeleteCheckbox")]
        public IActionResult Delete(int[] cheeseIds) {

            foreach (int cheeseId in cheeseIds)
            {
                context.Cheeses.Remove(context.Cheeses.Single(p => p.ID == cheeseId));
            }

            context.SaveChanges();

            return Redirect("/Cheese");
        }

        [HttpGet]
        public IActionResult Edit(int cheeseId)
        {
            ViewBag.title = "Edit Cheeses";
            Cheese cheese = context.Cheeses.Single(p => p.ID == cheeseId);

            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel();

            return View(editCheeseViewModel.CreateCheeseViewModel(cheese));
        }

        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheeseViewModel)
        {
            if (ModelState.IsValid) 
            {
                context.Cheeses.Remove(context.Cheeses.Single(p => p.ID == editCheeseViewModel.CheeseId));

                Cheese cheese = editCheeseViewModel.CreateCheese();

                context.Cheeses.Add(cheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(editCheeseViewModel);
        }
    }
}