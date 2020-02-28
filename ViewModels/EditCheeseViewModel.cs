using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class EditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }
        public List<SelectListItem> CheeseTypes { get; set; }

        // empty constructor
        public EditCheeseViewModel()
        {
        }

        // constructor
        public EditCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            /*
            Categories = new List<SelectListItem>();

            foreach (CheeseCategory category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
            */

            BuildCatetoriesSelectListItems(categories);
        }

        public EditCheeseViewModel CreateCheeseViewModel(Cheese cheese)
        {
            this.CheeseId = cheese.ID;
            this.Name = cheese.Name;
            this.Description = cheese.Description;
            this.CategoryID = cheese.CategoryID;
            this.Rating = cheese.Rating;

            return this;
        }
    }
}
