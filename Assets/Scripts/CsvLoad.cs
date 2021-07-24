using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CsvLoad : MonoBehaviour
{
    void Start()
    {
        test();
    }

    void test()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources " + "/" + "Script.txt");

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split('\n');
            for (int i = 0; i < data_values.Length; i++)
            {
                Debug.Log(data_values[i].ToString());
            }
        }

    }
}