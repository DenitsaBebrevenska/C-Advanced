namespace CustomMinFunction
{
    internal class Program
    {
        static void Main()
        {
            //Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection. Use Func<T, T>.

            int[] numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> smallerNumber = (a, b) => a < b ? a : b;
            Console.WriteLine(numbers.Aggregate(smallerNumber));
        }
    }
}
