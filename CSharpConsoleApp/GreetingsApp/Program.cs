using DisplayApp;
using UtilityApp;

namespace GreetingsApp
{
    /// <summary>
    /// Program is the entry class of the application.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Terminator terminator = new Terminator();
            ConsoleWriter consoleWriter = new ConsoleWriter();
            Greet greet = new Greet();
            consoleWriter.WriteColored($"{greet.MorningGreet("MockName")}\n", ConsoleColor.Green);
            consoleWriter.WriteColored($"{greet.AfternoonGreet("MockName")}\n", ConsoleColor.Blue);
            consoleWriter.WriteColored($"{greet.EveningGreet("MockName")}\n", ConsoleColor.Yellow);
            consoleWriter.WriteColored($"{greet.NightGreet("MockName")}\n", ConsoleColor.DarkGray);
            terminator.Terminate();
        }
    }
}