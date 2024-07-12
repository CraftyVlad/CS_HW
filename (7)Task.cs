// ../../../TestFiles

Console.WriteLine("Enter folder path:");
string folderPath = Console.ReadLine()!;

if (Directory.Exists(folderPath))
{
    DisplayFolderContent(folderPath);
}
else
{
    Console.WriteLine("Folder doesnt exist.");
}

static void DisplayFolderContent(string folderPath)
{
    string[] files = Directory.GetFiles(folderPath);
    string[] subFolders = Directory.GetDirectories(folderPath);

    Console.WriteLine($"\nFiles in folder {folderPath}:");
    foreach (string file in files)
    {
        Console.WriteLine(Path.GetFileName(file));
    }

    Console.WriteLine($"\nSubfolders in folder {folderPath}:");
    foreach (string subFolder in subFolders)
    {
        Console.WriteLine(Path.GetFileName(subFolder));
        DisplayFolderContent(subFolder);
    }
}