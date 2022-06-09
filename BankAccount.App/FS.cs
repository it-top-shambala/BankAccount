using System.Net;

namespace BankAccount.App;

public static class FS
{
    private static readonly string FileName = "test.log";
    public static void Show(string message)
    {
        using StreamWriter streamWriter = new StreamWriter(FileName, append: true);
        streamWriter.WriteLine(message);
    }
}