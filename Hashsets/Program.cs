using System.Diagnostics;

namespace Hashsets;

class Chapter11
{
    static string? section;
    static void OneSecondDelay()
    {
        Thread.Sleep( TimeSpan.FromSeconds(1) );
    }
    static void Main()
    {
        OneSecondDelay();
        Console.WriteLine("-----------------------------------------------------------\n" +
                          "Which section would you like to view?\n" +
                          "1: Section2\n" +
                          "2: Section3 (contains Section4, Section5 and Section6)\n");
        
        section = Console.ReadLine()?.ToLower();
        switch (section)
        {
            case "section2" or "1": 
                section = "Section 2";
                OneSecondDelay();
                Section2();
                break;
            case "section3" or "2":
                section = "Section 3";
                OneSecondDelay();
                Section3();
                break;
            default: 
                OneSecondDelay();
                Console.WriteLine("Try again.");
                Main();
                break;
        }
    }

    static void Section2()
    {
        string[] names = { "Lucas", "Christoffer", "Leonard", "Emilie", "Frederik", 
            "Frederik", "Holger", "Jakob", "Nikolaj" };

        Console.WriteLine($"\n---------------------------------------\n" +
                          $"There is currently {names.Length} students.\n" +
                          $"The names of the students are:");

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
        
        HashSet<string> hashSet = new HashSet<string>(names);
        Console.WriteLine($"\n---------------------------------------\n" +
                          $"Count of elements in HashSet: {hashSet.Count}.\n" +
                          $"The elements in the HashSet is:");
        foreach (var elements in hashSet)
        {
            Console.WriteLine(elements);
        }

        Console.WriteLine("\n--------------------------\n" +
                          "Who is the smelly one?\n");
        string? answer = Console.ReadLine()?.ToLower();
        switch (answer)
        {
            case "jakob":
                OneSecondDelay();
                Console.WriteLine($"That's correct!");
                break;
            default:
                OneSecondDelay();
                Console.WriteLine("That's not true...");
                break;
        }
        OneSecondDelay();
        Console.WriteLine($"{section} is terminated.");
        Main();
    }

    static void Section3()
    {
        string[] names1 = { "Frederik", "Nikolaj", "Jakob", "Lucas", "Leonard", "Christoffer" };
        string[] names2 = { "Frederik", "Holger", "Alfred", "Marie", "Emilie" };

        HashSet<string> hashSetN1 = new HashSet<string>(names1);
        Console.WriteLine("---------------------\n" +
                          "Data in HashSet 1:");
        foreach (var element in hashSetN1)
        {
            Console.WriteLine(element);
        }

        HashSet<string> hashSetN2 = new HashSet<string>(names2);
        Console.WriteLine("\n---------------------\n" +
                          "Data in HashSet 2:");
        foreach (var element in hashSetN2)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("\n----------------------------------------\n" +
                          "Do you want to Unify these HashSets?\n" +
                          "y/n\n");
        var unify = Console.ReadLine()?.ToLower();
        switch (unify)
        {
            case "y":
                OneSecondDelay();
                //Unionize data
                Console.WriteLine("\nHashSet 1 and HashSet 2 unified:");
                hashSetN1.UnionWith(hashSetN2);
                foreach (var element in hashSetN1)
                {
                    Console.WriteLine(element);
                }

                OneSecondDelay();
                Console.WriteLine($"{section} is terminated.");
                break;
            default:
                OneSecondDelay();
                break;
        }

        Console.WriteLine("\nok\n" +
                          "\nDo you want to commence a new section?" +
                          "\n1: Section 4 (ExceptWith)" +
                          "\n2: Section 5 (SymmetricExceptWith)" +
                          "\n3: Section 6 (Performance)");
        
        var newsection = Console.ReadLine()?.ToLower();
        switch (newsection)
        {
            case "section4" or "1":
                OneSecondDelay();
                Section4();
                break;
            case "section5" or "2":
                OneSecondDelay();
                Section5();
                break;
            case "section6" or "3":
                OneSecondDelay();
                Section6();
                break;
            case "n":
                OneSecondDelay();
                Main();
                break;
        }

        void Section4()
        {
            HashSet<string> hashSetN3 = new HashSet<string>(names1);

            foreach (var element in hashSetN3)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\n---------------------------------------------------------\n" +
                              "Do you want to remove duplicate elements using ExceptWith?" +
                              "\ny/n\n");
            string? exceptwith = Console.ReadLine();
            switch (exceptwith)
            {
                case "y":
                    hashSetN3.ExceptWith(hashSetN2);
                    Console.WriteLine("-----------------------------\n" +
                                      "HashSet without duplicates:\n");
                    foreach (var element in hashSetN3)
                    {
                        Console.WriteLine(element);
                    }

                    Main();
                    break;
                default:
                    Console.WriteLine("ok");
                    Main();
                    break;
            }
        }

        void Section5()
        {
            HashSet<string> hashSetN4 = new HashSet<string>(names1);
            Console.WriteLine("\n---------------------------------------------------------\n" +
                              "Showing elements before using SymmetricExceptWith:");
            Console.WriteLine("HashSet 1:");
            foreach (var element in hashSetN4)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("HashSet 2:");
            foreach (var element in hashSetN2)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\n---------------------------------------------------------\n" +
                              "Using SymmetricExceptWith on HashSets:");
            hashSetN4.SymmetricExceptWith(hashSetN2);
            foreach (var element in hashSetN4)
            {
                Console.WriteLine(element);
            }
        }

        void Section6()
        {
            int amountOfNames = 4000;
            string[] bigListOfNames = new string[amountOfNames];
            for (int i = 0; i < amountOfNames; i++)
            {
                switch (i)
                {
                    case 0:
                        bigListOfNames[i] = "Emilie";
                        break;
                    case 1:
                        bigListOfNames[i] = "Leonard";
                        break;
                    case 2:
                        bigListOfNames[i] = "Lucas";
                        break;
                    case 3:
                        bigListOfNames[i] = "Nikolaj";
                        break;
                    case 4:
                        bigListOfNames[i] = "Christoffer";
                        break;
                    default:
                        bigListOfNames[i] = "Jakob";
                        break;
                }   
            }

            Console.WriteLine(
                $"Do you want to test the performance between List<> and HashSet<> using a string of {bigListOfNames.Length} elements?" +
                $"\ny/n\n");
            var perf = Console.ReadLine()?.ToLower();
            switch (perf)
            {
                case "y":
                    OneSecondDelay();
                    PerformanceTest();
                    break;
                case "n":
                    OneSecondDelay();
                    Console.WriteLine("Returning to start...");
                    OneSecondDelay();
                    Main();
                    break;
                default:
                    OneSecondDelay();
                    Console.WriteLine("goodbye.");
                    OneSecondDelay();
                    break;
            }

            void PerformanceTest()
            {
                Console.WriteLine("Do you want to test performance in other tests?" +
                                  "\nAvailable tests:" +
                                  "\n1: Add()" +
                                  "\n2: Contains()" +
                                  "\n3: Remove()" +
                                  "\n N: Return to start.");
                var testToRun = Console.ReadLine()?.ToLower();
                switch (testToRun)
                {
                    case "1" or "add":
                        PerformanceAdd();
                        break;
                    case "2" or "contains":
                        PerformanceContains();
                        break;
                    case "3" or "remove":
                        PerformanceRemove();
                        break;
                    case "n":
                        Console.WriteLine("Returning to start...");
                        Main();
                        break;
                    default:
                        PerformanceTest();
                        break;
                }
            }

            void PerformanceAdd()
            {
                //Testing Add() performance between List<> and HashSet<>
                //List will simply add elements to it, where as HashSet will check if a duplicate element appears.
                //Therefore List are more likely going to perform better in this test than HashSet.
                List<string> listNames = new List<string>();
                var s1 = Stopwatch.StartNew();
                foreach (string element in bigListOfNames)
                {
                    listNames.Add(element);
                }

                s1.Stop();
                Console.WriteLine($"List performance: {s1.Elapsed.TotalMilliseconds:0.0000}");

                HashSet<string> hashSetNames = new HashSet<string>(StringComparer.Ordinal);
                var s2 = Stopwatch.StartNew();
                foreach (string element in bigListOfNames)
                {
                    hashSetNames.Add(element);
                }

                s2.Stop();
                Console.WriteLine($"HashSet performance: {s2.Elapsed.TotalMilliseconds:0.0000}");

                OneSecondDelay();
                Console.WriteLine("... the results are in!\n");
                OneSecondDelay();

                if (s1.Elapsed.TotalMilliseconds < s2.Elapsed.TotalMilliseconds)
                {
                    Console.WriteLine("List was the fastest.");
                }
                else if (s1.Elapsed.TotalMilliseconds > s2.Elapsed.TotalMilliseconds)
                {
                    Console.WriteLine("HashSet was the fastest.");
                }
                else
                {
                    Console.WriteLine("Just kidding, I'm a dumb computer :)");
                }
                OneSecondDelay();
                Console.WriteLine("Returning to performance menu...");
                OneSecondDelay();
                PerformanceTest();
            }
            
            void PerformanceContains()
            {
                //Testing Contains() performance between List<> and HashSet<>.
                //As explained above; HashSet will check for duplicate elements and will skip them.
                //The duplicate elements are still inside the HashSet, but they are arranged in a way that makes them easy to count.
                //This should results in HashSet being faster than List.
                List<string> listNames = new List<string>();
                var s1 = Stopwatch.StartNew();
                foreach (string element in bigListOfNames)
                {
                    var contains = listNames.Contains(element);
                }

                s1.Stop();

                Console.WriteLine($"List performance: {s1.Elapsed.TotalMilliseconds:0.0000}");

                HashSet<string> hashSetNames = new HashSet<string>(StringComparer.Ordinal);
                var s2 = Stopwatch.StartNew();
                foreach (string element in bigListOfNames)
                {
                    hashSetNames.Contains(element);
                }

                s2.Stop();
                Console.WriteLine($"HashSet performance: {s2.Elapsed.TotalMilliseconds:0.0000}");
                
                OneSecondDelay();
                Console.WriteLine("... the results are in!\n");
                OneSecondDelay();

                if (s1.Elapsed.TotalMilliseconds < s2.Elapsed.TotalMilliseconds)
                {
                    Console.WriteLine("List was the fastest.");
                }
                else if (s1.Elapsed.TotalMilliseconds > s2.Elapsed.TotalMilliseconds)
                {
                    Console.WriteLine("HashSet was the fastest.");
                }
                else
                {
                    Console.WriteLine("Just kidding, I'm a dumb computer :)");
                }
                OneSecondDelay();
                Console.WriteLine("Returning to performance menu...");
                OneSecondDelay();
                PerformanceTest();
            }
            
            void PerformanceRemove()
            {
                //Testing Remove() performance between List<> and HashSet<>
                //This should give similar results to the ones in the Contains() method, since it is practically the same operation.
                //HashSet should be faster than List
                List<string> listNames = new List<string>();
                var s1 = Stopwatch.StartNew();
                foreach (string element in bigListOfNames)
                {
                    listNames.Remove(element);
                }

                s1.Stop();

                Console.WriteLine($"List performance: {s1.Elapsed.TotalMilliseconds:0.0000}");

                HashSet<string> hashSetNames = new HashSet<string>(StringComparer.Ordinal);
                var s2 = Stopwatch.StartNew();
                foreach (string element in bigListOfNames)
                {
                    hashSetNames.Remove(element);
                }

                s2.Stop();
                Console.WriteLine($"HashSet performance: {s2.Elapsed.TotalMilliseconds:0.0000}");

                OneSecondDelay();
                Console.WriteLine("... the results are in!\n");
                OneSecondDelay();

                if (s1.Elapsed.TotalMilliseconds < s2.Elapsed.TotalMilliseconds)
                {
                    Console.WriteLine("List was the fastest.");
                }
                else if (s1.Elapsed.TotalMilliseconds > s2.Elapsed.TotalMilliseconds)
                {
                    Console.WriteLine("HashSet was the fastest.");
                }
                else
                {
                    Console.WriteLine("Just kidding, I'm a dumb computer :)");
                }
                OneSecondDelay();
                Console.WriteLine("Returning to performance menu...");
                OneSecondDelay();
                PerformanceTest();
            }
        }
    }
}