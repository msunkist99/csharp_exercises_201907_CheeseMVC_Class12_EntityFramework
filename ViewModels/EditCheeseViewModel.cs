using MK_CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK_CheeseMVC.ViewModels
{
    public class EditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public  EditCheeseViewModel CreateCheeseViewModel(Cheese cheese)
        {
            this.CheeseId = cheese.CheeseId;
            this.Name = cheese.Name;
            this.Description = cheese.Description;
            this.Type = cheese.Type;
            this.Rating = cheese.Rating;

            return this;
        }
    }
}
