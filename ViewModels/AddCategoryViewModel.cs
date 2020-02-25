using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "You must enter a name for your cheese category.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
