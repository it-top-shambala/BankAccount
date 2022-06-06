namespace BankAccount.App
{
    internal static class Program
    {
        private static void Main()
        {
            Account.Error = CLI.ShowError;
            Account.Info = CLI.ShowInfo;
            Account.Success = CLI.ShowSuccess;
            
            Console.Write("Хотите открыть счёт? (Y/Д - да): ");
            var choise = Console.ReadLine();

            if (choise != "Y" && choise != "y" && choise != "Д" && choise != "д")
            {
                CLI.ShowInfo("До свидания ...");
                return;
            }

            Console.Write("Сколько денег хотите положить при открытии счёта? - ");
            int.TryParse(Console.ReadLine(), out var initBalance);
            var account = new Account(initBalance);
            Console.WriteLine(account.Balance);

            account.Add(2000);
            Console.WriteLine(account.Balance);

            //TODO Дома дописать программу на реализацию внесения и снятия денег со счёта.
            //TODO Добавить запись в файл и прявязать её к делегатам Info, Error, Success
        }
    }
}