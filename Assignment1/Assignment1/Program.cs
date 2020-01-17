using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //if ('1' > '2')
            //{
            //    Console.WriteLine("ddd");
            //}
            //else
            //{
            //    int a = '9';
            //    Console.WriteLine("ffff");
            //}

            //Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull("random string")); // null
            //Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull("159")); // null
            //Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull("0xFF34F")); // null
            //Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull("0b0110101011101011100000")); // 0b1001010100010100011111

            Console.WriteLine("0b0000111010110 ->" + BigNumberCalculator.GetTwosComplementOrNull("0b0000111010110")); // 0b1111000101010
            Console.WriteLine("0b1000 ->" + BigNumberCalculator.GetTwosComplementOrNull("0b1000")); // 0b1000

            Console.WriteLine("0b00001101011 ->" + BigNumberCalculator.ToBinaryOrNull("0b00001101011")); // 0b00001101011
            Console.WriteLine("0x00F24 ->" + BigNumberCalculator.ToBinaryOrNull("0x00F24")); // 0b00000000111100100100
            Console.WriteLine("123 ->" + BigNumberCalculator.ToBinaryOrNull("123")); // 0b01111011
            Console.WriteLine("-123 ->" + BigNumberCalculator.ToBinaryOrNull("-123")); // 0b10000101
        }
    }
}
