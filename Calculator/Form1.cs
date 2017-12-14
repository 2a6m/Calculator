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

        private List<string> Calculs = new List<string>();
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
            string txt = "";
            // find the function with this name
            txt += String.Format("{0}({1})", FunctionBox.Text, string.Join(";", this.functionmanager.SearchFunction(FunctionBox.Text)[0].ParametersName));
            InputBox.Text = txt;
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            // method to write HELP message
            Function<string> fct = functionmanager.SearchFunction(FunctionBox.Text)[0];
            string txtHelp = fct.HelpMessage;
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
            foreach (string Cal in this.Calculs)
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

        private List<string> Cut(string s, Regex rg)
        {
            List<string> args0 = new List<string>();
            Match m = rg.Match(s);

            if (m.Success)
            {
                // if we find an another function, we restart the process of Analyse (here is the recursivity)
                args0.Add(Analyse(s));
            }
            else
            {
                // we split the string with the first character ;
                string[] args = s.Split(new char[] { ';' }, 2);
                if (args.Length == 2)
                    foreach (string arg in args)
                    {
                        // we ask to look if we could cut the two parts received
                        args0.AddRange(Cut(arg, rg));
                    }
                else
                {
                    // if it was just an argument, we return it so it could be added to the list
                    args0.Add(args[0]);
                }
            }

            // if it was just an argument, we return it so it could be added to the list
            return args0;
        }

        private string Analyse(string s)
        {
            // create the regex with the list of function in the dll loaded
            List<string> nfct = new List<String>();
            foreach (IFunction fct in this.functionmanager.FunctionList)
            {
                nfct.Add(fct.Name);
            }
            string fcttxt = string.Join("|", nfct.ToArray());


            string rgstr = string.Format(@"^(?<fct>({0}))\((?<args>.*)\)$", fcttxt);
            Regex rg = new Regex(rgstr);

            Match m = rg.Match(s);

            // if there is a match, we seperate the fct and the args
            if (m.Success)
            {
                string fctname = m.Groups["fct"].Value;

                // we cut the args
                string[] args = this.Cut(m.Groups["args"].Value, rg).ToArray();
                
                // we find the function with his name
                Function<string> function = this.functionmanager.SearchFunction(fctname)[0];

                // we compute and we add it to the list
                string ans = function.Evaluate(args).ToString();
                string cal = string.Format("{0}{1}>{2}{3}{4}", s, System.Environment.NewLine, ans, System.Environment.NewLine, System.Environment.NewLine);
                this.Calculs.Add(cal);

                // there are returns for the recursivity of the function
                return ans;
            }
            return "";
        }
        // 
    }
}
