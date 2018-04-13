using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALE1_test
{
    public class Proposition
    {
        private const char not_sign = '~';
        private const char and_sign = '&';
        private const char or_sign = '|';
        private const char implication_sign = '>';
        private const char equation_sign = '=';
        private const char bracket = '(';
        private const char inverce_bracket = ')';
        private const char comma = ',';
        private int proposition_palce = 0;
        private bool first_negative = false;
        private bool second_negative = false;

        private List<Predicate> predicatess;

        public List<Predicate> predicates
        {
            get { return predicatess; }
            set { predicatess = value; }
        }
        private List<Proposition> childs;

        public List<Proposition> child_propositions
        {
            get { return childs; }
            set { childs = value; }
        }
        private bool negative_value;

        public bool negative_proposition
        {
            get { return negative_value; }
            set { negative_value = value; }
        }
        private bool negative_;

        public bool negative__
        {
            get { return negative_; }
            set { negative_ = value; }
        }
        
        
        private string inputstring;
        
	    public string input_string
	    {
		    get { return inputstring;}
		    set { inputstring = value;}
	    }
	
        private string sign;

        public string proposition_sign
        {
            get { return sign; }
            set { sign = value; }
        }
        private int firstpredicatevalue;

        public int first_predicate_value
        {
            get { return firstpredicatevalue; }
            set { firstpredicatevalue = value; }
        }
        private int secondpredicatevalue;

        public int second_predicate_value
        {
            get { return secondpredicatevalue; }
            set { secondpredicatevalue = value; }
        }
        public Proposition(string input_string)
        {
            this.input_string = input_string;
            if (input_string[0].Equals(not_sign))
            {
                input_string = parseNegativeProposition(input_string);
                this.negative__ = true;
            }
            input_string = signHandler(input_string);
            input_string = bracketHandler(input_string);
            child_propositions = new List<Proposition>();
            predicates = new List<Predicate>();

            string first_proposition_string = parseInputString(input_string);
            if (first_proposition_string[0].Equals(not_sign) && first_proposition_string.Contains(','))
            {
                first_proposition_string = parseNegativeProposition(first_proposition_string);
                first_negative = true;
            }
            if (first_proposition_string[0].Equals(and_sign) || first_proposition_string[0].Equals(equation_sign) || first_proposition_string[0].Equals(implication_sign)
                || first_proposition_string[0].Equals(or_sign))
            {
                proposition_palce = 0;
                Proposition new_prop = new Proposition(first_proposition_string);
                if (first_negative)
                {
                    new_prop.negative__ = true;
                }
                this.child_propositions.Add(new_prop);
            }
            else
            {
                predicates.Add(new Predicate(first_proposition_string));
            }
            input_string = removeStringFromInputString(input_string, first_proposition_string);
            string second_proposition_string = parseInputString(input_string);

            if (second_proposition_string[0].Equals(not_sign) && second_proposition_string.Contains(','))
            {
                second_proposition_string = parseNegativeProposition(second_proposition_string);
                second_negative = true;
            }
            if (second_proposition_string[0].Equals(and_sign) || second_proposition_string[0].Equals(equation_sign) || second_proposition_string[0].Equals(implication_sign)
                || second_proposition_string[0].Equals(or_sign))
            {
                proposition_palce = 1;
                Proposition new_prop = new Proposition(second_proposition_string);
                if (second_negative)
                {
                    new_prop.negative__ = true;
                }
                this.child_propositions.Add(new_prop);
            }

            else
            {
                predicates.Add(new Predicate(second_proposition_string));
            }
        }
        public string signHandler(string input_string)
        {
            if (input_string[0].Equals(and_sign) || input_string[0].Equals(not_sign) 
                || input_string[0].Equals(equation_sign) || input_string[0].Equals(implication_sign) 
                || input_string[0].Equals(or_sign))
            {
                input_string = assisgnSign(input_string);
            }
            return input_string;
        }
        public string bracketHandler(string input_string)
        {
            if (input_string[0].Equals(bracket))
            {
                input_string = cleanFromBarckets(input_string);
            }
            return input_string;
        }
        public string assisgnSign(string input_string)
        {
            string temp_sign = "";
            temp_sign += input_string[0];
            this.proposition_sign = temp_sign;
            return input_string.Substring(1, input_string.Length-1);

        }

        public string cleanFromBarckets(string input_string){
            return input_string.Substring(1, input_string.Length-2);
        }
        private bool hasStringBrakeds(string input_string)
        {
            if (input_string.Length > 1)
            {
                if (input_string.Contains(bracket))
                {
                    if (input_string[0].Equals(and_sign)||input_string[0].Equals(or_sign)||input_string[0].Equals(equation_sign)||input_string[0].Equals(implication_sign))
                    {
                        return true;
                    }
                    else if (input_string[0].Equals(not_sign) && (input_string[2].Equals(and_sign) || input_string[2].Equals(or_sign) || input_string[2].Equals(equation_sign) || input_string[2].Equals(implication_sign)))
                    {
                        return true;
                    }
                
                }
            } return false;
        }
        public string parseInputString(string input_string)
        {
                if (hasStringBrakeds(input_string))
                {
                    int bracket_count = 0;
                    for (int counter = 0; counter < input_string.Length; counter++)
                    {
                        if (input_string[counter].Equals(bracket))
                        {
                            bracket_count++;
                        }
                        else if (input_string[counter].Equals(inverce_bracket))
                        {
                            bracket_count--;
                        }
                        else if ((counter != 0 && counter != 1) && bracket_count == 0)
                        {
                            string predicate = input_string.Substring(0, counter);
                            return predicate;
                        }
                    }
                }
                else
                {
                    if (input_string.Length > 1 && input_string.Contains(','))
                    {
                        return input_string.Substring(0, input_string.IndexOf(','));
                    }
                    else
                    {
                        return input_string;
                    }
                }
            return input_string;
        }
        public string parseNegativeProposition(string input_string)
        {
            negative_proposition = true;
            string temp_string = input_string.Substring(2, input_string.Length-3);
            Console.WriteLine(temp_string);
            return temp_string;
        }
        public string removeStringFromInputString(string input_string ,string input_string_to_remove)
        {
            if (negative_proposition)
            {
                input_string_to_remove = "~(" + input_string_to_remove + ")";
            }
            if (input_string.Length > input_string_to_remove.Length)
            {
                int index = input_string.IndexOf(input_string_to_remove);
                string cleanPath = (index < 0)
                    ? input_string
                    : input_string.Remove(index, input_string_to_remove.Length + 1);
                return cleanPath;
            }
            return "";
        }
        private String normalizeSign()
        {
            if (proposition_sign.Contains(and_sign))
            {
                return "and";
            }
            else if (proposition_sign.Contains(or_sign))
            {
                return "or";
            }
            else if (proposition_sign.Contains(implication_sign))
            {
                return "implicates";
            }
            else
            {
                return "equates";
            }
        }
        private bool hasChildren()
        {
            if (child_propositions.Count>0)
            {
                return true;
            }
            return false;
        }
        public String getPropositionASCIIFormat()
        {
            string output_string = "";
            if (hasChildren())
            {
                if (child_propositions.Count == 1)
                {
                    if (proposition_palce == 0)
                    {
                        output_string += proposition_sign + "(" + child_propositions[0].getPropositionASCIIFormat() + "," + predicates[0].getPredicateASCIIFormat() + ")";
                    }
                    else
                    {
                        output_string += proposition_sign + "(" + predicates[0].getPredicateASCIIFormat() + "," + child_propositions[0].getPropositionASCIIFormat() + ")";
                    }
                }
                else
                {
                    output_string += proposition_sign + "(" + child_propositions[0].getPropositionASCIIFormat() + "," + child_propositions[1].getPropositionASCIIFormat() + ")";
                }
            }
            else
            {
                output_string += proposition_sign + "(" + predicates[0].getPredicateASCIIFormat() + "," + predicates[1].getPredicateASCIIFormat() + ")";
            }
            if (negative__)
            {
                output_string = "~(" + output_string + ")";
            }
            return output_string;
        }
        public String getPropositionNormalizedFormat()
        {
            string output_string = "";
            if (hasChildren())
            {
                if (child_propositions.Count == 1)
                {
                    if (proposition_palce == 0)
                    {
                        output_string += "(" + child_propositions[0].getPropositionNormalizedFormat() + " " + normalizeSign() + " " + predicates[0].getPredicateNormalizedFormat() + ")";
                    }
                    else
                    {
                        output_string += "(" + predicates[0].getPredicateNormalizedFormat() + " " + normalizeSign() + " " + child_propositions[0].getPropositionNormalizedFormat() + ")";
                    }
                }
                else
                {
                    output_string += "(" + child_propositions[0].getPropositionNormalizedFormat() + " " + normalizeSign() + " " + child_propositions[1].getPropositionNormalizedFormat() + ")";
                }
            }
            else
            {
                output_string += "(" + predicates[0].getPredicateNormalizedFormat() + " " + normalizeSign() + " " + predicates[1].getPredicateNormalizedFormat() + ")";
            }
            return output_string;
        }
        public String getPropositionNANDFormat()
        {
            string output_string = "";
            if (hasChildren())
            {
                if (child_propositions.Count == 1)
                {
                    if (proposition_palce == 0)
                    {
                        switch (Convert.ToChar(proposition_sign))
                        {
                            case or_sign:
                                output_string += "%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNegativeNANDFormat() + ")";
                                break;
                            case equation_sign:
                                output_string += "%(%(%(%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNegativeNANDFormat() + "),%("
                                    + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNegativeNANDFormat() + ")),%(%(" + child_propositions[0].getPropositionNANDFormat()
                                    + "," + predicates[0].getPredicateNANDFormat() + "),%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNANDFormat() + "))),%(%(%("
                                    + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNegativeNANDFormat() + "),%(" + child_propositions[0].getPropositionNANDFormat()
                                    + "," + predicates[0].getPredicateNegativeNANDFormat() + ")),%(%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNANDFormat() + "),%("
                                    + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNANDFormat() + "))))";
                                break;
                            case implication_sign:
                                output_string += "%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNegativeNANDFormat() + ")";
                                break;
                            default:
                                output_string += "%(%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNANDFormat() + "),%(" + child_propositions[0].getPropositionNANDFormat() + "," + predicates[0].getPredicateNANDFormat() + "))";
                                break;
                        }
                    }
                    else
                    {
                        switch (Convert.ToChar(proposition_sign))
                        {
                            case or_sign:
                                output_string += "%(" + predicates[0].getPredicateNegativeNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + ")";
                                break;
                            case equation_sign:
                                output_string += "%(%(%(%(" + predicates[0].getPredicateNegativeNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "),%("
                                    + predicates[0].getPredicateNegativeNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + ")),%(%(" + predicates[0].getPredicateNANDFormat()
                                    + "," + child_propositions[0].getPropositionNANDFormat() + "),%(" + predicates[0].getPredicateNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "))),%(%(%("
                                    + predicates[0].getPredicateNegativeNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "),%(" + predicates[0].getPredicateNegativeNANDFormat()
                                    + "," + child_propositions[0].getPropositionNANDFormat() + ")),%(%(" + predicates[0].getPredicateNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "),%("
                                    + predicates[0].getPredicateNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "))))";
                                break;
                            case implication_sign:
                                output_string += "%(" + predicates[0].getPredicateNegativeNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + ")";
                                break;
                            default:
                                output_string += "%(%(" + predicates[0].getPredicateNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "),%(" + predicates[0].getPredicateNANDFormat() + "," + child_propositions[0].getPropositionNANDFormat() + "))";
                                break;
                        }
                    }
                }
                else
                {
                    switch (Convert.ToChar(proposition_sign))
                    {
                        case or_sign:
                            output_string += "%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + ")";
                            break;
                        case equation_sign:
                            output_string += "%(%(%(%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "),%("
                                + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + ")),%(%(" + child_propositions[0].getPropositionNANDFormat()
                                + "," + child_propositions[1].getPropositionNANDFormat() + "),%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "))),%(%(%("
                                + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "),%(" + child_propositions[0].getPropositionNANDFormat()
                                + "," + child_propositions[1].getPropositionNANDFormat() + ")),%(%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "),%("
                                + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "))))";
                            break;
                        case implication_sign:
                            output_string += "%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + ")";
                            break;
                        default:
                            output_string += "%(%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "),%(" + child_propositions[0].getPropositionNANDFormat() + "," + child_propositions[1].getPropositionNANDFormat() + "))";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToChar(proposition_sign))
                {
                    case or_sign:
                        output_string += "%(" + predicates[0].getPredicateNegativeNANDFormat() + "," + predicates[1].getPredicateNegativeNANDFormat() + ")";
                        break;
                    case equation_sign:
                        output_string += "%(%(%(%(" + predicates[0].getPredicateNegativeNANDFormat() + "," + predicates[1].getPredicateNegativeNANDFormat() + "),%(" 
                            + predicates[0].getPredicateNegativeNANDFormat() + "," + predicates[1].getPredicateNegativeNANDFormat() + ")),%(%(" + predicates[0].getPredicateNANDFormat() 
                            + "," + predicates[1].getPredicateNANDFormat() + "),%(" + predicates[0].getPredicateNANDFormat() + "," + predicates[1].getPredicateNANDFormat() + "))),%(%(%(" 
                            + predicates[0].getPredicateNegativeNANDFormat() + "," + predicates[1].getPredicateNegativeNANDFormat() + "),%(" + predicates[0].getPredicateNegativeNANDFormat() 
                            + "," + predicates[1].getPredicateNegativeNANDFormat() + ")),%(%(" + predicates[0].getPredicateNANDFormat() + "," + predicates[1].getPredicateNANDFormat() + "),%(" 
                            + predicates[0].getPredicateNANDFormat() + "," + predicates[1].getPredicateNANDFormat() + "))))";
                        break;
                    case implication_sign:
                        output_string += "%(" + predicates[0].getPredicateNegativeNANDFormat() + "," + predicates[1].getPredicateNegativeNANDFormat() + ")";
                        break;
                    default:
                        output_string += "%(%(" + predicates[0].getPredicateNANDFormat() + "," + predicates[1].getPredicateNANDFormat() + "),%(" + predicates[0].getPredicateNANDFormat() + "," + predicates[1].getPredicateNANDFormat() + "))";
                        break;
                }
            }
            return output_string;
        }
        public bool calculate()
        {
            bool end_value = false;
            if (hasChildren())
            {
                switch (Convert.ToChar(proposition_sign))
                {
                    case and_sign:
                        if (child_propositions.Count == 1)
                        {
                            if (proposition_palce == 0)
                            {
                                if (child_propositions[0].calculate() && predicates[0].getValue())
                                {
                                    return true;
                                }
                                return false;
                            }
                            else
                            {
                                if (predicates[0].getValue() && child_propositions[0].calculate())
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (child_propositions[0].calculate() && child_propositions[1].calculate())
                            {
                                return true;
                            }
                            return false;
                        }

                    case or_sign:
                        if (child_propositions.Count == 1)
                        {
                            if (proposition_palce == 0)
                            {
                                if (!child_propositions[0].calculate() && !predicates[0].getValue())
                                {
                                    return false;
                                }
                                return true;
                            }
                            else
                            {
                                if (!predicates[0].getValue() && !child_propositions[0].calculate())
                                {
                                    return false;
                                }
                                return true;
                            }
                        }
                        else
                        {
                            if (!child_propositions[0].calculate() && !child_propositions[1].calculate())
                            {
                                return false;
                            }
                            return true;
                        }

                    case implication_sign:
                        if (child_propositions.Count == 1)
                        {
                            if (proposition_palce == 0)
                            {
                                if (!child_propositions[0].calculate() || predicates[0].getValue())
                                {
                                    return true;
                                }
                                return false;
                            }
                            else
                            {
                                if (!predicates[0].getValue() || child_propositions[0].calculate())
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (!child_propositions[0].calculate() || child_propositions[1].calculate())
                            {
                                return true;
                            }
                            return false;
                        }

                    case equation_sign:
                        if (child_propositions.Count == 1)
                        {
                            if (proposition_palce == 0)
                            {
                                if (child_propositions[0].calculate() && predicates[0].getValue() ||
                                !child_propositions[0].calculate() && !predicates[0].getValue())
                                {
                                    return true;
                                }
                                return false;
                            }
                            else
                            {
                                if (predicates[0].getValue() && child_propositions[0].calculate() ||
                                !predicates[0].getValue() && !child_propositions[0].calculate())
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (child_propositions[0].calculate() && child_propositions[1].calculate() ||
                                !child_propositions[0].calculate() && !child_propositions[1].calculate())
                            {
                                return true;
                            }
                            return false;
                        }
                }
            }
            else
            {
                switch (Convert.ToChar(proposition_sign))
                {
                    case and_sign:
                        if (predicates[0].getValue() && predicates[1].getValue())
                        {
                            if (negative__)
                            {
                                return false;
                            }
                            return true;
                        }
                        if (negative__)
                        {
                            return true;
                        }
                        return false;

                    case or_sign:
                        if (!predicates[0].getValue() && !predicates[1].getValue())
                        {
                            if (negative__)
                            {
                                return true;
                            }
                            return false;
                        }
                        if (negative__)
                        {
                            return false;
                        }
                        return true;

                    case implication_sign:
                        if (!predicates[0].getValue() || predicates[1].getValue())
                        {
                            if (negative__)
                            {
                                return false;
                            }
                            return true;
                        }
                        if (negative__)
                        {
                            return true;
                        }
                        return false;

                    case equation_sign:
                        if (predicates[0].getValue() && predicates[1].getValue() ||
                            !predicates[0].getValue() && !predicates[1].getValue())
                        {
                            if (negative__)
                            {
                                return false;
                            }
                            return true;
                        }
                        if (negative__)
                        {
                            return true;
                        }
                        return false;
                }
            }
            return end_value;
        }
    }
}
