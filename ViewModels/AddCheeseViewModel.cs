using Microsoft.AspNetCore.Mvc.Rendering;
using MK_CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MK_CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required(ErrorMessage ="You must enter a name for your cheese.")]
        [Display(Name="Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="You must add a description for your cheese.")]
        [Display(Name="Cheese Description")]
        public string Description { get; set; }

        [Display(Name = "Cheese Type")] 
        public CheeseType Type { get; set; }

        [Required(ErrorMessage = "You must enter a cheese rating value of 1 through 5.")]
        [Range( 1,5)]
        [Display(Name = "Cheese Rating")]
        public int Rating { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            }) ;

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            }); 

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }

        public virtual Cheese CreateCheese()
        {
            Cheese cheese = new Cheese()
            {
                Name = this.Name,
                Description = this.Description,
                Type = this.Type,
                Rating = this.Rating
            };

            return cheese;
        }
    }
}
