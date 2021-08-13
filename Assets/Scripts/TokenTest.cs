using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenTest : MonoBehaviour
{

    public Token token = new Token();
    public int a; //a = token 종류
    public int b; // b = token 개수


    public int happy;
    public int love;
    public int hope;
    public int peace;
    public int sad;
    public int anger;
    public int tired;
    public int fear;
    /*
    토큰 종류 
    token_happy;
    token_love;
    token_hope;
    token_peace;
    token_sad;
    token_anger;
    token_tired;
    token_fear;
    */
 
    void Update() 
    {
        happy = token.token_anger;
        love = token.token_love;
        hope = token.token_hope;
        peace = token.token_peace;
        sad = token.token_sad;
        anger = token.token_anger;
        tired = token.token_tired;
        fear = token.token_fear;


        if (Input.GetKeyDown(KeyCode.A))
        {
            TokenUp();

        }
    }

    public void TokenUp()
    {
        a = Random.Range(1, 8);
        b = Random.Range(1, 3);

        if (a == 1)
        {
            token.token_happy += b;
            Debug.Log("happy는" + token.token_happy);
        }
        if (a == 2)
        {
            token.token_love += b;
            Debug.Log("love는" + token.token_love);
        }
        if (a == 3)
        {
            token.token_hope += b;
            Debug.Log("hope는" + token.token_hope);
        }
        if (a == 4)
        {
            token.token_peace += b;
            Debug.Log("peace는" + token.token_peace);
        }
        if (a == 5)
        {
            token.token_sad += b;
            Debug.Log("sad는" + token.token_sad);
        }
        if (a == 6)
        {
            token.token_anger += b;
            Debug.Log("anger는" + token.token_anger);
        }
        if (a == 7)
        {
            token.token_tired += b;
            Debug.Log("tired는" + token.token_tired);

        }
        if (a == 8)
        {
            token.token_fear += b;
            Debug.Log("fear는" + token.token_fear);

        }


    }
}
