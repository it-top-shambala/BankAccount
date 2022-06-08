namespace BankAccount.App
{
    internal static class Program
    {
        private static void Main()
        {
            Account.Error = CLI.ShowError;
            Account.Info = CLI.ShowInfo;
            Account.Success = CLI.ShowSuccess;
            Account.SuccessFile = File.RecToFileSuccess;
            Account.ErrorFile = File.RecToFileError;
            Account.InfoFile = File.RecToFileInfo;
            Console.Write("Хотите открыть счёт? (Y/Д - да): ");
            var choise = Console.ReadLine();

            if (choise != "Y" && choise != "y" && choise != "Д" && choise != "д")
            {
                CLI.ShowInfo("До свидания ...");
                return;
            }
            Console.WriteLine("Введите номер счета : ");
            string payment = Console.ReadLine();
            Console.Write("Сколько денег хотите положить при открытии счёта? - ");
            int.TryParse(Console.ReadLine(), out var initBalance);
            var account = new Account(initBalance, payment);
            Console.WriteLine(account.Balance);

            int key;
            string str;
            do
            {
                Console.WriteLine("\t\tДействия:\n"
                    + "1.Внести наличнвые.\n"
                    + "2.Снять наличные\n"
                    + "3.Баланс\n"
                    + "4.\n"
                    + "0.Exit");
                int.TryParse(Console.ReadLine(), out key);
                switch (key)
                {
                    case 1:                       
                        Console.Write("Введите сумму денег: ");
                        str = Console.ReadLine();
                        account.Add(double.Parse(str));
                        break;
                    case 2:
                        Console.WriteLine(("Введите сумму денег: "));
                        str = Console.ReadLine();
                        account.Sub(double.Parse(str));
                        break;
                    case 3:
                        
                        Console.WriteLine(account.Balance);
                        break;
                }
            } while (key != 0);

            //TODO Дома дописать программу на реализацию внесения и снятия денег со счёта.
            //TODO Добавить запись в файл и прявязать её к делегатам Info, Error, Success


        }
    }
}