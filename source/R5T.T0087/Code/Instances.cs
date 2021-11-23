using System;

using R5T.T0088;
using R5T.T0089;


namespace R5T.T0087
{
    public static class Instances
    {
        public static IAnsiColorCode AnsiColorCode { get; } = T0089.AnsiColorCode.Instance;
        public static IConsoleOperator ConsoleOperator { get; } = T0088.ConsoleOperator.Instance;
    }
}
