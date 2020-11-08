using System;
using System.IO;
using System.Xml.Linq;

class StaticFunctions
{
    static IEnumerable<string> EnumerateFilesRecursively(string path)
    /*Enumerate all files in a given folder recursively including the entire sub-folder 
    hierarchy. You can use System.IO.Directory. You could use the generator pattern (yield 
    keyword) to implement the iterator*/
    {
        /*IMPLEMENT HERE*/
    }

    static string FormatByteSize(long byteSize)
    /*Format a byte size in human readable form. Use the following units: B, kB, MB, GB, 
    TB, PB, EB, and ZB where 1kB = 1000B. The numerical value should be greater or equal 
    to 1, less than 1000 and formatted with 2 fixed digits after the decimal point, e.g. 
    1.30kB.*/
    {
        /*IMPLEMENT HERE*/   
    }

    static XDocument CreateReport(IEnumerable<string> files)
    /*Create a HTML document containing a table with three columns: “Type”, “Count”, and 
    “Size” for the file name extension (converted to lower case), the number of files with 
    this type, and the total size of all files with this type, respectively. You can use 
    System.IO.FileInfo to get the size of a file with a given path. Sort the table by the 
    byte size value of the “Size” column in descending order. Use your FormatByteSize function 
    to format the value printed in the “Size” column. Implement this function using LINQ 
    queries making use of group by and orderby. Use the System.Xml.Linq.XElement constructor 
    to functionally construct the XML document*/
    {
        /*IMPLEMENT HERE*/
    }

    public static void Main(string[] args)
    /*Take two command line arguments. The first value is the path of the input folder and the 
    second the path of the HTML report output file. Call the functions above to create the 
    report file.*/
    {
        /*IMPLEMENT HERE*/
    }
}