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

    public GameObject singleShotButtonLeft;
    public GameObject singleShotButtonRight;
    public GameObject DoubleShotButtonLeft;
    public GameObject DoubleShotButtonRight;
    private Image loadingLeft;
    private Image loadingRight;

    Recipe recipe;

    void Start(){
        recipe = GameObject.Find("RecipeTest").GetComponent<Recipe>();
        }

    


    //left side buttons of the espresso machine
    public void espressoButtonLeft(int shotAmount){
        if(shotAmount == 1 && !shotpullingLeft){
            loadingLeft = singleShotButtonLeft.GetComponent<Image>(); 
        }
        else if (shotAmount==2 && !shotpullingLeft){
            loadingLeft = DoubleShotButtonLeft.GetComponent<Image>();
        }

        if(!shotpullingLeft){
            shotpullingLeft = true;
            StartCoroutine(shotTimingLeft(shotAmount, loadingLeft));
        }
        else{
            shotpullingLeft = false;
            loadingLeft.fillAmount = 1;
            loadingLeft.color = new Color32(181,181,181,255);
        }
    }

    IEnumerator shotTimingLeft(int shotAmount, Image loading){
        shottimingLeft = 0;
            
        while(shotpullingLeft && shottimingLeft < 4 ){
            shottimingLeft += Time.deltaTime;

            fill = (float) shottimingLeft / 4;
            loading.fillAmount = fill;

            if(shottimingLeft < ristretto){
                loading.color = new Color32(255,255,255, 255);
            }
            else if(shottimingLeft < espresso){
                loading.color = new Color32(255,195,117, 255);
            }
            else if(shottimingLeft < lungo){
                loading.color = new Color32(255,155,97, 255);
            }
            else{
                loading.color = new Color32(255,97,97,255);
            }

            yield return null;
        }

        if(shottimingLeft < ristretto){
            Debug.Log("shot pulling cancelled (Left)");
        }
        else if(ristretto<= shottimingLeft && shottimingLeft < espresso){
            Debug.Log("ristretto: " + shotAmount + " shots (Left)");
            for(int i=0;i<shotAmount;i++){recipe.Add_shot();}
        }
        else if(espresso<shottimingLeft && shottimingLeft < lungo){
            Debug.Log("espresso: " + shotAmount + " shots (Left)");
            for(int i=0;i<shotAmount;i++){recipe.Add_shot();}
        }
        else if(shottimingLeft >= lungo){
            Debug.Log("lungo: " + shotAmount + " shots (Left)");
            for(int i=0;i<shotAmount;i++){recipe.Add_shot();}
        }

        

    }


    //right side of the espresso machine
    public void espressoButtonRight(int shotAmount){
        if(shotAmount == 1 && !shotpullingRight){
            loadingRight = singleShotButtonRight.GetComponent<Image>(); 
        }
        else if (shotAmount==2 && !shotpullingRight){
            loadingRight = DoubleShotButtonRight.GetComponent<Image>();
        }
        
        if(!shotpullingRight){
            shotpullingRight = true;
            StartCoroutine(shotTimingRight(shotAmount, loadingRight));
        }
        else{
            shotpullingRight = false;
            loadingRight.fillAmount = 1;
            loadingRight.color = new Color32(181,181,181,255);
        }
    }


    IEnumerator shotTimingRight(int shotAmount, Image loading){
        shottimingRight = 0;
            
        while(shotpullingRight && shottimingRight < 4 ){
            shottimingRight += Time.deltaTime;

            fill = (float) shottimingRight / 4;
            loading.fillAmount = fill;

            if(shottimingRight < ristretto){
                loading.color = new Color32(255,255,255, 255);
            }
            else if(shottimingRight < espresso){
                loading.color = new Color32(255,195,117, 255);
            }
            else if(shottimingRight < lungo){
                loading.color = new Color32(255,155,97, 255);
            }
            else{
                loading.color = new Color32(255,97,97,255);
            }

            yield return null;
        }

        if(shottimingRight < ristretto){
            Debug.Log("shot pulling cancelled (Right)");
            
        }
        else if(ristretto<= shottimingRight && shottimingRight < espresso){
            Debug.Log("ristretto: " + shotAmount + " shots (Right)");
            for(int i=0;i<shotAmount;i++){recipe.Add_shot();}
        }
        else if(espresso<shottimingRight && shottimingRight < lungo){
            Debug.Log("espresso: " + shotAmount + " shots (Right)");
            for(int i=0;i<shotAmount;i++){recipe.Add_shot();}
        }
        else if(shottimingRight >= lungo){
            Debug.Log("lungo: " + shotAmount + " shots (Right)");
            for(int i=0;i<shotAmount;i++){recipe.Add_shot();}
        }

    }
  
    

    
    

    


}
