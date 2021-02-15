using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty, ans = "Y";
            int sum1 = 0, sum2 = 0;

            //input number
            Console.Write("Input your lucky ticket number!: ");
            input = Console.ReadLine();

            //catch if user not entered a value
            if(input == string.Empty)
            {
                Console.WriteLine("You not entered a number! Please, enter number of your lucky ticket!");
                Console.WriteLine("-------------------------------------------------------------");
                Main(args);
            }
            char[] number = input.ToCharArray();
            int[] digits = new int[number.Length];
            int[] newDigits = new int[number.Length + 1];

            //transfer from char array to integer array and prepend 0 if has odd number of digits 
            //catch if user entered a non-number symbols
            try
            {
                //if number of digits is not odd
                if (number.Length == 4 || number.Length == 6 || number.Length == 8)
                {
                    for (int i = 0; i < digits.Length; i++)
                    {
                        digits[i] = int.Parse(number[i].ToString());
                    }

                    //sum of first half and sum of second half
                    for (int i = 0; i < digits.Length / 2; i++)
                        sum1 += digits[i];
                    for (int i = digits.Length/2; i < digits.Length; i++)
                        sum2 += digits[i];
                }
                //if number of digits is odd
                else
                {
                    for (int i = 0; i < newDigits.Length; i++)
                    {
                        if (i == 0)
                            newDigits[i] = 0;
                        else
                            newDigits[i] = int.Parse(number[i - 1].ToString());
                    }

                    //sum of first half and sum of second half
                    for (int i = 0; i < newDigits.Length / 2; i++)
                        sum1 += newDigits[i];
                    for (int i = newDigits.Length/2; i < newDigits.Length; i++)
                        sum2 += newDigits[i];
                }
            }
            catch
            {
                Console.WriteLine("You not entered a number! Please, enter number of your lucky ticket!");
                Console.WriteLine("-------------------------------------------------------------");
                Main(args);
            }

            //----------------------FOR DEBUG-----------------------//
            //printAll(newDigits);
            //break;
            //-----------------------------------------------------//

            //output result
            if (sum1 == sum2)
                Console.WriteLine("You are really lucky! :)");
            else
                Console.WriteLine("Maybe another time. :(");

            Console.Write("Continue?(Y/N): ");
            ans = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------------");

            //check user's answer
            if (ans == "Y" || ans == "y")
                Main(args);
            else if (ans == string.Empty)
                Main(args);
            else
                Environment.Exit(0);
        }

        static void printAll(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
                Console.Write(arr[i]);
            Console.WriteLine();
        }
    }
}