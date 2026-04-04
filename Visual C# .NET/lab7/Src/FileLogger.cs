using System;
using System.IO;

namespace Examination.Src
{
    public class FileLogger
    {
        private readonly string _filePath;

        public string FilePath => _filePath;

        public FileLogger(string filePath = "Log.txt")
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            _filePath = filePath;
        }

        public void LogWithDate(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Write(logEntry);
        }  

        public void Log(string message)
        {
            Write(message);
        }    

        private void Write(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, append: true))
                {
                    writer.WriteLine(message);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log file {_filePath}: {ex.Message}");
            }
        }
    }
}