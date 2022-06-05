namespace BankAccount.App
{
    internal static class Program
    {
        private static void Main()
        {
            using FS fs = new FS("newLog.log");
            Account.Error = CLI.ShowError;
            Account.Error += fs.ShowError;
            Account.Info = CLI.ShowInfo;
            Account.Info += fs.ShowInfo;
            Account.Success = CLI.ShowSuccess;
            Account.Success += fs.ShowSuccess;
            Console.Write("Do you want to open account? (Y/N - да): ");
            var choise = Console.ReadLine();
            if (choise != "Y" && choise != "y" && choise != "N" && choise != "n")
            {
                CLI.ShowInfo("Good bye ...");
                return;
            }
            Console.Write("How much money you have? - ");
            int.TryParse(Console.ReadLine(), out var initBalance);
            var account = new Account(initBalance);
            Console.WriteLine($"Your start balance {account.Balance}");
            int op;
            while (true)
            {
                Console.WriteLine("Enter 1: to add many , Enter 2 to pick many ; 3 to exit?: ");
                op = Convert.ToInt32(Console.ReadLine());

                if (op > 3 || op < 0)
                {
                    Console.Write("Enter again!: ");
                    op = Convert.ToInt32(Console.ReadLine());
                } 
                if (op == 3) break;

                switch (op)
                {
                    case 1:
                    {
                        Console.WriteLine("How much many you want to add? : ");
                        double many = Convert.ToInt32(Console.ReadLine()); 
                        account.Add(many);
                    }break;
                    case 2:
                    {
                        Console.WriteLine("How much many you want to pick? : ");
                        double many = Convert.ToInt32(Console.ReadLine()); 
                        account.Sub(many);
                    }break; 
                }
                CLI.ShowInfo(message:$"Your balance: {account.Balance}");
            }
            
            //TODO Дома дописать программу на реализацию внесения и снятия денег со счёта.
            //TODO Добавить запись в файл и прявязать её к делегатам Info, Error, Success
        }
    }
}