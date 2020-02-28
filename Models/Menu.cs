using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        IList<CheeseMenu> CheeseMenus;

        // constructor
        public Menu()
        {
        }
    }
}
