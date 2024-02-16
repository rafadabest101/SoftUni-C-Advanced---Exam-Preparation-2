using System;
using System.Collections.Generic;

namespace SU_AdvancedExamPrep2
{
    internal class Program
    {
        static void Main()
        {
            List<string> toolInts = Console.ReadLine().Split().ToList();
            Queue<int> tools = new Queue<int>();
            foreach(string tool in toolInts) tools.Enqueue(int.Parse(tool));

            List<string> substanceInts = Console.ReadLine().Split().ToList();
            Stack<int> substances = new Stack<int>();
            foreach(string substance in substanceInts) substances.Push(int.Parse(substance));

            List<string> challenges = Console.ReadLine().Split().ToList();

            while(true)
            {
                bool challengeResolved = false;
                foreach(string ch in challenges)
                {
                    if(tools.Peek() * substances.Peek() == int.Parse(ch))
                    {
                        tools.Dequeue();
                        substances.Pop();
                        challenges.Remove(ch);
                        
                        challengeResolved = true;
                        break;
                    }
                }
                
                if(!challengeResolved)
                {
                    tools.Enqueue(tools.Dequeue() + 1);
                    substances.Push(substances.Pop() - 1);
                    if(substances.Peek() == 0) substances.Pop();
                }

                if(substances.Count == 0 || tools.Count == 0 || challenges.Count == 0)
                {
                    if((substances.Count == 0 || tools.Count == 0) && challenges.Count > 0)
                    {
                        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    }
                    else if(challenges.Count == 0)
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    }

                    if(tools.Count > 0) Console.WriteLine($"Tools: {string.Join(", ", tools)}");
                    if(substances.Count > 0) Console.WriteLine($"Substances: {string.Join(", ", substances)}");
                    if(challenges.Count > 0) Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");

                    return;
                }
            }
        }
    }
}