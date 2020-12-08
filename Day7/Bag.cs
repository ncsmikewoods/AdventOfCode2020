using System.Collections.Generic;

namespace Day7
{
    public class Bag
    {
        public string Name { get; set; }
        public Dictionary<string, int> ParsedChildren { get; set; } = new Dictionary<string, int>();
        public Dictionary<Bag, int> Children { get; set; } = new Dictionary<Bag, int>();
        public List<Bag> Parents { get; set; } = new List<Bag>();

        public int CountBags(bool countYourself = true)
        {
            var sum = countYourself ? 1 : 0;

            foreach (var (childBag, count) in Children)
            {
                sum += count * childBag.CountBags();
            }

            return sum;
        }
    }
}