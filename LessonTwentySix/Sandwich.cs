using System;
using System.Collections.Generic;

namespace LessonTwentySix
{
    
    public class Sandwich
    {
        public string Bread { get; set; }
        public string Meat { get; set; }
        public string Cheese { get; set; }
        public List<string> Vegetables { get; set; } = new();
        public List<string> Sauces { get; set; } = new();

        public override string ToString()
        {
            return $"Sandwich [Bread: {Bread}, Meat: {Meat}, Cheese: {Cheese}, " +
                   $"Vegetables: {string.Join(", ", Vegetables)}, Sauces: {string.Join(", ", Sauces)}]";
        }
    }

    
    public interface ISandwichBuilder
    {
        ISandwichBuilder AddBread(string bread);
        ISandwichBuilder AddMeat(string meat);
        ISandwichBuilder AddCheese(string cheese);
        ISandwichBuilder AddVeggies(params string[] veggies);
        ISandwichBuilder AddSauces(params string[] sauces);
        Sandwich Build();
    }

    
    public class CustomSandwichBuilder : ISandwichBuilder
    {
        private Sandwich _sandwich = new();

        public ISandwichBuilder AddBread(string bread)
        {
            _sandwich.Bread = bread;
            return this;
        }

        public ISandwichBuilder AddMeat(string meat)
        {
            _sandwich.Meat = meat;
            return this;
        }

        public ISandwichBuilder AddCheese(string cheese)
        {
            _sandwich.Cheese = cheese;
            return this;
        }

        public ISandwichBuilder AddVeggies(params string[] veggies)
        {
            _sandwich.Vegetables.AddRange(veggies);
            return this;
        }

        public ISandwichBuilder AddSauces(params string[] sauces)
        {
            _sandwich.Sauces.AddRange(sauces);
            return this;
        }

        public Sandwich Build()
        {
            Sandwich result = _sandwich;
            _sandwich = new Sandwich(); 
            return result;
        }
    }

    
    public class SandwichDirector
    {
        private readonly ISandwichBuilder _builder;

        public SandwichDirector(ISandwichBuilder builder)
        {
            _builder = builder;
        }

        public Sandwich MakeVegetarianSandwich()
        {
            return _builder
                .AddBread("Whole Wheat")
                .AddCheese("Cheddar")
                .AddVeggies("Lettuce", "Tomatoes", "Cucumbers")
                .AddSauces("Mayonnaise", "Mustard")
                .Build();
        }
    }


    class SandwichBuilderPattern
    {
        public static void Execute()
        {
            ISandwichBuilder builder = new CustomSandwichBuilder();

            
            Sandwich custom = builder
                .AddBread("White")
                .AddMeat("Chicken")
                .AddCheese("Mozzarella")
                .AddVeggies("Lettuce", "Cucumbers")
                .AddSauces("Mustard")
                .Build();

            Console.WriteLine("Custom Sandwich:");
            Console.WriteLine(custom);

            
            SandwichDirector director = new(builder);
            Sandwich vegetarian = director.MakeVegetarianSandwich();

            Console.WriteLine("\nVegetarian Sandwich:");
            Console.WriteLine(vegetarian);
        }
    }
}
