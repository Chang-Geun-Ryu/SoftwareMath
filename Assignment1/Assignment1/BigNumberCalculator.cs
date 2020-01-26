using System;
using System.Linq;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        private int mBitCount = 0;
        private EMode mMode = EMode.Binary;

        public BigNumberCalculator(int bitCount, EMode mode)
        {
            this.mBitCount = bitCount;
            this.mMode = mode;
        }

        public static string GetOnesComplementOrNull(string num)
        {
            if (num.Contains("0b") && num.Length > 2)
            {
                CharEnumerator ch = num.Substring(2).GetEnumerator();
                string strBinary = "0b";

                while (ch.MoveNext() == true)
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

            string strOnce = GetOnesComplementOrNull(num);

            if (strOnce.Length > 0)
            {
                chArray = strOnce.ToCharArray();
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
                if (checkBinary(num) == false)
                {
                    return null;
                }

                return num;
            }
            else if (num.Contains("0x") && num.Length > 2)
            {
                if (checkHex(num) == false)
                {
                    return null;
                }

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
                
                return getDecimalToBinaryCallByBinary(num);
                
            }

            return null;
        }

        public static string ToHexOrNull(string num)
        {
            if (num.Contains("0b") && num.Length > 2)
            {
                if (checkBinary(num) == false)
                {
                    return null;
                }

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
                if (checkHex(num) == false)
                {
                    return null;
                }

                return num;
            }
            else if (checkDecimal(num))
            {
                string sBinary = getDecimalToBinary(num);

                return getBinaryToHex(sBinary, false);
            }

            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            if (num.Contains("0b"))
            {
                if (checkBinary(num) == false)
                {
                    return null;
                }

                return getBinaryToDecimal(num);
            }
            else if (num.Contains("0x"))
            {
                if (checkHex(num) == false)
                {
                    return null;
                }

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

            string sBinary1 = "";
            string sBinary2 = "";

            if (checkBinary(num1) || checkHex(num1))
            {
                sBinary1 = ToBinaryOrNull(num1);
            }
            else if (checkDecimal(num1))
            {
                sBinary1 = getDecimalToBinaryCallAdd(num1);
            }
            else
            {
                return null;
            }

            if (checkBinary(num2) || checkHex(num2))
            {
                sBinary2 = ToBinaryOrNull(num2);
            }
            else if (checkDecimal(num2))
            {
                sBinary2 = getDecimalToBinaryCallAdd(num2);
            }
            else
            {
                return null;
            }

            if (sBinary1 == null || sBinary2 == null)
            {
                return null;
            }

            sBinary1 = getBitPolish(sBinary1);
            sBinary2 = getBitPolish(sBinary2);

            if (sBinary1 == null || sBinary2 == null)
            {
                return null;
            }

            string sResult = getSumBinary(sBinary1, sBinary2, out bOverflow);

            if (this.mMode == EMode.Binary)
            {

                return "0b" + sResult;
            }
            else if (this.mMode == EMode.Decimal)
            {
                return getBinaryToDecimal("0b" + sResult);
            }

            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;

            string sBinary1 = "";
            string sBinary2 = "";

            if (checkBinary(num1) || checkHex(num1))
            {
                sBinary1 = ToBinaryOrNull(num1);
            }
            else if (checkDecimal(num1))
            {
                sBinary1 = getDecimalToBinaryCallAdd(num1);
            }
            else
            {
                return null;
            }

            if (checkBinary(num2) || checkHex(num2))
            {
                sBinary2 = ToBinaryOrNull(num2);
            }
            else if (checkDecimal(num2))
            {
                sBinary2 = getDecimalToBinaryCallAdd(num2);
            }
            else
            {
                return null;
            }

            if (sBinary1 == null || sBinary2 == null)
            {
                return null;
            }

            sBinary1 = getBitPolish(sBinary1);
            sBinary2 = getBitPolish(sBinary2);

            sBinary2 = GetTwosComplementOrNull("0b" + sBinary2);

            if (sBinary1 == null || sBinary2 == null)
            {
                return null;
            }

            string sResult = getSumBinary(sBinary1, sBinary2.Substring(2), out bOverflow);

            if (this.mMode == EMode.Binary)
            {

                return "0b" + sResult;
            }
            else if (this.mMode == EMode.Decimal)
            {
                return getBinaryToDecimal("0b" + sResult);
            }

            return null;
        }

        private string getSumBinary(string num1, string num2, out bool bOverflow)
        {
            string sResult = "";

            char[] chNumFirstArr = num1.ToCharArray();
            char[] chNumSecondArr = num2.ToCharArray();
            //char[] chResult = new char[this.mBitCount];

            int nAddOne = 0;
            int index = this.mBitCount - 1;
            bOverflow = false;
            int[] mCarry = new int[2];

            while (index >= 0)
            {
                if ((chNumFirstArr[index] - 48) + (chNumSecondArr[index] - 48) + nAddOne == 3)
                {
                    nAddOne = 1;
                    sResult = "1" + sResult;
                }
                else if ((chNumFirstArr[index] - 48) + (chNumSecondArr[index] - 48) + nAddOne == 2)
                {
                    nAddOne = 1;
                    sResult = "0" + sResult;
                }
                else if ((chNumFirstArr[index] - 48) + (chNumSecondArr[index] - 48) + nAddOne == 1)
                {
                    nAddOne = 0;
                    sResult = "1" + sResult;
                }
                else if ((chNumFirstArr[index] - 48) + (chNumSecondArr[index] - 48) + nAddOne == 0)
                {
                    nAddOne = 0;
                    sResult = "0" + sResult;
                }
                else
                {
                    return null;
                }

                mCarry[index % 2] = nAddOne;

                --index;
            }

            if (chNumFirstArr[0] == chNumSecondArr[0] && sResult.ToCharArray()[0] != chNumSecondArr[0])
            {
                bOverflow = true;
            }

            return sResult;
        }

        private string getBitPolish(string num)
        {
            string sResult = "";
            string sBinary = num.Substring(2);


            if (this.mBitCount >= sBinary.Length)
            {
                char[] chArray = sBinary.ToCharArray();
                char cSign = chArray[0];
                string sZero = "";
                for (int i = 0; i < this.mBitCount - sBinary.Length; i++)
                {
                    sZero += cSign;
                }

                sResult = cSign + sZero + sBinary.Substring(1);


            }
            else
            {
                return null;
            }

            return sResult;
        }

        private static bool checkBinary(string num)
        {
            if (num.Length < 2)
            {
                return false;
            }
            if (num.ToCharArray()[0] != '0' || num.ToCharArray()[1] != 'b')
            {
                return false;
            }

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
                    return false;
                }
            }

            return true;
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

            while (SIGN <= nIndex)
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

            if (sValue == "")
            {
                sValue = "0";
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

                for (int i = 0; i < 4; i++)
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

        private static bool checkHex(string num)
        {
            if (num.Length < 2)
            {
                return false;
            }

            if (num.ToCharArray()[0] == '0' && num.ToCharArray()[1] == 'x')
            {
                char[] charArray = num.Substring(2).ToCharArray();
                char[] cHexArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

                for (int i = 0; i < charArray.Length; i++)
                {
                    if (Array.IndexOf(cHexArray, charArray[i]) >= 0)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
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

        private string getDecimalToBinaryCallAdd(string num)
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

            bool bOverFlow = true;
            string sTemp = sRemainders;
            for (int i = 0; i < this.mBitCount - sRemainders.Length; i++)
            {
                sTemp = "0" + sTemp;
                bOverFlow = false;
            }

            if (bOverFlow)
            {
                if (bNegative == false)
                {
                    return null;
                }
            }

            sRemainders = sTemp;

            if (bNegative)
            {
                string sResult = "";

                sResult = GetTwosComplementOrNull("0b" + sRemainders);

                //if (sResult.Substring(2).ToCharArray()[0] == '0')
                //{
                //    sResult = "0b1" + sResult.Substring(2);
                //}

                return sResult;
            }

            //if (nRemainder == 1)
            //{
            //    sRemainders = "0" + sRemainders;
            //}

            return "0b" + sRemainders;
        }

        private static string getDecimalToBinaryCallByBinary(string num)
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
                
                sResult = GetTwosComplementOrNull("0b" + sRemainders);

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

        private static string getDecimalToBinary(string num)
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