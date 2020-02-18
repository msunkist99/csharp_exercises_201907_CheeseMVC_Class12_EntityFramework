using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MK_CheeseMVC.Models;
using MK_CheeseMVC.ViewModels;

namespace MK_CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //static List<string> Cheeses = new List<string>();
        //static Dictionary<string, string> Cheeses = new Dictionary<string,string>();
        //static Dictionary<string, Cheese> Cheeses = new Dictionary<string, Cheese>();

        [HttpGet]
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();
            //ViewBag.cheeses = CheeseData.GetAll();
            //ViewBag.error = null;
            return View(cheeses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.title = "Add Cheese";
            //ViewBag.error = Error;

            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }

        [HttpPost]
        //public IActionResult Add(string name, string description)
        //public IActionResult NewCheese(Cheese cheese)
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese cheese = new Cheese()
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                    Rating = addCheeseViewModel.Rating
                };

                CheeseData.Add(cheese);

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        [HttpGet]
        public IActionResult DeleteCheckbox()
        {
            ViewBag.title = "Remove Cheeses with Checkboxes";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDropdownList()
        {
            ViewBag.title = "Remove Cheeses with Dropdown List";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("Cheese/DeleteDropdownList")]
        [Route("Cheese/DeleteCheckbox")]
        public IActionResult Delete(int[] cheeseIds) {

            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/Cheese");
        }

        [HttpGet]
        public IActionResult Edit(int cheeseId)
        {
            ViewBag.title = "Edit Cheeses";
            //ViewBag.cheese = CheeseData.GetById(cheeseId);

            Cheese cheese = CheeseData.GetById(cheeseId);

            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel();

            return View(editCheeseViewModel.CreateCheeseViewModel(cheese));
        }

        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheeseViewModel)
        {
            if (ModelState.IsValid) 
            {
                CheeseData.Remove(editCheeseViewModel.CheeseId);

                Cheese cheese = editCheeseViewModel.CreateCheese();

                CheeseData.Add(cheese);

                return Redirect("/Cheese");
            }

            return View(editCheeseViewModel);
        }
    }
}