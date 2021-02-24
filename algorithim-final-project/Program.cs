using System;
using System.Collections.Generic;
using System.Text;

// Algorithms and Data Structures Final Project
// Maggie Dalke

namespace algorithim_final_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // QUESTION 1 
            Dictionary<int, int> myVendingMachine = new Dictionary<int, int>() { { 20, 5 }, { 10, 5 }, { 5, 10 }, { 2, 15 }, { 1, 15 } };

            Console.WriteLine("VENDING MACHINE \nThis vending machine accepts $1, $2, $5, $10, and $20 coins. \n");
            int price = priceOfItem();
            int amountPaid = amountPaidByUser();
            VendingMachine(myVendingMachine, price, amountPaid);

            while (!QuitVendingMachine())
            {
                Console.WriteLine("\nBUYING NEW ITEM FROM VENDING MACHINE\n");
                int price2 = priceOfItem();
                int amountPaid2 = amountPaidByUser();
                VendingMachine(myVendingMachine, price2, amountPaid2);
            }

            // QUESTION 2 TEST CASES
            Console.WriteLine("QUESTION TWO");
            string file1 = "RTFFFFYYUPPPEEeEUUU";
            string file2 = "M";
            string file3 = null;
            string file4 = "KDSL:::SDDDDDDDDDD";
            string file5 = "";
            string file6 = "WDSRCcfF@@@@@@KKSDSK";

            PrintFiles(file1);
            PrintFiles(file2);
            PrintFiles(file3);
            PrintFiles(file4);
            PrintFiles(file5);
            PrintFiles(file6);
        }

        //QUESTION 1 - VENDING MACHINE            

        static int validateNum(string input)
        {
            int validNum;

            while (!int.TryParse(input, out validNum))
            {
                Console.WriteLine("You did not enter a valid price, please enter a positive number.");
                input = Console.ReadLine();
            }

            while (validNum < 1)
            {
                Console.WriteLine("Please enter a positive Number.");
                validNum = validateNum(Console.ReadLine());
            }
            return validNum;
        }

        static int priceOfItem()
        {
            Console.WriteLine("Please enter the price of the item you want to purchase.");
            int ValidNum = validateNum(Console.ReadLine());
            return ValidNum;
        }

        static int amountPaidByUser()
        {
            Console.WriteLine("Please enter the amount you are putting into the machine.");
            int ValidNum = validateNum(Console.ReadLine());
            return ValidNum;
        }

        static Dictionary<int, int> VendingMachine(Dictionary<int, int> vendingMachine, int price, int paid)
        {
            int amountOwed = paid - price;
            Dictionary<int, int> change = new Dictionary<int, int>();
            int[] coinValues = new int[] { 20, 10, 5, 2, 1 };
            int coinIndex = 0;

            while (paid < price)
            {
                int outstandingBalance = price - paid;
                Console.WriteLine("You did not enter a sufficent amount of coins. you still owe ${0} \n", outstandingBalance);
                paid += amountPaidByUser();

                if (paid > price)
                {
                    amountOwed = Math.Abs(price - paid);
                    break;
                }
            }

            while (amountOwed > 0)
            {
                if (!(coinIndex < coinValues.Length))
                {
                    Console.WriteLine("Not enough change in machine. Returning your ${0}.", paid);
                    break;
                }

                int coinValue = coinValues[coinIndex];

                while (amountOwed >= coinValue && vendingMachine[coinValue] > 0)
                {
                    if (amountOwed >= coinValue && !change.ContainsKey(coinValue))
                    {
                        change.Add(coinValue, 1);
                    }
                    else
                    {
                        change[coinValue] += 1;
                    }
                    vendingMachine[coinValue] -= 1;
                    amountOwed -= coinValue;
                }
                coinIndex++;
            }

            if (change.Count == 0)
            {
                Console.WriteLine("Thank you, have a great day!");
            }
            else if (amountOwed == 0)
            {
                PrintChange(change);
                Console.WriteLine("Thank you, have a great day!");
            }

            return change;
        }

        static void PrintChange(Dictionary<int, int> dict)
        {
            Console.WriteLine("\nYour change is: ");
            foreach (KeyValuePair<int, int> item in dict)
            {
                string handleCoin = item.Value > 1 ? "coins" : "coin";
                Console.WriteLine("{0} - ${1} {2}.", item.Value, item.Key, handleCoin);
            }
        }

        static bool QuitVendingMachine()
        {
            bool quit = false;
            Console.WriteLine("\nWould you like to quit the program? \nPress \"q\" to quit or enter to continue with another purchase.");

            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                quit = true;
                Console.Clear();
            }
            return quit;
        }

        // QUESTION 2 - COMPRESS AND DECOMPRESS A FILE.

        static string compressFile(string file)
        {
            string validFile = file.ToUpper();

            StringBuilder compressedFile = new StringBuilder("");
            int charIndex = 0;
            char character;

            while (charIndex < validFile.Length)
            {
                character = validFile[charIndex];

                if (charIndex >= file.Length - 2)
                {
                    compressedFile.Append(validFile[charIndex]);
                    charIndex++;
                    continue;
                }

                if (character != validFile[charIndex + 2])
                {
                    compressedFile.Append(character);
                }

                if (character == validFile[charIndex + 1] && character == validFile[charIndex + 2])
                {
                    int counter = 1;

                    while (character == validFile[charIndex + 1])
                    {
                        counter++;
                        charIndex++;
                        if (charIndex == validFile.Length - 1)
                        {
                            break;
                        }
                    }
                    compressedFile.Append(character);
                    compressedFile.Append(counter);
                }
                charIndex++;
            }
            return compressedFile.ToString();
        }

        static string decompressFile(string file)
        {

            StringBuilder decompressedFile = new StringBuilder("");
            int charIndex = 0;
            char character;

            while (charIndex < file.Length)
            {
                character = file[charIndex];

                if (Char.IsDigit(character))
                {
                    double characterCount = Char.GetNumericValue(character);

                    while (characterCount > 2)
                    {
                        decompressedFile.Append(file[charIndex - 1]);
                        characterCount--;
                    }
                    decompressedFile.Append(file[charIndex - 1]);
                }
                else
                {
                    decompressedFile.Append(character);
                }
                charIndex++;
            }
            return decompressedFile.ToString();
        }

        static void PrintFiles(string file)
        {
            Console.WriteLine("\nORIGINAL FILE: \"{0}\"", file);
            if (file == null || file.Length == 0)
            {
                Console.WriteLine("ERROR: INVALID FILE NAME", file);
            }
            else
            {
                string compressed = compressFile(file);
                string decompressed = decompressFile(compressFile(file));
                Console.WriteLine("Compressed File: {0} \nDecompressed File: {1}", compressed, decompressed);
            }            
        }

    }
}
