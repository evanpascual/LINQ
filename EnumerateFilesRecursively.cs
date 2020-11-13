/* Temporary separate file for notes/testing 
of EnumerateFilesRecursively function
*/
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// code found on StackOverflow from 2013, will look more into this
// slightly modified

namespace ConsoleApp {

    class Program {
        
        static IEnumerable<string> EnumerateFilesRecursively(string path) {

            // checks every file in folder
            foreach (var file in Directory.GetFiles(path))
            {
                yield return file;                
            }

            // checks every folder within the directory
            foreach (var folder in Directory.GetDirectories(path))
            {
                // recursively call functions to check number of folders in each subfolder
                foreach(var file in EnumerateFilesRecursively(folder))
                    yield return file;
            }
        }

        // use this to test (don't know how to run yet though)
        static void Main(string[] args) {

            var line = EnumerateFilesRecursively(args[0]);
            Console.WriteLine(line);
        }
    }
}

// I placed this EnumerateFilesRecursively function in the Program.cs file with its friends :)
// I left this file here doe so you know I didnt just up and delete your work
// -Evan