using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Application
{
    class Files
    {
        static void Main(string[] args)
        {
            Files filesClass = new Files();

            Console.WriteLine("Enter path");
            string path = Console.ReadLine();

            Console.WriteLine("Choose extension");
            string extension = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("File does not exist");
            }

            filesClass.runDirs(path, extension);

            Console.WriteLine("Finished");
        }

        private void runDirs(string path, string extension)
        {
            string[] directoryEntries = Directory.GetDirectories(path);

            foreach (string dirpath in directoryEntries)
            {
                if(!(directoryEntries.Length == 0))
                {
                    string[] fileEntries = Directory.GetFiles(dirpath);

                    foreach (string filepath in fileEntries)
                    {
                        File.Move(filepath, Path.ChangeExtension(filepath, extension));
                        Console.WriteLine(filepath);
                    }
                    runDirs(dirpath, extension);
                }
            }
        }
    }
}