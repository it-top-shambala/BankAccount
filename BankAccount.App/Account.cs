namespace BankAccount.App;

public class Account
{
    private double _balance;
    private static bool _availability = false;
    
    public static bool Availability
    {
        get => _availability;
    }
    
    public double Balance
    {
        get
        {
            Info?.Invoke("Запрошенная сумма остатка счета");
            return _balance;
        }
    }

    static public Action<string> Info;
    static public Action<string> Error;
    static public Action<string> Success;

    public Account()
    {
        _availability = true;
        _balance = 0;
        Success?.Invoke($"Счет успешно открыт!");
    }

    public Account(double balance)
    {
        _availability = true;
        _balance = balance;
    }

    public void Add(double sum)
    {
        if (sum < 0)
        {
            Error?.Invoke("Попытка добавть отрицательную сумму на счет");
        }
        else
        {
            _balance += sum;
            Success?.Invoke($"Зачисленно {sum} денег");
        }
    }

    public void Sub(double sum)
    {
        if (sum > _balance)
        {
            sum = 0;
            Error?.Invoke("Сумма превышает баланс");
        }
        else
        {
            _balance -= sum;
            Success?.Invoke($"Списанно {sum} денег");
        }
    }

}