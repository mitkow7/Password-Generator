using System.Text;

namespace PasswordGenerator
{
    internal class PasswordGenerator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Write a minimum length!");
                int minLength = int.Parse(Console.ReadLine());
                Console.WriteLine("Write a maximum length!");
                int maxLength = int.Parse(Console.ReadLine());

                string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                                      "abcdefghijklmnopqrstuvwxyz" +
                                      "\"!\\\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

                string generatedPassword = PasswordGenerate(minLength,maxLength, allowedChars);

                Console.WriteLine("Do you want to save the file?");
                string saveFileChoice = Console.ReadLine();

                if (saveFileChoice == "yes" || saveFileChoice == "Yes" || saveFileChoice == "y" || saveFileChoice == "YES")
                {
                    Console.WriteLine("Do u want to save your e-mail with your password?");
                    string saveEmailChoice = Console.ReadLine();

                    string email = "";
                    if (saveEmailChoice == "yes" || saveEmailChoice == "Yes" || saveEmailChoice == "y" || saveEmailChoice == "YES")
                    {
                        Console.WriteLine("Write your e-mail.");
                        email = Console.ReadLine();
                    }

                    Console.WriteLine("Write a file name.");
                    string fileName = Console.ReadLine();

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filePath = path + $"\\{fileName}.txt";

                    TextWriter tw = new StreamWriter($"{filePath}", true);

                    if (email.Length != 0)
                    {
                        tw.WriteLine($"E-mail: {email}");
                    }
                    tw.WriteLine($"Password: {generatedPassword}");
                    tw.WriteLine("");

                    tw.Close();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("Successful");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                }
                else if (saveFileChoice == "no" || saveFileChoice == "No" || saveFileChoice == "n" || saveFileChoice == "NO")
                {
                    Console.WriteLine();
                    Console.WriteLine("Okay!");
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!\nTry again!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    return;
                }

                Console.WriteLine("Generated Password:");
                Console.WriteLine(generatedPassword);

                Console.WriteLine();
                Console.WriteLine("Do u want to generate another password?");
                string continueChoice = Console.ReadLine();

                if (continueChoice == "yes" || continueChoice == "Yes" || continueChoice == "y" || continueChoice == "YES")
                {
                    Console.WriteLine();
                    continue;
                }
                else if (continueChoice == "no" || continueChoice == "No" || continueChoice == "n" || continueChoice == "NO")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using my generator!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!\nTry again!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    continue;
                }
            }
        }

        private static string PasswordGenerate(int minLength, int maxLength, string allowedChars)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            if (minLength > maxLength)
            {
                string err1 = "Error";
                return err1;
            }

            int rndIndex = rnd.Next(minLength, maxLength + 1);
            
            for (int i = 0; i < rndIndex; i++)
            {
                if (sb.Length == rndIndex)
                {
                    break;
                }

                int randomIndex = rnd.Next(0, allowedChars.Length);

                char randomChar = allowedChars[randomIndex];

                sb.Append(randomChar);
            }

            return sb.ToString();
        }
    }
}
