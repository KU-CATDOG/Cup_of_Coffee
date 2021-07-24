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

    public static bool Save(string saveString, int saveNum)
    {
        
        //int saveNum = 1; //받아올 세이브 번호
        if (File.Exists(SAVE_FOLDER + "save" + saveNum + ".txt"))
        {
            Debug.Log("덮어쓰기?");
            return false;
        }
        File.WriteAllText(SAVE_FOLDER + "save" + saveNum + ".txt", saveString);
        return true;
    }

    public static void SaveOverwrite(string saveString, int saveNum)
    {
        //int saveNum = 1; //받아올 세이브 번호
        if (File.Exists(SAVE_FOLDER + "save" + saveNum + ".txt"))
        {
            File.WriteAllText(SAVE_FOLDER + "save" + saveNum + ".txt", saveString);
        }
    }

    public static string Load(int saveNum)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] savefiles = directoryInfo.GetFiles("*.txt");
        
        if (File.Exists(SAVE_FOLDER + "save" + saveNum + ".txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "save" + saveNum + ".txt");
            return saveString;
        }
        else return null;

    }

    public static int GetSaveFileCount() {
        int count = 0;

        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] savefiles = directoryInfo.GetFiles("*.txt");

        foreach (var saveFile in savefiles) {
            if (saveFile.Name.Contains("save")) {
                count++;
            }
        }

        return count;
    } 
}
