using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1_test
{
    public class Simplifyer
    {
        private string[,] truthtable;

        public string[,] truth_table
        {
            get { return truthtable; }
            set { truthtable = value; }
        }
        public Simplifyer()
        {

        }
        public string[,] getSimplifyedTruthTable(string[,] passed_truth_table)
        {
            List<string[]> simplifyed_table = new List<string[]>();
            List<string[]> simplifyed_table_possitive_results = new List<string[]>();
            List<string[]> simplifyed_table_negative_results = new List<string[]>();
            //looping each row starting from the 2nd row beacuse the fist is filled with the Predicate's letter
            for (int row_counter_for_the_passed_truth_table = 1; row_counter_for_the_passed_truth_table < passed_truth_table.GetLength(0); row_counter_for_the_passed_truth_table++)
            {
                //checking if the row's result is equal to 1
                if (passed_truth_table[row_counter_for_the_passed_truth_table, passed_truth_table.GetLength(1) - 1].Equals("1"))
                {
                    string[] current_element = new string[passed_truth_table.GetLength(1) - 1];
                    //creating the new element which will be used for comparing to the rest
                    for (int current_element_predicate_value = 0; current_element_predicate_value < passed_truth_table.GetLength(1) - 1; current_element_predicate_value++)
                    {
                        current_element[current_element_predicate_value] = passed_truth_table[row_counter_for_the_passed_truth_table, current_element_predicate_value];
                    }
                    //cwElement(current_element, "* new current element");
                    //starting the comparison with the other elements
                    for (int row_counter_for_comparing_the_second_element = 1; row_counter_for_comparing_the_second_element < passed_truth_table.GetLength(0); row_counter_for_comparing_the_second_element++)
                    {
                        //checking if the second element result is equal to 1
                        if (passed_truth_table[row_counter_for_comparing_the_second_element, passed_truth_table.GetLength(1) - 1].Equals("1"))
                        {

                            string[] second_element = new string[passed_truth_table.GetLength(1) - 1];
                            //creating the new element which will be used for comparing to the first one
                            for (int second_element_predicate_value = 0; second_element_predicate_value < passed_truth_table.GetLength(1) - 1; second_element_predicate_value++)
                            {
                                second_element[second_element_predicate_value] = passed_truth_table[row_counter_for_comparing_the_second_element, second_element_predicate_value];
                            }
                            //cwElement(second_element, "+ new second element");
                            //checking if the 2 elements are diffrent
                            if (!checkIfElementsAreTheSame(current_element, second_element))
                            {
                                if (checkIsPossibleToSimplify(current_element, second_element))
                                {
                                    //creating the new element which will be passed in the new list
                                    string[] new_element_for_simplifyed_table = new string[passed_truth_table.GetLength(1)];
                                    for (int new_element_counter = 0; new_element_counter < passed_truth_table.GetLength(1) - 1; new_element_counter++)
                                    {
                                        if (current_element[new_element_counter].Equals(second_element[new_element_counter]) || current_element[new_element_counter].Equals("*"))
                                        {
                                            new_element_for_simplifyed_table[new_element_counter] = current_element[new_element_counter];
                                        }
                                        else
                                        {
                                            new_element_for_simplifyed_table[new_element_counter] = "*";
                                        }
                                    }
                                    //adding the answear for the notation in the array
                                    new_element_for_simplifyed_table[passed_truth_table.GetLength(1) - 1] = passed_truth_table[row_counter_for_the_passed_truth_table, passed_truth_table.GetLength(1) - 1];
                                    simplifyed_table_possitive_results.Add(new_element_for_simplifyed_table);
                                    //break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    string[] current_negative_element = new string[passed_truth_table.GetLength(1)];
                    //creating the new newgative element jsut passed down
                    for (int current_element_predicate_value = 0; current_element_predicate_value < passed_truth_table.GetLength(1) - 1; current_element_predicate_value++)
                    {
                        current_negative_element[current_element_predicate_value] = passed_truth_table[row_counter_for_the_passed_truth_table, current_element_predicate_value];
                    }
                    current_negative_element[passed_truth_table.GetLength(1) - 1] = passed_truth_table[row_counter_for_the_passed_truth_table, passed_truth_table.GetLength(1) - 1];
                    simplifyed_table_negative_results.Add(current_negative_element);
                }
            }
            //creating the fist row with the predicates names and the proposition
            string[] predicates_name = new string[passed_truth_table.GetLength(1)];
            for (int i = 0; i < passed_truth_table.GetLength(1); i++)
            {
                predicates_name[i] = passed_truth_table[0, i];
            }
            //addding it to the list
            simplifyed_table.Add(predicates_name);
            //adding both the resuling list to the master list
            foreach (string[] item in simplifyed_table_negative_results)
            {
                simplifyed_table.Add(item);
            }
            //List<string[]> new_simplifyed_table_possitive_results = simplifyed_table_possitive_results;
            List<string[]> new_simplifyed_table_possitive_results = getDistinctElements(simplifyed_table_possitive_results);
            //List<string[]> new_simplifyed_table_possitive_results = simplifyed_table_possitive_results;
            //removing the items which are not valid

            new_simplifyed_table_possitive_results = removeInvalidItems(new_simplifyed_table_possitive_results, simplifyed_table_negative_results);

            foreach (string[] item in new_simplifyed_table_possitive_results)
            {
                simplifyed_table.Add(item);
            }

            //converting the List<string[]> to array cuz C# cant convert it with ToAarry()...
            string[,] simplifyed_table_arry = new string[simplifyed_table.Count, simplifyed_table[0].Length];
            for (int i = 0; i < simplifyed_table.Count; i++)
            {
                for (int ii = 0; ii < simplifyed_table[0].Length; ii++)
                {
                    simplifyed_table_arry[i, ii] = simplifyed_table[i][ii];
                    //Console.Write(simplifyed_table_arry[i, ii] + " ");
                }
                //Console.WriteLine("");
            }
            //recurse
            if (new_simplifyed_table_possitive_results.Count > 0)
            {
                if (continueToSimplify(new_simplifyed_table_possitive_results[0]))
                {
                    string[,] next_iteration_of_table = getSimplifyedTruthTable(simplifyed_table_arry);
                    if (checkIfPropositionsAreValid(next_iteration_of_table))
                    {
                        simplifyed_table_arry = next_iteration_of_table;
                    }
                }
            }
            return simplifyed_table_arry;
        }
        public bool checkIfPropositionsAreValid(string[,] array)
        {
            //if (hasSimplifyedMoreThanTwoTimes(array))
            //{
                int number_of_redicates_not_valid = 0;
                int number_of_simplified_predicates = 0;
                //looping the simplified elements
                for (int simplified_row_iterator = 1; simplified_row_iterator < array.GetLength(0); simplified_row_iterator++)
                {
                    if (array[simplified_row_iterator, array.GetLength(1) - 1].Equals("1"))
                    {
                        number_of_simplified_predicates++;
                        string[] current_element = new string[array.GetLength(1) - 1];
                        for (int simplified_column_iterator = 0; simplified_column_iterator < array.GetLength(1) - 1; simplified_column_iterator++)
                        {
                            current_element[simplified_column_iterator] = array[simplified_row_iterator, simplified_column_iterator];
                        }
                        //startring to loop the 0 combinations
                        for (int row_iterator_zero = 1; row_iterator_zero < array.GetLength(0); row_iterator_zero++)
                        {
                            int number_of_indentical_elements = 0;
                            if (array[row_iterator_zero, array.GetLength(1) - 1].Equals("0"))
                            {
                                for (int column_iterator_zero = 0; column_iterator_zero < array.GetLength(1) - 1; column_iterator_zero++)
                                {
                                    if (current_element[column_iterator_zero].Equals(array[row_iterator_zero, column_iterator_zero])||current_element[column_iterator_zero].Equals("*"))
                                    {
                                        number_of_indentical_elements++;
                                    }
                                }
                            }
                            if (number_of_indentical_elements == array.GetLength(1) - 1)
                            {
                                number_of_redicates_not_valid++;
                                break;
                            }
                        }
                    }
                }
                if (number_of_redicates_not_valid != number_of_simplified_predicates)
                {
                    return true;
                }
                return false;
            //}
        }
        
        public List<string[]> removeInvalidItems(List<string[]> simplified_list,List<string[]> non_simplified_list)
        {
            if (simplified_list.Count > 0)
            {
                List<string[]> new_simplified_list = simplified_list;
                for (int simplified_list_iterator = 0; simplified_list_iterator < new_simplified_list.Count; simplified_list_iterator++)
                {
                    for (int non_simplified_list_row_iterator = 0; non_simplified_list_row_iterator < non_simplified_list.Count; non_simplified_list_row_iterator++)
                    {
                        int same_item_increment = 0;
                        for (int columnt_iterator = 0; columnt_iterator < non_simplified_list[0].Length - 1; columnt_iterator++)
                        {
                            if (new_simplified_list[simplified_list_iterator][columnt_iterator].Equals(non_simplified_list[non_simplified_list_row_iterator][columnt_iterator]) || new_simplified_list[simplified_list_iterator][columnt_iterator].Equals("*"))
                            {
                                same_item_increment++;
                            }
                        }
                        if (same_item_increment == simplified_list[0].Length - 1)
                        {
                            new_simplified_list.Remove(new_simplified_list[simplified_list_iterator]);
                            simplified_list_iterator--;
                            break;
                        }
                    }
                }
                return new_simplified_list;
            }
            return simplified_list;
        }
        public bool continueToSimplify(string[] string_array)
        {
            int already_simplified_predicates = 0;
            for (int counter = 0; counter < string_array.Length-1; counter++)
            {
                if (string_array[counter].Equals("*"))
                {
                        already_simplified_predicates++;
                }
            }
            if (already_simplified_predicates < string_array.Length - 2)
            {
                return true;
            }
            return false;
        }
        public bool checkIsPossibleToSimplify(string[] first_element, string[] second_element)
        {
            int same_elements_counter = 0;
            for (int counter = 0; counter < first_element.Length; counter++)
            {
                if (first_element[counter].Equals(second_element[counter]) || first_element[counter].Equals("*") )
                {
                    same_elements_counter++;
                }
            }
            if (same_elements_counter == first_element.Length - 1)
            {
                return true;
            }
            return false;
        }
        public List<string[]> getDistinctElements(List<string[]> list)
        {
            List<string[]> temp_list = new List<string[]>();
            bool add_first_time = false;
            for (int i = 0; i < list.Count; i++)
            {
                string[] current_item = list[i];
                if (!add_first_time)
                {
                    add_first_time = true;
                    temp_list.Add(current_item);
                }
                int is_present = 0;
                for (int ii = 0; ii < temp_list.Count; ii++)
                {
                    if (i != ii)
                    {
                        if (!checkIfElementsAreTheSame(current_item, temp_list[ii]))
                        {
                            is_present++;
                        }
                    }
                } 
                if (is_present == temp_list.Count)
                {
                    temp_list.Add(current_item);
                }
            }
            return temp_list;
        }
        public bool checkIfElementsAreTheSame(string[] first_element, string[] second_element)
        {
            if (first_element.Length == second_element.Length)
            {
                int counter = 0;
                for (int element_position = 0; element_position < first_element.Length; element_position++)
                {
                    if (first_element[element_position].Equals(second_element[element_position]))
                    {
                        counter++;
                    }
                }
                if (counter == first_element.Length)
                {
                    //Console.WriteLine("---all of the elements are the same");
                    return true;
                }
                return false;
            }
            //Console.WriteLine("elements not the same length");
            return false;
        }
    }
}
