using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    internal class Program
    {
        static readonly int r = 5;
        static readonly int c = 5;
        static void Main(string[] args)
        {
            GenerateRandomNumbers();
            var Grid = GenerateRandomNumbers();
            var listOfWord = readTextFile();
            
            foreach (var word in listOfWord)
            {
                if (checkMatch(Grid, word, r, c))
                    Console.Write(word);
            }
            Console.ReadLine();
        }

        private static List<string> readTextFile() {
            
            var list = new List<string>();
            
            var fileStream = new FileStream(@"C:\Temp\words.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }
        private static char[,] GenerateRandomNumbers()
        {
            char[,] Grid = new char[5, 5];
            char[] randomLetter = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Random rng = new Random();

            for (int i = 0; i<Grid.GetLength(0); i++)
            {
                for (int j = 0; j<Grid.GetLength(1); j++)
                {                 
                    int nextRandom = rng.Next(0, 26);

                    char actualRandomLetter = randomLetter[nextRandom];

                 Grid[i, j] = actualRandomLetter;
               }
            } 
            return Grid;
        }

        // Function to check if a word exists in a grid
        // starting from the first match in the grid
        // level: index till which pattern is matched
        // x, y: current position in 2D array
        static bool findmatch(char[,] mat, string pat, int x, int y,
                                int nrow, int ncol, int level)
        {
            int l = pat.Length;

            // Pattern matched
            if (level == l)
                return true;

            // Out of Boundary
            if (x < 0 || y < 0 || x >= nrow || y >= ncol)
                return false;

            // If grid matches with a letter while
            // recursion
            if (mat[x, y] == pat[level])
            {

                // Marking this cell as visited
                char temp = mat[x, y];
                mat[x, y] = '#';

                // finding subpattern in 4 directions
                bool res = findmatch(mat, pat, x - 1, y, nrow, ncol, level + 1) |
                            findmatch(mat, pat, x + 1, y, nrow, ncol, level + 1) |
                            findmatch(mat, pat, x, y - 1, nrow, ncol, level + 1) |
                            findmatch(mat, pat, x, y + 1, nrow, ncol, level + 1);

                // marking this cell
                // as unvisited again
                mat[x, y] = temp;
                return res;
            }
            else // Not matching then false
                return false;
        }

        // Function to check if the word exists in the grid or not
        static bool checkMatch(char[,] mat, string pat, int nrow, int ncol)
        {

            int l = pat.Length;

            // if total characters in matrix is
            // less than pattern length
            if (l > nrow * ncol)
                return false;

            // Traverse in the grid
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncol; j++)
                {

                    // If first letter matches, then recur and check
                    if (mat[i, j] == pat[0])
                        if (findmatch(mat, pat, i, j, nrow, ncol, 0))
                            return true;
                }
            }
            return false;
        }


    }
}
