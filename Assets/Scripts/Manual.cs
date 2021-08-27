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
    public GameObject CaramelMacchiato;
    public GameObject Americano;
    public GameObject CafeMocha;
    public GameObject Cappuchino;
    public GameObject VanillaLatte;
    public GameObject CafeLatte;
    public GameObject GreenteaLatte;
    public GameObject StrawberryLatte;
    public GameObject Choco;
    public GameObject Smoothie;
    public GameObject BubbleTea;
    public GameObject Frappuccino;

    public void On() //Manual Open할 때
    {
        Square.SetActive(true);
        Coffee.SetActive(true);
        Latte.SetActive(true);
        Else.SetActive(true);
        Home.SetActive(true);
        Espresso.SetActive(true);
        CaramelMacchiato.SetActive(true);
        Americano.SetActive(true);
        CafeMocha.SetActive(true);
        Cappuchino.SetActive(true);          
        VanillaLatte.SetActive(true);
        CafeLatte.SetActive(true);
        GreenteaLatte.SetActive(true);
        StrawberryLatte.SetActive(true);
        Choco.SetActive(true);
        Smoothie.SetActive(true);
        BubbleTea.SetActive(true);
        Frappuccino.SetActive(true);

    }


    public void Off() // Home키 눌렀을 때 다 비활성화
    {
        Square.SetActive(false);
        Coffee.SetActive(false);
        Latte.SetActive(false);
        Else.SetActive(false);
        Home.SetActive(false);
        Espresso.SetActive(false);
        CaramelMacchiato.SetActive(false);
        CafeMocha.SetActive(false);
        Cappuchino.SetActive(false);
        Americano.SetActive(false);
        CafeMocha.SetActive(false);
        VanillaLatte.SetActive(false);
        CafeLatte.SetActive(false);
        GreenteaLatte.SetActive(false);
        StrawberryLatte.SetActive(false);
        Choco.SetActive(false);
        Smoothie.SetActive(false);
        BubbleTea.SetActive(false);
        Frappuccino.SetActive(false);
        
    }

    public void Explain() //Home 키 만 남기기
        {
            Square.SetActive(true);
            Coffee.SetActive(false);
            Latte.SetActive(false);
            Else.SetActive(false);
            Home.SetActive(true);
            Espresso.SetActive(false);
            CaramelMacchiato.SetActive(false);
            CafeMocha.SetActive(false);
            Cappuchino.SetActive(false);
            Americano.SetActive(false);
            CafeMocha.SetActive(false);
            VanillaLatte.SetActive(false);
            CafeLatte.SetActive(false);
            GreenteaLatte.SetActive(false);
            StrawberryLatte.SetActive(false);
            Choco.SetActive(false);
            Smoothie.SetActive(false);
            BubbleTea.SetActive(false);
            Frappuccino.SetActive(false);

    }


}
