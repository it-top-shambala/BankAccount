namespace BankAccount.App;
/// <summary>
/// Класс описывающий аккаут в банке
/// </summary>
public class Account
{
    
    private double _balance;
    /// <summary>
    /// 
    /// </summary>
    public double Balance
    {
        get
        {
            Info?.Invoke("Запрошена сумма остатка счёта");
            return _balance;
        }
    }
    
    public static Action<string> Info;
    public static Action<string> Error;
    public static Action<string> Success;

    public static Action<string> InfoFile;
    public static Action<string> ErrorFile;
    public static Action<string> SuccessFile;

    public Account()
    {
        _balance = 0;
        Success?.Invoke("Счёт успешно открыт!");
    }
    public Account(double balance)
    {
        _balance = balance;
        Success?.Invoke("Счёт успешно открыт!");
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
            Success?.Invoke($"Добавлено {sum} денег");
            SuccessFile?.Invoke($"Добавлено {sum} денег");
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
            Success?.Invoke($"Снято {sum} денег");
            SuccessFile?.Invoke($"Снято {sum} денег");
        }
    }
}