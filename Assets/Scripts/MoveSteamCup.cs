using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSteamCup : MonoBehaviour, IDragHandler
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

    private const float steamingXPos = 395f;

    private bool isSteaming = false;

    private Vector2 originalPosition;

    private SteamType steamType = SteamType.None;

    private void Start()
    {
        originalPosition = transform.localPosition;
        //transform.localPosition = new Vector2(transform.localPosition.x, minHeight);
        //gameObject.SetActive(false);
    }

    public void StartSteaming()
    {
        isSteaming = true;
        steamType = SteamType.None;
        steamTypeText.text = "";
        transform.localPosition = new Vector2(steamingXPos, minHeight);
    }

    public void StopSteaming()
    {
        isSteaming = false;
        steamTypeText.text = "";
        transform.localPosition = originalPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isSteaming)
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

            if (transform.localPosition.y < bubbleHeight)
            {
                // none
                //Debug.Log("None");
                steamTypeText.text = "";
                steamType = SteamType.None;
            }
            else if (transform.localPosition.y >= bubbleHeight && transform.localPosition.y < steamHeight)
            {
                // 우유 거품
                //Debug.Log("Bubble");
                steamTypeText.text = "Bubble";
                steamType = SteamType.Bubble;
            }
            else if (transform.localPosition.y >= steamHeight)
            {
                // 스팀
                //Debug.Log("Steam");
                steamTypeText.text = "Steam";
                steamType = SteamType.Steam;
            }
        }
    }

    public void FinishedSteaming()
    {
        switch (steamType)
        {
            case SteamType.None:

                break;
            case SteamType.Bubble:
                recipe.Add_milk_bubble();
                break;
            case SteamType.Steam:
                recipe.Add_milk();
                break;
        }

        StopSteaming();
    }
}
