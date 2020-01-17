using System;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public BigNumberCalculator(int bitCount, EMode mode)
        {
        }

        public static string GetOnesComplementOrNull(string num)
        {
            if (num.Contains("0b"))
            {
                CharEnumerator ch = num.Substring(2).GetEnumerator();
                string strBinary = "0b";

                while(ch.MoveNext())
                {
                    if (ch.Current.Equals('0'))
                    {
                        strBinary += "1";
                    }
                    else if (ch.Current.Equals('1'))
                    {
                        strBinary += "0";
                    }
                    else
                    {
                        return null;
                    }
                }

                return strBinary;
            }
            return null;
        }

        public static string GetTwosComplementOrNull(string num)
        {
            string strOnce = GetOnesComplementOrNull(num);

            if (strOnce.Length > 0)
            {
                char[] chArray = strOnce.ToCharArray();
                bool bAddOne = true;
                int index = chArray.Length - 1;

                while (index > 0)
                {
                    if (chArray[index].Equals('0'))
                    {
                        if (bAddOne)
                        {
                            chArray[index] = '1';
                            bAddOne = false;
                        }
                    }
                    else if (chArray[index].Equals('1'))
                    {
                        if (bAddOne)
                        {
                            chArray[index] = '0';
                            bAddOne = true;
                        }
                    }
                    else
                    {
                        return new string(chArray);
                    }

                    --index;
                }
            }
            return null;
        }

        public static string ToBinaryOrNull(string num)
        {
            if (num.Contains("0b"))
            {
                return num;
            }
            else if (num.Contains("0x"))
            {
                char[] chArray = num.ToCharArray();
                int index = chArray.Length - 1;
                string sBinary = "";

                while (index > 0)
                {
                    sBinary = HexToBinary(chArray[index]) + sBinary;

                    index--;
                }

                return "0b" + sBinary;
            }
            else
            {
                int number = Math.Abs(Int32.Parse(num));
                int pow = 0;
                bool first = true;
                string sbinary = "";

                while (true)
                {
                    if (first)
                    {
                        int value = (int)Math.Pow(2, pow);
                        if ((number - value) > 0)
                        {
                            pow++;
                        }
                        else
                        {
                            first = false;
                        }
                    }
                    else
                    {
                        int value = (int)Math.Pow(2, pow);
                        if ((number - value) >= 0)
                        {
                            number -= value;
                            
                            sbinary += "1";
                        }
                        else
                        {
                            sbinary += "0";
                        }

                        pow--;

                        if (number <= 0 || pow < 0)
                        {
                            break;
                        }
                    }
                }
                
                if (num.Contains('-'))
                {
                    sbinary = GetTwosComplementOrNull("0b" + sbinary);
                }
                else
                {
                    sbinary = "0b" + sbinary;
                }

                return sbinary;
            }
            return null;
        }

        public static string ToHexOrNull(string num)
        {
            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public static string HexToBinary(char hex)
        {
            if (hex.Equals('0'))
            {
                return "0000";
            }
            else if (hex.Equals('1'))
            {
                return "0001";
            }
            else if (hex.Equals('2'))
            {
                return "0010";
            }
            else if (hex.Equals('3'))
            {
                return "0011";
            }
            else if (hex.Equals('4'))
            {
                return "0100";
            }
            else if (hex.Equals('5'))
            {
                return "0101";
            }
            else if (hex.Equals('6'))
            {
                return "0110";
            }
            else if (hex.Equals('7'))
            {
                return "0111";
            }
            else if (hex.Equals('8'))
            {
                return "1000";
            }
            else if (hex.Equals('9'))
            {
                return "1001";
            }
            else if (hex.Equals('A'))
            {
                return "1010";
            }
            else if (hex.Equals('B'))
            {
                return "1011";
            }
            else if (hex.Equals('C'))
            {
                return "1100";
            }
            else if (hex.Equals('D'))
            {
                return "1101";
            }
            else if (hex.Equals('E'))
            {
                return "1110";
            }
            else if (hex.Equals('F'))
            {
                return "1111";
            }
            return null;
        }
    }
}