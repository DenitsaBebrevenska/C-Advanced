namespace RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main()
        {
            char[,] bunnyLair = SpawnBunnyLair();
            int playerRowLocation = -1;
            int playerColLocation = -1;

            for (int i = 0; i < bunnyLair.GetLength(0); i++)
            {
                string currentRow = Console.ReadLine();

                for (int j = 0; j < bunnyLair.GetLength(1); j++)
                {
                    bunnyLair[i, j] = currentRow[j];

                    if (currentRow[j] == 'P')
                    {
                        playerRowLocation = i;
                        playerColLocation = j;
                    }
                }
            }

            List<char> movementList = Console.ReadLine().ToCharArray().ToList();
            int[] lastPosition = new int[] { playerRowLocation, playerColLocation };

            for (int i = 0; i < movementList.Count; i++)
            {
                switch (movementList[i])
                {
                    case 'L':
                        playerColLocation--;
                        break;
                    case 'R':
                        playerColLocation++;
                        break;
                    case 'U':
                        playerRowLocation--;
                        break;
                    case 'D':
                        playerRowLocation++;
                        break;
                }

                if (ExitsTheLair(playerRowLocation, playerColLocation, bunnyLair))
                {
                    Console.WriteLine($"won: {lastPosition[0]} {lastPosition[1]}");
                    bunnyLair[lastPosition[0], lastPosition[1]] = '.';
                }

                if (KilledByBunny(playerRowLocation, playerColLocation, bunnyLair))
                {
                    Console.WriteLine($"dead: {playerRowLocation} {playerColLocation}");
                    bunnyLair[lastPosition[0], lastPosition[1]] = '.';
                }

                if (!ExitsTheLair(playerRowLocation, playerColLocation, bunnyLair) 
                    && !KilledByBunny(playerRowLocation, playerColLocation, bunnyLair))
                {
                    bunnyLair[lastPosition[0], lastPosition[1]] = '.';
                    lastPosition[0] = playerRowLocation;
                    lastPosition[1] = playerColLocation;
                }
                
                MultiplyBunnies(bunnyLair);


            }
        }

        static char[,] SpawnBunnyLair()
        {
            int[] matrixDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixDetails[0];
            int cols = matrixDetails[1];
            char[,] bunnyLair = new char[rows, cols];
            return bunnyLair;
        }

        static void MultiplyBunnies(char[,] bunnyLair)
        {
            
        }

        static bool KilledByBunny(int playerRowLocation, int playerColLocation, char[,] bunnyLair)
        {
            return bunnyLair[playerRowLocation, playerColLocation] == 'B';
        }

        static bool ExitsTheLair(int playerRowLocation, int playerColLocation, char[,] bunnyLair)
        {
            return playerRowLocation < 0 || playerRowLocation >= bunnyLair.GetLength(0) ||
                   playerColLocation < 0 || playerColLocation >= bunnyLair.GetLength(1);
        }

        static bool AreValidCoordinates()
        {

        }
    }
}
