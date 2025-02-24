using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Interfaces;

namespace Tic_Tac_Toe_v3.Services
{
    public class ConsoleService : IConsoleService
    {
        public void WriteLine(string message) => Console.WriteLine(message);

        public void Write(string message) => Console.Write(message);

        public string ReadLine()
        {
            try
            {
                return Console.ReadLine() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading input: {ex.Message}");
                return string.Empty;
            }
        }

        public void Clear() => Console.Clear();

        public void SetForegroundColor(ConsoleColor color) => Console.ForegroundColor = color;

        public void ResetColor() => Console.ResetColor();

        public void WriteLine() => Console.WriteLine();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
    }
}