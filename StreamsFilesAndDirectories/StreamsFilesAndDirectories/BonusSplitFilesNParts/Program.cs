namespace BonusSplitFilesNParts
{
    internal class Program
    {
        static void Main()
        {
            string directory = "../../../input.txt";
            Console.WriteLine("How many parts do you want to split the input.txt file into?");
            string input = Console.ReadLine();

            byte[] fileBytes = File.ReadAllBytes(directory);

            while (!CheckUserInput(input, fileBytes.Length))
            {
                input = Console.ReadLine();
            }
        }

        static bool CheckUserInput(string input, long fileLength)
        {
            long partsCount;

            try
            {
                partsCount = long.Parse(input);
            }
            catch (Exception parsingException)
            {
                Console.WriteLine("Please enter a number!");
                return false;
            }
            if (partsCount < 0)
            {
                Console.WriteLine("The parts count cannot be a negative number! Enter a new count!");
                return false;
            }

            if (partsCount > fileLength)
            {
                Console.WriteLine("Cannot split file into more parts than its length! Enter a new count!");
                return false;
            }

            return true;
        }

        static void ParseInput()
        {

        }
    }
}
