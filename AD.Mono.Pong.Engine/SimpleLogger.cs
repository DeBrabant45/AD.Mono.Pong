using System;
using System.IO;

namespace AD.Mono.Pong.Engine;

public static class SimpleLogger
{
    private static StreamWriter _logFile;

    static SimpleLogger()
    {
        _logFile = new StreamWriter("game_log.txt", true);
    }

    public static void Log(string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _logFile.WriteLine($"{timestamp}: {message}");
        _logFile.Flush();
    }

    public static void Close()
    {
        _logFile.Close();
    }
}