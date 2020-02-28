using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class AddMenuViewModel
    {
        [Required(ErrorMessage = "You must enter a name for your cheese menu.")]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }
    }
}
