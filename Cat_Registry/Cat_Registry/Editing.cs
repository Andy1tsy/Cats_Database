using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cat_Database.Program;
using static Cat_Database.Menus;
using static Cat_Database.ConsoleIO;



namespace Cat_Database
{
    public static class Editing
    {
      
      
        public static void EditByNumber()
        {
            while (true)
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                Console.CursorVisible = true;
                TextPos(currentX, currentY);
                Console.Write("                        ");
                TextPos(currentX, currentY);
                Console.Write(numberPrompt);
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number <= collection.Count && number >0)
                    {
                        TextPos(currentX, currentY);
                        collection[number-1].name = EditString(namePrompt, collection[number - 1].name);
                        TextPos(currentX, ++currentY);
                        collection[number - 1].breed = EditString(breedPrompt, collection[number - 1].breed);
                        TextPos(currentX, ++currentY);
                        collection[number - 1].color = EditString(colorPrompt, collection[number - 1].color);
                        TextPos(currentX, ++currentY);
                        collection[number - 1].age = EditInt(agePrompt, collection[number - 1].age);
                        TextPos(currentX, ++currentY);
                        collection[number - 1].weight = EditDouble(weightPrompt, collection[number - 1].weight);
                        Console.CursorVisible = false;
                        return;
                    }
                }
            }
        }

        public static void DeleteByNumber()
        {
          while(true)
            {
                int currentX = editingCatX;
                int currentY = editingCatY;
                Console.CursorVisible = true;
                TextPos(currentX, currentY);
                Console.Write("                                   ");
                TextPos(currentX, currentY);
                Console.Write(numberPrompt);
                if ( int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number < collection.Count)
                    {
                        Console.CursorVisible = false;
                        collection.RemoveAt(number-1);
                        return;
                    }
                }
            }
        }

        public static void AddNewCat()
        {
            int currentX = editingCatX;
            int currentY = editingCatY;
            Console.CursorVisible = true;
            Cat newCat = new Cat();
            TextPos(currentX, currentY);
            newCat.name = EnterString(namePrompt);
            TextPos(currentX, ++currentY);
            newCat.breed = EnterString(breedPrompt);
            TextPos(currentX, ++currentY);
            newCat.color = EnterString(colorPrompt);
            TextPos(currentX, ++currentY);
            newCat.age = EnterInt(agePrompt);
            TextPos(currentX, ++currentY);
            newCat.weight = EnterDouble(weightPrompt);
            collection.Add(newCat);
            Console.CursorVisible = false;

        }

      

    }
}
