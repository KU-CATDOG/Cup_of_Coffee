using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drink : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Sprite[] drinkImages;
    private Dictionary<string, Sprite> drinkImagesDic = new Dictionary<string, Sprite>();

    private Image image;
    private RectTransform rectTr;

    private Vector2 initPos;

    public CsvLoadCustomer Customer;
    public bool SpecialCustomer = false;

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

    public void OnBeginDrag(PointerEventData data)
    {
        //Debug.Log("OnBeginDrag");
        initPos = rectTr.anchoredPosition;
    }

    public void OnDrag(PointerEventData data)
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        rectTr.position = mousePos;

    }
    public void OnEndDrag(PointerEventData data)
    {
        //Debug.Log("OnEndDrag");
        if (rectTr.anchoredPosition.y < -124)
        {
            rectTr.anchoredPosition = initPos;
        }
        else
        {
            if(Customer.GetComponent<CsvLoadCustomer>().isActive){
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                rectTr.anchoredPosition = initPos;
                HideDrink();
            }
            else{
                SpecialCustomer = true;
                rectTr.anchoredPosition = initPos;
                HideDrink();
            }
        }

    }
}
