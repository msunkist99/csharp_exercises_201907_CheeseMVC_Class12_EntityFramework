using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public CheeseCategory Category { get; set; }
        public int Rating { get; set; }

        // dotnet ef migrationsadd CategoryID
        // dotnet ef database update
        public int CategoryID { get; set; }
    }
}
