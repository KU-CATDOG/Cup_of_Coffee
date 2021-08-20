using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class CsvLoadTest : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text ViewScript;
    public Text NameTag;

    public GameObject Customer;
    public GameObject Customertext;


    public Image CharacterSprite;
    private TextAsset[] NPCscripts;

    GameTime gameTime;
    int dayCount = 0;

    int currentOrder = 0;



    public class scripts
    {   //class to store each script
        public int day;
        public int order;
        public string script;
        public string name;
    }

    List<scripts> inGameScripts = new List<scripts>(); //list to store all scripts
    List<scripts> Sorted = new List<scripts>(); //sort scripts by day and order

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

            if (currentOrder >= 32) // 알바생과 점장 대사가 끝났을 때
            {
                ViewScript.text = "";
                Customertext.SetActive(true);
                Customer.SetActive(true);
                Customer.GetComponent<CsvLoadCustomer>().isActive = true;
            }
            else
            {
                LoadInGameScript();
            }
        }
    }


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

    void LoadInGameScript()
    {
        dayCount = gameTime.day;

        if (currentOrder >= Sorted.Count)
        {
            DialogueBox.SetActive(false);
            return;
        }

        if (dayCount != Sorted[currentOrder].day)
        {
            DialogueBox.SetActive(false);
            return;
        }
        else
        {
            DialogueBox.SetActive(true);

            MatchCharacter(Sorted[currentOrder].name);
            ViewScript.text = Sorted[currentOrder].script;
            currentOrder++;
        }

    }

    void SortScripts()
    {
        Sorted = inGameScripts.OrderBy(x => x.day).ThenBy(x => x.order).ToList();
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
        }
    }

}