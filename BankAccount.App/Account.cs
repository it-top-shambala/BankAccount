namespace BankAccount.App;
/// <summary>
/// Сlass describing a bank account
/// Класс описывающий аккаут в банке
/// </summary>
public class Account
{
    
    private double _balance;
    /// <summary>
    /// Variable balance
    /// Переменная баланс
    /// </summary>
    public double Balance
    {
        get
        {
            Info?.Invoke($"{DateTime.Now} Запрошена сумма остатка счёта");
            return _balance;
        }
    }
    
    public static Action<string> Info;
    public static Action<string> Error;
    public static Action<string> Success;

    public static Action<string> InfoFile;
    public static Action<string> ErrorFile;
    public static Action<string> SuccessFile;

    /// <summary>
    /// Тhe constructor that creates the default account
    /// Конструктор создающий аккаунт по умолчанию 
    /// </summary>
    public Account()
    {
        _balance = 0;
        Success?.Invoke($"{DateTime.Now} Счёт успешно открыт!"); ;
    }
    /// <summary>
    /// Constructor with one parameter that creates an account
    /// Конструктор с одним параметром создающий аккаунт
    /// </summary>
    /// <param name="balance">Balanse(Баланс)</param>
    public Account(double balance)
    {
        _balance = balance;
        Success?.Invoke($"{DateTime.Now} Счёт успешно открыт!");
        SuccessFile?.Invoke("Счёт успешно открыт!");
    }

    public void Add(double sum)
    {
        if (sum < 0)
        {
            Error?.Invoke("Попытка добавить отрицательную сумму");
            ErrorFile?.Invoke("Попытка добавить отрицательную сумму");
        }
        else
        { 
            _balance += sum;
            Success?.Invoke($"{DateTime.Now} Добавлено {sum} денег");
            SuccessFile?.Invoke($"{DateTime.Now} Добавлено {sum} денег");
        }
        
    }

    public void Sub(double sum)
    {
        if (sum > _balance)
        {
            Error?.Invoke("Попытка снять больше денег, чем у вас есть");
            ErrorFile?.Invoke("Попытка снять больше денег, чем у вас есть");
        }
        else
        {
            _balance -= sum;
            Success?.Invoke($"{DateTime.Now} Снято {sum} денег");
            SuccessFile?.Invoke($"{DateTime.Now} Снято {sum} денег");
        }
    }
}