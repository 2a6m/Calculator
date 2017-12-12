namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ShowBox = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ComputeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.FunctionButton = new System.Windows.Forms.Button();
            this.FunctionBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.ShowBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.InputBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FunctionBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.31503F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.684976F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 522);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ShowBox
            // 
            this.ShowBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowBox.Location = new System.Drawing.Point(2, 2);
            this.ShowBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShowBox.Multiline = true;
            this.ShowBox.Name = "ShowBox";
            this.ShowBox.ReadOnly = true;
            this.ShowBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ShowBox.Size = new System.Drawing.Size(381, 493);
            this.ShowBox.TabIndex = 0;
            this.ShowBox.TextChanged += new System.EventHandler(this.ShowBox_TextChanged);
            // 
            // InputBox
            // 
            this.InputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputBox.Location = new System.Drawing.Point(2, 499);
            this.InputBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(381, 20);
            this.InputBox.TabIndex = 1;
            this.InputBox.TextChanged += new System.EventHandler(this.InputBox_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.ComputeButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.SaveButton, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.LoadButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.HelpButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FunctionButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(387, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(161, 493);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ComputeButton
            // 
            this.ComputeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComputeButton.Location = new System.Drawing.Point(2, 394);
            this.ComputeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComputeButton.Name = "ComputeButton";
            this.ComputeButton.Size = new System.Drawing.Size(157, 97);
            this.ComputeButton.TabIndex = 4;
            this.ComputeButton.Text = "Compute";
            this.ComputeButton.UseVisualStyleBackColor = true;
            this.ComputeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveButton.Location = new System.Drawing.Point(2, 296);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(157, 94);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadButton.Location = new System.Drawing.Point(2, 198);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(157, 94);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpButton.Location = new System.Drawing.Point(2, 100);
            this.HelpButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(157, 94);
            this.HelpButton.TabIndex = 1;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // FunctionButton
            // 
            this.FunctionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionButton.Location = new System.Drawing.Point(2, 2);
            this.FunctionButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FunctionButton.Name = "FunctionButton";
            this.FunctionButton.Size = new System.Drawing.Size(157, 94);
            this.FunctionButton.TabIndex = 0;
            this.FunctionButton.Text = "Function";
            this.FunctionButton.UseVisualStyleBackColor = true;
            this.FunctionButton.Click += new System.EventHandler(this.FunctionButton_Click);
            // 
            // FunctionBox
            // 
            this.FunctionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionBox.FormattingEnabled = true;
            this.FunctionBox.Location = new System.Drawing.Point(387, 499);
            this.FunctionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FunctionBox.Name = "FunctionBox";
            this.FunctionBox.Size = new System.Drawing.Size(161, 21);
            this.FunctionBox.TabIndex = 3;
            this.FunctionBox.SelectedIndexChanged += new System.EventHandler(this.FunctionBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox ShowBox;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ComputeButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button FunctionButton;
        private System.Windows.Forms.ComboBox FunctionBox;
    }
}

