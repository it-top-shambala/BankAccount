namespace BankAccount.App
{
    internal static class Program
    {
        private static void Main()
        {
            Account.Error = CLI.ShowError;
            Account.Info = CLI.ShowInfo;
            Account.Success = CLI.ShowSuccess;

            Account.Info += LogToFile;
            Account.Error += LogToFile;
            Account.Success += LogToFile;

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

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Если хотите снять деньги со счета, введите 1.");
                Console.WriteLine("Если хотите положить деньги на счет, введите 2.");
                Console.WriteLine("Если хотите посмотреть остаток на счете, введите 3.");
                Console.WriteLine("Если хотите закончить сессию, введите 0.");

                int.TryParse(Console.ReadLine(), out var userInput);
                double amount = 0.0;
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Сколько денег хотите снять?");
                        double.TryParse(Console.ReadLine(), out amount);
                        account.Sub(amount);
                        break;
                    case 2:
                        Console.WriteLine("Сколько денег хотите положить?");
                        double.TryParse(Console.ReadLine(), out amount);
                        account.Add(amount);
                        break;
                    case 3:
                        Console.WriteLine($"Ваш баланс: {account.Balance}");
                        break;
                    case 0:
                        Console.WriteLine("Сессия завершена");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод! Повторите попытку.");
                        break;
                }

            }


            //TODO Дома дописать программу на реализацию внесения и снятия денег со счёта.
            //TODO Добавить запись в файл и прявязать её к делегатам Info, Error, Success

        }

        static void LogToFile(string message)
        {
            using StreamWriter file = new StreamWriter(path: "account.log", append: true);
            file.WriteLine(message);
            file.Close();
        }

    }
}