﻿using System;
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
        int curwinWidth = 100;  
        public Form1()
        {
            InitializeComponent();
            DicPathString.Text = Program.thisProgram.GetDictionaryPath();
            replaceLettersCheckbox.Checked = Program.thisProgram.replLetters;
            saveCopyCheckbox.Checked = Program.thisProgram.saveCopy;
            this.Size = new Size(Program.thisProgram.winWidth, Program.thisProgram.winHeight);
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
                        tabSpace = "                ".Substring(rahword.Length);
                    if (Program.thisProgram.HasDuplicate(word) !=-1)
                    {
                        rahword = "[D] "+rahword;
                    }
                    else
                    {
                        rahword = "    "+rahword;
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
		
		/*
		//To allow the user to rearrange the contents of a ListBox in a C# WinForms application, we can use the drag-and-drop functionality of the ListBox control. Here's an example function that demonstrates how to implement this functionality:
private void wordsList_MouseDown(object sender, MouseEventArgs e)
{
    if (wordsList.SelectedItem == null) return;
    wordsList.DoDragDrop(wordsList.SelectedItem, DragDropEffects.Move);
}

private void listBox1_DragOver(object sender, DragEventArgs e)
{
    e.Effect = DragDropEffects.Move;
}

private void wordsList_DragDrop(object sender, DragEventArgs e)
{
    int newIndex = wordsList.IndexFromPoint(wordsList.PointToClient(new Point(e.X, e.Y)));
    if (newIndex < 0) newIndex = wordsList.Items.Count - 1;
    object droppedItem = e.Data.GetData(typeof(string));
    wordsList.Items.Remove(droppedItem);
    wordsList.Items.Insert(newIndex, droppedItem);
}
//This function uses the MouseDown, DragOver, and DragDrop events of the ListBox control to implement drag-and-drop functionality. When the user clicks on an item in the ListBox, the MouseDown event is triggered, and the selected item is added to the drag-and-drop data using the DoDragDrop method. When the user drags the item over the ListBox, the DragOver event is triggered, and the Effect property of the DragEventArgs object is set to Move to indicate that the item can be moved. When the user drops the item onto the ListBox, the DragDrop event is triggered, and the dropped item is removed from its original position in the ListBox and inserted at the new position specified by the IndexFromPoint method
//To use this function in your WinForms application, you can add the MouseDown, DragOver, and DragDrop event handlers to your ListBox control and copy the code above into the corresponding event handlers.
		*/
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
            Program.thisProgram.winWidth = this.Width;
             ResizeAll();
        }

        private void ResizeAll()
        {
            curwinHeight = Program.thisProgram.winHeight;
            curwinWidth = Program.thisProgram.winWidth;
             ResizeForm(wordsList,258);
             int secondRowLoc = (int)(curwinWidth / 1.8);
             wordsList.Left = secondRowLoc;
             rightPanel.Left = secondRowLoc;
             wordsList.Width = curwinWidth - wordsList.Location.X -20;
             rightPanel.Width = curwinWidth - wordsList.Location.X -20;
             topPanel.Width = secondRowLoc -30;
             DicPathString.Width = secondRowLoc - buttonSaveDictionary.Width - buttonOpenDic.Width - 50;
             int textfieldsheight = (curwinHeight-228)/2;
             midPanel.Location = new Point(midPanel.Location.X, textfieldsheight + 90);
             midPanel.Width = topPanel.Width;
             
             inputTextField.Size = new Size(secondRowLoc -40, textfieldsheight);
             outputTextField.Size = inputTextField.Size;
             
             outputTextField.Location = new Point(outputTextField.Location.X, textfieldsheight + 162);
             
        }
        private void ResizeForm(Control obj, int offset)
        {
            int newitemHeight = (curwinHeight-offset);
            obj.Size = new Size(obj.Size.Width, newitemHeight);
        }
    }
}