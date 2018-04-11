namespace ALE1_test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_trigger = new System.Windows.Forms.Button();
            this.text_box_input = new System.Windows.Forms.TextBox();
            this.data_grid_view_truth_table = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data_grid_view_simplified_truth_table = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.text_box_output_hex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_box_output_dnf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.text_box_output_dnf_simplified = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_box_output_nand = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.data_grid_truth_table_dnf = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_truth_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_simplified_truth_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_truth_table_dnf)).BeginInit();
            this.SuspendLayout();
            // 
            // button_trigger
            // 
            this.button_trigger.Location = new System.Drawing.Point(1036, 12);
            this.button_trigger.Name = "button_trigger";
            this.button_trigger.Size = new System.Drawing.Size(112, 23);
            this.button_trigger.TabIndex = 0;
            this.button_trigger.Text = "Process";
            this.button_trigger.UseVisualStyleBackColor = true;
            this.button_trigger.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_box_input
            // 
            this.text_box_input.Location = new System.Drawing.Point(110, 12);
            this.text_box_input.Name = "text_box_input";
            this.text_box_input.Size = new System.Drawing.Size(920, 20);
            this.text_box_input.TabIndex = 1;
            this.text_box_input.Text = ">(a,B) ";
            this.text_box_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // data_grid_view_truth_table
            // 
            this.data_grid_view_truth_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_truth_table.Location = new System.Drawing.Point(16, 176);
            this.data_grid_view_truth_table.Name = "data_grid_view_truth_table";
            this.data_grid_view_truth_table.Size = new System.Drawing.Size(1132, 183);
            this.data_grid_view_truth_table.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Truth Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Simplified Truth Table";
            // 
            // data_grid_view_simplified_truth_table
            // 
            this.data_grid_view_simplified_truth_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_simplified_truth_table.Location = new System.Drawing.Point(16, 377);
            this.data_grid_view_simplified_truth_table.Name = "data_grid_view_simplified_truth_table";
            this.data_grid_view_simplified_truth_table.Size = new System.Drawing.Size(1132, 191);
            this.data_grid_view_simplified_truth_table.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Logic Proposition:";
            // 
            // text_box_output_hex
            // 
            this.text_box_output_hex.Location = new System.Drawing.Point(110, 43);
            this.text_box_output_hex.Name = "text_box_output_hex";
            this.text_box_output_hex.Size = new System.Drawing.Size(920, 20);
            this.text_box_output_hex.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hex:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "DNF:";
            // 
            // text_box_output_dnf
            // 
            this.text_box_output_dnf.Location = new System.Drawing.Point(110, 73);
            this.text_box_output_dnf.Name = "text_box_output_dnf";
            this.text_box_output_dnf.Size = new System.Drawing.Size(920, 20);
            this.text_box_output_dnf.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "DNF simplified:";
            // 
            // text_box_output_dnf_simplified
            // 
            this.text_box_output_dnf_simplified.Location = new System.Drawing.Point(110, 102);
            this.text_box_output_dnf_simplified.Name = "text_box_output_dnf_simplified";
            this.text_box_output_dnf_simplified.Size = new System.Drawing.Size(920, 20);
            this.text_box_output_dnf_simplified.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "NAND:";
            // 
            // text_box_output_nand
            // 
            this.text_box_output_nand.Location = new System.Drawing.Point(110, 131);
            this.text_box_output_nand.Name = "text_box_output_nand";
            this.text_box_output_nand.Size = new System.Drawing.Size(920, 20);
            this.text_box_output_nand.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 568);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Truth Table From DNF";
            // 
            // data_grid_truth_table_dnf
            // 
            this.data_grid_truth_table_dnf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_truth_table_dnf.Location = new System.Drawing.Point(16, 584);
            this.data_grid_truth_table_dnf.Name = "data_grid_truth_table_dnf";
            this.data_grid_truth_table_dnf.Size = new System.Drawing.Size(1132, 168);
            this.data_grid_truth_table_dnf.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 759);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.data_grid_truth_table_dnf);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text_box_output_nand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_box_output_dnf_simplified);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_box_output_dnf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_box_output_hex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.data_grid_view_simplified_truth_table);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data_grid_view_truth_table);
            this.Controls.Add(this.text_box_input);
            this.Controls.Add(this.button_trigger);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_truth_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_simplified_truth_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_truth_table_dnf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_trigger;
        private System.Windows.Forms.TextBox text_box_input;
        private System.Windows.Forms.DataGridView data_grid_view_truth_table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView data_grid_view_simplified_truth_table;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_box_output_hex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_box_output_dnf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_box_output_dnf_simplified;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_box_output_nand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView data_grid_truth_table_dnf;
    }
}

