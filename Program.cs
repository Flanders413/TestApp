using System;
using System.Linq;
using System.Collections.Generic;

namespace DringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IDrink> drinks = new List<IDrink>();

            drinks.Add(new Juice("Banana"));
            drinks.Add(new Juice("Orange", true));
            drinks.Add(new Beer("Budweiser", 5.5));
            drinks.Add(new Soda("Coke"));
            drinks.Add(new Soda("Pepsi"));
            drinks.Add(new MyDrink());

            foreach (Drink drink in drinks)
                Console.WriteLine(drink.DrinkDescription);
        }
    }

    public interface IDrink
    {
        string Name { get; }
        string AdditionalDescr { get; }
        bool Carbonated { get; }
    }

    public class Drink : IDrink
    {
        public Drink ()
        {
            Name = "Unknown drink";
            AdditionalDescr = "";   // to avoid default value of 'null'
        }
        public string DrinkDescription
        {
            get
            {
                return $"{Name}, {(Carbonated ? "" : "not ")}cabonated{(AdditionalDescr.Length > 0 ? ", " : "")}{AdditionalDescr}.";
            }
        }
        public string Name { get; set; }
        public string AdditionalDescr { get; set; }
        public bool Carbonated { get; set; }

    }

    public class Juice : Drink
    {
        public Juice(string fruitName, bool carbonated = false) 
        {
            FruitName = $"{fruitName.First().ToString().ToUpper()}{fruitName.Substring(1).ToLower()}";
            Carbonated = carbonated;
            Name = $"{(carbonated ? "Sparking" : "")} {FruitName} Juice";
            AdditionalDescr = $"made from {fruitName.ToLower()}s";
        }

        public string FruitName { get; set; }
    }


    public class Beer : Drink
    {
        public Beer(string name, double alcoholPct) 
        {
            AlcoholContent = alcoholPct;
            Name = name;
            AdditionalDescr = $"{alcoholPct}%";
            Carbonated = true;
        }

        public double AlcoholContent { get; set; }

    }

    public class Soda : Drink
    {
        public Soda (string name) 
        {
            Name = name;
            Carbonated = true;
        }
    }

    public class MyDrink : Drink
    {
        public MyDrink() { }
        
    }

}
