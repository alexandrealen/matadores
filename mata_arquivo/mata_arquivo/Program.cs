using System;
using System.IO;

namespace mata_logs
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < Convert.ToDouble(args[0]); i++)
                {
                    var logs = new DirectoryInfo(args[i+2]).GetFiles("*.txt");
                    foreach (var log in logs)
                    {
                        if (DateTime.UtcNow - log.CreationTimeUtc > TimeSpan.FromHours(Convert.ToDouble(args[1])))
                        {
                            File.Delete(log.FullName);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try to execute with: 'mata_arquivo.exe <number of folders> <lifetime in hours> <folder path> <optional folder path 2>'");
                Console.WriteLine(@"Example: 'mata_arquivo.exe 1 24 C:\Desktop\logs'");
                Console.WriteLine(@"Example 2: 'mata_arquivo.exe 2 24 C:\Desktop\logs C:\Desktop\blogs'");
            }
        }
    }
}
