using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_1Y_DSaA_BingoCardV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] bingoCard = new int[5][];
            string[][] displayCard = new string[5][];
            List<int> numPool = new List<int>();
            Random rnd = new Random();

            // declaration
            for (int x = 0; x < bingoCard.Length; x++)
            {
                bingoCard[x] = new int[5];
                displayCard[x] = new string[5];
                for (int y = 0; y < bingoCard[x].Length; y++)
                {
                    bingoCard[x][y] = -1;
                }
            }

            // filling up
            for (int x = 0; x < bingoCard.Length; x++) // column
            {
                numPool.Clear(); // removes all the content of the list
                for (int y = 1; y <= 15; y++) // generating possible numbers for the column
                    numPool.Add(y + (x * 15));

                for (int y = 0; y < bingoCard[x].Length; y++) // row
                {
                    bingoCard[x][y] = numPool[rnd.Next(numPool.Count())];
                    numPool.Remove(bingoCard[x][y]);
                }
            }

            // transfer the values from int to string card
            for (int x = 0; x < bingoCard.Length; x++)
            {
                for (int y = 0; y < bingoCard[x].Length; y++)
                {
                    displayCard[y][x] = bingoCard[y][x] + "";
                    while (displayCard[y][x].Length < 3)
                        displayCard[y][x] = " " + displayCard[y][x];
                }
            }

            displayCard[2][2] = "FRE";

            // display the card
            Console.WriteLine(" |  B  |  I  |  N  |  G  |  O  | ");
            Console.WriteLine(" ===============================");
            for (int x = 0; x < displayCard.Length; x++)
            {
                Console.Write(" | ");
                for (int y = 0; y < displayCard[x].Length; y++)
                    Console.Write(displayCard[y][x] + " | ");
                Console.WriteLine("\n ===============================");
            }

            Console.ReadKey(); 
        }
    }
}
