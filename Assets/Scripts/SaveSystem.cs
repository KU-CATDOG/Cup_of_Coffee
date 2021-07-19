using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    private static string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init()
    {
        //Test if directory exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Creates the directory
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static bool Save(string saveString)
    {
        
        int saveNum = 1; //받아올 세이브 번호
        if (File.Exists("save" + saveNum + ".txt"))
        {
            Debug.Log("덮어쓰기?");
            return false;
        }
        File.WriteAllText(SAVE_FOLDER + "save.txt", saveString);
        return true;
    }

    public static void SaveOverwrite(string saveString)
    {
        int saveNum = 1; //받아올 세이브 번호
        if (File.Exists("save" + saveNum + ".txt"))
        {
            File.WriteAllText(SAVE_FOLDER + "save.txt", saveString);
        }
    }
    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] savefiles = directoryInfo.GetFiles("*.txt");
        
        if (File.Exists(Application.dataPath + "save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "save.txt");
            return saveString;
        }
        else return null;

    }
}
