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

    public void Save(int saveNum)
    {
        //get daycount from gm?
        int dayCount = 0;
        int falseCount = 0;

        // TimeManager 오브젝트를 찾아서 day를 받아와 저장
        GameTime gameTime = GameObject.Find("TimeManager").GetComponent<GameTime>();
        if (gameTime != null)
        {
            dayCount = gameTime.day;
        }

        Debug.Log("save activated");

        SaveObject saveObject = new SaveObject
        {
            dayCount = dayCount,
            falseCount = falseCount
        };
        string json = JsonUtility.ToJson(saveObject);
        bool saveCheck = SaveSystem.Save(json, saveNum);
        if (!saveCheck)
        {
            if (overwriteCheck)
            {
                SaveSystem.SaveOverwrite(json, saveNum);
            }
        }

    }

    public void Load(int saveNum)
    {
        Debug.Log("load activated");
        string saveString = SaveSystem.Load(saveNum);
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            //Debug.Log(saveObject.dayCount + saveObject.falseCount);

            // 인게임씬에서 TimeManager 오브젝트를 찾아 dayCount를 적용
            GameTime gameTime = GameObject.Find("TimeManager").GetComponent<GameTime>();
            if (gameTime != null)
            {
                gameTime.day = saveObject.dayCount;
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        Save();
    //    }
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        Load();
    //    }
    //}

    private class SaveObject
    {
        public int dayCount;
        public int falseCount;
    }

}
