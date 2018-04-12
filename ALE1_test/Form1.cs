using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE1_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reader reader = new Reader(text_box_input.Text);
            //cleaning the input
            string cleaned_string = reader.ProcessedInput;
            string binnary = "";

            //generating the truth table
            string[,] table = reader.generateTruthTableWithUniqueChars();
            //creating the array list for the simplifing 
            string[,] new_table_for_simplification = new string[table.GetLength(0), table.GetLength(1) + 1];
            //creating a data grid

            for (int row = 0; row < table.GetLength(0); row++)
            {
                string[] asd = new string[table.GetLength(1)];
                for (int i = 0; i < table.GetLength(1); i++)
                {
                    if (row != 0)
                    {
                        asd[i] = table[row, i];
                    }
                    new_table_for_simplification[row, i] = table[row, i];
                    if (i == table.GetLength(1) - 1)
                    {
                        new_table_for_simplification[row, new_table_for_simplification.GetLength(1) - 1] = cleaned_string;
                    }
                }
                if (row != 0)
                {
                    string new_proposition = reader.replaceUniquePredicates(cleaned_string, asd);
                    string value = Convert.ToInt16(new Proposition(new_proposition).calculate()).ToString();
                    binnary = value + binnary;
                    new_table_for_simplification[row, table.GetLength(1)] = value;
                }
            }


            generateTableInForm(new_table_for_simplification);

            string strHex = Convert.ToInt32(binnary, 2).ToString("X");
            text_box_output_hex.Text = strHex;

            Console.WriteLine("staring simplifing");
            Simplifyer simm = new Simplifyer();
            string[,] simplifyed_table = simm.getSimplifyedTruthTable(new_table_for_simplification);

            generateFormSimplifiedTable(simplifyed_table);


            Console.WriteLine("staring normalizator");

            //creating normalizer class
            Normalizator norm = new Normalizator(new_table_for_simplification, simplifyed_table);
            string norm_prop = norm.getDNFFromTruthTable();
            text_box_output_dnf.Text = norm_prop;

            Proposition prop1 = new Proposition(cleaned_string);

            text_box_output_nand.Text = prop1.getPropositionNANDFormat();

            string norm_prop_simplified = norm.getDNFFromSimplifiedTruthTable();
            text_box_output_dnf_simplified.Text = norm_prop_simplified;


            cleaned_string = norm_prop;
            binnary = "";
            table = reader.generateTruthTableWithUniqueChars();
            new_table_for_simplification = new string[table.GetLength(0), table.GetLength(1) + 1];
            Console.WriteLine("starting truth table from dnf");
            for (int row = 0; row < table.GetLength(0); row++)
            {
                string[] asd = new string[table.GetLength(1)];
                for (int i = 0; i < table.GetLength(1); i++)
                {
                    if (row != 0)
                    {
                        asd[i] = table[row, i];
                    }
                    new_table_for_simplification[row, i] = table[row, i];
                    if (i == table.GetLength(1) - 1)
                    {
                        new_table_for_simplification[row, new_table_for_simplification.GetLength(1) - 1] = cleaned_string;
                    }
                }
                if (row != 0)
                {
                    string new_proposition = reader.replaceUniquePredicates(cleaned_string, asd);
                    string value = Convert.ToInt16(new Proposition(new_proposition).calculate()).ToString();
                    binnary = value + binnary;
                    new_table_for_simplification[row, table.GetLength(1)] = value;
                }
            }
            generateFormDNFTable(new_table_for_simplification);
        }
        private void generateFormDNFTable(string[,] simplifyed_table)
        {
            DataTable data_table = new DataTable();
            for (int column = 0; column < simplifyed_table.GetLength(1); column++)
            {
                data_table.Columns.Add(simplifyed_table[0, column]);
            }
            for (int row = 1; row < simplifyed_table.GetLength(0); row++)
            {
                data_table.Rows.Add();
            }
            for (int row = 1; row < simplifyed_table.GetLength(0); row++)
            {
                for (int columns = 0; columns < simplifyed_table.GetLength(1); columns++)
                {
                    data_table.Rows[row - 1][columns] = simplifyed_table[row, columns];
                }
            }
            data_grid_truth_table_dnf.DataSource = data_table;
            formatTable(data_grid_truth_table_dnf, simplifyed_table.GetLength(1), simplifyed_table[0, simplifyed_table.GetLength(1) - 1]);
        }
        private void generateFormSimplifiedTable(string[,] simplifyed_table)
        {
            DataTable data_table = new DataTable();
            for (int column = 0; column < simplifyed_table.GetLength(1); column++)
            {
                data_table.Columns.Add(simplifyed_table[0, column]);
            }
            for (int row = 1; row < simplifyed_table.GetLength(0); row++)
            {
                data_table.Rows.Add();
            }
            for (int row = 1; row < simplifyed_table.GetLength(0); row++)
            {
                for (int columns = 0; columns < simplifyed_table.GetLength(1); columns++)
                {
                    data_table.Rows[row - 1][columns] = simplifyed_table[row, columns];
                }
            }
            data_grid_view_simplified_truth_table.DataSource = data_table;
            formatTable(data_grid_view_simplified_truth_table, simplifyed_table.GetLength(1), simplifyed_table[0, simplifyed_table.GetLength(1) - 1]);
        }

        private void generateTableInForm(string[,] new_table_for_simplification)
        {
            DataTable data_table = new DataTable();
            for (int column = 0; column < new_table_for_simplification.GetLength(1); column++)
            {
                data_table.Columns.Add(new_table_for_simplification[0, column]);
            }
            for (int row = 1; row < new_table_for_simplification.GetLength(0); row++)
            {
                data_table.Rows.Add();
            }
            for (int row = 1; row < new_table_for_simplification.GetLength(0); row++)
            {
                for (int columns = 0; columns < new_table_for_simplification.GetLength(1); columns++)
                {
                    data_table.Rows[row-1][columns] = new_table_for_simplification[row, columns];
                }
            }
            data_grid_view_truth_table.DataSource = data_table;
            formatTable(data_grid_view_truth_table, new_table_for_simplification.GetLength(1),new_table_for_simplification[0,new_table_for_simplification.GetLength(1)-1]);
        }
        private void formatTable(DataGridView data_grid,int iterator,string last_element)
        {
            for (int column = 0; column < iterator-1; column++)
            {
                data_grid.Columns[column].Width = 25;
            }
            int last_column_width = 0;
            foreach (char c in last_element)
            {
                last_column_width += 5;
            }
            if (last_column_width < 100)
            {
                last_column_width = 100;
            }
            data_grid.Columns[iterator - 1].Width = last_column_width;
        }
    }
}
