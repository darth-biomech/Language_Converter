namespace Language_Converter
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.DicPathString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenDictionaryDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenDic = new System.Windows.Forms.Button();
            this.inputTextField = new System.Windows.Forms.TextBox();
            this.startConversionBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.wordsList = new System.Windows.Forms.ListBox();
            this.butAddWord = new System.Windows.Forms.Button();
            this.butEditWord = new System.Windows.Forms.Button();
            this.curWordAlienField = new System.Windows.Forms.TextBox();
            this.curWordMRuField = new System.Windows.Forms.TextBox();
            this.curWordMEnField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.wordnumber = new System.Windows.Forms.TextBox();
            this.replaceLettersCheckbox = new System.Windows.Forms.CheckBox();
            this.buttonSaveDictionary = new System.Windows.Forms.Button();
            this.saveCopyCheckbox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.languageSelectionBox = new System.Windows.Forms.ComboBox();
            this.wikiFormatCheck = new System.Windows.Forms.CheckBox();
            this.midPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.outputTextField = new System.Windows.Forms.TextBox();
            this.conflictLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.midPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DicPathString
            // 
            this.DicPathString.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.DicPathString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DicPathString.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.DicPathString.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.DicPathString.Location = new System.Drawing.Point(38, 25);
            this.DicPathString.Margin = new System.Windows.Forms.Padding(2);
            this.DicPathString.Multiline = true;
            this.DicPathString.Name = "DicPathString";
            this.DicPathString.Size = new System.Drawing.Size(306, 26);
            this.DicPathString.TabIndex = 6;
            this.DicPathString.Text = "c:\\";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dictionary file";
            // 
            // buttonOpenDic
            // 
            this.buttonOpenDic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDic.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonOpenDic.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.buttonOpenDic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonOpenDic.Location = new System.Drawing.Point(0, 25);
            this.buttonOpenDic.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOpenDic.Name = "buttonOpenDic";
            this.buttonOpenDic.Size = new System.Drawing.Size(32, 26);
            this.buttonOpenDic.TabIndex = 2;
            this.buttonOpenDic.Text = "···";
            this.buttonOpenDic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonOpenDic.UseVisualStyleBackColor = false;
            this.buttonOpenDic.Click += new System.EventHandler(this.buttonOpenDic_Click);
            // 
            // inputTextField
            // 
            this.inputTextField.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.inputTextField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTextField.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.inputTextField.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.inputTextField.Location = new System.Drawing.Point(20, 82);
            this.inputTextField.Margin = new System.Windows.Forms.Padding(2);
            this.inputTextField.Multiline = true;
            this.inputTextField.Name = "inputTextField";
            this.inputTextField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextField.Size = new System.Drawing.Size(480, 109);
            this.inputTextField.TabIndex = 0;
            // 
            // startConversionBtn
            // 
            this.startConversionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startConversionBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.startConversionBtn.Location = new System.Drawing.Point(2, 0);
            this.startConversionBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startConversionBtn.Name = "startConversionBtn";
            this.startConversionBtn.Size = new System.Drawing.Size(118, 37);
            this.startConversionBtn.TabIndex = 2;
            this.startConversionBtn.Text = "TRANSLATE";
            this.startConversionBtn.UseVisualStyleBackColor = true;
            this.startConversionBtn.Click += new System.EventHandler(this.startConversionBtn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(0, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Input text";
            // 
            // wordsList
            // 
            this.wordsList.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.wordsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wordsList.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.wordsList.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.wordsList.FormattingEnabled = true;
            this.wordsList.ItemHeight = 14;
            this.wordsList.Items.AddRange(new object[] {"etc", "One", "two"});
            this.wordsList.Location = new System.Drawing.Point(512, 10);
            this.wordsList.Margin = new System.Windows.Forms.Padding(2);
            this.wordsList.Name = "wordsList";
            this.wordsList.ScrollAlwaysVisible = true;
            this.wordsList.Size = new System.Drawing.Size(322, 184);
            this.wordsList.TabIndex = 9;
            this.wordsList.SelectedIndexChanged += new System.EventHandler(this.wordsList_SelectedIndexChanged);
            // 
            // butAddWord
            // 
            this.butAddWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddWord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.butAddWord.Location = new System.Drawing.Point(2, 6);
            this.butAddWord.Margin = new System.Windows.Forms.Padding(2);
            this.butAddWord.Name = "butAddWord";
            this.butAddWord.Size = new System.Drawing.Size(123, 25);
            this.butAddWord.TabIndex = 10;
            this.butAddWord.Text = "Add new word";
            this.butAddWord.UseVisualStyleBackColor = true;
            this.butAddWord.Click += new System.EventHandler(this.buttAddWord_Click);
            // 
            // butEditWord
            // 
            this.butEditWord.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butEditWord.Enabled = false;
            this.butEditWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEditWord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.butEditWord.Location = new System.Drawing.Point(209, 6);
            this.butEditWord.Margin = new System.Windows.Forms.Padding(2);
            this.butEditWord.Name = "butEditWord";
            this.butEditWord.Size = new System.Drawing.Size(109, 25);
            this.butEditWord.TabIndex = 11;
            this.butEditWord.Text = "Modify word";
            this.butEditWord.UseVisualStyleBackColor = true;
            this.butEditWord.Click += new System.EventHandler(this.butEditWord_Click);
            // 
            // curWordAlienField
            // 
            this.curWordAlienField.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.curWordAlienField.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.curWordAlienField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.curWordAlienField.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.curWordAlienField.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.curWordAlienField.Location = new System.Drawing.Point(10, 63);
            this.curWordAlienField.Margin = new System.Windows.Forms.Padding(2);
            this.curWordAlienField.Name = "curWordAlienField";
            this.curWordAlienField.Size = new System.Drawing.Size(299, 23);
            this.curWordAlienField.TabIndex = 12;
            this.curWordAlienField.TextChanged += new System.EventHandler(this.curWordAlienField_TextChanged);
            // 
            // curWordMRuField
            // 
            this.curWordMRuField.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.curWordMRuField.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.curWordMRuField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.curWordMRuField.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.curWordMRuField.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.curWordMRuField.Location = new System.Drawing.Point(11, 116);
            this.curWordMRuField.Margin = new System.Windows.Forms.Padding(2);
            this.curWordMRuField.Name = "curWordMRuField";
            this.curWordMRuField.Size = new System.Drawing.Size(298, 23);
            this.curWordMRuField.TabIndex = 13;
            this.curWordMRuField.TextChanged += new System.EventHandler(this.curWordMRuField_TextChanged);
            // 
            // curWordMEnField
            // 
            this.curWordMEnField.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.curWordMEnField.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.curWordMEnField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.curWordMEnField.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.curWordMEnField.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.curWordMEnField.Location = new System.Drawing.Point(10, 170);
            this.curWordMEnField.Margin = new System.Windows.Forms.Padding(2);
            this.curWordMEnField.Name = "curWordMEnField";
            this.curWordMEnField.Size = new System.Drawing.Size(298, 23);
            this.curWordMEnField.TabIndex = 14;
            this.curWordMEnField.TextChanged += new System.EventHandler(this.curWordMEnField_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(1, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Alien word";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(2, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Meaning (Ru)\r\n\r\n";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(2, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Meaning (En)";
            // 
            // wordnumber
            // 
            this.wordnumber.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.wordnumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wordnumber.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.wordnumber.Location = new System.Drawing.Point(84, 40);
            this.wordnumber.Margin = new System.Windows.Forms.Padding(2);
            this.wordnumber.Name = "wordnumber";
            this.wordnumber.ReadOnly = true;
            this.wordnumber.Size = new System.Drawing.Size(36, 20);
            this.wordnumber.TabIndex = 18;
            // 
            // replaceLettersCheckbox
            // 
            this.replaceLettersCheckbox.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.replaceLettersCheckbox.Location = new System.Drawing.Point(133, -1);
            this.replaceLettersCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.replaceLettersCheckbox.Name = "replaceLettersCheckbox";
            this.replaceLettersCheckbox.Size = new System.Drawing.Size(115, 37);
            this.replaceLettersCheckbox.TabIndex = 19;
            this.replaceLettersCheckbox.Text = "Parse to Raharr script rules";
            this.replaceLettersCheckbox.UseVisualStyleBackColor = true;
            this.replaceLettersCheckbox.CheckedChanged += new System.EventHandler(this.replaceLettersCheckbox_CheckedChanged);
            // 
            // buttonSaveDictionary
            // 
            this.buttonSaveDictionary.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveDictionary.Enabled = false;
            this.buttonSaveDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveDictionary.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonSaveDictionary.Location = new System.Drawing.Point(348, 26);
            this.buttonSaveDictionary.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveDictionary.Name = "buttonSaveDictionary";
            this.buttonSaveDictionary.Size = new System.Drawing.Size(132, 25);
            this.buttonSaveDictionary.TabIndex = 21;
            this.buttonSaveDictionary.Text = "Save Dictionary";
            this.buttonSaveDictionary.UseVisualStyleBackColor = true;
            this.buttonSaveDictionary.Click += new System.EventHandler(this.buttonSaveDictionary_Click);
            // 
            // saveCopyCheckbox
            // 
            this.saveCopyCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveCopyCheckbox.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.saveCopyCheckbox.Location = new System.Drawing.Point(348, 56);
            this.saveCopyCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.saveCopyCheckbox.Name = "saveCopyCheckbox";
            this.saveCopyCheckbox.Size = new System.Drawing.Size(79, 20);
            this.saveCopyCheckbox.TabIndex = 20;
            this.saveCopyCheckbox.Text = "A copy";
            this.saveCopyCheckbox.UseVisualStyleBackColor = true;
            this.saveCopyCheckbox.CheckedChanged += new System.EventHandler(this.saveCopyCheckbox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.Location = new System.Drawing.Point(64, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "№";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.Location = new System.Drawing.Point(129, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 25);
            this.button1.TabIndex = 24;
            this.button1.Text = "Add [---]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonAddDivider_Click);
            // 
            // languageSelectionBox
            // 
            this.languageSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageSelectionBox.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.languageSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelectionBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.languageSelectionBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.languageSelectionBox.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.languageSelectionBox.FormattingEnabled = true;
            this.languageSelectionBox.Items.AddRange(new object[] {"Russian", "English"});
            this.languageSelectionBox.Location = new System.Drawing.Point(336, 4);
            this.languageSelectionBox.Margin = new System.Windows.Forms.Padding(2);
            this.languageSelectionBox.Name = "languageSelectionBox";
            this.languageSelectionBox.Size = new System.Drawing.Size(132, 24);
            this.languageSelectionBox.TabIndex = 32;
            this.languageSelectionBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // wikiFormatCheck
            // 
            this.wikiFormatCheck.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wikiFormatCheck.Checked = true;
            this.wikiFormatCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wikiFormatCheck.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.wikiFormatCheck.Location = new System.Drawing.Point(406, 56);
            this.wikiFormatCheck.Margin = new System.Windows.Forms.Padding(2);
            this.wikiFormatCheck.Name = "wikiFormatCheck";
            this.wikiFormatCheck.Size = new System.Drawing.Size(81, 20);
            this.wikiFormatCheck.TabIndex = 27;
            this.wikiFormatCheck.Text = "Wiki format";
            this.wikiFormatCheck.UseVisualStyleBackColor = true;
            this.wikiFormatCheck.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // midPanel
            // 
            this.midPanel.Controls.Add(this.languageSelectionBox);
            this.midPanel.Controls.Add(this.label3);
            this.midPanel.Controls.Add(this.replaceLettersCheckbox);
            this.midPanel.Controls.Add(this.startConversionBtn);
            this.midPanel.Controls.Add(this.checkBox1);
            this.midPanel.Location = new System.Drawing.Point(20, 191);
            this.midPanel.Margin = new System.Windows.Forms.Padding(0);
            this.midPanel.Name = "midPanel";
            this.midPanel.Size = new System.Drawing.Size(480, 73);
            this.midPanel.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(0, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Resulting text";
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.checkBox1.Location = new System.Drawing.Point(133, 34);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 21);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Show in Raharr";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.wikiFormatCheck);
            this.topPanel.Controls.Add(this.saveCopyCheckbox);
            this.topPanel.Controls.Add(this.buttonSaveDictionary);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.buttonOpenDic);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.DicPathString);
            this.topPanel.Location = new System.Drawing.Point(20, 1);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(487, 81);
            this.topPanel.TabIndex = 30;
            // 
            // outputTextField
            // 
            this.outputTextField.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (9)))), ((int) (((byte) (64)))), ((int) (((byte) (104)))));
            this.outputTextField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextField.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.outputTextField.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (198)))), ((int) (((byte) (231)))), ((int) (((byte) (253)))));
            this.outputTextField.Location = new System.Drawing.Point(20, 265);
            this.outputTextField.Margin = new System.Windows.Forms.Padding(2);
            this.outputTextField.Multiline = true;
            this.outputTextField.Name = "outputTextField";
            this.outputTextField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextField.Size = new System.Drawing.Size(480, 122);
            this.outputTextField.TabIndex = 3;
            this.outputTextField.Click += new System.EventHandler(this.outputTextField_SelectionChangedArgs);
            this.outputTextField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.outputTextField_MouseClick);
            this.outputTextField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.outputTextField_KeyUp);
            this.outputTextField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.outputTextField_MouseClick);
            // 
            // conflictLabel
            // 
            this.conflictLabel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.conflictLabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.conflictLabel.Location = new System.Drawing.Point(124, 41);
            this.conflictLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.conflictLabel.Name = "conflictLabel";
            this.conflictLabel.Size = new System.Drawing.Size(147, 19);
            this.conflictLabel.TabIndex = 31;
            this.conflictLabel.Text = "Conflict with № 000: Meaning";
            // 
            // rightPanel
            // 
            this.rightPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rightPanel.Controls.Add(this.butAddWord);
            this.rightPanel.Controls.Add(this.conflictLabel);
            this.rightPanel.Controls.Add(this.button1);
            this.rightPanel.Controls.Add(this.butEditWord);
            this.rightPanel.Controls.Add(this.curWordMEnField);
            this.rightPanel.Controls.Add(this.label6);
            this.rightPanel.Controls.Add(this.label4);
            this.rightPanel.Controls.Add(this.label5);
            this.rightPanel.Controls.Add(this.curWordMRuField);
            this.rightPanel.Controls.Add(this.label7);
            this.rightPanel.Controls.Add(this.wordnumber);
            this.rightPanel.Controls.Add(this.curWordAlienField);
            this.rightPanel.Location = new System.Drawing.Point(514, 265);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(2);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(320, 210);
            this.rightPanel.TabIndex = 32;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (89)))), ((int) (((byte) (135)))));
            this.ClientSize = new System.Drawing.Size(843, 475);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.outputTextField);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.midPanel);
            this.Controls.Add(this.wordsList);
            this.Controls.Add(this.inputTextField);
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (214)))), ((int) (((byte) (250)))));
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1879, 1671);
            this.MinimumSize = new System.Drawing.Size(754, 292);
            this.Name = "GUI";
            this.Text = "Language Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.GUI_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.midPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel rightPanel;

        private System.Windows.Forms.Label conflictLabel;

        private System.Windows.Forms.Panel topPanel;

        private System.Windows.Forms.Panel midPanel;

        public System.Windows.Forms.CheckBox wikiFormatCheck;

        private System.Windows.Forms.ComboBox languageSelectionBox;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label7;

        public System.Windows.Forms.CheckBox saveCopyCheckbox;

        private System.Windows.Forms.CheckBox replaceLettersCheckbox;

        private System.Windows.Forms.TextBox wordnumber;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Button butEditWord;
        private System.Windows.Forms.TextBox curWordAlienField;
        private System.Windows.Forms.TextBox curWordMRuField;
        private System.Windows.Forms.TextBox curWordMEnField;

        private System.Windows.Forms.Button butAddWord;

        public System.Windows.Forms.Button buttonSaveDictionary;

        private System.Windows.Forms.ListBox wordsList;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        public System.Windows.Forms.TextBox inputTextField;
        private System.Windows.Forms.Button startConversionBtn;

        public System.Windows.Forms.TextBox outputTextField;

        private System.Windows.Forms.OpenFileDialog OpenDictionaryDialog;
        private System.Windows.Forms.Button buttonOpenDic;

        public System.Windows.Forms.TextBox DicPathString;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}