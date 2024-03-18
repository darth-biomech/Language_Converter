using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// ReSharper disable StringLiteralTypo
namespace Language_Converter
{

    static class Program
    {
        public static RaharrTranslator instance;
        public static GUI gui;

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId = -1);
        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            AttachConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            instance = new RaharrTranslator();
            gui = new GUI();
            instance.Start();
            Application.Run(gui);
        }
    }

}