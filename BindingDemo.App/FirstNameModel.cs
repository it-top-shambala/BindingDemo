using System.IO;

namespace BindingDemo.App;

public static class FirstNameModel
{
    private const string FileName = "name.dat";

    public static void Export(string firstName)
    {
        using var file = new StreamWriter(FileName, false);
        file.WriteLine(firstName);
    }

    public static string Import()
    {
        using var file = new StreamReader(FileName);
        return file.ReadLine();
    }
}
