using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspressoMachine : MonoBehaviour
{
    float ristretto = 1;
    float espresso = 2;
    float lungo = 3;

    bool shotpullingLeft = false;
    float shottimingLeft = 0;
    bool shotpullingRight = false;
    float shottimingRight = 0;
    float fill = 0;

    public GameObject Left1;
    public GameObject Left2;
    public GameObject Left3;
    public GameObject Right1;
    public GameObject Right2;
    public GameObject Right3;
    private Image loadingLeft;
    private Image loadingRight;

    Recipe recipe;

    void Start()
    {
        recipe = GameObject.Find("RecipeTest").GetComponent<Recipe>();
    }

    #region SingleShot
    public void SingleRistretto()
    {
        if (!shotpullingLeft)
        {
            loadingLeft = Left1.GetComponent<Image>();
            shotpullingLeft = true;
            loadingLeft.color = new Color32(158, 222, 115, 255);
            StartCoroutine(shotTimingLeft(ristretto, loadingLeft));
        }
        else
        {
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
        }

    }


    public void SingleEspresso()
    {

        if (!shotpullingLeft)
        {
            loadingLeft = Left2.GetComponent<Image>();
            shotpullingLeft = true;
            loadingLeft.color = new Color32(247, 234, 0, 255);
            StartCoroutine(shotTimingLeft(espresso, loadingLeft));
        }
        else
        {
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
        }
    }

    public void SingleLungo()
    {

        if (!shotpullingLeft)
        {
            loadingLeft = Left3.GetComponent<Image>();
            shotpullingLeft = true;
            loadingLeft.color = new Color32(228, 137, 0, 255);
            StartCoroutine(shotTimingLeft(lungo, loadingLeft));
        }
        else
        {
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
        }
    }


    IEnumerator shotTimingLeft(float EspressoType, Image loading)
    {
        shottimingLeft = 0;

        while (shotpullingLeft && shottimingLeft < EspressoType)
        {
            shottimingLeft += Time.deltaTime;

            fill = (float)shottimingLeft / EspressoType;
            loadingLeft.fillAmount = fill;

            yield return null;
        }

        if (shotpullingLeft)
        {
            if (EspressoType == ristretto)
            {
                Debug.Log("ristretto: 1 shot");
                recipe.Add_shot();
            }
            else if (EspressoType == espresso)
            {
                Debug.Log("espresso: 1 shot");
                recipe.Add_shot();
            }
            else if (EspressoType == lungo)
            {
                Debug.Log("lungo: 1 shot");
                recipe.Add_shot();
            }
        }

        shotpullingLeft = false;
    }

    #endregion

    #region DoubleShot
    public void DoubleRistretto()
    {

        if (!shotpullingRight)
        {
            loadingRight = Right1.GetComponent<Image>();
            shotpullingRight = true;
            loadingRight.color = new Color32(158, 222, 115, 255);
            StartCoroutine(shotTimingRight(ristretto, loadingRight));
        }
        else
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
        }

    }

    public void DoubleEspresso()
    {

        if (!shotpullingRight)
        {
            loadingRight = Right2.GetComponent<Image>();
            shotpullingRight = true;
            loadingRight.color = new Color32(247, 234, 0, 255);
            StartCoroutine(shotTimingRight(espresso, loadingRight));
        }
        else
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
        }
    }

    public void DoubleLungo()
    {

        if (!shotpullingRight)
        {
            loadingRight = Right3.GetComponent<Image>();
            shotpullingRight = true;
            loadingRight.color = new Color32(228, 137, 0, 255);
            StartCoroutine(shotTimingRight(lungo, loadingRight));
        }
        else
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
        }
    }


    IEnumerator shotTimingRight(float EspressoType, Image loading)
    {
        shottimingRight = 0;

        while (shotpullingRight && shottimingRight < EspressoType)
        {
            shottimingRight += Time.deltaTime;

            fill = (float)shottimingRight / EspressoType;
            loadingRight.fillAmount = fill;

            yield return null;
        }

        if (shotpullingRight)
        {
            if (EspressoType == ristretto)
            {
                Debug.Log("ristretto: 2 shot");
                recipe.Add_shot();
                recipe.Add_shot();
            }
            else if (EspressoType == espresso)
            {
                Debug.Log("espresso: 2 shot");
                recipe.Add_shot();
                recipe.Add_shot();
            }
            else if (EspressoType == lungo)
            {
                Debug.Log("lungo: 2 shot");
                recipe.Add_shot();
                recipe.Add_shot();
            }
        }

        shotpullingRight = false;
    }



    #endregion





}
