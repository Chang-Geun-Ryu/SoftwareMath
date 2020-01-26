using System;
using System.Linq;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        private int mBitCount = 0;
        private EMode Mode = EMode.Binary;

        public BigNumberCalculator(int bitCount, EMode mode)
        {
            this.mBitCount = bitCount;
            this.Mode = mode;
        }

        public static string GetOnesComplementOrNull(string num)
        {
            if (num.Contains("0b") && num.Length > 2)
            {
                CharEnumerator ch = num.Substring(2).GetEnumerator();
                string strBinary = "0b";

                while(ch.MoveNext() == true)
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
            if (num.Contains("0b") == false || num.Length <= 2)
            {
                return null;
            }

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
            if (num == null)
            {
                return null;
            }

            if (num.Contains("0b") && num.Length > 2)
            {
                char[] chArray = num.Substring(2).ToCharArray();
                for (int i = 0; i < chArray.Length; i++)
                {
                    if (chArray[i].Equals('1'))
                    {
                        continue;
                    }
                    else if (chArray[i].Equals('0'))
                    {
                        continue;
                    }
                    else
                    {
                        return null;
                    }
                }

                return num;
            }
            else if (num.Contains("0x") && num.Length > 2)
            {
                char[] chArray = num.ToCharArray();
                int index = chArray.Length - 1;
                string sBinary = "";

                while (index > 0)
                {
                    sBinary = getHexToBinary(chArray[index]) + sBinary;

                    index--;
                }

                return "0b" + sBinary;
            }
            else if (checkDecimal(num))
            {
                return decimalToBinaryCallByBinary(num);
            }

            return null;
        }

        public static string ToHexOrNull(string num)
        {
            if (num.Contains("0b") && num.Length > 2)
            {
                char[] chArray = num.Substring(2).ToCharArray();
                if (chArray.Length % 4 == 0)
                {

                }
                else
                {
                    string sZero = "";
                    string sAddBinary = "0";
                    if (chArray[0] == '1')
                    {
                        sAddBinary = "1";
                    }
                    
                    for (int i = 0; i < 4 - num.Substring(2).Length % 4; i++)
                    {
                        sZero = sAddBinary + sZero;
                    }
                    num = "0b" + sZero + num.Substring(2);
                }

                return getBinaryToHex(num);
            }
            else if (num.Contains("0x") && num.Length > 2)
            {
                return num;
            }
            else if (checkDecimal(num))
            {
                string sBinary = decimalToBinary(num);

                return getBinaryToHex(sBinary, false);
            }

            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            if (num.Contains("0b"))
            {
                return getBinaryToDecimal(num);
            }
            else if (num.Contains("0x"))
            {
                string sBinary = ToBinaryOrNull(num);

                return getBinaryToDecimal(sBinary);
            }
            else if (checkDecimal(num))
            {
                return num;
            }

            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;

            if (this.Mode == EMode.Binary)
            {

            }
            else if (this.Mode == EMode.Decimal)
            {
                if (checkDecimal(num1) == false || checkDecimal(num2) == false)
                {
                    return null;
                }


            }


            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        private static string getBinaryToDecimal(string num)
        {
            char[] chArray = num.ToCharArray();
            bool bNegative = false;
            int nIndex = chArray.Length - 1;
            const int SIGN = 2;
            int nPow = 0;
            string sValue = "";

            if (chArray[SIGN] == '1')
            {
                bNegative = true;
                chArray = GetTwosComplementOrNull(num).ToCharArray();
            }

            while (SIGN < nIndex)
            {
                if (chArray[nIndex--] == '1')
                {
                    sValue = getSumDecimalString(sValue, getBinaryPower(nPow));
                }

                nPow++;
            }

            if (bNegative)
            {
                sValue = "-" + sValue;
            }

            return sValue;
        }

        private static string getBinaryToHex(string num, bool bFlag = true)
        {
            char[] chArray = num.Substring(2).ToCharArray();
            //char[] chArray = num.ToCharArray();
            string sAddZero = "";
            char[] cHexArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        
            chArray = (sAddZero + new string(chArray)).ToCharArray();
            int nIndex = chArray.Length - 1;
            string sResult = "";

            while (nIndex >= 3)
            {
                int nValue = 0;
                int nPow = 0;

                for(int i = 0; i < 4; i++)
                {
                    if (chArray[nIndex--] == '1')
                    {
                        nValue += 1 << nPow;
                    }

                    nPow++;
                }

                sResult = cHexArray[nValue] + sResult; 
            }


            return "0x" + sResult;
        }

        private static string getHexToBinary(char hex)
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

        private static bool checkDecimal(string num)
        {
            if (num.Contains("0b"))
            {
                return false;
            }
            else if (num.Contains("0x"))
            {
                return false;
            }
            else
            {
                if (num == "-0" || num == "-")
                {
                    return false;
                }
                

                char[] checkCharArray = { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                char[] charArray = num.ToCharArray();
                int index = charArray.Length;

                while (index > 0)
                {
                    index--;

                    if (Array.IndexOf(checkCharArray, charArray[index]) >= 0)
                    {
                        if (index != 0 && charArray[index] == '-')
                        {
                            return false;
                        }
                        else if (index == 0 && charArray[index] == '0' && charArray.Length > 1)
                        {
                            return false;
                        }
                        else if (index == 0)
                        {
                            //if (num.Contains('1'))
                            {
                                return true;
                            }
                        }

                        continue;
                    }

                    return false;
                }
            }

            return false;
        }

        private static string convertDecimalToString(Int64 nNumber)
        {
            if (nNumber == 0)
            {
                return "0";
            }

            char[] charArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool bNegative = nNumber < 0 ? true : false;
            string sResult = "";

            nNumber = Math.Abs(nNumber);

            while (nNumber > 0)
            {
                sResult = charArray[nNumber % 10] + sResult;
                nNumber /= 10;
            }

            if (bNegative)
            {
                sResult = "-" + sResult;
            }

            return sResult;
        }

        private static string getSumNumberASCII(char chFirst, char chSecond, int nOne = 0)
        {
            char[] charArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            if ((Array.IndexOf(charArray, chFirst) < 0) || (Array.IndexOf(charArray, chSecond) < 0))
            {
                return null;
            }

            string sResult = "";
            int nSum = (chFirst - 48) + (chSecond - 48) + nOne;

            while (nSum >= 0)
            {
                sResult = (char)((nSum % 10) + 48) + sResult;
                nSum /= 10;

                if (nSum == 0)
                {
                    break;
                }
            }

            return sResult;
        }

        private static string getBinaryPower(int nPow)
        {
            if (nPow == 0)
            {
                return "1";
            }
            else if (nPow == 1)
            {
                return "2";
            }

            string sResult = "2";

            for (int idxPow = 2; idxPow <= nPow; idxPow++)
            {
                int nIndex = sResult.Length - 1;
                char[] chArray = sResult.ToCharArray();
                bool bOne = false;
                string sTemp = "";

                while (nIndex >= 0)
                {
                    int nOne = bOne ? 1 : 0;
                    string sSum = getSumNumberASCII(chArray[nIndex], chArray[nIndex], nOne);

                    char[] chSubArray = sSum.ToCharArray();

                    bOne = chSubArray.Length == 2 ? true : false;

                    if (nIndex == 0)
                    {
                        sTemp = new string(chSubArray) + sTemp;
                    }
                    else
                    {
                        sTemp = new string(chSubArray, chSubArray.Length - 1, 1) + sTemp;
                    }
                    
                    nIndex--;
                }

                sResult = sTemp;

            }

            return sResult;
        }

        private static string getSumDecimalString(string sFirst, string sSecond)
        {
            string sResult = "";
            int diffLength = sFirst.Length - sSecond.Length > 0 ? sFirst.Length - sSecond.Length : sSecond.Length - sFirst.Length;
            string sZero = "";

            for (int idx = 0; idx < diffLength; idx++)
            {
                sZero += "0";
            }

            if (sFirst.Length - sSecond.Length > 0)
            {
                sSecond = sZero + sSecond;
            }
            else
            {
                sFirst = sZero + sFirst;
            }

            int nIndex = sFirst.Length - 1;
            char[] chFirstArr = sFirst.ToCharArray();
            char[] chSecondArr = sSecond.ToCharArray();
            bool bOne = false;

            while (nIndex >= 0)
            {
                string sSum = getSumNumberASCII(chFirstArr[nIndex], chSecondArr[nIndex], bOne ? 1 : 0);

                char[] chSubArray = sSum.ToCharArray();

                bOne = chSubArray.Length == 2 ? true : false;

                if (nIndex == 0)
                {
                    sResult = new string(chSubArray) + sResult;
                }
                else
                {
                    sResult = new string(chSubArray, chSubArray.Length - 1, 1) + sResult;
                }

                nIndex--;
            }

            return sResult;
        }


        private static string decimalToBinaryCallByBinary(string num)
        {
            bool bNegative = false;
            char[] chArray = num.ToCharArray();
            const int DIVIDER = 2;

            if (chArray[0] == '-')
            {
                bNegative = true;
                chArray = num.Substring(1).ToCharArray();
            }

            int[] nCalcArray = new int[chArray.Length];

            for (int i = 0; i < chArray.Length; i++)
            {
                nCalcArray[i] = chArray[i] - 48;
            }


            int nTemp = 0;
            string sQuotients = "";
            string sRemainders = "";
            int nRemainder = 0;

            while (nCalcArray.Length > 0)
            {
                for (int i = 0; i < nCalcArray.Length; i++)
                {
                    nTemp += nCalcArray[i];

                    int nQuotient = nTemp / DIVIDER;
                    nRemainder = nTemp % DIVIDER;

                    nTemp = nRemainder * 10;

                    sQuotients += (char)(nQuotient);
                }


                chArray = sQuotients.ToCharArray();
                if (chArray[0] == 0)
                {
                    chArray = sQuotients.Substring(1).ToCharArray();

                }

                nCalcArray = new int[chArray.Length];

                for (int i = 0; i < chArray.Length; i++)
                {
                    nCalcArray[i] = chArray[i];
                }

                sRemainders = (char)(nRemainder + 48) + sRemainders;
                sQuotients = "";
                nTemp = 0;
            }

            if (bNegative)
            {
                string sResult = "";
                //if (sRemainders.ToCharArray()[0] == '1')
                //{
                //    if (sRemainders.ToCharArray().Length % 4 == 0)
                    {
                        sResult = GetTwosComplementOrNull("0b" + sRemainders);
                    }
                //    else
                //    {
                //        sResult = GetTwosComplementOrNull("0b0" + sRemainders);
                //    }
                    
                //}
                //else
                //{
                //    sResult = GetTwosComplementOrNull("0b0" + sRemainders);
                //}

                if (sResult.Substring(2).ToCharArray()[0] == '0')
                {
                    sResult = "0b1" + sResult.Substring(2);
                }
                
                return sResult;
            }

            if (nRemainder == 1)
            {
                sRemainders = "0" + sRemainders;
            }

            return "0b" + sRemainders;
        }

        private static string decimalToBinary(string num)
        {
            bool bNegative = false;
            char[] chArray = num.ToCharArray();
            const int DIVIDER = 2;

            if (chArray[0] == '-')
            {
                bNegative = true;
                chArray = num.Substring(1).ToCharArray();
            }

            int[] nCalcArray = new int[chArray.Length];

            for (int i = 0; i < chArray.Length; i++)
            {
                nCalcArray[i] = chArray[i] - 48;
            }
            

            int nTemp = 0;
            string sQuotients = "";
            string sRemainders = "";
            int nRemainder = 0;

            while (nCalcArray.Length > 0)
            {
                for (int i = 0; i < nCalcArray.Length; i++)
                {
                    nTemp += nCalcArray[i];

                    int nQuotient = nTemp / DIVIDER;
                    nRemainder = nTemp % DIVIDER;

                    nTemp = nRemainder * 10;

                    sQuotients += (char)(nQuotient);
                }


                chArray = sQuotients.ToCharArray();
                if (chArray[0] == 0)
                {
                    chArray = sQuotients.Substring(1).ToCharArray();
                    
                }

                nCalcArray = new int[chArray.Length];

                for (int i = 0; i < chArray.Length; i++)
                {
                    nCalcArray[i] = chArray[i];
                }

                sRemainders = (char)(nRemainder + 48) + sRemainders;
                sQuotients = "";
                nTemp = 0;
            }

            if (bNegative)
            {
                if (sRemainders.Length % 4 == 0)
                {
                    sRemainders = "0000" + sRemainders;
                }
                else
                {
                    string sTempNegative = sRemainders;
                    for (int i = 0; i < 4 - sRemainders.Length % 4; i++)
                    {
                        sTempNegative = "0" + sTempNegative;
                    }
                    sRemainders = sTempNegative;
                }

                return GetTwosComplementOrNull("0b" + sRemainders);
            }

            string sTemp = sRemainders;
            for (int i = 0; i < 4 - sRemainders.Length % 4; i++)
            {
                sTemp = "0" + sTemp;
            }
            sRemainders = sTemp;

            return "0b" + sRemainders;
        }
    }
}