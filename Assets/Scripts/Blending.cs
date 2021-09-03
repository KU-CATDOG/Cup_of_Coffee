using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Blending : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform recttransform;
    public GameObject blend;
    public GameObject spoon;
    public GameObject Recipe;
    public GameObject blendFront;

    bool Spoonmove1 = false;
    bool Spoonmove2 = false;
    int blendtoken = 0;

    void Start()
    {
        recttransform = GetComponent<RectTransform>();
    }


    public void Blend()
    {
        blend.SetActive(true);
        spoon.SetActive(true);
        blendFront.SetActive(true);
    }
    public void OnBeginDrag(PointerEventData eventData) //드래그 시작할 때
    {

    }

    public void OnDrag(PointerEventData eventData) //드래그 중일 때
    {

        recttransform.anchoredPosition += new Vector2(eventData.delta.x / 10, 0);
        if (recttransform.anchoredPosition.x < 290)
        {
            Spoonmove1 = true;
        }
        if (recttransform.anchoredPosition.x > 290 && Spoonmove1 == true)
        {
            Spoonmove2 = true;

        }
        if (Spoonmove1 == true && Spoonmove2 == true)
        {
            blendtoken++;
            Debug.Log(blendtoken + "번 섞음");
            if (blendtoken > 10)
            {
                Recipe.GetComponent<Recipe>().Add_blend();
                Debug.Log("다 섞었음");
                blendtoken = 0;
                blend.SetActive(false);
                spoon.SetActive(false);
                blendFront.SetActive(false);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    
}

