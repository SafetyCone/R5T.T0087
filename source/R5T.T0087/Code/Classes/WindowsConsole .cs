using System;
using System.IO;


namespace R5T.T0087
{
    // From: https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging.Console/Internal/WindowsLogConsole.cs
    public class WindowsConsole : IConsole
    {
        #region Static

        private static bool SetConsoleColor(ConsoleColor? background, ConsoleColor? foreground)
        {
            if (background.HasValue)
            {
                Console.BackgroundColor = background.Value;
            }

            if (foreground.HasValue)
            {
                Console.ForegroundColor = foreground.Value;
            }

            var colorWasSet = background.HasValue || foreground.HasValue;
            return colorWasSet;
        }

        private static void ResetColor()
        {
            Console.ResetColor();
        }

        private static void Write(Action action, ConsoleColor? background, ConsoleColor? foreground)
        {
            var colorWasChanged = WindowsConsole.SetConsoleColor(background, foreground);

            action();

            if (colorWasChanged)
            {
                WindowsConsole.ResetColor();
            }
        }

        #endregion


        private TextWriter TextWriter { get; }


        /// <inheritdoc />
        public WindowsConsole(bool useStandardError = false)
        {
            TextWriter = useStandardError
                ? Console.Error
                : Console.Out
                ;
        }

        public void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            WindowsConsole.Write(
                () => this.TextWriter.Write(message),
                background,
                foreground);
        }

        public void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            WindowsConsole.Write(
                 () => this.TextWriter.WriteLine(message),
                 background,
                 foreground);
        }

        public void Flush()
        {
            // No action required since every write sends data directly to the console output stream.
        }
    }
}