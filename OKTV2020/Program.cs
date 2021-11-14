using System;
using System.Collections.Generic;
using System.Linq;

namespace OKTV2020
{
    class Program
    {
        static void TaskOne()
        {
            (bool isDivisible, List<int> partialResults) IsDivisibleWithThirtySeven(int number)
            {
                bool isDivisible = false;
                List<int> partialResults = new();

                while (number >= 37)
                {
                    string numberAsString = number.ToString();
                    int length = numberAsString.Length;

                    int firstSection = int.Parse(numberAsString.Substring(0, length - 1));
                    int lastSection = int.Parse(numberAsString.Substring(length - 1));

                    number = firstSection - (lastSection * 11);

                    if (number >= 0)
                    {
                        partialResults.Add(number);

                    }
                }

                if (number % 37 == 0)
                {
                    isDivisible = true;
                }

                return (isDivisible, partialResults);
            }

            int input = int.Parse(Console.ReadLine());
            (bool isDivisible, List<int> partialResults) = IsDivisibleWithThirtySeven(input);

            Console.WriteLine(isDivisible ? "IGEN" : "NEM");
            foreach (int partialResult in partialResults)
            {
                Console.Write("{0} ", partialResult);
            }
            Console.WriteLine();
        }

        static void TaskTwo()
        {
            string FindLongestMutatedSequence(string sequence)
            {
                string bases = "ACGT";
                int length = sequence.Length;
                string longestMutatedSequence = "";

                for(int i = 0; i < length - 1; i++)
                {
                    for(int j = sequence.Substring(i).Length; j > 0; j--)
                    {
                        string testedSequence = sequence.Substring(i, j);
                        Dictionary<char, int> occurences = new();

                        foreach (char possibleBase in bases)
                        {
                            occurences.Add(possibleBase, 0);
                            foreach (char @base in testedSequence)
                            {
                                if (@base == possibleBase)
                                {
                                    occurences[@base] += 1;
                                }
                            }
                        }

                        KeyValuePair<char, int> baseWithMaxOccurence = occurences.Aggregate((x, y) => x.Value >= y.Value ? x : y);
                        if (baseWithMaxOccurence.Value >= (testedSequence.Length + 2 - 1) / 2 && testedSequence.Length > longestMutatedSequence.Length)
                        {
                            longestMutatedSequence = testedSequence;
                        } 
                    }
                }

                return longestMutatedSequence;
            }

            string input = Console.ReadLine();
            string longestMutatedSequence = FindLongestMutatedSequence(input);
            Console.WriteLine(longestMutatedSequence.Length);
        }

        static void TaskThree()
        {
            string[] firstLineStringArray = Console.ReadLine().Split(" ");
            int N = int.Parse(firstLineStringArray[0]);
            int Q = int.Parse(firstLineStringArray[1]);

            List<int> lengthsOfSections = new();
            List<(int first, int second)> lengthsOfSectionsInQuestions = new();

            string[] secondLineStringArray = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                lengthsOfSections.Add(int.Parse(secondLineStringArray[i]));
            }

            for(int i = 0; i < Q; i++)
            {
                string[] lineStringArray = Console.ReadLine().Split(" ");
                int first = int.Parse(lineStringArray[0]);
                int second = int.Parse(lineStringArray[1]);
                lengthsOfSectionsInQuestions.Add((first, second));
            }

            foreach((int first, int second) in lengthsOfSectionsInQuestions)
            {
                List<(int a, int b, int c)> possibilities = new();
                for(int i = 0; i < lengthsOfSections.Count; i++)
                {
                    if(lengthsOfSections[i] < first + second && first < lengthsOfSections[i] + second && second < first + lengthsOfSections[i])
                    {
                        possibilities.Add((lengthsOfSections[i], first, second));
                    }
                }
                Console.WriteLine(possibilities.Count);
            }
        }

        static void TaskFour()
        {
            string[] firstLineStringArray = Console.ReadLine().Split(" ");
            int N = int.Parse(firstLineStringArray[0]);
            int Q = int.Parse(firstLineStringArray[1]);
        }

        static void Main(string[] args)
        {
            //TaskOne();
            //TaskTwo();
            //TaskThree();
            TaskFour();
        }
    }
}
