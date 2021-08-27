using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManualExplain : MonoBehaviour
{
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

    public void Start()
    {
        Espresso.SetActive(false);
        CaramelMacchiato.SetActive(false);
        Americano.SetActive(false);
        CafeMocha.SetActive(false);
        Cappuchino.SetActive(false);
        VanillaLatte.SetActive(false);
        CafeLatte.SetActive(false);
        GreenteaLatte.SetActive(false);
        StrawberryLatte.SetActive(false);
        Choco.SetActive(false);
        Smoothie.SetActive(false);
        BubbleTea.SetActive(false);
        Frappuccino.SetActive(false);

    }
    public void EspressoExplain()
    {
        Espresso.SetActive(true);
    }
    public void CaramelMacchiatoExplain()
    {
        CaramelMacchiato.SetActive(true);
    }
    public void AmericanoExplain()
    {
        Americano.SetActive(true);
    }
    public void CafeMochaExplain()
       {
           CafeMocha.SetActive(true);
       }
    public void CappuchinoExplain()
    {
        Cappuchino.SetActive(true);
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
    public void ChocoExplain()
    {
        Choco.SetActive(true);
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
        CaramelMacchiato.SetActive(false);
        Americano.SetActive(false);
        CafeMocha.SetActive(false);
        Cappuchino.SetActive(false); 
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
