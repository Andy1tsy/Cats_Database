using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cat_Database.Program;

namespace Cat_Database
{
    public static class Sorting
    {
        public static void SortByName()
        {
            collection.Sort((obj1, obj2) => obj1.name.CompareTo(obj2.name));
        }

        public static void SortByBreed()
        {
            collection.Sort((obj1, obj2) => obj1.breed != null ? obj2.breed != null ? obj1.breed.CompareTo(obj2.breed) : 1 : -1);
        }

        public static void SortByColor()
        {
            collection.Sort((obj1, obj2) => obj1.color != null ? obj2.color != null ? obj1.color.CompareTo(obj2.color) : 1 : -1);
        }

        public static void SortByAge()
        {
            collection.Sort((obj1, obj2) => obj1.age.HasValue ? obj2.age.HasValue ? obj1.age.Value.CompareTo(obj2.age.Value) : 1 : -1);
        }

        public static void SortByWeight()
        {
            collection.Sort((obj1, obj2) => obj1.weight.HasValue ? obj2.weight.HasValue ? obj1.weight.Value.CompareTo(obj2.weight.Value) : 1 : -1);
        }
    }
}
