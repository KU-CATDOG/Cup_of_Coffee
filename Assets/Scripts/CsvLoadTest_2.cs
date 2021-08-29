using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class CsvLoadTest_2 : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text ViewScript;
    public Text NameTag;

    public GameObject Customer;
    public GameObject Customertext;

    public DialogueEvent DialogueEvent;

    public Image CharacterSprite;
    private TextAsset[] NPCscripts;

    GameTime gameTime;
    int dayCount = 0;
    int closeTime = 18; //마지막 손님 받는 시간
    public int currentOrder = 0;

    [HideInInspector]
    public bool getCustomerOrder = false, endScript = false, pausescript = false;

    public class scripts
    {   //class to store each script
        public int day;
        public int order;
        public string script;
        public string name;
    }

    List<scripts> inGameScripts = new List<scripts>(); //list to store all scripts
    public List<scripts> Sorted = new List<scripts>(); //sort scripts by day and order





    void Start()
    {
        Customer = GameObject.Find("CsvCustomer");
        gameTime = GameObject.Find("TimeManager").GetComponent<GameTime>();

        if (gameTime != null)
        {
            dayCount = gameTime.day;
        }

        LoadCSV();
        SortScripts();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (getCustomerOrder) // 알바생과 점장 대사가 끝났을 때
            {

                // DialogueBox.SetActive(false);
                // ViewScript.text = "";
                Customertext.SetActive(true);
                Customer.SetActive(true);
                Customer.GetComponent<CsvLoadCustomer>().isActive = true;

                if (gameTime.hour >= closeTime)
                {
                    Customertext.SetActive(false);
                    Customer.SetActive(false);
                    Customer.GetComponent<CsvLoadCustomer>().isActive = false;
                    getCustomerOrder = false;
                    endScript = false;
                }
            }
            else
            {
                if (DialogueBox.activeSelf == false)
                {
                    DialogueBox.SetActive(true);
                }
                LoadInGameScript();
            }
        }
    }

    #region initialize scripts

    void LoadCSV()
    {

        NPCscripts = Resources.LoadAll<TextAsset>("CharacterScripts");
        foreach (var script in NPCscripts)
        {
            string[] data = script.text.Split(new char[] { '\n' });

            for (int i = 0; i < data.Length - 1; i++)
            {
                var singleData = Regex.Split(data[i], ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                inGameScripts.Add(new scripts { day = int.Parse(singleData[0]), order = int.Parse(singleData[1]), script = singleData[2].Trim('"'), name = script.name.Split(' ')[0] });
            }
        }


    }

    void SortScripts()
    {
        Sorted = inGameScripts.OrderBy(x => x.day).ThenBy(x => x.order).ToList();
    }

    #endregion


    void LoadInGameScript()
    {
        dayCount = gameTime.day;

        if (endScript || Sorted[currentOrder].day != dayCount) //그 날의 대사가 끝났을 때
        {
            DialogueBox.SetActive(false);
            if (gameTime.hour < closeTime)
            {
                getCustomerOrder = true; //손님 주문 받기 시작
            }
            return;
        }
        else
        {
            DialogueBox.SetActive(true);
            DialogueEvent.EventByDay(Sorted[currentOrder].day, Sorted[currentOrder].order); //각 대사의 이벤트
            MatchCharacter(Sorted[currentOrder].name);
            if(!pausescript){
                ViewScript.text = Sorted[currentOrder].script;
                currentOrder++;
            }
        }

    }



    void MatchCharacter(string name)
    {
        NameTag.text = name;
        switch (name)
        {
            case "점장":
                CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/점장");
                break;
            case "카페알바생":
                CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/알바생2");
                break;
            case "감시자":
                CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/감시자");
                break;
            case "반란군":
                CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/반란군");
                break;
            case "브로커":
                CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/브로커");
                break;
            case "상관":
                CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/상관");
                break;
            default:
                CharacterSprite.gameObject.SetActive(false);
                break;
        }
    }


}