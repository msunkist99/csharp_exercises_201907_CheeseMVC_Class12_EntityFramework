using Microsoft.AspNetCore.Mvc.Rendering;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required(ErrorMessage = "You must enter a name for your cheese.")]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must add a description for your cheese.")]
        [Display(Name = "Cheese Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "You must enter a cheese rating value of 1 through 5.")]
        [Range(1, 5)]
        [Display(Name = "Cheese Rating")]
        public int Rating { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        // empty constructor required for model binding
        public AddCheeseViewModel()
        {
        }

        //constructor
        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (CheeseCategory category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
        }

        public virtual Cheese CreateCheese()
        {
            Cheese cheese = new Cheese()
            {
                Name = this.Name,
                Description = this.Description,
                CategoryID = this.CategoryID,
                Rating = this.Rating
            };

            return cheese;
        }
    }
}
