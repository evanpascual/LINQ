﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LINQ
{
    class Program
    {
        /*Enumerate all files in a given folder recursively including the entire sub-folder 
        hierarchy. You can use System.IO.Directory. You could use the generator pattern (yield 
        keyword) to implement the iterator*/
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


        /* Formats an inputted byte size into a simplified unit(B, kB, MB, GB, TB, PB, EB, 
        or ZB). The numerical value should be greater or equal to 1, less than 1000 and 
        formatted with 2 fixed digits after the decimal point*/
        static string FormatByteSize(long byteSize)
        {
            if(byteSize >= 1) //Checks that the byte size is non-negative
            {
                if(byteSize >= 1000)
                {
                    double convertedByte = (double)byteSize / 1000; /*Converts long to a double so that 
                    decimal place can be used.*/
                    if(convertedByte >= 1000)
                    {
                        convertedByte /= 1000;
                        if(convertedByte >= 1000)
                        {
                            convertedByte /= 1000;
                            if(convertedByte >= 1000)
                            {
                                convertedByte /= 1000;
                                if(convertedByte >= 1000)
                                {
                                    convertedByte /= 1000;
                                    if(convertedByte >= 1000)
                                    {
                                        convertedByte /= 1000;
                                        if(convertedByte >= 1000)
                                        {
                                        convertedByte /= 1000;
                                        return (String.Format("{0:0.00}", convertedByte) + "zB");
                                        } else {return String.Format("{0:0.00}", convertedByte) + "EB";}
                                    } else {return String.Format("{0:0.00}", convertedByte) + "PB";}
                                } else {return String.Format("{0:0.00}", convertedByte) + "TB";}
                            } else {return String.Format("{0:0.00}", convertedByte) + "GB";}
                        } else {return String.Format("{0:0.00}", convertedByte) + "MB";}
                    } else {return String.Format("{0:0.00}", convertedByte) + "kB";}
                } else {return String.Format("{0:0.00}", byteSize) + "B";}
            }  return null; //value is a negative byte size
        }


        // /*Create a HTML document containing a table with three columns: “Type”, “Count”, and 
        // “Size” for the file name extension (converted to lower case), the number of files with 
        // this type, and the total size of all files with this type, respectively. You can use 
        // System.IO.FileInfo to get the size of a file with a given path. Sort the table by the 
        // byte size value of the “Size” column in descending order. Use your FormatByteSize function 
        // to format the value printed in the “Size” column. Implement this function using LINQ 
        // queries making use of group by and orderby. Use the System.Xml.Linq.XElement constructor 
        // to functionally construct the XML document*/
        private static XDocument CreateReport(IEnumerable<string> files){  
        
            XDocument doc = new XDocument(
                new XElement("html", 
                    new XElement("head",
                        new XElement("title","Data File")),
                new XElement("body",
                    new XElement("table", new XAttribute("boder", "1"),
                        new XElement("thread",
                            new XElement("tr",
                                new XElement("th","Type"),
                                new XElement("th","Count"),
                                new XElement("th","Size"))),
                        new XElement("tbody",
                            from file in files
                                group file by Path.GetExtension(file).ToLower() into typeGroup
                                let totalSize = typeGroup.Sum(file => new FileInfo(file).Length)
                                orderby totalSize descending
                                select new XElement("tr",
                                    new XElement("td",typeGroup.Key),
                                    new XElement("td",typeGroup.Count()),
                                    new XElement("td",FormatByteSize(totalSize))))))));
                          
             return doc;
        
        //reference for table creation: https://www.c-sharpcorner.com/blogs/convert-an-xml-into-html-table-using-linqtoxml1
        //for getting length of file using FileInfo : https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=net-5.0 
            
        }


        /* Takes two command line arguments: The first value is the path of the input folder and the 
        second the path of the HTML report output file.*/
        public static void Main(string[] args)
        {
            //takes user input on what folder path to check
            Console.WriteLine("Enter path of the input folder: ");
            string input;
            input = Console.ReadLine();

            //calls for the files to be enumerated
            IEnumerable<string> files = EnumerateFilesRecursively(input);
            
            //creates output file
            XDocument report = CreateReport(files);

            //takes user input on where the output file should be place + the name of it
            Console.WriteLine("Enter path of the output file:");
            string output = Console.ReadLine();
            output = output + ".html"; //changes the user input to make it an .html extension
            report.Save(output);
        }
    }
}
