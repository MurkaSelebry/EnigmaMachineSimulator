namespace Enigma2
{
    partial class SettingsForm
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
            this.oneRing = new System.Windows.Forms.DomainUpDown();
            this.comboBoxReflector = new System.Windows.Forms.ComboBox();
            this.useCustomReflector = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.twoRing = new System.Windows.Forms.DomainUpDown();
            this.threeRing = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxReflector = new System.Windows.Forms.TextBox();
            this.trackBarSound = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.rotor1 = new System.Windows.Forms.ComboBox();
            this.rotor2 = new System.Windows.Forms.ComboBox();
            this.rotor3 = new System.Windows.Forms.ComboBox();
            this.fourRing = new System.Windows.Forms.DomainUpDown();
            this.rotor4 = new System.Windows.Forms.ComboBox();
            this.useM4 = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.checkBoxCopy = new System.Windows.Forms.CheckBox();
            this.textBoxGroups = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new Enigma2.ELabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSound)).BeginInit();
            this.SuspendLayout();
            // 
            // oneRing
            // 
            this.oneRing.Items.Add("Z");
            this.oneRing.Items.Add("A");
            this.oneRing.Items.Add("B");
            this.oneRing.Items.Add("C");
            this.oneRing.Items.Add("D");
            this.oneRing.Items.Add("E");
            this.oneRing.Items.Add("F");
            this.oneRing.Items.Add("G");
            this.oneRing.Items.Add("H");
            this.oneRing.Items.Add("I");
            this.oneRing.Items.Add("J");
            this.oneRing.Items.Add("K");
            this.oneRing.Items.Add("L");
            this.oneRing.Items.Add("M");
            this.oneRing.Items.Add("O");
            this.oneRing.Items.Add("P");
            this.oneRing.Items.Add("Q");
            this.oneRing.Items.Add("R");
            this.oneRing.Items.Add("S");
            this.oneRing.Items.Add("T");
            this.oneRing.Items.Add("U");
            this.oneRing.Items.Add("V");
            this.oneRing.Items.Add("W");
            this.oneRing.Items.Add("X");
            this.oneRing.Items.Add("Y");
            this.oneRing.Items.Add("Z");
            this.oneRing.Items.Add("A");
            this.oneRing.Location = new System.Drawing.Point(59, 24);
            this.oneRing.Name = "oneRing";
            this.oneRing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.oneRing.Size = new System.Drawing.Size(42, 20);
            this.oneRing.TabIndex = 0;
            this.oneRing.Text = "A";
            this.oneRing.SelectedItemChanged += new System.EventHandler(this.oneRing_SelectedItemChanged);
            // 
            // comboBoxReflector
            // 
            this.comboBoxReflector.FormattingEnabled = true;
            this.comboBoxReflector.Items.AddRange(new object[] {
            "B - YRUHQSLDPXNGOKMIEBFZCWVJAT",
            "C - FVPJIAOYEDRZXWGCTKUQSBNMHL",
            "BThin - ENKQAUYWJICOPBLMDXZVFTHRGS",
            "CThin - RDOBJNTKVEHMLFCWZAXGYIPSUQ"});
            this.comboBoxReflector.Location = new System.Drawing.Point(12, 95);
            this.comboBoxReflector.Name = "comboBoxReflector";
            this.comboBoxReflector.Size = new System.Drawing.Size(463, 21);
            this.comboBoxReflector.TabIndex = 1;
            this.comboBoxReflector.Text = "B - YRUHQSLDPXNGOKMIEBFZCWVJAT";
            // 
            // useCustomReflector
            // 
            this.useCustomReflector.AutoSize = true;
            this.useCustomReflector.Location = new System.Drawing.Point(12, 72);
            this.useCustomReflector.Name = "useCustomReflector";
            this.useCustomReflector.Size = new System.Drawing.Size(64, 17);
            this.useCustomReflector.TabIndex = 2;
            this.useCustomReflector.Text = "Custom:";
            this.useCustomReflector.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ring:";
            // 
            // twoRing
            // 
            this.twoRing.Items.Add("Z");
            this.twoRing.Items.Add("A");
            this.twoRing.Items.Add("B");
            this.twoRing.Items.Add("C");
            this.twoRing.Items.Add("D");
            this.twoRing.Items.Add("E");
            this.twoRing.Items.Add("F");
            this.twoRing.Items.Add("G");
            this.twoRing.Items.Add("H");
            this.twoRing.Items.Add("I");
            this.twoRing.Items.Add("J");
            this.twoRing.Items.Add("K");
            this.twoRing.Items.Add("L");
            this.twoRing.Items.Add("M");
            this.twoRing.Items.Add("O");
            this.twoRing.Items.Add("P");
            this.twoRing.Items.Add("Q");
            this.twoRing.Items.Add("R");
            this.twoRing.Items.Add("S");
            this.twoRing.Items.Add("T");
            this.twoRing.Items.Add("U");
            this.twoRing.Items.Add("V");
            this.twoRing.Items.Add("W");
            this.twoRing.Items.Add("X");
            this.twoRing.Items.Add("Y");
            this.twoRing.Items.Add("Z");
            this.twoRing.Items.Add("A");
            this.twoRing.Location = new System.Drawing.Point(107, 24);
            this.twoRing.Name = "twoRing";
            this.twoRing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.twoRing.Size = new System.Drawing.Size(42, 20);
            this.twoRing.TabIndex = 4;
            this.twoRing.Text = "A";
            this.twoRing.SelectedItemChanged += new System.EventHandler(this.twoRing_SelectedItemChanged);
            // 
            // threeRing
            // 
            this.threeRing.Items.Add("Z");
            this.threeRing.Items.Add("A");
            this.threeRing.Items.Add("B");
            this.threeRing.Items.Add("C");
            this.threeRing.Items.Add("D");
            this.threeRing.Items.Add("E");
            this.threeRing.Items.Add("F");
            this.threeRing.Items.Add("G");
            this.threeRing.Items.Add("H");
            this.threeRing.Items.Add("I");
            this.threeRing.Items.Add("J");
            this.threeRing.Items.Add("K");
            this.threeRing.Items.Add("L");
            this.threeRing.Items.Add("M");
            this.threeRing.Items.Add("O");
            this.threeRing.Items.Add("P");
            this.threeRing.Items.Add("Q");
            this.threeRing.Items.Add("R");
            this.threeRing.Items.Add("S");
            this.threeRing.Items.Add("T");
            this.threeRing.Items.Add("U");
            this.threeRing.Items.Add("V");
            this.threeRing.Items.Add("W");
            this.threeRing.Items.Add("X");
            this.threeRing.Items.Add("Y");
            this.threeRing.Items.Add("Z");
            this.threeRing.Items.Add("A");
            this.threeRing.Location = new System.Drawing.Point(155, 24);
            this.threeRing.Name = "threeRing";
            this.threeRing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.threeRing.Size = new System.Drawing.Size(42, 20);
            this.threeRing.TabIndex = 5;
            this.threeRing.Text = "A";
            this.threeRing.SelectedItemChanged += new System.EventHandler(this.threeRing_SelectedItemChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reflector:";
            // 
            // textBoxReflector
            // 
            this.textBoxReflector.Location = new System.Drawing.Point(79, 69);
            this.textBoxReflector.Name = "textBoxReflector";
            this.textBoxReflector.Size = new System.Drawing.Size(396, 20);
            this.textBoxReflector.TabIndex = 7;
            // 
            // trackBarSound
            // 
            this.trackBarSound.LargeChange = 1;
            this.trackBarSound.Location = new System.Drawing.Point(515, 1);
            this.trackBarSound.Name = "trackBarSound";
            this.trackBarSound.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSound.Size = new System.Drawing.Size(45, 123);
            this.trackBarSound.TabIndex = 8;
            this.trackBarSound.Value = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rotors:";
            // 
            // rotor1
            // 
            this.rotor1.FormattingEnabled = true;
            this.rotor1.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII"});
            this.rotor1.Location = new System.Drawing.Point(316, 24);
            this.rotor1.Name = "rotor1";
            this.rotor1.Size = new System.Drawing.Size(49, 21);
            this.rotor1.TabIndex = 11;
            this.rotor1.Text = "I";
            // 
            // rotor2
            // 
            this.rotor2.FormattingEnabled = true;
            this.rotor2.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII"});
            this.rotor2.Location = new System.Drawing.Point(371, 24);
            this.rotor2.Name = "rotor2";
            this.rotor2.Size = new System.Drawing.Size(49, 21);
            this.rotor2.TabIndex = 12;
            this.rotor2.Text = "II";
            // 
            // rotor3
            // 
            this.rotor3.FormattingEnabled = true;
            this.rotor3.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII"});
            this.rotor3.Location = new System.Drawing.Point(426, 24);
            this.rotor3.Name = "rotor3";
            this.rotor3.Size = new System.Drawing.Size(49, 21);
            this.rotor3.TabIndex = 13;
            this.rotor3.Text = "III";
            // 
            // fourRing
            // 
            this.fourRing.BackColor = System.Drawing.Color.Salmon;
            this.fourRing.Items.Add("Z");
            this.fourRing.Items.Add("A");
            this.fourRing.Items.Add("B");
            this.fourRing.Items.Add("C");
            this.fourRing.Items.Add("D");
            this.fourRing.Items.Add("E");
            this.fourRing.Items.Add("F");
            this.fourRing.Items.Add("G");
            this.fourRing.Items.Add("H");
            this.fourRing.Items.Add("I");
            this.fourRing.Items.Add("J");
            this.fourRing.Items.Add("K");
            this.fourRing.Items.Add("L");
            this.fourRing.Items.Add("M");
            this.fourRing.Items.Add("O");
            this.fourRing.Items.Add("P");
            this.fourRing.Items.Add("Q");
            this.fourRing.Items.Add("R");
            this.fourRing.Items.Add("S");
            this.fourRing.Items.Add("T");
            this.fourRing.Items.Add("U");
            this.fourRing.Items.Add("V");
            this.fourRing.Items.Add("W");
            this.fourRing.Items.Add("X");
            this.fourRing.Items.Add("Y");
            this.fourRing.Items.Add("Z");
            this.fourRing.Items.Add("A");
            this.fourRing.Location = new System.Drawing.Point(12, 24);
            this.fourRing.Name = "fourRing";
            this.fourRing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fourRing.Size = new System.Drawing.Size(42, 20);
            this.fourRing.TabIndex = 14;
            this.fourRing.Text = "A";
            // 
            // rotor4
            // 
            this.rotor4.BackColor = System.Drawing.Color.Salmon;
            this.rotor4.FormattingEnabled = true;
            this.rotor4.Items.AddRange(new object[] {
            "Beta",
            "Gamma"});
            this.rotor4.Location = new System.Drawing.Point(241, 24);
            this.rotor4.Name = "rotor4";
            this.rotor4.Size = new System.Drawing.Size(69, 21);
            this.rotor4.TabIndex = 15;
            this.rotor4.Text = "Beta";
            // 
            // useM4
            // 
            this.useM4.AutoSize = true;
            this.useM4.Location = new System.Drawing.Point(241, 47);
            this.useM4.Name = "useM4";
            this.useM4.Size = new System.Drawing.Size(45, 17);
            this.useM4.TabIndex = 16;
            this.useM4.Text = "Use";
            this.useM4.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 129);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(62, 21);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(79, 129);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(62, 21);
            this.buttonOpen.TabIndex = 18;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // checkBoxCopy
            // 
            this.checkBoxCopy.AutoSize = true;
            this.checkBoxCopy.Checked = true;
            this.checkBoxCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCopy.Location = new System.Drawing.Point(265, 132);
            this.checkBoxCopy.Name = "checkBoxCopy";
            this.checkBoxCopy.Size = new System.Drawing.Size(58, 17);
            this.checkBoxCopy.TabIndex = 19;
            this.checkBoxCopy.Text = "Group:";
            this.checkBoxCopy.UseVisualStyleBackColor = true;
            // 
            // textBoxGroups
            // 
            this.textBoxGroups.Location = new System.Drawing.Point(323, 129);
            this.textBoxGroups.Name = "textBoxGroups";
            this.textBoxGroups.Size = new System.Drawing.Size(63, 20);
            this.textBoxGroups.TabIndex = 20;
            this.textBoxGroups.Text = "4";
            this.textBoxGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxGroups.TextChanged += new System.EventHandler(this.textBoxGroups_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 21;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 22;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 33);
            this.label3.Name = "label3";
            this.label3.NewText = "Volume";
            this.label3.RotateAngle = -90;
            this.label3.Size = new System.Drawing.Size(31, 91);
            this.label3.TabIndex = 9;
            this.label3.Text = "        \r\n        \r\n        \r\n        \r\n        \r\n        \r\n    ";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 156);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxGroups);
            this.Controls.Add(this.checkBoxCopy);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.useM4);
            this.Controls.Add(this.rotor4);
            this.Controls.Add(this.fourRing);
            this.Controls.Add(this.rotor3);
            this.Controls.Add(this.rotor2);
            this.Controls.Add(this.rotor1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarSound);
            this.Controls.Add(this.textBoxReflector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.threeRing);
            this.Controls.Add(this.twoRing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useCustomReflector);
            this.Controls.Add(this.comboBoxReflector);
            this.Controls.Add(this.oneRing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DomainUpDown oneRing;
        private System.Windows.Forms.ComboBox comboBoxReflector;
        private System.Windows.Forms.CheckBox useCustomReflector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown twoRing;
        private System.Windows.Forms.DomainUpDown threeRing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxReflector;
        private System.Windows.Forms.TrackBar trackBarSound;
        private ELabel label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox rotor1;
        private System.Windows.Forms.ComboBox rotor2;
        private System.Windows.Forms.ComboBox rotor3;
        private System.Windows.Forms.DomainUpDown fourRing;
        private System.Windows.Forms.ComboBox rotor4;
        private System.Windows.Forms.CheckBox useM4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.CheckBox checkBoxCopy;
        private System.Windows.Forms.TextBox textBoxGroups;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}