using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cat_Database.Program;
using static Cat_Database.ConsoleIO;


namespace Cat_Database
{


    public static class Menus
    {
        public static int mainMenuSelector = 0;
        public static string mainMenuHeader = "-Main menu-";
        public static string[] mainMenuItems = {
            "Create test data   ",
            "Clear all data     ",
            "Edit data items >> ",
            "Sort data items >> ",
            "Filter data     >> ",
            "Save data to file  ",
            "Load data from file",
            "Exit program       "
        };

        public static int editSubMenuSelector = 0;
        public static string editSubMenuHeader = "-Edit menu-";
        public static string[] editSubMenuItems = {
            "Add cat to database ",
            "Delete cat by number",
            "Edit cat by number  ",
            "Return to main menu "
        };

        public static int sortSubMenuSelector = 0;
        public static string sortSubMenuHeader = "-Sort menu-";
        public static string[] sortSubMenuItems = {
            "Sorting  by name ",
            "Sorting  by breed",
            "Sorting  by color",
            "Sorting  by age  ",
            "Sorting by weight",
            "Return to main   "
        };

        public static int filterSubMenuSelector = 0;
        public static string filterSubMenuHeader = "-Filter menu-";
        public static string[] filterSubMenuItems = {
            "Filter  by name   >> ",
            "Filter  by breed  >> ",
            "Filter  by color  >> ",
            "Filter  by age    >> ",
            "Filter  by weight >> ",
            "Cancel all filters   ",
            "Save filtered to file",
            "Return to main     "
        };

        public static int filterByNameSubMenuSelector = 0;
        public static string filterByNameSubMenuHeader = "-Filter by name menu-";
        public static string[] filterByNameSubMenuItems = {
            "Names, beginning from letter... ",
            "Names, beginning to letter...   ",
            "Names, begis at exact letter... ",
            "Return to previous menu     "
        };

        public static int filterByBreedSubMenuSelector = 0;
        public static string filterByBreedSubMenuHeader = "-Filter by breed menu-";
        public static string[] filterByBreedSubMenuItems = {
            "Breed, beginning from letter...  ",
            "Breed, beginning to letter...    ",
            "Breed, entered exactly by user...",
            "Return to  previous menu      "
        };

        public static int filterByColorSubMenuSelector = 0;
        public static string filterByColorSubMenuHeader = "-Filter by color menu-";
        public static string[] filterByColorSubMenuItems = {
            "Color, beginning from letter...  ",
            "Color, beginning to letter...    ",
            "Color, entered exactly by user...",
            "Return to  previous menu      "
        };

        public static int filterByAgeSubMenuSelector = 0;
        public static string filterByAgeSubMenuHeader = "-Filter by age menu-";
        public static string[] filterByAgeSubMenuItems = {
            "Age, which is more than ...",
            "Age, which is less than ...",
            "Age, which is equal to ... ",
            "Return to  previous menu   "
        };

        public static int filterByWeightSubMenuSelector = 0;
        public static string filterByWeightSubMenuHeader = "-Filter by weight menu-";
        public static string[] filterByWeightSubMenuItems = {
            "Weight, which is more than ...",
            "Weight, which is less than ...",
            "Weight, which is equal to ... ",
            "Return to  previous menu      "
        };



        public static void CurrentMenu(string[] currentMenuItems, string currentMenuHeader, ref int currentMenuSelector)
        {
            int currentX = menuX;
            int currentY = menuY;
            TextColor(menuFrameColor);
            TextPos(currentX, currentY);
            Console.CursorVisible = false;
            //drawing menu frame
            for (int i = 0; i < currentMenuItems.Length + 2; ++i)
            {
                for (int j = 0; j < currentMenuItems[0].Length + 2; ++j )
                {
                    TextPos(currentX + j, currentY + i);
                    if (i == 0 && j == 0)
                        Console.Write('╔');
                    else if (i == 0 && j == currentMenuItems[0].Length + 1)
                        Console.Write('╗');
                    else if (i == currentMenuItems.Length + 1 && j == 0)
                        Console.Write('╚');
                    else if (i == currentMenuItems.Length + 1 && j == currentMenuItems[0].Length + 1)
                         Console.Write('╝');
                    else if (i == 0 || i == currentMenuItems.Length + 1)
                        Console.Write('═');
                    else if (j == 0 || j == currentMenuItems[0].Length + 1)
                        Console.Write('║');
                    else
                        Console.Write(' ');
                }
            }
            // header
            TextColor(menuFrameColor);
            currentX = menuX + currentMenuItems[0].Length / 2 - currentMenuHeader.Length / 2;
            currentY = menuY ;
            TextPos(currentX, currentY);
            Console.Write(currentMenuHeader);

            //output menu items
            TextColor(menuItemColor);
            currentX = menuX + 1;
            currentY = menuY + 1;
            TextPos(currentX , currentY );
            for(int i = 0; i < currentMenuItems.Length; ++i)
            {
                TextPos(currentX , currentY  + i);
                Console.Write(currentMenuItems[i]);
            }

            TextColor(menuSelectedItemColor);
            TextPos(currentX , currentY);
            Console.Write(currentMenuItems[0]);
            currentMenuSelector = 0;
            // processing keys up and down arrows
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (currentMenuSelector == currentMenuItems.Length -1)
                        {
                            currentX = menuX + 1;
                            TextPos(currentX, currentY);
                            TextColor(menuItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                            currentMenuSelector = 0;
                            currentX = menuX + 1;
                            currentY = menuY + 1;
                            TextPos(currentX, currentY);
                            TextColor(menuSelectedItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                        }
                        else
                        {
                            currentX = menuX + 1;
                            TextPos(currentX, currentY);
                            TextColor(menuItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                            currentMenuSelector++;
                            currentX = menuX + 1;
                            currentY++;
                            TextPos(currentX, currentY);
                            TextColor(menuSelectedItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (currentMenuSelector == 0)
                        {
                            currentX = menuX + 1;
                            TextPos(currentX, currentY);
                            TextColor(menuItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                            currentMenuSelector = currentMenuItems.Length - 1;
                            currentX = menuX + 1;
                            currentY = menuY + currentMenuItems.Length;
                            TextPos(currentX, currentY);
                            TextColor(menuSelectedItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                        }
                        else
                        {
                            currentX = menuX + 1;
                            TextPos(currentX, currentY);
                            TextColor(menuItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                            currentMenuSelector--;
                            currentX = menuX + 1;
                            currentY--;
                            TextPos(currentX, currentY);
                            TextColor(menuSelectedItemColor);
                            Console.Write(currentMenuItems[currentMenuSelector]);
                        }
                        break;

                    default:
                        break;
                }

            } while (key.Key != ConsoleKey.Enter);
        }
    }
}
