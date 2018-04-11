using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALE1_test
{
    class Reader
    {
        private string input;

        public string Input
        {
            get { return input; }
            set { input = value; }
        }
        private string[] processed_input;

        public string[] ProcessedInput
        {
            get { return processed_input; }
            set { processed_input = value; }
        }
        public Reader(string input)
        {
            this.input = input;
            this.processed_input = processInput();
        }
        public string[] processInput()
        {
            string[] temp_array = Regex.Split(Input, string.Empty);

            //clearing the input
            string[] new_temp_array = cleanString(temp_array, 0);

            return new_temp_array;
        }
        private string[] cleanString(string[] char_array, int index)
        {
            if (char_array.Length - 1 == index)
            {
                return char_array;
            }
            else if (char_array[index].Equals(" "))
            {
                var foos = new List<string>(char_array);
                foos.Remove(" ");
                char_array = foos.ToArray();
                return cleanString(char_array, index);
            }
            return cleanString(char_array, ++index);
        }
        public string replacePredicates(string input,string[] predicate_values)
        {
            StringBuilder sb = new StringBuilder(input);
            int[] predicate_indexes = getIndexesOfPredicates(input);
            for (int char_index = 0; char_index < predicate_indexes.Length; char_index++)
            {
                sb[predicate_indexes[char_index]] = Convert.ToChar(predicate_values[char_index]);
            }
            input = sb.ToString();
            //Console.WriteLine(input);
            return input;
        }
        public string replaceUniquePredicates(string input, string[] predicate_values)
        {
            int i = 0;
            List<char> char_list = new List<char>();
            foreach (char c in input)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    if (checkForChar(char_list, c))
                    {
                        char_list.Add(c);
                    }
                }
            }
            foreach (char c in char_list)
            {
               input = input.Replace(c, Convert.ToChar(predicate_values[i]));
                i++;
            }
            return input;
        }

        public string[,] generateTruthTableWithoutUniqueChars()
        {
            int number_of_predicates = getNumberOfPredicates(this.Input);
            int rows = (int)Math.Pow(2, number_of_predicates);
            string[,] truthArray = new string[(int)rows + 1, number_of_predicates];
            int[] indexes_of_predicates = getIndexesOfPredicates(this.Input);
            string[] predicates = getPredicates(this.Input);

            //assignming the top row with the letters for the predicates
            for (int i = 0; i < number_of_predicates; i++)
            {
                truthArray[0, i] = predicates[i];
            }
            //making the truth table 
            for (int column_counter = 0; column_counter < number_of_predicates; column_counter++)
            {
                int changer = (int)Math.Pow(2, column_counter + 1);
                int where_to_change_value = rows / changer;
                bool value = true;
                int cc = 0;
                for (int row_counter = 1; row_counter <= rows; row_counter++)
                {
                    if (cc == where_to_change_value)
                    {
                        value = !value;
                        cc = 0;
                    }
                    cc++;
                    truthArray[row_counter, column_counter] = Convert.ToInt16(value).ToString();
                }
            }
            return truthArray;
        }
        public string[,] generateTruthTableWithUniqueChars()
        {
            {
                int number_of_predicates = getNumberOfUniquePredicates(this.Input);
                int rows = (int)Math.Pow(2, number_of_predicates);
                string[,] truthArray = new string[(int)rows + 1, number_of_predicates];
                string[] predicates = getUniquePredicates(this.Input);

                //assignming the top row with the letters for the predicates
                for (int i = 0; i < number_of_predicates; i++)
                {
                    truthArray[0, i] = predicates[i];
                }
                //making the truth table 
                for (int column_counter = 0; column_counter < number_of_predicates; column_counter++)
                {
                    int changer = (int)Math.Pow(2, column_counter + 1);
                    int where_to_change_value = rows / changer;
                    bool value = true;
                    int cc = 0;
                    for (int row_counter = 1; row_counter <= rows; row_counter++)
                    {
                        if (cc == where_to_change_value)
                        {
                            value = !value;
                            cc = 0;
                        }
                        cc++;
                        truthArray[row_counter, column_counter] = Convert.ToInt16(value).ToString();
                    }
                }
                return truthArray;
            }
        }
        public int getNumberOfPredicates(string input)
        {
            int counter = 0;
            foreach (char c in input)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    counter++;
                }
            }
            return counter;
        }
        private int[] getIndexesOfPredicates(string input)
        {
            int[] indexes = new int[getNumberOfPredicates(input)];
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z'))
                {
                    indexes[counter] = i;
                    counter++;
                }
            }
            return indexes;
        }
        private string[] getPredicates(string input)
        {
            string[] indexes = new string[getNumberOfPredicates(input)];
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z'))
                {
                    indexes[counter] = input[i].ToString();
                    counter++;
                }
            }
            return indexes;
        }
        public int getNumberOfUniquePredicates(string input)
        {
            int counter = 0;
            List<char> char_list = new List<char>();
            foreach (char c in input)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    if (checkForChar(char_list, c))
                    {
                        counter++;
                        char_list.Add(c);
                    }
                }
            }
            return counter;
        }
        private bool checkForChar(List<char> char_list,char cc)
        {
            if (char_list.Count > 0)
            {
                foreach (char c in char_list)
                {
                    if (c.Equals(cc))
                    {
                        return false;
                    }
                } return true;
            }
            else { return true; }
        }
        private string[] getUniquePredicates(string input)
        {
            string[] indexes = new string[getNumberOfUniquePredicates(input)];
            List<char> char_list = new List<char>();
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z'))
                {
                    if (checkForChar(char_list, input[i]))
                    {
                        indexes[counter] = input[i].ToString();
                        char_list.Add(input[i]);
                        counter++;
                    }
                }
            }
            return indexes;
        }
    }
    
}
