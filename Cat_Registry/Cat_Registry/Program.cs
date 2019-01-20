using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Cat_Database.Menus;
using static Cat_Database.Editing;
using static Cat_Database.Sorting;
using static Cat_Database.Filtering;
using static Cat_Database.IOXML;
using static Cat_Database.MenusCommands;
using static Cat_Database.ConsoleIO;

namespace Cat_Database
{
    class Program
    {
        public static readonly List<Cat> collection = new List<Cat>();
        public static Cat[] testArray = {
        new Cat("Jack", "Bengal", "Leopard", 1, 2.6 ),
        new Cat("Mike", "British", "Blue", 3, 3.4),
        new Cat("Cavebdish", "Ragdoll", "Silver", 3, 5.1),
        new Cat("Valentino", "Maine-Coon", "Black", 2, 8.4),
        new Cat("Leo", "Scottish", "Tabby", 4, 1.9),
        new Cat("Marcus", "Persian", "Cinnamon", 2, 4.3)
        };

        //--------=====  IO controllers  ==========-------
        public static IOXML xmlController = new IOXML();
        public static IOtxt txtController = new IOtxt();

        public delegate void Command();

        public struct CommandInfo
        {
            public string name;
            public Command command;

            public CommandInfo(string name, Command command)
            {
                this.name = name;
                this.command = command;
            }
        }

      

        //------------------M A I N --------------------    
        public static void Main(string[] args)
        {
            string title = "\t\t---- Cat's Database \"Fluffy Romeo\" ----";
            string header = " ---- Cat's Database \"Fluffy Romeo\" ---- ";
            SetConsoleParam(title, header);
            OperateMainMenu();
            
            Console.ReadKey(true);

        }
   

        public static void CreateTestingData()
        {
            if (collection.Count == 0)
            {
                for (int i = 0; i < testArray.Length; i++)
                {
                    collection.Add(testArray[i].Clone());
                }
            }
            
        }

        public static void Clear()
        {
            collection.Clear();
        }

        public static Command TakeCommand(CommandInfo[] commandInfoArray, int currentMenuSelector)
        {
            TextColor(menuFrameColor);
            TextPos(dataX, dataY);
            Console.Write("\t" + commandInfoArray[currentMenuSelector].name);
            return commandInfoArray[currentMenuSelector].command;
               
        }

       //------------ Operate Main Menu ------
        public static void OperateMainMenu()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(collection, catsHeader);
                CurrentMenu(mainMenuItems, mainMenuHeader, ref mainMenuSelector);
               
                Command command = TakeCommand(mainMenuArray, mainMenuSelector);
                if (command == null)
                     return;
                command();
            }
        }

        //-------------------- Operate Edit Menu----------

        public static void OperateEditMenu()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(collection, catsHeader);
                CurrentMenu(editSubMenuItems, editSubMenuHeader, ref editSubMenuSelector);

                Command command = TakeCommand(editSubMenuArray, editSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }

        //------------------------ Operate Sort Menu -------------------
        public static void OperateSortMenu()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(collection, catsHeader);
                CurrentMenu(sortSubMenuItems, sortSubMenuHeader, ref sortSubMenuSelector);

                Command command = TakeCommand(sortSubMenuArray, sortSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }

        //------------------------ Operate Filter Menu-------------------
        public static void OperateFilterMenu()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                OutData(tempCollection, filteredCatsHeader + filtersList);
                CurrentMenu(filterSubMenuItems, filterSubMenuHeader, ref filterSubMenuSelector);

                Command command = TakeCommand(filterSubMenuArray, filterSubMenuSelector);
                if (command == null)
                    return;
                command();
            }
        }


    }
}
