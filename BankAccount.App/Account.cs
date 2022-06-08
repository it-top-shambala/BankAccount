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
            Info?.Invoke($"{DateTime.Now} Запрошена сумма остатка счёта №{_paymentAccount}");
            InfoFile?.Invoke($"{DateTime.Now} Запрошена сумма остатка счёта №{_paymentAccount}", _paymentAccount + "Info.txt");
            return _balance;
        }
    }
    private string _paymentAccount;
    /// <summary>
    /// Payment account
    /// Расчетный счет
    /// </summary>
    public string PaymentAccount { get { return _paymentAccount; } }
    
    public static Action<string> Info;
    public static Action<string> Error;
    public static Action<string> Success;

    public static Action<string, string> InfoFile;
    public static Action<string, string> ErrorFile;
    public static Action<string, string> SuccessFile;

    /// <summary>
    /// Тhe constructor that creates the default account
    /// Конструктор создающий аккаунт по умолчанию 
    /// </summary>
    public Account()
    {
        _paymentAccount = "";
        _balance = 0;
        Success?.Invoke($"{DateTime.Now} Счёт №{_paymentAccount} успешно открыт!");
        SuccessFile?.Invoke($"{DateTime.Now} Счёт №{_paymentAccount} успешно открыт!", _paymentAccount + "Success.txt");
    }
    /// <summary>
    /// Constructor with one parameter that creates an account
    /// Конструктор с одним параметром создающий аккаунт
    /// </summary>
    /// <param name="balance">Balanse (Баланс)</param>
    /// <param name="playmentAccount">Payment account (Расчетный счет)</param>
    public Account(double balance, string playmentAccount)
    {
        _paymentAccount = playmentAccount;
        _balance = balance;
        Success?.Invoke($"{DateTime.Now} Счёт {_paymentAccount} успешно открыт!");
        SuccessFile?.Invoke($"{DateTime.Now} Счёт {_paymentAccount} успешно открыт!", _paymentAccount + "Success.txt");
    }

    public void Add(double sum)
    {
        if (sum < 0)
        {
            Error?.Invoke("Попытка добавить отрицательную сумму");
            ErrorFile?.Invoke("Попытка добавить отрицательную сумму", _paymentAccount + "Error.txt");
        }
        else
        { 
            _balance += sum;
            Success?.Invoke($"{DateTime.Now} Добавлено {sum} денег");
            SuccessFile?.Invoke($"{DateTime.Now} Добавлено {sum} денег", _paymentAccount + "Success.txt");
        }
        
    }

    public void Sub(double sum)
    {
        if (sum > _balance)
        {
            Error?.Invoke("Попытка снять больше денег, чем у вас есть");
            ErrorFile?.Invoke("Попытка снять больше денег, чем у вас есть", _paymentAccount + "Error.txt");
        }
        else
        {
            _balance -= sum;
            Success?.Invoke($"{DateTime.Now} Снято {sum} денег");
            SuccessFile?.Invoke($"{DateTime.Now} Снято {sum} денег", _paymentAccount + "Success.txt");
        }
    }
}