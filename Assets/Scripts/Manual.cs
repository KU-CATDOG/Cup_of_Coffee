using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    public GameObject Square;
    public GameObject Coffee;
    public GameObject Latte;
    public GameObject Else;
    public GameObject Home;
    public GameObject Espresso;
    public GameObject Americano;
    public GameObject CafeMocha;
    public GameObject VanillaLatte;
    public GameObject CafeLatte;
    public GameObject GreenteaLatte;
    public GameObject StrawberryLatte;
    public GameObject Smoothie;
    public GameObject BubbleTea;
    public GameObject Frappuccino;

    private void Start()
    {
       

    }
    public void On() //Manual Open�� ��
    {
        Square.SetActive(true);
        Coffee.SetActive(true);
        Latte.SetActive(true);
        Else.SetActive(true);
        Home.SetActive(true);
        Espresso.SetActive(true);
        Americano.SetActive(true);
        CafeMocha.SetActive(true);
        VanillaLatte.SetActive(true);
        CafeLatte.SetActive(true);
        GreenteaLatte.SetActive(true);
        StrawberryLatte.SetActive(true);
        Smoothie.SetActive(true);
        BubbleTea.SetActive(true);
        Frappuccino.SetActive(true);

    }

  
    public void Off() // HomeŰ ������ �� �� ��Ȱ��ȭ
    {
        Square.SetActive(false);
        Coffee.SetActive(false);
        Latte.SetActive(false);
        Else.SetActive(false);
        Home.SetActive(false);
        Espresso.SetActive(false);
        Americano.SetActive(false);
        CafeMocha.SetActive(false);
        VanillaLatte.SetActive(false);
        CafeLatte.SetActive(false);
        GreenteaLatte.SetActive(false);
        StrawberryLatte.SetActive(false);
        Smoothie.SetActive(false);
        BubbleTea.SetActive(false);
        Frappuccino.SetActive(false);
    
    }

    public void Explain() //Home Ű �� �����
    {
        Square.SetActive(true);
        Coffee.SetActive(false);
        Latte.SetActive(false);
        Else.SetActive(false);
        Home.SetActive(true);
        Espresso.SetActive(false);
        Americano.SetActive(false);
        CafeMocha.SetActive(false);
        VanillaLatte.SetActive(false);
        CafeLatte.SetActive(false);
        GreenteaLatte.SetActive(false);
        StrawberryLatte.SetActive(false);
        Smoothie.SetActive(false);
        BubbleTea.SetActive(false);
        Frappuccino.SetActive(false);
       

    }
}
