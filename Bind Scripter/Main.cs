﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using MetroFramework.Forms;

namespace Bind_Scripter
{
    public partial class Main : MetroForm
    {
        public string bindKey;                  //Keybind to start the Script
        public string cancelBindKey;            //Keybind to Cancel the script
        public string fileName;                 //Filename of the outputted .cfg
        public string alias;                    //Hard to explain, read the Github page for information - MIGHT REMOVE
        public string sourceFile;               //Source file of the text you want to bind
        public string appDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();

        public string prefix;

        public int delay;
        public int isStarting = 0;
        public int preInt = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            bindKey = bind_textBox.Text;
            cancelBindKey = cancel_textBox.Text;
            fileName = fileName_textBox.Text;
            alias = alias_textBox.Text;
            sourceFile = sourceFile_textBox.Text;
            
            delay = Convert.ToInt32(delay_textBox.Text);

            if (delay < 500)
            {
                delay = 500;
                delay_textBox.Text = 500.ToString();
            }

            CreateFile();
        }

        public void CreateFile()
        {
            string[] lines = File.ReadAllLines(sourceFile).ToArray();
            List<string> storageList = new List<string>();

            string currentLine;

            int amount = 10;
            int setnum = 0;

            if (!File.Exists(appDirectory + fileName + ".cfg"))
            {
                var myfile = File.Create(appDirectory + fileName + ".cfg");
                myfile.Close();
            }

            else if (File.Exists(appDirectory + fileName + ".cfg"))
            {
                File.Delete(appDirectory + fileName + ".cfg"); 
            }

            int lineCount = File.ReadLines(sourceFile).Count();

            using (StreamWriter streamWriter = new StreamWriter(appDirectory + fileName + ".cfg", true))
            {
                using (StreamReader streamReader = new StreamReader(sourceFile))
                {
                    streamWriter.Write("// GENERATED BY \"BIND SCRIPTER\" \n");
                    streamWriter.Write("// Questions should be sent to /u/metherul \n");
                    streamWriter.Write("// Line Count: " + lineCount + "\n\n");

                    streamWriter.Write("bind " + bindKey + " \"" + "exec " + fileName + "; " + alias + "Set" + "0\"");
                    streamWriter.Write("\n");
                    streamWriter.Write("bind " + cancelBindKey + " \"" + alias + "Cancel\"");
                    streamWriter.Write("\n\n");

                    for (int counter = 0; counter < lines.Length; counter++)
                    {
                        currentLine = lines[counter];

                        if (!string.IsNullOrWhiteSpace(currentLine))
                        {
                            prefix = ("alias " + alias + counter.ToString() + " \"say ");

                            streamWriter.WriteLine(prefix + lines[counter] + "\"");
                        }

                        //

                        if (storageList[setnum].Length != amount)
                        {
                            storageList[setnum] = alias + counter;
                        }

                        else if (storageList[setnum].Length == amount)
                        {
                            setnum++;
                            storageList.Add("");
                        }

                        for (int i = 0; i < storageList.Count; i++)
                        {
                            streamWriter.Write(storageList[i]);
                        }
                    }

                    streamWriter.Write("\n");

                    for (int counter = 0; counter < lines.Length; counter++)
                    {
                        prefix = ("alias " + alias + "Set" + counter + " \"" + "alias " + alias + "Cancel" + " \"alias " + alias + "Set" + counter + 1 + "\"\"\";");

                        streamWriter.Write("\n" + prefix);

                        //for (int i = 0; i < lines.Length; i++)
                        //{
                        //    if (lines[i].Length != amount)
                        //        list[setNum] = 

                        //}
                    }
                }
            }
        }

        private void openFile_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                sourceFile_textBox.Text =  openFileDialog.FileName;
            }
        }
    }
}