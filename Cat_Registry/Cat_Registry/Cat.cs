using System;
using static Cat_Database.Program;


namespace Cat_Database
{
    public class Cat
    {
        public string name;
        public string breed;
        public string color;
        public int? age;
        public double? weight;

        public Cat(string name, string breed, string color, int? age, double? weight)
        {
            this.name = name;
            this.breed = breed;
            this.color = color;
            this.age = age;
            this.weight = weight;
        }

        public Cat(string name, string breed, string color)
        {
            this.name = name;
            this.breed = breed;
            this.color = color;
            this.age = null;
            this.weight = null;
        }

        public Cat(string name)
        {
            this.name = name;
            this.breed = null;
            this.color = null;
            this.age = null;
            this.weight = null;
        }

        public Cat( )
        {
            this.name = null;
            this.breed = null;
            this.color = null;
            this.age = null;
            this.weight = null;
        }

        public Cat Clone()
        {
            return (Cat)MemberwiseClone();
        }


        public override string ToString()
        {
            return string.Format("Name: {0,-12}; Breed:  {1,-12}; Color: {2,-10}; Age : {3,-4}; Weight: {4,-5}\n",
                                 name ?? "(?)", breed ?? "(?)", color ?? "(?)", age ?? 0, weight?? 0.0); ;
        }
    }
}
