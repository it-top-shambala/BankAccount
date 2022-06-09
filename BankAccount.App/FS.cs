using System.Net;

namespace BankAccount.App;

public static class FS
{
    private static readonly string FileName = "test.log";
    public static void Show(string message)
    {
<<<<<<< HEAD
        using StreamWriter streamWriter = new StreamWriter(FileName, append: true);
        streamWriter.WriteLine(message);
=======
        _fileName = fileName;
        _streamWriter = new StreamWriter(_fileName, append: false);
>>>>>>> 9bea3e7a22fea028509d22dd5dd48ab5dcb2f39f
    }
}