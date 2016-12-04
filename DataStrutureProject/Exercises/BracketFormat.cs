using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureProject.Exercises
{
    public class BracketFormat
    {
        public static async Task ValidateStringBrackets(string input)
        {
            //Input
            //string input = "(a[]{}([{}]d))";
            var acceptedSymbols = new Dictionary<char, char>();
            acceptedSymbols.Add('(', ')');
            acceptedSymbols.Add('[', ']');
            acceptedSymbols.Add('{', '}');

            var stack = new Stack<char>();

            var output = new Task(() =>
            {
                foreach (var character in input.ToCharArray())
                {
                    if (acceptedSymbols.ContainsKey(character))
                        stack.Push(character);
                    else
                    {
                        if (acceptedSymbols.ContainsValue(character))
                        {
                            var previuosSymbol = stack.Peek();
                            var item = acceptedSymbols.FirstOrDefault(a => a.Value.Equals(character));

                            if (previuosSymbol == item.Key)
                                stack.Pop();
                        }
                    }
                }

                if (stack.Count() > 0)
                    Console.WriteLine("String format is not correct");
                else
                    Console.WriteLine("String format is correct");

            });


            output.Start();
            await output;
        }
    }
}
