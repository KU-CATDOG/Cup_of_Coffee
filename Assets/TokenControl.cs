using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TokenControl : MonoBehaviour
{
    public bool isHidden;
    public Sprite[] tokenImages;
    private Dictionary<string, Sprite> tokenImagesDic = new Dictionary<string, Sprite>();

    private Image image;
    private RectTransform rectTr;

    private Vector2 initPos;

    public CsvLoadCustomer Customer;

    public bool SpecialCustomer = false;
    private void Start()
    {
        foreach (Sprite tokenImage in tokenImages)
        {
            tokenImagesDic.Add(tokenImage.name, tokenImage);
        }
        image = gameObject.GetComponent<Image>();
        rectTr = gameObject.GetComponent<RectTransform>();
        HideToken();
    }

    public void ShowToken(string name)
    {

        HideToken();
        image.color = Color.white;

        if (tokenImagesDic.ContainsKey(name) == false)
        {
            Debug.Log("No Image Resource: " + name);
            return;
        }

        image.sprite = tokenImagesDic[name];
        rectTr.sizeDelta = tokenImagesDic[name].bounds.size * 100;
        isHidden = false;
        StartCoroutine(Transition());

    }

    public void HideToken()
    {
        isHidden = true;
        image.sprite = null;
        rectTr.sizeDelta = Vector2.one * 100;
        image.color = Color.clear;
        rectTr.anchoredPosition = new Vector2(0, -110);
    }

    IEnumerator Transition()
    {
        Vector2 startPos = rectTr.anchoredPosition;
        Vector2 finalPos = new Vector2(0, rectTr.anchoredPosition.y - 140.0f);

        float elapsedTime = 0;

        while (elapsedTime < 1)
        {
            rectTr.anchoredPosition = Vector2.Lerp(startPos, finalPos, (elapsedTime / 1));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTr.anchoredPosition = finalPos;
    }
}
