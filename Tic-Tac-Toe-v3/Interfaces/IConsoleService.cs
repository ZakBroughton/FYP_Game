using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_v3.Interfaces
{
    /// <summary>
    /// Provides methods for interacting with the console.
    /// </summary>
    public interface IConsoleService
    {
        /// <summary>
        /// Writes the specified message to the console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        void WriteLine(string message);

        /// <summary>
        /// Writes the specified message to the console without a newline character.
        /// </summary>
        /// <param name="message">The message to write.</param>
        void Write(string message);

        /// <summary>
        /// Reads a line of characters from the console.
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if the end of the input stream is reached.</returns>
        string ReadLine();

        /// <summary>
        /// Clears the console buffer and corresponding console window of display information.
        /// </summary>
        void Clear();

        /// <summary>
        /// Sets the foreground color of the console.
        /// </summary>
        /// <param name="color">The color to set.</param>
        void SetForegroundColor(ConsoleColor color);

        /// <summary>
        /// Resets the console color to its default value.
        /// </summary>
        void ResetColor();

        /// <summary>
        /// Writes a newline character to the console.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Obtains the next character or function key pressed by the user.
        /// </summary>
        /// <returns>An object that describes the <see cref="ConsoleKey"/> constant and Unicode character, if any, that correspond to the pressed console key.</returns>
        ConsoleKeyInfo ReadKey();



    }
}