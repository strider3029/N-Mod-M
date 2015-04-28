using System;
using System.IO;

namespace NModM
{
    class NModM
    {
        static int Main(string[] args)
        {
            // Check the argument and file exists
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.Write("You failed to specify the file to read, or entered a non existant file path.\nPlease try again with the file name as the first argument.");
                return 0;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (null == line) continue;

                    if ("" == line) continue;

                    string[] numberBlocks = line.Split(',');

                    if (numberBlocks.Length != 2) continue;

                    int n = Convert.ToInt32(numberBlocks[0]);
                    int m = Convert.ToInt32(numberBlocks[1]);

                    PrintNModM(n, m);
                }
            }

            return 0;
        }

        static void PrintNModM(int n, int m)
        {
            if (m == 0) return;

            int quotient = n / m;
            int product = quotient * m;
            int nModm = n - product;

            Console.WriteLine(nModm);
        }
    }
}
