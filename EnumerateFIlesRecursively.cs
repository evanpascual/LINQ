/* Temporary separate file for notes/testing 
of EnumerateFilesRecursively function
*/

// code found on StackOverflow from 2013, will look more into this
IEnumerable<string> Search(string sDir)
{
    foreach (var file in Directory.GetFiles(sDir))
    {
        yield return file;                
    }

    foreach (var directory in Directory.GetDirectories(sDir))
    {
        foreach(var file in Search(directory))
            yield return file;
    }
}