using System;
using System.IO;


namespace R5T.T0087
{
    public class BasicConsole : IBasicConsole
    {
        private TextWriter TextWriter { get; }


        /// <inheritdoc />
        public BasicConsole(bool useStandardError = false)
        {
            this.TextWriter = useStandardError
                ? Console.Error
                : Console.Out
                ;
        }

        public void Write(string message)
        {
            this.TextWriter.Write(message);
        }

        public void WriteLine(string message)
        {
            this.TextWriter.WriteLine(message);
        }
    }
}
