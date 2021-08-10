using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSteamCup : MonoBehaviour, IDragHandler
{
    public float maxHeight;
    public float minHeight;
    public float bubbleHeight;
    public float steamHeight;

    private void Start()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, minHeight);
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2(transform.position.x, eventData.position.y);

        // y��ǥ�� ���� ������ �� ������ ��
        if (transform.localPosition.y < minHeight)
            transform.localPosition = new Vector2(transform.localPosition.x, minHeight);
        else if (transform.localPosition.y > maxHeight)
            transform.localPosition = new Vector2(transform.localPosition.x, maxHeight);

        if (transform.localPosition.y < bubbleHeight)
        {
            // none
            Debug.Log("None");
        }
        else if (transform.localPosition.y >= bubbleHeight && transform.localPosition.y < steamHeight)
        {
            // ���� ��ǰ
            Debug.Log("Bubble");
        }
        else if (transform.localPosition.y >= steamHeight)
        {
            // ����
            Debug.Log("Steam");
        }
    }
}
