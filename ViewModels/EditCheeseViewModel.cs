using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class EditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public  EditCheeseViewModel CreateCheeseViewModel(Cheese cheese)
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
