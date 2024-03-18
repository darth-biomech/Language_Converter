using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
// ReSharper disable StringLiteralTypo
namespace Language_Converter
{

    public struct DictionaryWord
    {
        public static string separator = "--------------------------------------------------------------------------------------------------------------------------------";
        private static string[] ending4 = new[] {
            "tion","ance","ence","ment","ness","ship","sion","able","ible","ical","ious","less"
        };
        private static string[] ending3 = new[] {
            "ing","acy","dom","ism","ist","ity","ate","ify","ize","ise","ful","ous","ish","ive",
            "ила","или","ями","ами","ими","ыми","ого","его","ому","ему", "ешь","ете","ишь","ите" 
        };
        private static string[] ending2 = new[] {
            "ed","al","er","or","ty","en","fy","al","ic",
            "ов","ам","ям","ах","ях","ая","яя","ий","ый","ую","юю","ое","ее","ие","ые","им","ым","ой",
            "ей","ом","ем","их","ых","ет","ут","ит","ат","ят" 
        };
        private static string[] ending1 = new[] {
            "s","y",
            "а","я","ы","и","е","о","у","ю","ь"
        };
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
        public DictionaryWord(string _raharr, int _index)
        {
            this.wordRu = _raharr;
            this.wordEn = Program.thisProgram.Transcriptize(_raharr);
            this.raharr = _raharr;
            this.index = _index;
        }
        public static DictionaryWord Separator(int i) => new DictionaryWord(separator, i);

        public bool Contains(string word)
        {
            bool result = false;
            if (word != string.Empty)
            {
                string pattern = @"\b" + word + @"\b";
                Regex re = new Regex(pattern,RegexOptions.IgnoreCase);
                result = re.IsMatch(wordEn) || re.IsMatch(wordRu);
                //if not found, try variations
                if (!result)
                {
                    word = TryRemoveSuffixes(word);
                    pattern = @"\b" + word + @"\b";
                    re = new Regex(pattern,RegexOptions.IgnoreCase);
                    result = re.IsMatch(wordEn) || re.IsMatch(FixRussianDef(wordRu));
                }
            }
            return result;
        }

        private static string FixRussianDef(string def)
        {
            string[] words = def.Split();
            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                result += TryRemoveSuffixes(words[i]) + ", ";
            }

            return result;
        }
        private static string TryRemoveSuffixes(string word)
        {
            
            if (word.Length >5 && word.TestEnding(ending4))
                word = word.Substring(0, word.Length - 4);
            else if (word.Length >4 && word.TestEnding(ending3))
                word = word.Substring(0, word.Length - 3);
            else if (word.Length >3 && word.TestEnding(ending2))
                word = word.Substring(0, word.Length - 2);
            else if (word.Length >2 && word.TestEnding(ending1))
                word = word.Substring(0, word.Length - 1);
            return word;
        }

        public bool IsSeparator() { return raharr.Contains("----"); }
    }
    static class Program
    {
        public static MainBody thisProgram;
        public static Form1 guiForm;
        public static int Clamp(int value, int min, int max)  
        {  
            return (value < min) ? min : (value > max) ? max : value;  
        }
        
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId = -1);
        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            AttachConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            thisProgram = new MainBody();
            guiForm = new Form1();
            thisProgram.Start();
            Application.Run(guiForm);
        }

        public static bool TestEnding(this string a, string[] b)
        {
            if(a != String.Empty && b.Length > 0)
            {
                a = a.ToLower();
                foreach (string s in b)
                {
                    if (a.EndsWith(s)) return true;
                }
            }
            return false;
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
        public bool wikiFormat = true;
        public int winHeight = 550;
        public int winWidth = 1140;

        public Dictionary<int, int> translationIndexes;
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
            dict = Regex.Replace(dict, @"<style>(\n|.)*?style>", "");
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
                            DictionaryWord curWord = DictionaryWord.Separator(wordIndex);
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
            _settingsIni.Write("winHeight", winHeight.ToString(), "Dictionary");
            _settingsIni.Write("winWidth", winWidth.ToString(), "Dictionary");
        }
        private void LoadSettings()
        {
            if (pathToDictionary == String.Empty)
                pathToDictionary = Application.StartupPath;
            TryGetSettingValue("PathToDictionary", ref pathToDictionary);
            TryGetSettingValue("SaveCopy",ref saveCopy);
            TryGetSettingValue("ReplaceLetters", ref replLetters);
            TryGetSettingValue("winHeight", ref winHeight);
            TryGetSettingValue("winWidth", ref winWidth);
        }
 
        private void TryGetSettingValue(string key, ref int var)
        {
            if (!_settingsIni.KeyExists(key, "Dictionary"))
            {
                _settingsIni.Write(key, var.ToString(), "Dictionary");
            }
            else
            {
                var = Int32.Parse(_settingsIni.Read(key, "Dictionary"));
            }
        }
        private void TryGetSettingValue(string key, ref bool var)
        {
            if (!_settingsIni.KeyExists(key, "Dictionary"))
            {
                _settingsIni.Write(key, var.ToString(), "Dictionary");
            }
            else
            {
                var = _settingsIni.Read(key, "Dictionary").ToLower() == "true";
            }
        }
        private void TryGetSettingValue(string key, ref string var)
        {
            if (!_settingsIni.KeyExists(key, "Dictionary"))
            {
                _settingsIni.Write(key, var, "Dictionary");
            }
            else
            {
                var = _settingsIni.Read(key, "Dictionary");
            }
        }

        public void ChangeWord(DictionaryWord newWord)
        {
            int ai = -1;
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                if (word.index == newWord.index)
                {
                    // DictionaryWord oldWord = word;
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
                    DictionaryWord tempWord = word;
                    tempWord.index += 1;
                    tempDict.Add(tempWord);
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
            translationIndexes = new Dictionary<int, int>();
            if (text != string.Empty)
            {
                string regPattern = @"[.,<>{}!@#$%^&*()_+=\-\'\`\~|\/\\ 	:0-9;]";
                string fixedInput = Regex.Replace(text, regPattern, " ");
                string[] wordArray = fixedInput.Split();
                
                foreach (string word in wordArray)
                {
                    if (word != string.Empty)
                    {
                        foreach (DictionaryWord dictWord in Globals.wordsArray)
                        {
                            if (dictWord.Contains(word))
                            {
                                string replPattern = @"\b" + word + @"\b";
                                int wordPos = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);
                                if(wordPos >= 0)
                                    wordPos = text.Substring(0, Math.Min(text.Length,wordPos+1)).Split().Length;
                                if (!translationIndexes.ContainsKey(wordPos))
                                    translationIndexes.Add(wordPos,dictWord.index);
                                text = Regex.Replace(text, replPattern, dictWord.raharr);
                            }
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
            string newDictionary;
            string wikiClass = "wikitable";
            string wikiTableEn = " {{#if: {{{1|}}} | style=\"display:none\"| }}";
            string wikiTableRu = " {{#if: {{{1|}}} | | style=\"display:none\"}}";
            if (!wikiFormat)
            {
                wikiClass = "raharrTable";
                wikiTableEn = " class=\"enwords\"";
                wikiTableRu = " class=\"ruwords\"";
            }
            bool firstBit = true;
            newDictionary = "<table class=\""+wikiClass+"\" style=\"line-height: 1.3em!important;color: #9bdfff!important;background: #03132f!important;border: 1px solid #0084c2!important; width: 600px;\">";
            if (!wikiFormat)
                newDictionary = "<style>\nbody \n{\nbackground:black\n}\nth\n{\nborder: 1px solid #0084c2 !important;\n}\n.enwords \n{\ndisplay: none;\n}\n.ruwords \n{\ndisplay: table-cell;\n}\n \n</style>\n" + newDictionary;
            
            foreach (DictionaryWord word in Globals.wordsArray)
            {
                string curCell;
                if (word.IsSeparator())
                {
                    if (firstBit && wikiFormat)
                    {
                        firstBit = false;
                        curCell = "\n\t<tr><td colspan = \"2\"style=\"  text-align: right;\">{{Tnavbar-view|Dictionary}}</td></tr>\n\n";
                    } 
                    else
                        curCell = "\n\t<tr>\n\t\t<td colspan = \"2\"> &nbsp; <br> </td>\n\t</tr>\n";
                }
                else
                {
                    string wordBegin =          "\n\t<tr>\n";
                    string wordRu =             "\t\t<th"+wikiTableRu+">\t\t"+word.wordRu+" </th>\n";
                    string wordEn =             "\t\t<th"+wikiTableEn+">\t\t"+word.wordEn+" </th>\n";
                    string wordRuTranscript =   "\t\t<th"+wikiTableRu+">\t\t"+word.raharr+" </th>\n";
                    string wordEnTranscript =   "\t\t<th"+wikiTableEn+">\t\t"+Transcriptize(word.raharr)+" </th>\n";
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

        public int HasDuplicate(DictionaryWord word)
        {
            int result = -1;
            if (word.IsSeparator()) 
                return result;
            foreach (DictionaryWord wordMatch in Globals.wordsArray)
            {
                if (word.raharr == wordMatch.raharr && word.index != wordMatch.index)
                {
                    result = wordMatch.index;
                    break;
                }
                else if (word.index != wordMatch.index)
                {
                    string[] separator = {",", " ", "particle \"", "частица \"", "\""};
                    string[] defWords = (word.wordEn + " " + word.wordRu).Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    string stringToCheck = (wordMatch.wordEn + " " + wordMatch.wordRu);
                    if (defWords.Length > 0 && !word.wordRu.Contains("частица \"") )
                    {
                        
                            var pattern = new Regex(@"\W");
                            var q = pattern.Split(stringToCheck).Any(w => defWords.Contains(w)) && !stringToCheck.Contains("частица \"") ;
                            if (q)
                            {
                                result = wordMatch.index;
                                break;
                            }
                    }
                }
            }

            return result;
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