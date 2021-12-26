using System;
using System.IO;
using System.Collections.Generic;

namespace ExeDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votes = new Dictionary<string, int>();

            Console.Write("Enter the file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader stream = File.OpenText(path))
                {
                    while (!stream.EndOfStream)
                    {
                        string[] line = stream.ReadLine().Split(',');

                        string key = line[0];
                        int value = int.Parse(line[1]);

                        if(votes.ContainsKey(key))
                        {
                            /*
                                int tst = votes[key];

                                value = (tst + value);

                                votes[key] = value;
                            */
                            votes[key] += value;
                        }
                        else
                        {
                            votes.Add(key, value);
                        }
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach(KeyValuePair<string, int> obj in votes)
            {
                Console.WriteLine(obj.Key + ": " + obj.Value);
            }
        }
    }
}
