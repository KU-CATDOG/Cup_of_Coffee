using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotGlassDisplay : MonoBehaviour
{
    public Sprite[] shotStateImg;

    public Image leftLeft;
    public Image leftRight;
    public Image rightLeft;
    public Image rightRight;

    public int[] cup = new int[4];

    public EspressoMachine EM;
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            cup[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// var= 변수, state= 바꿀 bool상태
    /// </summary>
    /// <param name="var"></param>
    /// <param name="state"></param>
    public void ChangeState(int var, bool state, int type = 0)
    {

        switch (var)
        {
            case 1:
                EM.cupLeft1 = state;
                if (state)
                {
                    cup[0] = (int)EM.shotType;
                    StartCoroutine(spriteChangeWaiter(1, EM.shotType));
                    //leftLeft.sprite = shotStateImg[1];
                }
                else
                {
                    cup[0] = 0;
                    leftLeft.sprite = shotStateImg[0];
                }
                break;
            case 2:
                EM.cupLeft2 = state;

                if (state)
                {
                    cup[1] = (int)EM.shotType;
                    StartCoroutine(spriteChangeWaiter(2, EM.shotType));
                    //leftRight.sprite = shotStateImg[1];
                }
                else
                {
                    cup[1] = 0;
                    leftRight.sprite = shotStateImg[0];
                }
                break;
            case 3:
                EM.cupRight1 = state;
                if (state)
                {
                    cup[2] = (int)EM.shotType;
                    StartCoroutine(spriteChangeWaiter(3, EM.shotType));
                    //rightLeft.sprite = shotStateImg[1];
                }
                else
                {
                    cup[2] = 0;
                    rightLeft.sprite = shotStateImg[0];
                }
                break;
            case 4:
                EM.cupRight2 = state;
                if (state)
                {
                    cup[3] = (int)EM.shotType;
                    StartCoroutine(spriteChangeWaiter(4, EM.shotType));
                    //rightRight.sprite = shotStateImg[1];
                }
                else
                {
                    cup[3] = 0;
                    rightRight.sprite = shotStateImg[0];
                }
                break;
            default:
                break;
        }
    }

    public void LLButton()
    {

        if (EM.cupLeft1)
        {
            switch (cup[0])
            {
                case 1:
                    recipe.Add_shot_ristretto();
                    break;
                case 2:
                    recipe.Add_shot();
                    break;
                case 3:
                    recipe.Add_shot_lungo();
                    break;
                default:
                    break;
            }
            ChangeState(1, false);
        }
    }

    public void LRButton()
    {

        if (EM.cupLeft2)
        {
            switch (cup[1])
            {
                case 1:
                    recipe.Add_shot_ristretto();
                    break;
                case 2:
                    recipe.Add_shot();
                    break;
                case 3:
                    recipe.Add_shot_lungo();
                    break;
                default:
                    break;
            }
            ChangeState(2, false);
        }
    }
    public void RLButton()
    {

        if (EM.cupRight1)
        {
            switch (cup[2])
            {
                case 1:
                    recipe.Add_shot_ristretto();
                    break;
                case 2:
                    recipe.Add_shot();
                    break;
                case 3:
                    recipe.Add_shot_lungo();
                    break;
                default:
                    break;
            }
            ChangeState(3, false);
        }
    }
    public void RRButton()
    {

        if (EM.cupRight2)
        {
            switch (cup[3])
            {
                case 1:
                    recipe.Add_shot_ristretto();
                    break;
                case 2:
                    recipe.Add_shot();
                    break;
                case 3:
                    recipe.Add_shot_lungo();
                    break;
                default:
                    break;
            }
            ChangeState(4, false);
        }
    }

    IEnumerator spriteChangeWaiter(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        switch (index)
        {
            case 1:
                if (EM.isCanceled)
                {
                    EM.isCanceled = false;
                    leftLeft.sprite = shotStateImg[0];
                    break;
                }
                leftLeft.sprite = shotStateImg[1];
                break;
            case 2:
                if (EM.isCanceled)
                {
                    EM.isCanceled = false;
                    leftRight.sprite = shotStateImg[0];
                    break;
                }
                leftRight.sprite = shotStateImg[1];
                break;
            case 3:
                if (EM.isCanceled)
                {
                    EM.isCanceled = false;
                    rightLeft.sprite = shotStateImg[0];
                    break;
                }
                rightLeft.sprite = shotStateImg[1];
                break;
            case 4:
                if (EM.isCanceled)
                {
                    EM.isCanceled = false;
                    rightRight.sprite = shotStateImg[0];
                    break;
                }
                rightRight.sprite = shotStateImg[1];
                break;

        }
    }
}
