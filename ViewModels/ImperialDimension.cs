using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class ImperialDimension
    {
        public static readonly string[] Fractions = { "", "¹/₁₆", "¹/₈", "³/₁₆", "¹/₄", "⁵/₁₆", "³/₈", "⁷/₁₆", "¹/₂", "⁹/₁₆", "⁵/₈", "¹¹/₁₆", "³/₄", "¹³/₁₆", "⁷/₈", "¹⁵/₁₆" };
        public static readonly string[] LargeFractions = { "", "1/16", "1/8", "3/16", "1/4", "5/16", "3/8", "7/16", "1/2", "9/16", "5/8", "11/16", "3/4", "13/16", "7/8", "15/16" };

        public static int SetFraction(int rawValue, int fraction)
        {
            return rawValue == 0 ? fraction : (rawValue / 16) * 16 + fraction;
        }
        public static int GetFraction(int rawValue)
        {
            return rawValue % 16;
        }
        public static string GetFractionAsString(int rawValue)
        {
            return Fractions[rawValue % 16];
        }

        public static int SetWholeNumber(int rawValue, int wholeNumber)
        {
            return rawValue % 16 + wholeNumber * 16; 
        }
        public static int GetWholeNumber(int rawValue)
        {
            return rawValue == 0 ? 0 : rawValue / 16;
        }
    }
}
