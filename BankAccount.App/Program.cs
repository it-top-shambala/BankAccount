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

            Console.WriteLine("Введите 1 если хотите добавить");
            Console.WriteLine("Введите 2 если хотите снять");
            Console.WriteLine("Введите 3 выйти");

            byte brushOperation;
            byte.TryParse(Console.ReadLine(), out brushOperation);

            switch (brushOperation)
            {
                case 1:
                    {
                        Console.WriteLine("Какую сумму хотите добавить?");
                        double addedMoney;
                        double.TryParse(Console.ReadLine(), out addedMoney);

                        account.Add(addedMoney);

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Какую сумму хотите снять?");
                        double withdrawableMoney;
                        double.TryParse(Console.ReadLine(),out withdrawableMoney);

                        account.Sub(withdrawableMoney);

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("До свидания");

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Неправельный выбор операции");

                        break;
                    }

            }

            CLI.ShowInfo(message: $"Баланс: {account.Balance}");

            //TODO Дома дописать программу на реализацию внесения и снятия денег со счёта.
            //TODO Добавить запись в файл и прявязать её к делегатам Info, Error, Success
        }
    }
}