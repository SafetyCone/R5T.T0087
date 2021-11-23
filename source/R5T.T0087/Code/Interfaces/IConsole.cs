using System;


namespace R5T.T0087
{
    public interface IConsole
    {
        void Write(string message, ConsoleColor? background, ConsoleColor? foreground);
        void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground);
        void Flush();
    }
}