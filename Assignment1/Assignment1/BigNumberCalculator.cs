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
                int nNumber = Math.Abs(Int32.Parse(num));
                int nPow = 0;
                bool bFirst = true;
                string sBinary = "";

                while (true)
                {
                    if (bFirst)
                    {
                        int value = (int)Math.Pow(2, nPow);
                        if ((nNumber - value) > 0)
                        {
                            nPow++;
                        }
                        else
                        {
                            bFirst = false;
                        }
                    }
                    else
                    {
                        int value = (int)Math.Pow(2, nPow);
                        if ((nNumber - value) >= 0)
                        {
                            nNumber -= value;

                            sBinary += "1";
                        }
                        else
                        {
                            sBinary += "0";
                        }

                        nPow--;

                        if (nNumber <= 0 || nPow < 0)
                        {
                            break;
                        }
                    }
                }
                
                if (num.Contains('-'))
                {
                    sBinary = GetTwosComplementOrNull("0b" + sBinary);
                }
                else
                {
                    sBinary = "0b" + sBinary;
                }

                return sBinary;
            }
            return null;
        }

        public static string ToHexOrNull(string num)
        {

            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            if (num.Contains("0b"))
            {
                char[] chArray = num.ToCharArray();
                int nIndex = chArray.Length - 1;
                int nSign = 2;
                int nPow = 0;
                int nValue = 0;

                while (nSign < nIndex)
                {

                    if (chArray[nIndex--] == '1')
                    {
                        nValue += (int)Math.Pow(2, nPow);
                    }

                    nPow++;
                }

                //return nValue.ToString();
            }
            else if (num.Contains("0x"))
            {

            }
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