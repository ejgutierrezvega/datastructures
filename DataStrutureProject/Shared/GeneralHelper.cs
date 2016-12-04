using System;
using System.Collections;

namespace DataStructureProject.Shared
{
    public class GeneralHelper
    {
        public static ArrayList GetListOfNumbers(int size = 10)
        {
            Random r = new Random();
            var arrayList = new ArrayList();

            for (int i = 0; i < size; i++)
            {
                int randomNumber = r.Next(0, 100);
                while (arrayList.Contains(randomNumber))
                    randomNumber = r.Next(0, 100);
                arrayList.Add(randomNumber);
            }

            Console.WriteLine("Numbers: " + PrintListOfNumbers(arrayList));

            return arrayList;
        }

        public static string PrintListOfNumbers(ArrayList input)
        {
            string completeNumbers = string.Empty;
            foreach (var item in input)
                completeNumbers += item.ToString() + ", ";

            return completeNumbers.Remove(completeNumbers.LastIndexOf(","));
        }
    }
}
