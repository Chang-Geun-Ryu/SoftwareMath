using System;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // D01_Invalid Input Format
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-0") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0101") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0023") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("--11") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("00000000") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("+11") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0xx0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("    ") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull(null) == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("  24aA1  ") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull(" 123 3VXCa  ") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0bAA") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("KJDSLF:N(&#") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("#$@#$@#$") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("SER#$V@$V") == null);
            // D03_Decimal Input : Decimal -> Binary
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-3") == "0b101");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("123"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("123") == "0b01111011");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-123"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-123") == "0b10000101");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("0"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0") == "0b0");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("10"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("10") == "0b01010");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("100"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("100") == "0b01100100");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("1000"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("1000") == "0b01111101000");

            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("10000") == "0b010011100010000");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-13579"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-13579") == "0b100101011110101");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-135799753113579"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-135799753113579") == "0b100001000111110110100111111101001000000000010101");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775808")); // long.minvalue
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775808") == "0b1000000000000000000000000000000000000000000000000000000000000000");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775809"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775809") == "0b10111111111111111111111111111111111111111111111111111111111111111");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775810"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775810") == "0b10111111111111111111111111111111111111111111111111111111111111110");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull(int.MaxValue.ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull((int.MinValue + 1).ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull(int.MinValue.ToString())}");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            for (long i = -1; i < 1; ++i)
            {
                Console.WriteLine(i);
                string binary = Convert.ToString(i, 2);
                binary = binary.Insert(0, "0b");
                Console.WriteLine($"std : {binary}");
                Console.WriteLine($"{i} : {BigNumberCalculator.ToBinaryOrNull(i.ToString())}");
                long number = i - i - i;
                Console.WriteLine($"{number} : {BigNumberCalculator.ToBinaryOrNull(number.ToString())}");
                Console.WriteLine();
            }



            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("as89fdf0") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0xFAKEHEX") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0bFAKEBINARY") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("FAKEDECIMAL") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0x") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("    ") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("-") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("-10") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0xFC34") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b0000111010110") == "0b1111000101001");
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b1000") == "0b0111");
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b0110101011101011100000") == "0b1001010100010100011111");

            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b0000111010110") == "0b1111000101010");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b1000") == "0b1000");

            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b00001101011") == "0b00001101011");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0x00F24") == "0b00000000111100100100");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("123") == "0b01111011");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-123") == "0b10000101");

            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("-144") == "-144");
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("0x443FF") == "279551");
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("0x843FF") == "-506881");
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("0x843FF66FFCDDCDDDCDFFF") == "-9350296660948911804063745");
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("0b011110001111010101011") == "990891");
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("0b11110000") == "-16");

            Debug.Assert(BigNumberCalculator.ToHexOrNull("-155555551") == "0xF6BA6921");
            Debug.Assert(BigNumberCalculator.ToHexOrNull("5258") == "0x148A");
            Debug.Assert(BigNumberCalculator.ToHexOrNull("0x53ABC") == "0x53ABC");
            Debug.Assert(BigNumberCalculator.ToHexOrNull("0b110001001") == "0xF89");
            Debug.Assert(BigNumberCalculator.ToHexOrNull("0b000000110001001") == "0x0189");

            bool bOverflow;
            string ss = "";
            BigNumberCalculator calc1 = new BigNumberCalculator(8, EMode.Decimal);

            ss = calc1.AddOrNull("127", "-45", out bOverflow); // 82, bOverflow: false
            Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            ss = calc1.AddOrNull("128", "-45", out bOverflow); // null, bOverflow: false
            Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            ss = calc1.AddOrNull("120", "17", out bOverflow); // -119, bOverflow: true
            Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            ss = calc1.AddOrNull("-127", "-2", out bOverflow); // 127, bOverflow: true
            Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");

            //BigNumberCalculator calc2 = new BigNumberCalculator(8, EMode.Binary);

            //ss = calc2.AddOrNull("127", "-45", out bOverflow); // 0b01010010, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc2.AddOrNull("0b10000000", "0x6", out bOverflow); // 0b10000110, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc2.AddOrNull("0b01111", "0b11", out bOverflow); // 0b00001110, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc2.AddOrNull("50", "0b0110", out bOverflow); // 0b00111000, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");

            //BigNumberCalculator calc3 = new BigNumberCalculator(8, EMode.Decimal);

            //ss = calc3.SubtractOrNull("25", "52", out bOverflow); // -27, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc3.SubtractOrNull("0b100110", "-12", out bOverflow); // -14, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc3.SubtractOrNull("0b0001101", "10", out bOverflow); // 3, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");

            //BigNumberCalculator calc4 = new BigNumberCalculator(8, EMode.Binary);

            //ss = calc4.SubtractOrNull("25", "52", out bOverflow); // 0b11100101, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc4.SubtractOrNull("0b100110", "-12", out bOverflow); // 0b11110010, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");
            //ss = calc4.SubtractOrNull("0b0001101", "10", out bOverflow); // 0b00000011, bOverflow: false
            //Console.WriteLine($"num : {ss}, bOverflow: {bOverflow}");

            AddOrNullTest();
        }

        static void AddOrNullTest()
        {
            bool bOverflow = false;

            /********************************* Binary Test ***********************************/

            BigNumberCalculator calc1 = new BigNumberCalculator(8, EMode.Binary);

            //// AddOrNull test
            Debug.Assert(calc1.AddOrNull("127", "0", out bOverflow) == "0b01111111");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("-128", "0", out bOverflow) == "0b10000000");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("-64", "-65", out bOverflow) == "0b01111111");
            Debug.Assert(bOverflow);
            Debug.Assert(calc1.AddOrNull("64", "64", out bOverflow) == "0b10000000");
            Debug.Assert(bOverflow);
            Debug.Assert(calc1.AddOrNull("64", "63", out bOverflow) == "0b01111111");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("1", "-1", out bOverflow) == "0b00000000");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("1", "0xFF", out bOverflow) == "0b00000000");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("0b1", "0b11111111", out bOverflow) == "0b11111110");
            Debug.Assert(!bOverflow);

            // SubtractOrNull test
            Debug.Assert(calc1.SubtractOrNull("1", "-1", out bOverflow) == "0b00000010");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.SubtractOrNull("0b11", "0b0001", out bOverflow) == "0b11111110");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.SubtractOrNull("0b10000000", "0b10000000", out bOverflow) == "0b00000000");
            Debug.Assert(bOverflow);
            /********************************* Binary Test ***********************************/




            /********************************* Decimal Test *********************************/
            // Decimal Calculator test
            calc1 = new BigNumberCalculator(8, EMode.Decimal);

            // AddOrNull test
            Debug.Assert(calc1.AddOrNull("127", "0", out bOverflow) == "127");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("-128", "0", out bOverflow) == "-128");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("-64", "-65", out bOverflow) == "127");
            Debug.Assert(bOverflow);
            Debug.Assert(calc1.AddOrNull("64", "64", out bOverflow) == "-128");
            Debug.Assert(bOverflow);
            Debug.Assert(calc1.AddOrNull("64", "63", out bOverflow) == "127");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("1", "-1", out bOverflow) == "0");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("1", "0xFF", out bOverflow) == "0");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("0b1", "0b11111111", out bOverflow) == "-2");
            Debug.Assert(!bOverflow);

            // SubtractOrNull test
            Debug.Assert(calc1.SubtractOrNull("0b11", "0b0001", out bOverflow) == "-2");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.SubtractOrNull("1", "-1", out bOverflow) == "2");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.SubtractOrNull("0b10000000", "0b10000000", out bOverflow) == "0");
            Debug.Assert(bOverflow);
            /********************************* Decimal Test *********************************/

        }

    }

}
//if (chArray[index].Equals('0'))
//{
//    if (bAddOne)
//    {
//        chArray[index] = '1';
//        bAddOne = false;
//    }
//}
//else if (chArray[index].Equals('1'))
//{
//    if (bAddOne)
//    {
//        chArray[index] = '0';
//        bAddOne = true;
//    }
//}
//else
//{
//    return new string (chArray);
//}

//if (nTemp >= nDivisor)
//                {
//                    int nQuotient = nTemp / nDivisor;
//int nRemainder = nTemp % nDivisor;

//nTemp = nRemainder* 10;
//                }
//                else
//                {
//                    nTemp = nTemp* 10;
//                }