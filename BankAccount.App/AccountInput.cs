using System.Diagnostics.CodeAnalysis;
using static System.Console;
namespace BankAccount.App;

public class AccountInput
{
    private Account account;
    public void Start()
    {
        Account.Info = CLI.ShowInfo;
        Account.Info += WriteToFile;
        Account.Error = CLI.ShowError;
        Account.Error += WriteToFile;
        Account.Success = CLI.ShowSuccess;
        Account.Success += WriteToFile;
        
        RunMainMenu();
    }

    private void WriteToFile(string message)
    {
        using StreamWriter writer = new StreamWriter("file.txt", true);
        writer.WriteLine(message);
    }

    private void RunMainMenu()
    {
        string promt = @"


      ██████╗  █████╗ ███╗   ██╗██╗  ██╗     █████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███╗   ██╗████████╗
    ██╔══██╗██╔══██╗████╗  ██║██║ ██╔╝    ██╔══██╗██╔════╝██╔════╝██╔═══██╗██║   ██║████╗  ██║╚══██╔══╝
    ██████╔╝███████║██╔██╗ ██║█████╔╝     ███████║██║     ██║     ██║   ██║██║   ██║██╔██╗ ██║   ██║   
    ██╔══██╗██╔══██║██║╚██╗██║██╔═██╗     ██╔══██║██║     ██║     ██║   ██║██║   ██║██║╚██╗██║   ██║   
    ██████╔╝██║  ██║██║ ╚████║██║  ██╗    ██║  ██║╚██████╗╚██████╗╚██████╔╝╚██████╔╝██║ ╚████║   ██║   
    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝    ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   
                                                                                                       
    Добро пожаловать в банк. Что бы вы хотели сделать?
    (Используйте стрелки для навигации и Enter для выбора операции.)
    ";
        string[] options = { "Создать аккаунт", "Управление средствами", "Выход" };    
        Menu MainMenu = new Menu(promt, options);
        int selectedIndex = MainMenu.Run();
        
        switch (selectedIndex)
        {
            case 0:
                CreateAccMenu();
                break;
            case 1:
                ControlMenu();
                break;
            case 3:
                ExitMenu();
                break;
            
        }
    }


    private void Add()
    {
        Clear();
        WriteLine("Введите сумму зачисления.");
        double sum = double.Parse(ReadLine());
        account.Add(sum);
        ReadKey(true);
        ControlMenu();
    }

    private void Sub()
    {
        Clear();
        WriteLine("Введите сумму списания.");
        double sum = double.Parse(ReadLine());
        account.Sub(sum);
        ReadKey(true);
        ControlMenu();
    }
    private void ShowBalance()
    {
        Clear();
        WriteLine($"Баланс составляет {account.Balance} рублей");
        ReadKey(true);
        ControlMenu();
    }

    private void CreateAcc()
    {
        Clear();
        if (account != null)
        {
            WriteLine("Аккаун уже создан!");
            ReadKey(true);
            RunMainMenu();
        }
        account = new Account(); 
        ReadKey(true);
        RunMainMenu();
    }


    private void CreateAccMenu()
    {
        Clear();
        string promtCAM = "Вы подтверждаете создание счета?";
        string[] optionsCAM = { "Да", "Нет" };
        Menu camMenu = new Menu(promtCAM, optionsCAM);
        int selectedIndexCAM = camMenu.Run();

        switch (selectedIndexCAM)
        {
            case 0:
                CreateAcc();
                break;
            case 1:
                RunMainMenu();
                break;
        }
    }

    public void ControlMenu()
    {
        Clear();
        Clear();
        if (account == null)
        {
            WriteLine("Аккаунт не создан!");
            ReadKey(true);
            RunMainMenu();
        }

        string promtCM = "Выберите нужную операцию.";
        string[] optionsCM = { "Пополнить баланс", "Снять со счета", "Узнать баланс", "Назад" };
        Menu cmMenu = new Menu(promtCM, optionsCM);
        int selectedIndexCM = cmMenu.Run();

        switch (selectedIndexCM)
        {
            case 0:
                Add();
                break;
            case 1:
                Sub();
                break;
            case 2:
                ShowBalance();
                break;
            case 3:
                RunMainMenu();
                break;
        }
    }
    
    private void ExitMenu()
    {
        Clear();
        string promtEM = "Вы действительно хотите выйти?";
        string[] optionsEM = { "Да", "Нет" };
        Menu emMenu = new Menu(promtEM, optionsEM);
        int selecteIndexEM = emMenu.Run();

        switch (selecteIndexEM)
        {
            case 0:
                Clear();
                Environment.Exit(0);
                break;
            case 1:
                RunMainMenu();
                break;
        }

    }
}
