using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Blending : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform recttransform;
    public GameObject blend;
    public GameObject spoon;
    bool Spoonmove1 = false;
    bool Spoonmove2 = false;
    int blendtoken = 0;
    void Start()
    {
        recttransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Blend()
    {
        blend.SetActive(true);
        spoon.SetActive(true);

    }
    public void OnBeginDrag(PointerEventData eventData) //�巡�� ������ ��
    {


    }

    public void OnDrag(PointerEventData eventData) //�巡�� ���� ��
    {


        recttransform.anchoredPosition += eventData.delta;
        if (recttransform.anchoredPosition.x < -160)
        {
            Spoonmove1 = true;
        }
        if (recttransform.anchoredPosition.x > -160 && Spoonmove1 == true)
        {
            Spoonmove2 = true;

        }
        if (Spoonmove1 == true && Spoonmove2 == true)
        {
            blendtoken++;
            Debug.Log(blendtoken + "�� ����");
            Spoonmove1 = false;
            Spoonmove2 = false;

        }
    }

    public void OnEndDrag(PointerEventData eventData) //�巡�� ���� ��
    {



    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    void DistanceCheck()
    {

    }
}
