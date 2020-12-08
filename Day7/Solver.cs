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

        public int Solve2()
        {
            var shinyBag = _bagDefinitions.Single(b => b.Name.Equals("shiny gold"));

            var childBags = shinyBag.CountBags(false);
            return childBags;
        }

        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _bagDefinitions = lines.Select(ParseBagDefinition).ToList();

            foreach (var bag in _bagDefinitions)
            {
                // set bags that this one can contain
                foreach (var (childBagName, childBagCount) in bag.ParsedChildren)
                {
                    var matchingBagDefinition = _bagDefinitions.Find(b => b.Name.Equals(childBagName));
                    bag.Children.Add(matchingBagDefinition, childBagCount);
                }

                // go into those bags and set this one as a parent
                foreach (var child in bag.Children.Keys)
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
                var bagString = definitionTokens[i].Trim();
                var bagTokens = bagString.Split(" ");

                var bagCount = int.Parse(bagTokens.First());
                var bagName = string.Join(" ", bagTokens.Skip(1));

                bag.ParsedChildren.Add(bagName, bagCount);
            }

            return bag;
        }
    }
}