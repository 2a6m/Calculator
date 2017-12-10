using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Compute> Calculs = new List<Compute>();
        private string txtInput = "";
        private string txtOutput = "";

        private void ShowBox_TextChanged(object sender, EventArgs e)
        {
            // textbox to show all the compute
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            // txtbox to input compute to make
            txtInput = InputBox.Text;
        }

        private void FunctionButton_Click(object sender, EventArgs e)
        {
            // apply the choosen function
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            // method to write HELP message
            string txtHelp = "HELP";
            MessageBox.Show(txtHelp, "Help", MessageBoxButtons.OK);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // find files dll and load it
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // save txtOutput in a file.txt
            string Path = (@"Calculate.txt");
            System.IO.File.WriteAllText(Path, this.txtOutput);

            MessageBox.Show("Saved Successfully", "Save", MessageBoxButtons.OK);
        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            if (txtInput.Length > 0)
            {
                this.Analyse(txtInput);
            }

            // create the text for output in ShowBox
            this.txtOutput = "";
            foreach (Compute Cal in this.Calculs)
            {
                this.txtOutput += Cal.ToString();
            }

            // write text in ShowBox
            ShowBox.Text = this.txtOutput;
        }

        private void FunctionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show all the different function loaded
        }

        private void Analyse(string s)
        {
            Regex rg = new Regex(@"^\s*(?<int1>([+-]?\d+)|([+-]?\d+[.,]{1}[+-]?\d+))\s*(?<operator>[/*+-]{1})\s*(?<int2>([+-]?\d+)|([+-]?\d+[.,]{1}[+-]?\d+))\s*$");
            Match m = rg.Match(s);

            if (m.Success)
            {
                float int1 = float.Parse(m.Groups["int1"].Value);
                float int2 = float.Parse(m.Groups["int2"].Value);

                Compute Cal = new Compute(int1, int2, m.Groups["operator"].Value);

                this.Calculs.Add(Cal);
            }
            else
            {
                MessageBox.Show("[ERROR]: Calcul mal écrit.");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string Path = (@"Calculate.txt");
            System.IO.File.WriteAllText(Path, this.txtOutput);
        }
    }
}
