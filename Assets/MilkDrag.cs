using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MilkDrag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public MoveSteamCup steamCup;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!steamCup.steamingStart)
        {
            steamCup.steamingStart = true;
            StartCoroutine(steamCup.finishSteaming);

            steamCup.steamCheck = steamCup.SteamCheck();
            StartCoroutine(steamCup.steamCheck);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (steamCup.steamingStart)
        {
            transform.position = new Vector2(transform.position.x, eventData.position.y);

            // y��ǥ�� ���� ������ �� ������ ��
            if (transform.localPosition.y < steamCup.minHeight)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, steamCup.minHeight);
            }
            else if (transform.localPosition.y > steamCup.maxHeight)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, steamCup.maxHeight);
            }

            if (transform.localPosition.y < steamCup.bubbleHeight || transform.localPosition.y == steamCup.steamHeight)
            {
                // none
                steamCup.steamTypeText.text = "";
                steamCup.steamType = MoveSteamCup.SteamType.None;
            }
            else if (transform.localPosition.y >= steamCup.bubbleHeight && transform.localPosition.y < steamCup.steamHeight)
            {
                // ���� ��ǰ
                steamCup.steamTypeText.text = "Bubble";
                steamCup.steamType = MoveSteamCup.SteamType.Bubble;
            }
            else if (transform.localPosition.y > steamCup.steamHeight)
            {
                // ����
                steamCup.steamTypeText.text = "Steam";
                steamCup.steamType = MoveSteamCup.SteamType.Steam;
            }
        }
    }
}
