using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Data;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            IList<Menu> menus = context.Menus.ToList();

            return View(menus);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.title = "New Menu";

            AddMenuViewModel addModelViewModel = new AddMenuViewModel();

            return View(addModelViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu menu = new Menu()
                {
                    Name = addMenuViewModel.Name
                };

                context.Menus.Add(menu);
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/ " + menu.ID);
            }

            return View(addMenuViewModel);
        }

        [HttpGet]
        public IActionResult ViewMenu(int menuId)
        {
            Menu menu = context.Menus.Single(x => x.ID == menuId);

            List<CheeseMenu> items = context.CheeseMenus
                                            .Include(item => item.Cheese)
                                            .Where(cm => cm.MenuID == menuId)
                                            .ToList();

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel(items);
            viewMenuViewModel.Menu = menu;

            return View(viewMenuViewModel);
        }

        [HttpGet]
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(x => x.ID == id);

            List<Cheese> cheeses = context.Cheeses.ToList();

            AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(menu,cheeses);

            return View(addMenuItemViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                IList<CheeseMenu> existingItems = context.CheeseMenus
                                                         .Where(cm => cm.CheeseID == addMenuItemViewModel.CheeseId)
                                                         .Where(cm => cm.MenuID == addMenuItemViewModel.MenuId)
                                                         .ToList();

                if (existingItems.Count == 0)
                {
                    CheeseMenu cheeseMenu = new CheeseMenu()
                    {
                        CheeseID = addMenuItemViewModel.CheeseId,
                        MenuID = addMenuItemViewModel.MenuId
                    };

                    context.CheeseMenus.Add(cheeseMenu);
                    context.SaveChanges();

                    return Redirect("/Menu/ViewMenu/ " + addMenuItemViewModel.MenuId);
                }
            }

            return View("/Menu");
        }
    }
}