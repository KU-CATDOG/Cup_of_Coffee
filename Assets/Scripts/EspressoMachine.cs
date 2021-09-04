using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspressoMachine : MonoBehaviour
{
    float ristretto = 1;
    float espresso = 2;
    float lungo = 3;
    public float shotType;


    public bool shotpullingLeft = false;
    float shottimingLeft = 0;
    public bool shotpullingRight = false;
    float shottimingRight = 0;
    public float fill = 0;

    public bool cupLeft1 = false;
    public bool cupLeft2 = false;
    public bool cupRight1 = false;
    public bool cupRight2 = false;

    public GameObject Left1;
    public GameObject Left2;
    public GameObject Left3;
    public GameObject Right1;
    public GameObject Right2;
    public GameObject Right3;
    private Image loadingLeft;
    private Image loadingRight;

    public shotGlassDisplay shotGlass;
    public bool isCanceled;
    Recipe recipe;

    void Start()
    {
        recipe = GameObject.Find("RecipeTest").GetComponent<Recipe>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {    //(임시) Z 누르면 컵 제거
            RemoveCupLeft();
            RemoveCupRight();
        }
    }

    #region SingleShot

    public bool PlaceCupLeft()
    {
        if (!cupLeft1)
        {
            shotGlass.ChangeState(1, true, (int)shotType);
            Debug.Log("First cup placed on the left side");
            return true;
        }
        else if (cupLeft1 && !cupLeft2)
        {
            shotGlass.ChangeState(2, true, (int)shotType);
            Debug.Log("Second cup placed on the left side");
            return true;
        }
        else
        {
            Debug.Log("Remove cups before pulling another shot");
            return false;               //컵 2개가 이미 놓여있을 경우 false
        }
    }

    public void RemoveCupLeft()
    { // cupLeft2 -> 1 순으로 컵 제거
        if (shotpullingLeft)
        {        //샷 내리는 중 컵 제거하면 샷도 취소
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
        }
        if (cupLeft2)
        {
            shotGlass.ChangeState(2, false);
            Debug.Log("Second cup removed (Left)");
        }
        else if (cupLeft1)
        {
            shotGlass.ChangeState(1, false);
            Debug.Log("First cup removed (Left)");
        }
        else
        {
            Debug.Log("No cup to remove (Left)");
        }
    }


    public void SingleRistretto()
    {

        shotType = ristretto;
        if (!shotpullingLeft)
        {
            if (PlaceCupLeft())
            {
                loadingLeft = Left1.GetComponent<Image>();
                shotpullingLeft = true;
                loadingLeft.color = new Color32(158, 222, 115, 255);
                StartCoroutine(ShotTimingLeft(ristretto, loadingLeft));
            }
        }
        else
        {
            isCanceled = true;
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
            RemoveCupLeft();

        }

    }


    public void SingleEspresso()
    {
        shotType = espresso;
        if (!shotpullingLeft)
        {
            if (PlaceCupLeft())
            {
                loadingLeft = Left2.GetComponent<Image>();
                shotpullingLeft = true;
                loadingLeft.color = new Color32(247, 234, 0, 255);
                StartCoroutine(ShotTimingLeft(espresso, loadingLeft));
            }
        }
        else
        {
            isCanceled = true;
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
            RemoveCupLeft();

        }
    }

    public void SingleLungo()
    {
        shotType = lungo;
        if (!shotpullingLeft)
        {
            if (PlaceCupLeft())
            {
                loadingLeft = Left3.GetComponent<Image>();
                shotpullingLeft = true;
                loadingLeft.color = new Color32(228, 137, 0, 255);
                StartCoroutine(ShotTimingLeft(lungo, loadingLeft));
            }
        }
        else
        {
            isCanceled = true;
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
            RemoveCupLeft();

        }
    }

    private IEnumerator ShotTimingLeft(float EspressoType, Image loading)
    {
        // if(cupLeft1 && cupLeft2){
        //     Debug.Log("remove cups before pulling another shot!");
        //     yield break;
        // }
        // else if(cupLeft1){
        //     cupLeft2 = true;
        //     Debug.Log("Second cup placed on the left side");
        // }
        // else{
        //     cupLeft1 = true;
        //     Debug.Log("First cup placed on the left side");
        // }

        shottimingLeft = 0;
        SoundManager.Instance.PlaySFXSound("shot_extraction");
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
                //recipe.Add_shot_ristretto();
            }
            else if (EspressoType == espresso)
            {
                Debug.Log("espresso: 1 shot");
                //recipe.Add_shot();
            }
            else if (EspressoType == lungo)
            {
                Debug.Log("lungo: 1 shot");
                //recipe.Add_shot_lungo();
            }
        }

        shotpullingLeft = false;
    }

    #endregion

    #region DoubleShot

    public bool PlaceCupRight()
    {
        if (!cupRight1 && !cupRight2)
        {
            shotGlass.ChangeState(3, true, (int)shotType);
            shotGlass.ChangeState(4, true, (int)shotType);
            Debug.Log("Both cups placed on the right side");
            return true;
        }
        else
        {
            Debug.Log("Remove cups before pulling another shot");
            return false;
        }
    }

    public void RemoveCupRight()
    {
        if (shotpullingRight)
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
        }
        if (cupRight1 && cupRight1)
        {
            shotGlass.ChangeState(3, false);
            shotGlass.ChangeState(4, false);
            Debug.Log("Both cups removed on the right side");
        }
        else
        {
            Debug.Log("No cup to remove (Right)");
        }
    }

    public void DoubleRistretto()
    {
        shotType = ristretto;
        if (!shotpullingRight)
        {
            if (PlaceCupRight())
            {
                loadingRight = Right1.GetComponent<Image>();
                shotpullingRight = true;
                loadingRight.color = new Color32(158, 222, 115, 255);
                StartCoroutine(ShotTimingRight(ristretto, loadingRight));
            }
        }
        else
        {
            isCanceled = true;
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
            RemoveCupRight();
        }

    }

    public void DoubleEspresso()
    {
        shotType = espresso;
        if (!shotpullingRight)
        {
            if (PlaceCupRight())
            {
                loadingRight = Right2.GetComponent<Image>();
                shotpullingRight = true;
                loadingRight.color = new Color32(247, 234, 0, 255);
                StartCoroutine(ShotTimingRight(espresso, loadingRight));
            }
        }
        else
        {
            isCanceled = true;
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
            RemoveCupRight();
        }
    }

    public void DoubleLungo()
    {
        shotType = lungo;
        if (!shotpullingRight)
        {
            if (PlaceCupRight())
            {
                loadingRight = Right3.GetComponent<Image>();
                shotpullingRight = true;
                loadingRight.color = new Color32(228, 137, 0, 255);
                StartCoroutine(ShotTimingRight(lungo, loadingRight));
            }
        }
        else
        {
            isCanceled = true;
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
            RemoveCupRight();
        }
    }

    private IEnumerator ShotTimingRight(float EspressoType, Image loading)
    {

        shottimingRight = 0;
        SoundManager.Instance.PlaySFXSound("shot_extraction");
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
                //recipe.Add_shot_ristretto();
                //recipe.Add_shot_ristretto();
            }
            else if (EspressoType == espresso)
            {
                Debug.Log("espresso: 2 shot");
                //recipe.Add_shot();
                //recipe.Add_shot();
            }
            else if (EspressoType == lungo)
            {
                Debug.Log("lungo: 2 shot");
                //recipe.Add_shot_lungo();
                //recipe.Add_shot_lungo();
            }

        }

        shotpullingRight = false;
    }



    #endregion





}
