

namespace BankAccount.App
{
    internal class File
    {
        private readonly string _fileName;
        private StreamWriter _streamWriter;

        //public static void ShowInfo(string message)
        //{
        //    CLI.ShowInfo(message);
        //}

        public static void ShowError(string message)
        {
            CLI.ShowError(message);
        }

        public static void ShowSuccess(string massage)
        {
            CLI.ShowSuccess(massage);
        }

        public File(string fileName)
        {
            _fileName = fileName;
            _streamWriter = new StreamWriter(new FileStream(_fileName, FileMode.Create));
        }

        public async void AddingToFile( string message)
        {
           _streamWriter.Write(message);
            _streamWriter.Close();
        }
    }
}