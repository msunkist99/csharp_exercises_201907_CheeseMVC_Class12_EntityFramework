using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK_CheeseMVC.Models
{
    public class CheeseData
    {
        private static List<Cheese> cheeses = new List<Cheese>();

        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        public static void Add (Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        public static void Remove(int id)
        {
            Cheese cheese = GetById(id);
            cheeses.Remove(cheese);
        }

        public static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.CheeseId == id);
        }
    }
}
