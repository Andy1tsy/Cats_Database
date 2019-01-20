using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cat_Database.Menus;
using static Cat_Database.Editing;
using static Cat_Database.Sorting;
using static Cat_Database.Filtering;
using static Cat_Database.IOXML;
using static Cat_Database.MenusCommands;

namespace Cat_Database
{
    public static class ConsoleIO
    {

        //-------------- Constants for colors and coordinates ------------------
        public static int menuFrameColor = 151;// blue on gray
        public static int menuItemColor = 7;// black on gray
        public static int menuSelectedItemColor = 248;//white on dark gray

        public static int menuX = 5;//left top corner of menu coordinates
        public static int menuY = 2;

        public static int dataColor = 112;// gray on black

        public static int dataX = 5;//left top corner of data output coordinates
        public static int dataY = 14;

        public static int editingCatX = 40;// coords aside of menu - for adding or editing/filtering data
        public static int editingCatY = 3;

        // -------========== Prompt strings and headers ==========---------

        public static string filteredCatsHeader = "Накладені фільтри ";
        public static string catsHeader = "Список котів";

        public static string charPrompt = "Enter letter : ";
        public static string namePrompt = "Enter name : ";
        public static string breedPrompt = "Enter breed : ";
        public static string colorPrompt = "Enter color : ";
        public static string agePrompt = "Enter age : ";
        public static string weightPrompt = "Enter weight : ";
        public static string numberPrompt = "Enter number : ";


        //------==== Methods for cursor position and  color changing =======-----

        public static void TextPos(int x, int y) // C++ style
        {
            Console.SetCursorPosition(x, y);
        }

        public static void TextColor(int amount)// C++ style
        {
            Console.ForegroundColor = (ConsoleColor)(amount / 16);
            Console.BackgroundColor = (ConsoleColor)(amount % 16);
        }

        public static void TextColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }
        // ═ ║ ╔ ╗ ╚ ╝

        //----------------Console params -----------------------------

        public static void SetConsoleParam(string title, string header)
        {
            Console.WindowWidth = 100;
            Console.Title = title;
            Console.Clear();
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine(header);
        }
        //------=====  Output Data collection ======----------

        public static void OutData<T>(ICollection<T> collection, string header)
        {
            TextColor(dataColor);
            TextPos(dataX, dataY + 1);
            int currentNumber = 1;
            Console.WriteLine("\n\t" + header + ":");
            if (collection.Count == 0)
                Console.WriteLine("(список порожній)");
            foreach (T el in collection)
            {
                Console.WriteLine("{0,4}\t{1}", currentNumber++, el);
            }

        }

        //--------====== Entering and editing basic  methods for different types of data ==========----------

        public static string EnterString(string prompt)
        {
            Console.CursorVisible = true;
            Console.Write(prompt);
            string s = Console.ReadLine();
            return s == "" ? null : s;
        }

        public static string EditString(string prompt, string current)
        {
            Console.CursorVisible = true;
            Console.Write(prompt + " (current is " + current + " )");
            string s = Console.ReadLine();
            return s == "" ? current : s;
        }

        public static int? EnterInt(string prompt)
        {
            Console.CursorVisible = true;
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out int s) ? s : 0;
        }

        public static int? EditInt(string prompt, int? current)
        {
            Console.CursorVisible = true;
            Console.Write(prompt + " (current is " + current + " )");
            return int.TryParse(Console.ReadLine(), out int s) ? s : current;
        }

        public static double? EnterDouble(string prompt)
        {
            Console.CursorVisible = true;
            Console.Write(prompt);
            return double.TryParse(Console.ReadLine(), out double s) ? s : 0.0;
        }

        public static double? EditDouble(string prompt, double? current)
        {
            Console.CursorVisible = true;
            Console.Write(prompt + " (current is " + current + " )");
            return double.TryParse(Console.ReadLine(), out double s) ? s : current;
        }

        public static char EnterChar(string prompt)
        {
            Console.CursorVisible = true;
            Console.Write(prompt);
            char c = (char)Console.Read();
            Console.CursorVisible = false;
            if (char.IsLetter(c))
            {
                return char.ToUpper(c);
            }
            return c;


        }

    }
}
