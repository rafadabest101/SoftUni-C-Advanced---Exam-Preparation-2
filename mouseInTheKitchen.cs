using System;
using System.Collections.Generic;

namespace SU_AdvancedExamPrep2
{
    internal class Program
    {
        static void Main()
        {
            int[] lengths = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            int n = lengths[0];
            int m = lengths[1];

            char[,] matrix = new char[n, m];

            int mouseRow = 0;
            int mouseCol = 0;
            int cheeses = 0;
            for(int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for(int j = 0; j < m; j++)
                {
                    matrix[i, j] = row[j];
                    if(matrix[i, j] == 'M')
                    {
                        mouseRow = i;
                        mouseCol = j;
                    }
                    if(matrix[i, j] == 'C') cheeses++;
                }
            }

            string direction = Console.ReadLine();
            while(direction != "danger")
            {
                switch(direction)
                {
                    case "up":
                        if(mouseRow == 0)
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            Print(matrix);
                            return;
                        }
                        else
                        {
                            if(matrix[mouseRow - 1, mouseCol] == '@') mouseRow += 0;
                            else
                            {
                                mouseRow--;
                                matrix[mouseRow + 1, mouseCol] = '*';
                                if(matrix[mouseRow, mouseCol] == 'C')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    cheeses--;
                                    if(cheeses == 0)
                                    {
                                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                        Print(matrix);
                                        return;
                                    }
                                }
                                else if(matrix[mouseRow, mouseCol] == 'T')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    Console.WriteLine("Mouse is trapped!");
                                    Print(matrix);
                                    return;
                                }
                                else matrix[mouseRow, mouseCol] = 'M';
                            }
                        }
                        break;
                    case "right":
                        if(mouseCol == m - 1)
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            Print(matrix);
                            return;
                        }
                        else
                        {
                            if(matrix[mouseRow, mouseCol + 1] == '@') mouseRow += 0;
                            else
                            {
                                mouseCol++;
                                matrix[mouseRow, mouseCol - 1] = '*';
                                if(matrix[mouseRow, mouseCol] == 'C')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    cheeses--;
                                    if(cheeses == 0)
                                    {
                                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                        Print(matrix);
                                        return;
                                    }
                                }
                                else if(matrix[mouseRow, mouseCol] == 'T')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    Console.WriteLine("Mouse is trapped!");
                                    Print(matrix);
                                    return;
                                }
                                else matrix[mouseRow, mouseCol] = 'M';
                            }
                        }
                        break;
                    case "down":
                        if(mouseRow == n - 1)
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            Print(matrix);
                            return;
                        }
                        else
                        {
                            if(matrix[mouseRow + 1, mouseCol] == '@') mouseRow += 0;
                            else
                            {
                                mouseRow++;
                                matrix[mouseRow - 1, mouseCol] = '*';
                                if(matrix[mouseRow, mouseCol] == 'C')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    cheeses--;
                                    if(cheeses == 0)
                                    {
                                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                        Print(matrix);
                                        return;
                                    }
                                }
                                else if(matrix[mouseRow, mouseCol] == 'T')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    Console.WriteLine("Mouse is trapped!");
                                    Print(matrix);
                                    return;
                                }
                                else matrix[mouseRow, mouseCol] = 'M';
                            }
                        }
                        break;
                    case "left":
                        if(mouseCol == 0)
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            Print(matrix);
                            return;
                        }
                        else
                        {
                            if(matrix[mouseRow, mouseCol - 1] == '@') mouseRow += 0;
                            else
                            {
                                mouseCol--;
                                matrix[mouseRow, mouseCol + 1] = '*';
                                if(matrix[mouseRow, mouseCol] == 'C')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    cheeses--;
                                    if(cheeses == 0)
                                    {
                                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                        Print(matrix);
                                        return;
                                    }
                                }
                                else if(matrix[mouseRow, mouseCol] == 'T')
                                {
                                    matrix[mouseRow, mouseCol] = 'M';
                                    Console.WriteLine("Mouse is trapped!");
                                    Print(matrix);
                                    return;
                                }
                                else matrix[mouseRow, mouseCol] = 'M';
                            }
                        }
                        break;
                }
                direction = Console.ReadLine();
            }

            Console.WriteLine("Mouse will come back later!");
            Print(matrix);
        }

        public static void Print(char[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}