using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    public bool overwriteCheck;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        SaveSystem.Init(); 
    }

    private void Save()
    {
        //get daycount from gm?
        int dayCount = 0;
        int falseCount = 0;

        Debug.Log("save activated");

        SaveObject saveObject = new SaveObject
        {
            dayCount = dayCount,
            falseCount = falseCount
        };
        string json = JsonUtility.ToJson(saveObject);
        bool saveCheck = SaveSystem.Save(json);
        if (!saveCheck)
        {
            if (overwriteCheck)
            {
                SaveSystem.SaveOverwrite(json);
            }
        }

    }

    private void Load()
    {
        Debug.Log("load activated");
        string saveString = SaveSystem.Load();        
        if (saveString != null) 
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            //Debug.Log(saveObject.dayCount + saveObject.falseCount);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private class SaveObject
    {
        public int dayCount;
        public int falseCount;
    }

}
