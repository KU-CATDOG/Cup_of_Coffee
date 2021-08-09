using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManualExplain : MonoBehaviour
{
    public GameObject Espresso;
    public GameObject CafeMocha;
    public GameObject Americano;
    public GameObject VanillaLatte;
    public GameObject CafeLatte;
    public GameObject GreenteaLatte;
    public GameObject StrawberryLatte;
    public GameObject Smoothie;
    public GameObject BubbleTea;
    public GameObject Frappuccino;

    public void Start()
    {
        Espresso.SetActive(false); 
        CafeMocha.SetActive(false); 
        Americano.SetActive(false);
        VanillaLatte.SetActive(false);
        CafeLatte.SetActive(false);
        GreenteaLatte.SetActive(false);
        StrawberryLatte.SetActive(false);
        Smoothie.SetActive(false);
        BubbleTea.SetActive(false);
        Frappuccino.SetActive(false);
    }
    public void EspressoExplain()
    {
        Espresso.SetActive(true);
    }
    public void CafeMochaExplain()
    {
        CafeMocha.SetActive(true);
    }
    public void AmericanoExplain()
    {
        Americano.SetActive(true);
    }
    public void VanillaLatteExplain()
    {
        VanillaLatte.SetActive(true);
    }
    public void CafeLatteExplain()
    {
        CafeLatte.SetActive(true);
    }
    public void GreenteaLatteExplain()
    {
        GreenteaLatte.SetActive(true);
    }
    public void StrawberryLatteExplain()
    {
        StrawberryLatte.SetActive(true);
    }
    public void SmoothieExplain()
    {
        Smoothie.SetActive(true);
    }
    public void BubbleteaExplain()
    {
        BubbleTea.SetActive(true);
    }
    public void FrappuccinoExplain()
    {
        Frappuccino.SetActive(true);
    }

    public void ManualEnd()
    {
        Espresso.SetActive(false);
        CafeMocha.SetActive(false);
        Americano.SetActive(false);
        VanillaLatte.SetActive(false);
        CafeLatte.SetActive(false);
        GreenteaLatte.SetActive(false);
        StrawberryLatte.SetActive(false);
        Smoothie.SetActive(false);
        BubbleTea.SetActive(false);
        Frappuccino.SetActive(false);
    }
}
