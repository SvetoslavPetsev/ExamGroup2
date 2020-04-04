using System;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    class Program
    {
        static void Main()
        {
            Regex pattern = new Regex(@"^([@][#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])[@][#]+$");
            int countInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < countInput; i++)
            {
                string input = Console.ReadLine();
                Match matchedInput = pattern.Match(input);

                if (matchedInput.Success)
                {
                    string currBarcode = matchedInput.Groups["barcode"].Value;
                    string productGroup = string.Empty;
                    foreach (char symbol in currBarcode)
                    {
                        if (Char.IsDigit(symbol))
                        {
                            productGroup += symbol;
                        }
                    }
                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
