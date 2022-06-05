using System.Net;

namespace BankAccount.App;

public class FS : IDisposable   
{
    private readonly string _fileName;
    private StreamWriter _streamWriter;

    public FS(string fileName)
    {
        _fileName = fileName;
        _streamWriter = new StreamWriter(new FileStream(_fileName,FileMode.Create));
    }
    
    public void Show(string message)
    {
        _streamWriter.WriteLine(message);
    }
    
    public void ShowInfo(string message) => Show(message);
    public void ShowError(string message) => Show(message);
    public void ShowSuccess(string message) => Show(message);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    private void Dispose(bool disposing)
    {
            if (disposing) 
            {
                _streamWriter.Close();  
            }
        }
    }