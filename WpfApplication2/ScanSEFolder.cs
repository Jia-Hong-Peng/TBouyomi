﻿using System;
using System.IO;

namespace Twitch_Bouyomi
{
    public partial class MainWindow
    {
        private void GetSEFileList()
        {
            string SEPath = "SE";
            string[] SeFiles = Directory.GetFiles(SEPath, "*.mp3");

            for(int i = 0; i < SeFiles.Length; i++)
            {
                SeFiles[i] = Path.GetFileName(SeFiles[i]);
            }

            FileStream Fstream = null;
            Fstream = new FileStream(SEPath + "/" + "SEList.txt", FileMode.OpenOrCreate);
            Fstream.Close();
            Fstream = new FileStream(SEPath + "/" + "SEList.txt", FileMode.Truncate);  //清空txt文件
            Fstream.Close();
            Fstream = new FileStream(SEPath + "/" + "SEList.txt", FileMode.OpenOrCreate);
            StreamWriter FileWrite = new StreamWriter(Fstream);

            try
            {
                if(Fstream != null)
                {
                    string temp;
                    Fstream.Position = 0;
                    for(int i = 0;i< SeFiles.Length; i++)
                    {
                        Add_SE(SeFiles[i].ToString());
                        temp = SeFiles[i].ToString().Remove(SeFiles[i].ToString().LastIndexOf("."));
                        FileWrite.WriteLine(temp);
                        FileWrite.Flush();
                    }
                }
                SEList.Reverse();
            }
            catch (Exception ex)
            {
                Push_A_message_to_Room("Error:" + ex.Message + "\n");
            }


            Fstream.Close();
        }
    }
}
