using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.App
{
    internal class File
    {
        private readonly string _fileName;
        private StreamWriter _streamWriter;

        public static void ShowInfo(string message)
        {
            CLI.ShowInfo(message);
        }

        public static void ShowError(string message)
        {
            CLI.ShowError(message);
        }

        public static void ShowSuccess(string massage)
        {
            CLI.ShowSuccess(massage);
        }
    }
}
