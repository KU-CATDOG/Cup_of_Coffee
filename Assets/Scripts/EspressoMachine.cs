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

    bool cupLeft1 = false;
    bool cupLeft2 = false;
    bool cupRight1 = false;
    bool cupRight2 = false;

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

    void Update(){
        if(Input.GetKeyDown(KeyCode.Z)){    //(임시) Z 누르면 컵 제거
            removeCupLeft();
            removeCupRight();
        }
    }

    #region SingleShot

    public bool placeCupLeft(){
        if(!cupLeft1){
            cupLeft1 = true;
            Debug.Log("First cup placed on the left side");
            return true;
        }
        else if(cupLeft1 && !cupLeft2){
            cupLeft2 = true;
            Debug.Log("Second cup placed on the left side");
            return true;
        }
        else {
            Debug.Log("Remove cups before pulling another shot");
            return false;               //컵 2개가 이미 놓여있을 경우 false
        }
    }

    public void removeCupLeft(){ // cupLeft2 -> 1 순으로 컵 제거
        if(shotpullingLeft){        //샷 내리는 중 컵 제거하면 샷도 취소
            shotpullingLeft= false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
        }
        if(cupLeft2){
            cupLeft2 = false;
            Debug.Log("Second cup removed (Left)");
        }
        else if(cupLeft1){
            cupLeft1 = false;
            Debug.Log("First cup removed (Left)");
        }
        else{
            Debug.Log("No cup to remove (Left)");
        }
    }

    
    public void SingleRistretto()
    {
        
        if (!shotpullingLeft)
        {
            if(placeCupLeft()){
                loadingLeft = Left1.GetComponent<Image>();
                shotpullingLeft = true;
                loadingLeft.color = new Color32(158, 222, 115, 255);
                StartCoroutine(shotTimingLeft(ristretto, loadingLeft));
            }
        }
        else
        {
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
            removeCupLeft();
            
        }

    }


    public void SingleEspresso()
    {

        if (!shotpullingLeft)
        {
            if(placeCupLeft()){
                loadingLeft = Left2.GetComponent<Image>();
                shotpullingLeft = true;
                loadingLeft.color = new Color32(247, 234, 0, 255);
                StartCoroutine(shotTimingLeft(espresso, loadingLeft));
            }
        }
        else
        {
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
            removeCupLeft();
            
        }
    }

    public void SingleLungo()
    {

        if (!shotpullingLeft)
        {
            if(placeCupLeft()){
                loadingLeft = Left3.GetComponent<Image>();
                shotpullingLeft = true;
                loadingLeft.color = new Color32(228, 137, 0, 255);
                StartCoroutine(shotTimingLeft(lungo, loadingLeft));
            }
        }
        else
        {
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(200, 200, 200, 128);
            removeCupLeft();
            
        }
    }


    IEnumerator shotTimingLeft(float EspressoType, Image loading)
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

    public bool placeCupRight(){
        if(!cupRight1 && !cupRight2){
            cupRight1 = true;
            cupRight2 = true;
            Debug.Log("Both cups placed on the right side");
            return true;
        }
        else{
            Debug.Log("Remove cups before pulling another shot");
            return false;
        }
    }

    public void removeCupRight(){ 
        if(shotpullingRight){        
            shotpullingRight= false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
        }
        if(cupRight1 && cupRight1){
            cupRight1 = false;
            cupRight2 = false;
            Debug.Log("Both cups removed on the right side");
        }
        else{
            Debug.Log("No cup to remove (Right)");
        }
    }

    public void DoubleRistretto()
    {

        if (!shotpullingRight)
        {
            if(placeCupRight()){
                loadingRight = Right1.GetComponent<Image>();
                shotpullingRight = true;
                loadingRight.color = new Color32(158, 222, 115, 255);
                StartCoroutine(shotTimingRight(ristretto, loadingRight));
            }
        }
        else
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
            removeCupRight();
        }

    }

    public void DoubleEspresso()
    {

        if (!shotpullingRight)
        {
            if(placeCupRight()){
                loadingRight = Right2.GetComponent<Image>();
                shotpullingRight = true;
                loadingRight.color = new Color32(247, 234, 0, 255);
                StartCoroutine(shotTimingRight(espresso, loadingRight));
            }
        }
        else
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
            removeCupRight();
        }
    }

    public void DoubleLungo()
    {

        if (!shotpullingRight)
        {
            if(placeCupRight()){
                loadingRight = Right3.GetComponent<Image>();
                shotpullingRight = true;
                loadingRight.color = new Color32(228, 137, 0, 255);
                StartCoroutine(shotTimingRight(lungo, loadingRight));
            }
        }
        else
        {
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(200, 200, 200, 128);
            removeCupRight();
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
