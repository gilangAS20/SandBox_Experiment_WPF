using System;

namespace Compaer_Two_FolderPath
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Compare two folder Path \n\n");

            UserInput userInput = new UserInput();
            userInput.InputFT400FolderPath();
            //userInput.InputRI360FolderPath();
        }
    }
}