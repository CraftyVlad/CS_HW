using (StreamWriter sw = new StreamWriter("filePaths.txt"))
{
    sw.WriteLine("../../../TestFiles");
    sw.WriteLine("*.txt");
}

string[] paths = File.ReadAllLines("filePaths.txt");
string folderPath = paths[0];
string folderName = paths[1];

string[] files = Directory.GetFiles(folderPath, folderName);

foreach (string file in files)
{
    Console.WriteLine(file);
}