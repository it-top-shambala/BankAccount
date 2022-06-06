namespace BankAccount.App;

public static class CLI
{
    private static void Show(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void LogToFileAdd(double sum)
    {
        using StreamWriter file = new StreamWriter("notification.log", true);
        file.WriteLine($"Добавлено {sum} денег");

    }
    public static void LogToFileSub(double sum)
    {
        using StreamWriter file = new StreamWriter("notification.log", true);
        file.WriteLine($"Снято {sum} денег");

    }

    public static void ShowInfo(string message) => Show(message, ConsoleColor.Blue);
    public static void ShowError(string message) => Show(message, ConsoleColor.Red);
    public static void ShowSuccess(string message) => Show(message, ConsoleColor.Green);
}