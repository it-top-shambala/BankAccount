using static System.Console;
namespace BankAccount.App;

public class Menu
{
    private int _selectedIndex;
    private string _promt;
    private string[] _options;

    public Menu(string promt, string[] options)
    {
        _promt = promt;
        _options = options;
    }

    private void DisplayInfo()
    {
        WriteLine(_promt);
        for (int i = 0; i < _options.Length; i++)
        {
            string currentOption = _options[i];
            string prefix;
            if (i == _selectedIndex)
            {
                prefix = "*";
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                prefix = " ";
                ResetColor();
            }
            WriteLine($"{prefix} << {currentOption} >>");
        }
        ResetColor();
    }

    public int Run()
    {
        ConsoleKey keyPass;
        do
        {
            Clear();
            DisplayInfo();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPass = keyInfo.Key;

            if (keyPass == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex == -1)
                {
                    _selectedIndex = 0 ;
                }
            }
            else if (keyPass == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex == _options.Length)
                {
                    _selectedIndex = _options.Length - 1;
                }
            }

        } while (keyPass != ConsoleKey.Enter);
        return _selectedIndex;
    }
}