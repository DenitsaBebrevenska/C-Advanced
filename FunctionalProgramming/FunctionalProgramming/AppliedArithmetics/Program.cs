namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main()
        {
            //must use functions
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, string, List<int>> manipulateList = (numberList, command) =>
            {
                if (command == "add")
                {
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        numbers[i]++;
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        numbers[i] *= 2;
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        numbers[i]--;
                    }
                }
                
                return numberList;
            };


            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "add" || input == "multiply" || input == "subtract")
                {
                    manipulateList(numbers, input);
                    continue;
                }

                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
