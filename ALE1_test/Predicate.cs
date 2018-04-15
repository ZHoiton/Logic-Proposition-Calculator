using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1_test
{
    public class Predicate
    {
        private const char not_sign = '~';
        private const char bracket = '(';
        private const char inverce_bracket = ')';
        private string inputvalue;
        private bool isnegative;

        public bool is_negative
        {
            get { return isnegative; }
            set { isnegative = value; }
        }
        
        public string input_value
        {
            get { return inputvalue; }
            set { inputvalue = value; }
        }
        private bool predicatevalue;

        public bool predicate_value
        {
            get {
                if (is_negative)
                {
                    return !predicatevalue;
                }
                else
                {
                    return predicatevalue;
                }
            }
            set { predicatevalue = value; }
        }
        public Predicate(string input_string)
        {
            isnegative = false;
            input_string = parseInput(input_string);
            input_value = input_string;
        }
        private String parseInput(string input_string)
        {
            if (input_string.Contains(bracket) || input_string.Contains(inverce_bracket))
            {
                if (input_string.Contains(not_sign))
                {
                    input_string = assisgnSign(input_string);
                }
                input_string = cleanFromBarckets(input_string);
            }
            return input_string;
        }
        private string cleanFromBarckets(string input_string)
        {
            return input_string.Substring(1, input_string.Length - 2);
        }
        private string assisgnSign(string input_string)
        {
            string temp_sign = "";
            temp_sign += input_string[0];
            this.isnegative = true;
            return input_string.Substring(1, input_string.Length - 1);

        }
        public String getPredicateASCIIFormat()
        {
            if (is_negative)
            {
                return "~(" + input_value + ")";
            }
            else
            {
                return input_value;
            }
        }
        public String getPredicateNormalizedFormat()
        {
            if (is_negative)
            {
                return "not(" + input_value + ")";
            }
            else
            {
                return input_value;
            }
        }
        public String getPredicateNANDFormat()
        {
            if (is_negative)
            {
                return "%(" + input_value + "," + input_value + ")";
            }
            return input_value;
        }
        public String getPredicateNegativeNANDFormat()
        {
            if (is_negative)
            {
                return input_value;
            }
            return "%(" + getPredicateNANDFormat() + "," + getPredicateNANDFormat() + ")";
        }
        private bool value()
        {
            if (input_value.Equals("0"))
            {
                return false;
            }
            return true;
        }
        public bool getValue()
        {
            if (is_negative)
            {
                return !value();
            } 
            return value();
        }
    }
}
