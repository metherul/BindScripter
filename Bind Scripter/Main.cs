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
            //alias = alias_textBox.Text;
            alias = fileName_textBox.Text;
            sourceFile = sourceFile_textBox.Text;
            
            delay = Convert.ToInt32(delay_textBox.Text);

            if (delay < 200)
                delay = 500;

            CreateFile();
        }

        public void CreateFile()
        {
            string[] lines = File.ReadAllLines(sourceFile).ToArray();
            List<string> outputList = new List<string>();

            int stepper = 0;
            int counterStorage = 0;

            string currentLine;

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
                    streamWriter.Write("// Warning: Wait commands are disabled on certain servers. This will cause this script to fail, and may (in semi-rare cases) cause the game to crash. \n\n");
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

                        if (string.IsNullOrWhiteSpace(currentLine.Trim())) //Mates, this makes stuff work. Don't question it. 
                        {
                        }

                        else if (!string.IsNullOrWhiteSpace(currentLine.Trim()))
                        {
                            prefix = ("alias " + alias + stepper.ToString() + " \"say ");

                            streamWriter.WriteLine(prefix + lines[counter] + "\"");

                            outputList.Add(lines[counter]);

                            stepper++;
                        }

                        counterStorage = counter;
                    }

                    //START SCRIPT LOGIC

                    int aliasCounter = 0;
                    int backgroundCounter = 0;
                    int aliasCounterPacer = 1;

                    while (aliasCounter < outputList.Count + 1)
                    {
                        prefix = ("alias " + alias + "Set" + backgroundCounter + " \"" + "alias " + alias + "Cancel" + " \"alias " + alias + "Set" + (backgroundCounter + 1) + " \"\"\" ;");

                        streamWriter.Write("\n" + prefix);

                        while(aliasCounter < (10 * aliasCounterPacer) + (aliasCounterPacer - 1))
                        {
                            if (aliasCounter == outputList.Count - 1)
                            {
                                streamWriter.Write(alias + aliasCounter + "; wait " + delay);
                                break;
                            }

                            else
                                streamWriter.Write(alias + aliasCounter + "; wait " + delay + "; ");

                            aliasCounter++;
                        }

                        if (aliasCounter == outputList.Count - 1)
                            break;

                        if (aliasCounter != outputList.Count && aliasCounter != counterStorage)
                            streamWriter.Write(alias + "Set" + (backgroundCounter + 1) + "\"");


                        aliasCounterPacer++;
                        aliasCounter++;
                        backgroundCounter++;
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
