using System;
using System.Text;


namespace R5T.T0087
{
    public class AnsiConsole : IConsole
    {
        private StringBuilder OutputBuilder { get; } = new StringBuilder();
        private IBasicConsole BasicConsole { get; }


        public AnsiConsole(IBasicConsole basicConsole)
        {
            this.BasicConsole = basicConsole;
        }

        public AnsiConsole(bool useStandardError = false)
            : this(new BasicConsole(useStandardError))
        {
        }

        public void Flush()
        {
            this.BasicConsole.Write(this.OutputBuilder.ToString());
            this.OutputBuilder.Clear();
        }

        public void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            if(background.HasValue)
            {
                var colorEscapeCode = Instances.ConsoleOperator.GetAnsiBackgroundColorEscapeCode(background.Value);

                this.OutputBuilder.Append(colorEscapeCode);
            }

            if (foreground.HasValue)
            {
                var colorEscapeCode = Instances.ConsoleOperator.GetAnsiForegroundColorEscapeCode(background.Value);

                this.OutputBuilder.Append(colorEscapeCode);
            }

            this.OutputBuilder.Append(message);

            if(foreground.HasValue)
            {
                var defaultColorEscapeCode = Instances.AnsiColorCode.DefaultForeground();

                this.OutputBuilder.Append(defaultColorEscapeCode);
            }

            if (background.HasValue)
            {
                var defaultColorEscapeCode = Instances.AnsiColorCode.DefaultBackground();

                this.OutputBuilder.Append(defaultColorEscapeCode);
            }
        }

        public void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            this.Write(message, background, foreground);

            this.OutputBuilder.AppendLine();
        }
    }
}
