using System;
using System.Text;
using System.Linq;

namespace _01.Password_Reset
{
    class Program
    {
        static void Main()
        {
            string newPassword = string.Empty;
            string text = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Done")
            {

                string[] info = input.Split();
                string cmd = info[0];
                if (cmd == "TakeOdd")
                {
                    newPassword = string.Empty;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            newPassword += text[i];
                        }
                    }
                    Console.WriteLine(newPassword);
                }
                else if (cmd == "Cut")
                {
                    int index = int.Parse(info[1]);
                    int count = int.Parse(info[2]);

                    //string remove = newPassword.Substring(index, count);
                    newPassword = newPassword.Remove(index, count);
                    Console.WriteLine(newPassword);
                }
                else if (cmd == "Substitute")
                {
                    string substr = info[1];
                    string substit = info[2];

                    if (newPassword.Contains(substr))
                    {
                        newPassword = newPassword.Replace(substr, substit);
                        Console.WriteLine(newPassword);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {newPassword}");
        }
    }
}
