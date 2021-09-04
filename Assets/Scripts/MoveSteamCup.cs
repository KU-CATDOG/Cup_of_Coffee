using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSteamCup : MonoBehaviour
{
    public enum SteamType
    {
        None,
        Bubble,
        Steam
    }

    public Recipe recipe;
    public Text steamTypeText;
    public GameObject MilkCup;

    public float maxHeight;
    public float minHeight;
    public float bubbleHeight;
    public float steamHeight;

    [NonSerialized]
    public IEnumerator finishSteaming;
    [NonSerialized]
    public IEnumerator steamCheck;

    private const float steamingXPos = 395f;

    [HideInInspector]
    public bool steamingStart = false;

    private Vector2 originalPosition;

    public SteamType steamType = SteamType.None;
    private float bubble = 0;
    private float steam = 0;

    private void Start()
    {
        originalPosition = transform.localPosition;
        //transform.localPosition = new Vector2(transform.localPosition.x, minHeight);
        //gameObject.SetActive(false);
        MilkCup.SetActive(false);
    }

    

    public void StartSteaming()
    {
        MilkCup.SetActive(true);
        steamType = SteamType.None;
        steamTypeText.text = "";

        bubble = 0;
        steam = 0;
        transform.localPosition = new Vector2(steamingXPos, steamHeight);
    }

    public void StopSteaming()
    {
        steamingStart = false;
        steamTypeText.text = "";
        transform.localPosition = originalPosition;

        StopCoroutine(finishSteaming);
        StopCoroutine(steamCheck);
        MilkCup.SetActive(false);
    }

    public void FinishedSteaming()
    {
        if (bubble >= steam)
        {
            recipe.Add_milk_bubble();
        }
        else
        {
            if (recipe.pitcherMilkCount > 0)
            {
                int temp = recipe.pitcherMilkCount;
                for (int i = 0; i < temp; i++)
                {
                    recipe.Add_milk();
                }
            }

            recipe.Add_steam();
        }

        //Debug.Log("Bubble: " + bubble + " Steam: " + steam);
        StopSteaming();
    }
    
    
    public IEnumerator SteamCheck()
    {
        float time = 5f;
        while (time >= 0)
        {
            switch (steamType)
            {
                case SteamType.Bubble:
                    bubble += Time.deltaTime;
                    break;
                case SteamType.Steam:
                    steam += Time.deltaTime;
                    break;
            }
            time -= Time.deltaTime;
            yield return null;
        }
    }
    
}
