using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSteamCup : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    enum SteamType
    {
        None,
        Bubble,
        Steam
    }

    public Recipe recipe;
    public Text steamTypeText;
    public float maxHeight;
    public float minHeight;
    public float bubbleHeight;
    public float steamHeight;

    [NonSerialized]
    public IEnumerator finishSteaming;
    [NonSerialized]
    public IEnumerator steamCheck;

    private const float steamingXPos = 395f;

    private bool steamingStart = false;

    private Vector2 originalPosition;

    private SteamType steamType = SteamType.None;
    private float bubble = 0;
    private float steam = 0;

    private void Start()
    {
        originalPosition = transform.localPosition;
        //transform.localPosition = new Vector2(transform.localPosition.x, minHeight);
        //gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!steamingStart)
        {
            steamingStart = true;
            StartCoroutine(finishSteaming);

            steamCheck = SteamCheck();
            StartCoroutine(steamCheck);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (steamingStart)
        {
            transform.position = new Vector2(transform.position.x, eventData.position.y);

            // y좌표가 범위 밖으로 못 나가게 함
            if (transform.localPosition.y < minHeight)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, minHeight);
            }
            else if (transform.localPosition.y > maxHeight)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, maxHeight);
            }

            if (transform.localPosition.y < bubbleHeight || transform.localPosition.y == steamHeight)
            {
                // none
                steamTypeText.text = "";
                steamType = SteamType.None;
            }
            else if (transform.localPosition.y >= bubbleHeight && transform.localPosition.y < steamHeight)
            {
                // 우유 거품
                steamTypeText.text = "Bubble";
                steamType = SteamType.Bubble;
            }
            else if (transform.localPosition.y > steamHeight)
            {
                // 스팀
                steamTypeText.text = "Steam";
                steamType = SteamType.Steam;
            }
        }
    }

    public void StartSteaming()
    {
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
    }

    public void FinishedSteaming()
    {
        if (bubble >= steam)
        {
            recipe.Add_milk_bubble();
        }
        else
        {
            recipe.Add_milk();
        }

        //Debug.Log("Bubble: " + bubble + " Steam: " + steam);
        StopSteaming();
    }

    private IEnumerator SteamCheck()
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
