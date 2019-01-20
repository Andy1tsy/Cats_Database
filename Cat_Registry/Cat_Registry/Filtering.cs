using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static Cat_Database.Program;
using static Cat_Database.Menus;
using static Cat_Database.Editing;
using static Cat_Database.Sorting;
using static Cat_Database.Filtering;
using static Cat_Database.IOXML;
using static Cat_Database.MenusCommands;
using static Cat_Database.ConsoleIO;

namespace Cat_Database
{
    static class Filtering
    {
      
        public static List<Cat> tempCollection = new List<Cat>(collection);

        public static char c = ' ';
        public static string subDir = "filtered";
        public static string fileNameTemplate = "picked_";
        public static string filtersList = "";

        public static void OperateFilterByWeight()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(tempCollection, filteredCatsHeader + filtersList);
                CurrentMenu(filterByWeightSubMenuItems, filterByWeightSubMenuHeader, ref filterByWeightSubMenuSelector);

                Command command = TakeCommand(filterByWeightSubMenuArray, filterByWeightSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }

        public static void OperateFilterByAge()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(tempCollection, filteredCatsHeader + filtersList);
                CurrentMenu(filterByAgeSubMenuItems, filterByAgeSubMenuHeader, ref filterByAgeSubMenuSelector);

                Command command = TakeCommand(filterByAgeSubMenuArray, filterByAgeSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }

        public static void OperateFilterByColor()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(tempCollection, filteredCatsHeader + filtersList);
                CurrentMenu(filterByColorSubMenuItems, filterByColorSubMenuHeader, ref filterByColorSubMenuSelector);

                Command command = TakeCommand(filterByColorSubMenuArray, filterByColorSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }

        public static void OperateFilterByBreed()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(tempCollection, filteredCatsHeader + filtersList);
                CurrentMenu(filterByBreedSubMenuItems, filterByBreedSubMenuHeader, ref filterByBreedSubMenuSelector);

                Command command = TakeCommand(filterByBreedSubMenuArray, filterByBreedSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }

        public static void OperateFilterByName()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(tempCollection, filteredCatsHeader + filtersList);
                CurrentMenu(filterByNameSubMenuItems, filterByNameSubMenuHeader, ref filterByNameSubMenuSelector);

                Command command = TakeCommand(filterByNameSubMenuArray, filterByNameSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }
        //---=== cancel filters ====---

        public static void CancelAllFilters()
        {
            tempCollection.Clear();
            tempCollection = collection;
            filtersList = "";
        }

       

        //--------------Filtering by name methods ---------------------------

        public static void OperateFilterByNameAtLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));

            var filtered = tempCollection.Where(ch => ch.name.StartsWith(c.ToString())).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByNameSubMenuArray[filterByNameSubMenuSelector].name + " '" + c + "',";

        }

        public static void OperateFilterByNameBeforeLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));

            var filtered = tempCollection.Where(ch => c.ToString().CompareTo(ch.name[0].ToString()) >= 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByNameSubMenuArray[filterByNameSubMenuSelector].name + " '" + c + "',";
        }

        public static void OperateFilterByNameAfterLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));

            var filtered = tempCollection.Where(ch => c.ToString().CompareTo(ch.name[0].ToString()) <= 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByNameSubMenuArray[filterByNameSubMenuSelector].name + " '" + c + "',";
        }

        //------------------- Filtering by breed methods ---------------------------
        public static void OperateFilterByBreedExact()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            string c = EnterString(breedPrompt);
          
            var filtered = tempCollection.Where(ch => c.CompareTo(ch.breed) == 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByBreedSubMenuArray[filterByBreedSubMenuSelector].name + " '" + c + "',";
        }

        public static void OperateFilterByBreedBeforeLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));

            var filtered = tempCollection.Where(ch => c.ToString().CompareTo(ch.breed[0].ToString()) >= 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByBreedSubMenuArray[filterByBreedSubMenuSelector].name + " '" + c + "',";
        }

        public static void OperateFilterByBreedAfterLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));

            var filtered = tempCollection.Where(ch => c.ToString().CompareTo(ch.breed[0].ToString()) <= 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByBreedSubMenuArray[filterByBreedSubMenuSelector].name + " '" + c + "',";
        }

        //------------------- Filtering by color methods ---------------------------

        public static void OperateFilterByColorExact()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            string c = EnterString(colorPrompt);

            var filtered = tempCollection.Where(ch => c.CompareTo(ch.color) == 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByColorSubMenuArray[filterByColorSubMenuSelector].name + " '" + c + "',";
        }

        public static void OperateFilterByColorBeforeLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));

            var filtered = tempCollection.Where(ch => c.ToString().CompareTo(ch.color[0].ToString()) >= 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByColorSubMenuArray[filterByColorSubMenuSelector].name + " '" + c + "',";
        }

        public static void OperateFilterByColorAfterLetter()
        {
            do
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                TextPos(currentX, currentY);
                c = EnterChar(charPrompt);
            } while (!char.IsLetter(c));
            
            var filtered = tempCollection.Where(ch => c.ToString().CompareTo(ch.name[0].ToString()) <= 0).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByColorSubMenuArray[filterByColorSubMenuSelector].name + " '" + c + "',";

        }

        //------------------- Filtering by age methods ---------------------------

        public static void OperateFilterByAgeEqualTo()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            int? c = EnterInt(agePrompt);
            var filtered = tempCollection.Where(ch => c == ch.age).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByAgeSubMenuArray[filterByAgeSubMenuSelector].name + " '" + c.ToString() + "',";

        }

        public static void OperateFilterByAgeLessThan()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            int? c = EnterInt(agePrompt);
            var filtered = tempCollection.Where(ch => c >= ch.age).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByAgeSubMenuArray[filterByAgeSubMenuSelector].name + " '" + c.ToString() + "',";

        }

        public static void OperateFilterByAgeMoreThan()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            int? c = EnterInt(agePrompt);
            var filtered = tempCollection.Where(ch => c <= ch.age).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByAgeSubMenuArray[filterByAgeSubMenuSelector].name + " '" + c.ToString() + "',";

        }

        //------------------- Filtering by weight methods ---------------------------

        public static void OperateFilterByWeightEqualTo()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            double? c = EnterDouble(weightPrompt);
            var filtered = tempCollection.Where(ch => c == ch.weight).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByWeightSubMenuArray[filterByWeightSubMenuSelector].name + " '" + c.ToString() + "',";

        }

        public static void OperateFilterBWeightLessThan()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            double? c = EnterDouble(weightPrompt);
            var filtered = tempCollection.Where(ch => c >= ch.weight).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByWeightSubMenuArray[filterByWeightSubMenuSelector].name + " '" + c.ToString() + "',";

        }

        public static void OperateFilterByWeightMoreThan()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            TextPos(currentX, currentY);
            double? c = EnterDouble(weightPrompt);
            var filtered = tempCollection.Where(ch => c <= ch.weight).OrderByDescending(ch => ch.name);
            tempCollection = filtered.ToList();
            filtersList = filtersList + filterByWeightSubMenuArray[filterByWeightSubMenuSelector].name + " '" + c.ToString() + "',";

        }

        //-----------====== additional ========-----------

        public static void OutTempData()
        {
            BottomClear();
            TextColor(dataColor);
            TextPos(dataX, dataY + 1);
            Console.WriteLine("\n\tВідфільтрований список котів:");
            if (tempCollection.Count == 0)
                Console.WriteLine("(список порожній)");
            for (int i = 0; i < tempCollection.Count; i++)
            {
                Console.WriteLine("{0,4}\t{1}", i + 1, tempCollection[i]);
            }

        }

       //----==== Clears bottom part of screen ===-----
        public static void BottomClear()
        {
            int currentX = dataX;
            int currentY = dataY;
            TextPos(currentX, currentY);
            TextColor(dataColor);
            for ( int i = 0; i <= collection.Count; ++i)
            {
          
                Console.WriteLine("                                                                                              ");
                Console.WriteLine("                                                                                              ");
           
            }
        }

    }
}
