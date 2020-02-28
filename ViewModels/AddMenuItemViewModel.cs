using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int CheeseId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; }

        public AddMenuItemViewModel()
        {

        }

        public AddMenuItemViewModel(Menu menu, IEnumerable<Cheese> cheeses)
        {
            Menu = menu;

            Cheeses = new List<SelectListItem>();

            foreach(Cheese cheese in cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text = cheese.Name
                }
                );
            };
        }
    }
}
