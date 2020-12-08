using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    public class Solver
    {
        static List<Bag> _bagDefinitions;

        public Solver()
        {
            GetInputs();
        }

        public int Solve1()
        {
            var shinyBag = _bagDefinitions.Single(b => b.Name.Equals("shiny gold"));

            var parents = new HashSet<string>();
            CalculateBagParents(parents, shinyBag);

            return parents.Count;
        }

        static void CalculateBagParents(HashSet<string> bagNames, Bag bag)
        {
            foreach (var parent in bag.Parents)
            {
                bagNames.Add(parent.Name);
            }

            foreach (var parent in bag.Parents)
            {
                CalculateBagParents(bagNames, parent);
            }
        }

        // public int Solve2()
        // {
        //     var seatIds = Solve1();
        //     seatIds.Sort();
        //
        //     var validSeats = Enumerable.Range(seatIds[0], seatIds.Count);
        //     var missingSeats = validSeats.Except(seatIds);
        //
        //     return missingSeats.First();
        // }

        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _bagDefinitions = lines.Select(ParseBagDefinition).ToList();

            foreach (var bag in _bagDefinitions)
            {
                var childBags = _bagDefinitions.Where(b => bag.ChildrenNames.Contains(b.Name)).ToList();
                bag.Children = childBags;

                foreach (var child in childBags)
                {
                    child.Parents.Add(bag);
                }
            }
        }

        static Bag ParseBagDefinition(string input)
        {
            var definitionTokens = input.Split(new[]{"bags", "bag", " contain", ",", "."}, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag
            {
                Name = definitionTokens[0].Trim()
            };

            if (definitionTokens[1].Trim().Equals("no other")) return bag;

            for (var i = 1; i < definitionTokens.Length; i++)
            {
                var bagToken = definitionTokens[i].Trim();
                var bagName = string.Join(" ", bagToken.Split(" ").Skip(1));

                bag.ChildrenNames.Add(bagName);
            }

            return bag;
        }
    }

    public class Bag
    {
        public string Name { get; set; }
        public List<string> ChildrenNames { get; set; } = new List<string>();
        public List<Bag> Children { get; set; } = new List<Bag>();
        public List<Bag> Parents { get; set; } = new List<Bag>();
    }
}