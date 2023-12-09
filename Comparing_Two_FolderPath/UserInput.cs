namespace Compaer_Two_FolderPath;

public class UserInput
{
    string ft400FolderPath;
    internal string InputFT400FolderPath()
    {
        Console.WriteLine("Input FT400 config folder: ");
        ft400FolderPath = Console.ReadLine();
        Console.WriteLine("Your FT400 folder input is: \n" + ft400FolderPath);

        InputRI360FolderPath(ft400FolderPath);

        return ft400FolderPath;
    }

    private string ri360FolderPath;
    internal string InputRI360FolderPath(string ft400)
    {
        bool checkResult;
        do
        {
            Console.WriteLine("\nInput folder path you want to save new configuration: ");
            ri360FolderPath = Console.ReadLine();
            checkResult = CheckSameFolderPath(ft400FolderPath, ri360FolderPath);
            
            /*
            if (checkResult)
            {
                Console.WriteLine("\nYour folder path choosen is same as FT400 config folder");
                Console.WriteLine("          Please input another folder path");
                checkResult;
            }
            */

        } while (checkResult);

        return ri360FolderPath;
    }

    internal bool CheckSameFolderPath(string ft400, string ri360)
    {
        bool result;

        result = ft400 == ri360 ? true : false;
        string warning = "\nYour folder path choosen is same as FT400 config folder" +
                         "\n          Please input another folder path";

        string success = "\n Congratulations!! your input different folder path" +
                         "\n Your Configuration will be saved";
        if (result)
        {
        Console.WriteLine(warning);
        }
        else
        {
         Console.WriteLine(success);   
        }
        return result;
    }
}