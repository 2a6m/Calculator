using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperComputer;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private FunctionManager functionmanager;

        public Form1()
        {
            this.functionmanager = new FunctionManager();
            InitializeComponent();
            this.UpdateFromFunctionManager();
        }

        private List<Compute> Calculs = new List<Compute>();
        private string txtInput = "";
        private string txtOutput = "";
        private List<Object> Functions = new List<Object>(); // liste contenant les dll 

        
    // Output

        private void ShowBox_TextChanged(object sender, EventArgs e)
        {
            // textbox to show all the compute
        }   


    // Buttons


        private void FunctionButton_Click(object sender, EventArgs e)
        {
            
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            // method to write HELP message
            string txtHelp = "HELP";
            MessageBox.Show(txtHelp, "Help", MessageBoxButtons.OK);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // find DLL files and load them

            OpenFileDialog LoadFileDialog = new OpenFileDialog();

            string path = Directory.GetCurrentDirectory();
            LoadFileDialog.InitialDirectory = path;
            LoadFileDialog.Filter = "dll files (*.dll)|*.dll";

            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream File = LoadFileDialog.OpenFile();
                this.Functions.Add(File);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // save txtOutput in a file.txt
            string Path = (@"Calculate.txt");
            System.IO.File.WriteAllText(Path, this.txtOutput);

            MessageBox.Show("Successfully Saved", "Save", MessageBoxButtons.OK);
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

    // Input

        //InputBox

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            // txtbox to input compute to make
            txtInput = InputBox.Text;
        }

        // FunctionBox

        private void FunctionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When selecting a function in the combo box, it writes it in the input command
            InputBox.Text = FunctionBox.Text;
        }

        private void UpdateFromFunctionManager()
        {
            //Create a item in the FunctionBox for every function FunctionManager has
            FunctionBox.Items.Clear();
            foreach(IFunction fct in this.functionmanager.FunctionList)
            {
                string s = fct.Name;
                FunctionBox.Items.Add(s);
            }
            
        }

    // Computing 

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
                MessageBox.Show("Calcul mal écrit.","ERROR");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //
            string Path = (@"Calculate.txt");
            System.IO.File.WriteAllText(Path, this.txtOutput);
        }

        // 
    }
}
