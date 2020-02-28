using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.ViewModels
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }

        public ViewMenuViewModel(IList<CheeseMenu> cheeseMenus)
        {
            Items = cheeseMenus;
        }
    }
}
