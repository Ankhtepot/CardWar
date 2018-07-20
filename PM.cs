using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Public methods 
/// </summary>
namespace CardWar {
    class PM {
        public static String ListIntArray(int[] arr, string arrName = "") {
            string result = "Listing of array " + arrName + ":\n";
            for (int i = 0; i < arr.Length; i++) {
                result += "[" + i.ToString() + "]: " + arr[i].ToString() + ";";
            }
            return result;
        }

        public static int GetInputInt(string prompt, Boolean canBeNegative = false,
            Boolean canBeZero = false, int errorValue = -1,
            string variable = "", string errorMessage="Input Error:",
            string negativeErrMsg="Value cant be smaller then zero.",
            string zeroErrMessage="Value cant be zero.") {
            int result = errorValue;
            try {
                int tempResult = 0;
                Console.WriteLine(prompt+"\n");
                tempResult = int.Parse(Console.ReadLine());
                if (tempResult < 0 && !canBeNegative) throw new Exception(negativeErrMsg);
                if (tempResult == 0 && !canBeZero) throw new Exception(zeroErrMessage);
                result = tempResult;
            } catch (Exception e) {
                Console.WriteLine(errorMessage + e.Message);
            }
            return result;
        }
    }

}