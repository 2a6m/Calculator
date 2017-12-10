using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private string txtInput;
        private string txtOutput;

        private void ShowBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            txtInput = InputBox.Text;
        }

        private void FunctionButton_Click(object sender, EventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            Compute Calcul = new Compute(txtInput);
            this.Calculs.Add(Calcul);

            // Create the text for output in ShowBox
            this.txtOutput = "";
            foreach (Compute Cal in this.Calculs)
            {
                this.txtOutput += Cal.ToString();
                this.txtOutput += System.Environment.NewLine;
                this.txtOutput += System.Environment.NewLine;
            }

            // Write text in ShowBox
            ShowBox.Text = this.txtOutput;
        }

        private void FunctionBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
