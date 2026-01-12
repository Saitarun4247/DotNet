using System;
public class DirectoryDemo
{
    public void DirectoryDemoFunc(string directoryName)
    {
        if(Directory.Exists(directoryName))
        {
            System.Console.WriteLine("Folder already exists.");
        }
        else
        {
            Directory.CreateDirectory(directoryName);
            System.Console.WriteLine("Folder created successfully.");
        }
    }

    public void DriveInfoFunc(string driveName)
    {
        DriveInfo dInfo = new DriveInfo(driveName);
        System.Console.WriteLine($"Drive Name: {dInfo.Name}");
        System.Console.WriteLine($"Drive FileSystem: {dInfo.DriveType}");
        System.Console.WriteLine($"Drive Size:  {dInfo.TotalSize}");
        System.Console.WriteLine($"Drive FreeSpace:  {dInfo.AvailableFreeSpace}");
    }

    public void PathDemo()
    {
        string s =  @"C:\temp\MyData.text\machine.config\Alok\Dummy.Data\ABC.cs";
        System.Console.WriteLine(Path.GetFileName(s));
        System.Console.WriteLine(Path.GetTempPath());
    }

    public void ReafFile(string fileName)
    {
        fs = new FileStream(fileName,FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        System.Console.WriteLLine(sr.ReadToEnd());
        sr.Close();
        fs.Close();

    }
}