using System.IO;

public class FileStreamDemo
{
    FileStream fs = null;
    public void CreateFile(string fileName)
    {
        StreamWriter sw = null;
        try{
        fs = new FileStream(fileName, FileAccess.Write, FileMode.Create);
        sw = new StreamWriter(fs);
        sw.WriteLine("This is Just a Samole File for File to Demo");
        }
        catch(FileNotFoundException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch(FileLoadException e)
        {
            System.Console.WriteLine(e.Message);
        }
        finally
        {
            sw.Close();
            fs.Close();
        }

    }
    public ReadFile(string FileName)
    {

    }
}