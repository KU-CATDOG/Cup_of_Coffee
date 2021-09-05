using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Blending : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform rt;
    public GameObject blend;
    public GameObject spoon;
    public GameObject Recipe;
    public GameObject blendFront;
    public GameObject text;

    bool Spoonmove1 = false;
    bool Spoonmove2 = false;
    int blendtoken = 0;
    Vector2 initpos;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }


    public void Blend()
    {
        blend.SetActive(true);
        spoon.SetActive(true);
        blendFront.SetActive(true);
        text.SetActive(true);
    }
    public void OnBeginDrag(PointerEventData eventData) //드래그 시작할 때
    {
        initpos = spoon.transform.position;
    }

    public void OnDrag(PointerEventData eventData) //드래그 중일 때
    {
        rt.anchoredPosition += new Vector2(eventData.delta.x / 10, 0);


        if (rt.anchoredPosition.x < -6)
        {
            Spoonmove1 = true;
        }
        if (rt.anchoredPosition.x > 6 && Spoonmove1 == true)
        {
            Spoonmove2 = true;

        }
        if (Spoonmove1 == true && Spoonmove2 == true)
        {
            blendtoken++;
            Debug.Log(blendtoken + "번 섞음");
            if (blendtoken > 10)
            {
                Recipe.GetComponent<Recipe>().Add_mix();
                Debug.Log("다 섞었음");
                blendtoken = 0;
                spoon.transform.position = initpos;
                blend.SetActive(false);
                spoon.SetActive(false);
                blendFront.SetActive(false);
                text.SetActive(false);
                return;
            }

            Spoonmove1 = false;
            Spoonmove2 = false;

        }
    }

    public void OnEndDrag(PointerEventData eventData) //드래그 끝날 때
    {



    }


    public void OnPointerDown(PointerEventData eventData)
    {

    }

    void DistanceCheck()
    {

    }

    private void Update()
    {
        text.GetComponent<Text>().text = blendtoken + " 회 섞음";
    }



}

