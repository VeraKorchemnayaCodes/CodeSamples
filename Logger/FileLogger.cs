using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    private string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        FileStream stream = new(_filePath, FileMode.Append);
        StreamWriter writer = new(stream);
        writer.WriteLine($"{DateTime.Now} {ClassName} {logLevel}: {message}");
        writer.Dispose();
    }
}
