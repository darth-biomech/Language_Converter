﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Language_Converter
{

    public struct DictionaryWord
    {
        public string wordRu;
        public string wordEn;
        public string raharr;
        public int index;

        public DictionaryWord(string _wordRu, string _wordEn, string _raharr, int _index)
        {
            this.wordRu = _wordRu;
            this.wordEn = _wordEn;
            this.raharr = _raharr;
            this.index = _index;
        }

        public bool Contains(string word)
        {
            bool yes = false;
            if (word != string.Empty)
            {
                string pattern = @"\b" + word + @"\b";
                Regex re = new Regex(pattern,RegexOptions.IgnoreCase);
                yes = re.IsMatch(wordEn) || re.IsMatch(wordRu);
            }
            return yes;
        }
    }
    static class Program
    {
        public static MainBody thisProgram;
        public static Form1 guiForm;
        public static int Clamp(int value, int min, int max)  
        {  
            return (value < min) ? min : (value > max) ? max : value;  
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            thisProgram = new MainBody();
            guiForm = new Form1();
            thisProgram.Start();
            Application.Run(guiForm);
        }
    }

    public static class Globals
    {
        public static string wordDictionary="";
        public static List<DictionaryWord> wordsArray = new List<DictionaryWord>();
    }

    class MainBody
    {
        private IniFile _settingsIni = new IniFile();
        public string pathToDictionary = "";
        public bool saveCopy;
        public bool replLetters;

        public void Start()
        {
            LoadSettings();
            LoadDictionary();
            Program.guiForm.PopulateDictionaryList();
        }

        public void LoadDictionary()
        {
            if (File.Exists(pathToDictionary))
            {
                Globals.wordDictionary = File.ReadAllText(pathToDictionary);
                SplitDictionary();
            }
        }
        public void LoadDictionary(string newPath)
        {
            if (newPath != String.Empty)
            {
                pathToDictionary = newPath;
                SaveSettings();
                LoadDictionary();
            }
        }

        private void SplitDictionary()
        {
            string dict = Globals.wordDictionary;
            dict = Regex.Replace(dict, @"<th.*?>", "<th>");
            dict = Regex.Replace(dict, @"<table.*?>", "<table>");
            dict = Regex.Replace(dict, @"<td.*?>", "<td>");
            dict = Regex.Replace(dict, @"<br>", "");
            dict = ("<!DOCTYPE doctypeName [<!ENTITY nbsp '&#160;'>]>") + dict;
            bool isCorrectFile = true;
            XDocument parsed = null;
            try
            {
             parsed = XDocument.Parse(dict);
            }
            catch (Exception)
            {
                isCorrectFile = false;
                MessageBox.Show(@"The dictionary file is in incorrect format. Please read readme.txt for tips on the dictionary file formatting", @"Incorrect dictionary file format", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (isCorrectFile)
            {
                XElement rootThing = parsed.Element("table");
                if (rootThing != null)
                {
                    Globals.wordsArray.Clear();
                    int wordIndex = -1;
                    IEnumerable<XElement> elements =  
                        from el in rootThing.Elements()  
                        where el.Name == "tr" 
                        select el;
                    foreach (XElement dicLine in elements)
                    {
                        IEnumerable<XElement> Words =  
                            from wd in dicLine.Elements()  
                            where wd.Name == "th" 
                            select wd;
                        XElement[] wordElement = Words.ToArray();
                        wordIndex += 1;
                        if (wordElement.Length == 4)
                        {
                            DictionaryWord curWord = new DictionaryWord
                            (
                                wordElement[2].Value.Trim(),
                                wordElement[0].Value.Trim(),
                                wordElement[3].Value.Trim(),
                                wordIndex
                            );
                            Globals.wordsArray.Add(curWord);
                        }
                        else
                        {
                            DictionaryWord curWord = new DictionaryWord
                            (
                                "-------------",
                                "-------------",
                                "-------------",
                                wordIndex
                            );
                            Globals.wordsArray.Add(curWord);
                        }
                    }
                }
            }
        }
        public string GetDictionaryPath()
        {
            LoadSettings();
            return pathToDictionary;
        }

        public void SaveSettings()
        {
            _settingsIni.Write("PathToDictionary", pathToDictionary, "Dictionary");
            _settingsIni.Write("SaveCopy", saveCopy.ToString(), "Dictionary");
            _settingsIni.Write("ReplaceLetters", replLetters.ToString(), "Dictionary");
        }
        private void LoadSettings()
        {
            
            if(!_settingsIni.KeyExists("PathToDictionary","Dictionary"))
            {
                if (pathToDictionary == String.Empty)
                    pathToDictionary = Application.StartupPath;
                _settingsIni.Write("PathToDictionary", pathToDictionary, "Dictionary");
            }
            else
            {
                pathToDictionary = _settingsIni.Read("PathToDictionary","Dictionary");
            }
            if(!_settingsIni.KeyExists("SaveCopy","Dictionary"))
            {
                _settingsIni.Write("SaveCopy", saveCopy.ToString(), "Dictionary");
            }
            else
            {
                saveCopy = _settingsIni.Read("saveCopy","Dictionary") == "True";
            }
            if(!_settingsIni.KeyExists("ReplaceLetters","Dictionary"))
            {
                _settingsIni.Write("ReplaceLetters", replLetters.ToString(), "Dictionary");
            }
            else
            {
                replLetters = _settingsIni.Read("ReplaceLetters","Dictionary") == "True";
            }
        }
        public void ChangeWord(DictionaryWord newWord)
        {
            int ai = -1;
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                if (word.index == newWord.index)
                {
                    DictionaryWord oldWord = word;
                    int index = Globals.wordsArray.FindIndex(a => a.index==newWord.index);
                    ai = index;
                    Globals.wordsArray[index] = newWord;
                    break;
                }
            }
            Program.guiForm.PopulateDictionaryList(ai);
        }

        public void AddWord(DictionaryWord newWord)
        {
            int index = newWord.index-1;
            List<DictionaryWord> tempDict = new List<DictionaryWord>();
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                if (word.index == index)
                {
                    tempDict.Add(word);
                    tempDict.Add(newWord);
                }
                else if (word.index > index)
                {
                    DictionaryWord tempword = word;
                    tempword.index += 1;
                    tempDict.Add(tempword);
                }
                else
                {
                    tempDict.Add(word);
                }
            }
            Globals.wordsArray = tempDict;
            Program.guiForm.PopulateDictionaryList(index+1);
        }
            public DictionaryWord FindWord(int index)
        {
            DictionaryWord w = new DictionaryWord("NaN","NaN","NaN",-1);
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                if (word.index == index)
                {
                    w = word;
                    break;
                }
            }
            return w;
        }
 

        public string BeginConversion(string inputText,bool formatRaharr)
        {
            string text = inputText;
            if (inputText != string.Empty)
            {
                string regPattern = @"[.,<>{}!@#$%^&*()_+=\-\'\`\~|\/\\ 	:0-9;]";
                var fixedInput = Regex.Replace(text, regPattern, " ");
                string[] brokenText = fixedInput.Split();
                foreach (string word in brokenText)
                {
                    Console.WriteLine(word);
                    if (word != string.Empty)
                        foreach (DictionaryWord dictWord in Globals.wordsArray)
                        {
                            if (dictWord.Contains(word))
                            {
                                string replPattern = @"\b" + word + @"\b";
                                text = Regex.Replace(text, replPattern, dictWord.raharr);
                            }
                        }
                    
                }

                if (formatRaharr)
                    text = FormatRaharr(text);

            }
            else text = "Write something first!";
            return text;
        }
        public static string FormatRaharr(string word)
        {
            char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                        if (i > 2)
                        {
                            if (letters[i] == letters[i - 1] && (letters[i - 2] != '_' && letters[i - 1] != '.')) 
                                letters[i - 1] = '_';
                        }
                        else if (i == 1)
                            if ( letters[i] == letters[i-1] ) 
                                letters[i-1] = '_';

                        if (letters[i] == 'ь' || letters[i] == 'ъ' || letters[i] == 'Ь' || letters[i] == 'Ъ')
                        {
                            char symbol = letters[i];
                            char prev = letters[i - 1];
                            letters[i] = prev;
                            letters[i - 1] = symbol;
                        }
                }
                return new string(letters);
        }
        public void ExportDictionary(string path, bool asCopy = false)
        {
            string newDictionary = " ";
            bool firstbit = true;
            newDictionary = "<table class=\"wikitable\" style=\"line-height: 1.3em!important;color: #9bdfff!important;background: #03132f!important;border: 1px solid #0084c2!important; width: 600px;\">";
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                string curCell;
                if (word.raharr == "-------------")
                {
                    if (firstbit)
                    {
                        firstbit = false;
                        curCell = "\n\t<tr><td colspan = \"2\"style=\"  text-align: right;\">{{Tnavbar-view|Dictionary}}</td></tr>\n\n";
                    } 
                    else
                        curCell = "\n\t<tr>\n\t\t<td colspan = \"2\"> &nbsp; <br> </td>\n\t</tr>\n";
                }
                else
                {
                    string wordBegin =          "\n\t<tr>\n";
                    string wordRu =             "\t\t<th {{#if: {{{1|}}} | | style=\"display:none\"}}>\t\t"+word.wordRu+" </th>\n";
                    string wordEn =             "\t\t<th {{#if: {{{1|}}} | style=\"display:none\"| }}>\t\t"+word.wordEn+" </th>\n";
                    string wordRuTranscript =   "\t\t<th {{#if: {{{1|}}} | | style=\"display:none\"}}>\t\t"+word.raharr+" </th>\n";
                    string wordEnTranscript =   "\t\t<th {{#if: {{{1|}}} | style=\"display:none\"| }}>\t\t"+Transcriptize(word.raharr)+" </th>\n";
                    string wordEnd =            "\n\t</tr>\n";
                    curCell = wordBegin+wordEn+wordEnTranscript+"\n"+wordRu+wordRuTranscript+wordEnd;
                }
                newDictionary += curCell;
            }
            newDictionary += "\n</table>";
                string savePath = path;
                if (asCopy)
                    savePath = Path.ChangeExtension(path,"")+"_copy.txt";
            File.WriteAllText(savePath, newDictionary);
        }

        public string Transcriptize(string word)
        {
            char[] inWord = word.ToCharArray();
            List<string> newWord = new List<string> {""};
            newWord.Clear();
            foreach (char c in inWord)
            {
                newWord.Add(c.ToString());
            }
            for (int i = 0; i < newWord.Count; i++)
            {
                switch (newWord[i])
                {
                    case "а" : 
                        newWord[i] = "a"; break;
                    case "б" : 
                        newWord[i] = "b"; break;
                    case "в" : 
                        newWord[i] = "v"; break;
                    case "г" : 
                        newWord[i] = "g"; break;
                    case "д" : 
                        newWord[i] = "d"; break;
                    case "е" : 
                        newWord[i] = "e"; break;
                    case "ё" : 
                        newWord[i] = "e"; break;
                    case "ж" : 
                        newWord[i] = "zh"; break;
                    case "з" : 
                        newWord[i] = "z"; break;
                    case "и" : 
                        newWord[i] = "i"; break;
                    case "й" : 
                        newWord[i] = "i"; break;
                    case "к" : 
                        newWord[i] = "k"; break;
                    case "л" : 
                        newWord[i] = "l"; break;
                    case "м" : 
                        newWord[i] = "m"; break;
                    case "н" : 
                        newWord[i] = "n"; break;
                    case "о" : 
                        newWord[i] = "o"; break;
                    case "п" : 
                        newWord[i] = "p"; break;
                    case "р" : 
                        newWord[i] = "r"; break;
                    case "с" : 
                        newWord[i] = "s"; break;
                    case "т" : 
                        newWord[i] = "t"; break;
                    case "у" : 
                        newWord[i] = "u"; break;
                    case "ф" : 
                        newWord[i] = "f"; break;
                    case "х" :
                        newWord[i] = "h"; break;
                    case "ц" : 
                        newWord[i] = "tch"; break;
                    case "ч" : 
                        newWord[i] = "ch"; break;
                    case "ш" : 
                        newWord[i] = "sh"; break;
                    case "щ" : 
                        newWord[i] = "shch"; break;
                    case "ъ" : 
                        newWord[i] = "'"; break;
                    case "ы" : 
                        newWord[i] = "i"; break;
                    case "ь" : 
                        newWord[i] = ""; break;
                    case "э" : 
                        newWord[i] = "e"; break;
                    case "ю" : 
                        newWord[i] = "yu"; break;
                    case "я" : 
                        newWord[i] = "ya"; break;
                }
            }
            return  string.Join("", newWord);
        }
    }
}