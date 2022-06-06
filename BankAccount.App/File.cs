using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.App
{
    internal class File
    {
        public static void ShowFile(string message)
        {
            using (StreamWriter sw = new StreamWriter("Accaunt.csv", true, Encoding.Unicode))
            {
                sw.WriteLine(message);
            }
        }
    }
}
