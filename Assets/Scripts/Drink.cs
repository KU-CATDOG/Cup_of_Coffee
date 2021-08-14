using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drink : MonoBehaviour
{
    public Sprite[] drinkImages;
    private Dictionary<string, Sprite> drinkImagesDic = new Dictionary<string, Sprite>();

    private Image image;
    private RectTransform rectTr;

    private void Start()
    {
        foreach (Sprite drinkImage in drinkImages)
        {
            drinkImagesDic.Add(drinkImage.name, drinkImage);
        }

        image = gameObject.GetComponent<Image>();
        rectTr = gameObject.GetComponent<RectTransform>();

        HideDrink();
    }

    public void ShowDrink(string name)
    {
        HideDrink();
        image.color = Color.white;

        if (drinkImagesDic.ContainsKey(name) == false)
        {
            Debug.Log("No Image Resource: " + name);
            return;
        }

        image.sprite = drinkImagesDic[name];
        rectTr.sizeDelta = drinkImagesDic[name].bounds.size * 100;
    }

    public void HideDrink()
    {
        image.sprite = null;
        rectTr.sizeDelta = Vector2.one * 100;
        image.color = Color.clear;
    }
}
