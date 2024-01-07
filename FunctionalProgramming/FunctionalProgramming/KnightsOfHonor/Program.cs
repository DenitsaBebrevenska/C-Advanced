namespace KnightsOfHonor
{
    internal class Program
    {
        static Action<string> printSirName = name => Console.WriteLine($"Sir {name}");
        static void Main()
        {
            //Create a program that reads a collection of names as strings from the console, appends "Sir" in front of every name and prints it back in the console. Use Action<T>.
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names.ForEach(printSirName);
        }
    }
}
