namespace PeriodicTable
{
    internal class Program
    {
        static void Main()
        {
            byte entryCount = byte.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < entryCount; i++)
            {
                string[] currentEntry = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentEntry.Length; j++)
                {
                    elements.Add(currentEntry[j]);
                }
            }

            foreach (string element in elements.OrderBy(e => e))
            {
                Console.Write(element + " ");
            }
        }
    }
}
