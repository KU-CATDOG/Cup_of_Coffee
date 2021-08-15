using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class CsvLoadTest : MonoBehaviour
{
    public Text ViewScript;
    public GameObject Customer;
    public GameObject Customertext;
    int currentOrder = 0;    

    
    GameTime gameTime;
    int dayCount = 0;

    public class scripts{   //class to store each script
        public int day;
        public int order;
        public string script;
    }

    List<scripts> inGameScripts = new List<scripts>(); //list to store all scripts
    List<scripts> Sorted = new List<scripts>(); //sort scripts by day and order

    void Start()
    {
        Customer = GameObject.Find("CsvCustomer");

        gameTime = GameObject.Find("TimeManager").GetComponent<GameTime>();
        if(gameTime !=null){
            dayCount = gameTime.day;
        }

        LoadCSV();
        SortScripts();

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            LoadInGameScript();
            if (currentOrder == 32) // 알바생과 점장 대사가 끝났을 때
            {
                ViewScript.text = "";
                Customertext.SetActive(true);
                Customer.SetActive(true);
                Customer.GetComponent<CsvLoadCustomer>().isActive = true;
            }
        }
    }

    void LoadCSV(){
        TextAsset scriptResource = Resources.Load<TextAsset>("점장 대사");
        TextAsset scriptResource2 = Resources.Load<TextAsset>("카페알바생 대사");

        string [] data = scriptResource.text.Split(new char[] { '\n' });
        string [] data2 = scriptResource2.text.Split(new char[] { '\n' });

        for(int i=0; i<data.Length-1; i++){
            var singleData = Regex.Split(data[i], ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            inGameScripts.Add(new scripts{day = int.Parse(singleData[0]), order = int.Parse(singleData[1]), script = singleData[2].Trim('"')});
        }

        for(int i=0; i<data2.Length-1; i++){
            var singleData = Regex.Split(data2[i], ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            inGameScripts.Add(new scripts{day = int.Parse(singleData[0]), order = int.Parse(singleData[1]), script = singleData[2].Trim('"')});
        }


    }

    void LoadInGameScript(){
        dayCount = gameTime.day;

        if(currentOrder >= Sorted.Count){
            return;
        }

        if(dayCount != Sorted[currentOrder].day){
            ViewScript.gameObject.SetActive(false);
            return;
        }
        else{
            ViewScript.gameObject.SetActive(true);
            ViewScript.text = Sorted[currentOrder].script;
            currentOrder++;
        }
        
    }

    void SortScripts(){
        Sorted = inGameScripts.OrderBy(x=> x.day).ThenBy(x=> x.order).ToList();
    }
    
}