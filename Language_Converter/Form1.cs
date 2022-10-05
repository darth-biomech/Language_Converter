using System;
using System.Drawing;
using System.Linq;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Language_Converter
{
    public partial class Form1 : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private DictionaryWord currentWord = new DictionaryWord("NaN","NaN","NaN",-1);
        private bool wordIsModified;
        private bool displayInEnglish;
        int curwinHeight = 100;
        public Form1()
        {
            InitializeComponent();
            DicPathString.Text = Program.thisProgram.GetDictionaryPath();
            replaceLettersCheckbox.Checked = Program.thisProgram.replLetters;
            saveCopyCheckbox.Checked = Program.thisProgram.saveCopy;
            this.Size = new Size(this.Width, Program.thisProgram.winHeight);
            ResizeAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("Language_Converter.raharr_new.ttf");
            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            fontStream.Close();

            unsafe
            {
                fixed (byte* pFontData = fontdata)
                {
                    pfc.AddMemoryFont((System.IntPtr)pFontData, fontdata.Length);
                }
            }
        }

        private void buttonOpenDic_Click(object sender, EventArgs e)
        {
            OpenDictionaryDialog.Filter = @"txt files (*.txt)|*.txt|htm files (*.htm)|*.htm|html files (*.html)|*.html";
            OpenDictionaryDialog.FilterIndex = 1;
            OpenDictionaryDialog.RestoreDirectory = true;
            if (DicPathString.Text != string.Empty)
            {
                OpenDictionaryDialog.InitialDirectory = DicPathString.Text;
            }
            else
            {
                OpenDictionaryDialog.InitialDirectory = "c:\\";
            }
            if (OpenDictionaryDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                DicPathString.Text = OpenDictionaryDialog.FileName;
                Program.thisProgram.LoadDictionary(OpenDictionaryDialog.FileName);
                PopulateDictionaryList();
            }
        }

        public void PopulateDictionaryList( int selection = -1)
        {
            wordsList.Items.Clear();
            SwitchButtonsEditedWord(false);
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                if (word.raharr == "-------------")
                    wordsList.Items.Add("---------------------------------------");
                else
                {
                    string rahword =  word.raharr;
                    string meaning = word.wordRu;
                    if (displayInEnglish)
                    {
                        rahword = Program.thisProgram.Transcriptize(rahword);
                        meaning = word.wordEn;
                    }

                    string tabSpace = "";
                    if (rahword.Length < 11)
                        tabSpace = "           ".Substring(rahword.Length);
                    if (Program.thisProgram.HasDuplicate(word) !=-1)
                    {
                        rahword = "[D] "+rahword;
                    }

                    string numspace = " ";
                    if (word.index < 100)
                        numspace += " ";
                    if (word.index < 10)
                        numspace += " ";
                    rahword = word.index.ToString() + numspace + rahword;
                    wordsList.Items.Add(rahword+tabSpace+"- "+meaning);
                    wordsList.SelectedIndex = 0;
                }
            }

            if (selection != -1)
            {
                wordsList.SelectedIndex = selection;
            }
        }
        private void wordsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!wordIsModified)
            {
                currentWord = Program.thisProgram.FindWord(wordsList.SelectedIndex);
                curWordAlienField.Text = currentWord.raharr;
                curWordMEnField.Text = currentWord.wordEn;
                curWordMRuField.Text = currentWord.wordRu;
                wordnumber.Text = currentWord.index.ToString();
                SwitchButtonsEditedWord(false);
                int dupIndex = Program.thisProgram.HasDuplicate(currentWord);
                if (dupIndex !=-1)
                {
                    bool def = false;
                    DictionaryWord conflword = Program.thisProgram.FindWord(dupIndex);
                    string[] separator = { ",", " ","particle \"","частица \"","\"" };
                    string[] definitions = (currentWord.wordEn+" "+currentWord.wordRu).Split(separator,StringSplitOptions.RemoveEmptyEntries);
                   foreach (string word in definitions)
                    {
                        if (conflword.Contains(word))
                        {
                            def = true;
                            break;
                        }
                    }

                   string rah_word =conflword.raharr;
                   if (displayInEnglish)
                   {
                       rah_word =Program.thisProgram.Transcriptize(rah_word);
                   }

                   if (def)
                       conflictLabel.Text = "Conflict with №"+dupIndex+" "+rah_word+": Definition";
                   else
                       conflictLabel.Text = "Conflict with №"+dupIndex+" "+rah_word+": Word";
                }
                else
                {
                    conflictLabel.Text = " ";
                }
            }
            else wordsList.SelectedIndex = currentWord.index;

            if (currentWord.raharr == "-------------")
            {
                butEditWord.Enabled = false;
                curWordAlienField.Enabled = false;
                curWordMEnField.Enabled = false;
                curWordMRuField.Enabled = false;
            }
            else
            {
                butEditWord.Enabled = true;
                curWordAlienField.Enabled = true;
                curWordMEnField.Enabled = true;
                curWordMRuField.Enabled = true;
            }
        }


        private void curWordAlienField_TextChanged(object sender, EventArgs e)
        {
            SwitchButtonsEditedWord(true);
            currentWord.raharr = curWordAlienField.Text;
        }

        private void curWordMRuField_TextChanged(object sender, EventArgs e)
        {
            SwitchButtonsEditedWord(true);
            currentWord.wordRu = curWordMRuField.Text;
        }

        private void curWordMEnField_TextChanged(object sender, EventArgs e)
        {
            SwitchButtonsEditedWord(true);
            currentWord.wordEn = curWordMEnField.Text;
        }

        private void SwitchButtonsEditedWord(bool isTrue)
        {
                wordIsModified = isTrue;
                butEditWord.Enabled = isTrue;
            if (isTrue)
            {
                butAddWord.Text = @"Current as new";
            }
            else
            {
                butAddWord.Text = @"Add new word";
            }
        }
        private void butEditWord_Click(object sender, EventArgs e)
        {
            SwitchButtonsEditedWord(false);
            Program.thisProgram.ChangeWord(currentWord);
            buttonSaveDictionary.Enabled = true;
        }
        private void buttAddWord_Click(object sender, EventArgs e)
        {
            DictionaryWord tempWord;
            if (!wordIsModified)
            {
                tempWord = new DictionaryWord(" ", " ", " ", currentWord.index + 1);
            }
            else
            {
                tempWord = new DictionaryWord(currentWord.wordRu, currentWord.wordEn, currentWord.raharr, currentWord.index + 1);
            }

            Program.thisProgram.AddWord(tempWord);
            buttonSaveDictionary.Enabled = true;
        }
        private void buttonAddDivider_Click(object sender, EventArgs e)
        {
            int tempIndex = wordsList.SelectedIndex;
            DictionaryWord tempWord = new DictionaryWord("-------------", "-------------", "-------------", currentWord.index + 1);
            Program.thisProgram.AddWord(tempWord);
            buttonSaveDictionary.Enabled = true;
            PopulateDictionaryList(tempIndex);
        }
        private void startConversionBtn_Click(object sender, EventArgs e)
        {
            if (displayInEnglish)
                outputTextField.Text = Program.thisProgram.Transcriptize(Program.thisProgram.BeginConversion(inputTextField.Text,replaceLettersCheckbox.Checked));
            else
                outputTextField.Text = Program.thisProgram.BeginConversion(inputTextField.Text,replaceLettersCheckbox.Checked);
        }

        private void buttonSaveDictionary_Click(object sender, EventArgs e)
        {
            Program.thisProgram.ExportDictionary(DicPathString.Text,saveCopyCheckbox.Checked);
            buttonSaveDictionary.Enabled = false;
        }

        private void replaceLettersCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Program.thisProgram.replLetters = replaceLettersCheckbox.Checked;
        }

        private void saveCopyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Program.thisProgram.saveCopy = saveCopyCheckbox.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonSaveDictionary.Enabled || wordIsModified)
            {
                var window = MessageBox.Show(
                    "Your dictionary has unsaved changes!\n\n Exit without saving them?",
                    "Dictionary was modified",
                    MessageBoxButtons.YesNo);
                e.Cancel = (window == DialogResult.No);
            }

            Program.thisProgram.SaveSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                outputTextField.Font = new Font(pfc.Families[0], 11,FontStyle.Regular);
                if (displayInEnglish)
                    if (inputTextField.Text.Length > 1)
                        outputTextField.Text = Program.thisProgram.BeginConversion(inputTextField.Text,replaceLettersCheckbox.Checked);
 
            }
            else
            {
                outputTextField.Font = new Font("Arial", 10,FontStyle.Regular);
                if (displayInEnglish)
                    if (inputTextField.Text.Length > 1)
                        outputTextField.Text = Program.thisProgram.Transcriptize(Program.thisProgram.BeginConversion(inputTextField.Text,replaceLettersCheckbox.Checked));

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                displayInEnglish = false;
            else 
                displayInEnglish = true;
            PopulateDictionaryList(currentWord.index);
            if (inputTextField.Text.Length > 1)
                if (!displayInEnglish)
                    outputTextField.Text = Program.thisProgram.BeginConversion(inputTextField.Text,replaceLettersCheckbox.Checked);
                else if (!checkBox1.Checked)
                    outputTextField.Text = Program.thisProgram.Transcriptize(Program.thisProgram.BeginConversion(inputTextField.Text,replaceLettersCheckbox.Checked));

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Program.thisProgram.wikiFormat = checkBox2.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Program.thisProgram.winHeight = this.Height;
             ResizeAll();
        }

        private void ResizeAll()
        {
            curwinHeight = Program.thisProgram.winHeight;
             ResizeForm(wordsList,258);
             int textfieldsheight = (curwinHeight-228)/2;
             inputTextField.Size = new Size(inputTextField.Size.Width, textfieldsheight);
             midPanel.Location = new Point(midPanel.Location.X, textfieldsheight + 90);
             outputTextField.Location = new Point(outputTextField.Location.X, textfieldsheight + 162);
             outputTextField.Size = new Size(outputTextField.Size.Width, textfieldsheight);
             //  ResizeForm(outputTextField,0,0.3);
        }
        private void ResizeForm(Control obj, int offset)
        {
            int newitemHeight = (curwinHeight-offset);
            obj.Size = new Size(obj.Size.Width, newitemHeight);
        }
        private void ResizeForm(Control obj, int height, double percent)
        {
            int newitemHeight = (int) (curwinHeight*percent);
            obj.Size = new Size(obj.Size.Width, newitemHeight);
        }
    }
}