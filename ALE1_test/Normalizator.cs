using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1_test
{
    public class Normalizator
    {
        private string[,] input;

        public string[,] truth_array
        {
            get { return input; }
            set { input = value; }
        }
        private string[,] simplifiedarray;

	    public string[,] simplified_array
	    {
		    get { return simplifiedarray;}
		    set { simplifiedarray = value;}
	    }
	
        public Normalizator(string[,] truth_array,string[,] simplified_array)
        {
            this.input = truth_array;
            this.simplifiedarray = simplified_array;
        }
        public string getDNFFromTruthTable()
        {
            string new_proposition_master = "";
            bool first_time = true;
            //looping trught  the table's rows
            for (int truth_table_row_iterator = 1; truth_table_row_iterator < truth_array.GetLength(0); truth_table_row_iterator++)
            {
                if (truth_array.GetLength(1) - 1 > 1)
                {
                    //checking if the combination's result is 1
                    if (truth_array[truth_table_row_iterator, truth_array.GetLength(1) - 1].Equals("1"))
                    {
                        string new_proposition = "";
                        string new_predicate = "";
                        for (int truth_table_column_iterator = 0; truth_table_column_iterator < truth_array.GetLength(1) - 1; truth_table_column_iterator++)
                        {
                            if (truth_array[truth_table_row_iterator, truth_table_column_iterator].Equals("0"))
                            {
                                new_predicate = "~(" + truth_array[0, truth_table_column_iterator] + ")";
                            }
                            else
                            {
                                new_predicate = truth_array[0, truth_table_column_iterator];
                            }
                            if (truth_table_column_iterator > 0)
                            {
                                new_proposition = "&(" + new_proposition + "," + new_predicate + ")";
                            }
                            else
                            {
                                new_proposition += new_predicate;
                            }
                        }
                        if (!first_time)
                        {
                            new_proposition_master = "|(" + new_proposition_master + "," + new_proposition + ")";
                        }
                        else
                        {
                            new_proposition_master += new_proposition;
                            first_time = false;
                        }
                    }
                }
            }
            return new_proposition_master;
        }
        public string getDNFFromSimplifiedTruthTable()
        {
            string new_proposition_master = "";
            bool first_time = true;
            //looping trught  the table's rows
            for (int truth_table_row_iterator = 1; truth_table_row_iterator < simplified_array.GetLength(0); truth_table_row_iterator++)
            {
                if (simplified_array.GetLength(1) - 1 > 1)
                {
                    //checking if the combination's result is 1
                    if (simplified_array[truth_table_row_iterator, simplified_array.GetLength(1) - 1].Equals("1"))
                    {
                        string new_proposition = "";
                        string new_predicate = "";
                        bool fisrt_time_predicate = true;
                        for (int truth_table_column_iterator = 0; truth_table_column_iterator < simplified_array.GetLength(1) - 1; truth_table_column_iterator++)
                        {
                            bool temp = false;
                            if (simplified_array[truth_table_row_iterator, truth_table_column_iterator].Equals("0"))
                            {
                                new_predicate = "~(" + simplified_array[0, truth_table_column_iterator] + ")";
                                temp = true;
                            }
                            else if (simplified_array[truth_table_row_iterator, truth_table_column_iterator].Equals("1"))
                            {
                                new_predicate = simplified_array[0, truth_table_column_iterator];
                                temp = true;
                            }
                            if (temp)
                            {
                                if (!fisrt_time_predicate)
                                {
                                    new_proposition = "&(" + new_proposition + "," + new_predicate + ")";
                                }
                                else
                                {
                                    new_proposition += new_predicate;
                                    fisrt_time_predicate = false;
                                }
                            }
                        }
                        if (!first_time)
                        {
                            new_proposition_master = "|(" + new_proposition_master + "," + new_proposition + ")";
                        }
                        else
                        {
                            new_proposition_master += new_proposition;
                            first_time = false;
                        }
                    }
                }
            }
            return new_proposition_master;
        }
    }
}
