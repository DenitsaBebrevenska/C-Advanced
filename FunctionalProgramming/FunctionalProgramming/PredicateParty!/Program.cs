namespace PredicateParty_
{
    internal class Program
    {
        static Func<string, string, string, bool> _satisfiesCondition = (name, condition, filter) =>
        {
            if (condition == "StartsWith")
            {
                return name.Substring(0, filter.Length) == filter;
            }
            else if (condition == "EndsWith")
            {
                return name.Substring(name.Length - filter.Length) == filter;
            }
            else if (condition == "Length")
            {
                return name.Length == int.Parse(filter);
            }

            return false;
        };
        static void Main()
        {
            List<string> guestList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string condition = commandArgs[1];
                string filter = commandArgs[2];

                if (command == "Remove")
                {
                    for (int i = 0; i < guestList.Count; i++)
                    {
                        if (_satisfiesCondition(guestList[i], condition, filter))
                        {
                            guestList.RemoveAt(i);
                        }
                    }
                }
                else // Double
                {
                    for (int i = 0; i < guestList.Count; i++)
                    {
                        if (_satisfiesCondition(guestList[i], condition, filter))
                        {
                            guestList.Insert(i, guestList[i]);
                            i++;
                        }
                    }
                }
            }

            Console.WriteLine(guestList.Count > 0 ? $"{string.Join(", ", guestList)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
