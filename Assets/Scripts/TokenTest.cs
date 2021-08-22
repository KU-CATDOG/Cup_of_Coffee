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
    public int real;
    public int fake;
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
        happy = token.token_happy; // 1
        love = token.token_love; // 2
        hope = token.token_hope; // 3
        peace = token.token_peace; // 4
        sad = token.token_sad; // 5
        anger = token.token_anger; // 6
        tired = token.token_tired; // 7
        fear = token.token_fear; // 8
        real = token.real_token;
        fake = token.fake_token;


    }


    public void happyUp()
    {
        token.token_happy += Random.Range(1,3);
        Debug.Log("happy는" + token.token_happy);

    }
    public void loveUp()
    {
        token.token_love += Random.Range(1, 3);
        Debug.Log("love는" + token.token_love);

    }
    public void hopeUp()
    {
        token.token_hope += Random.Range(1, 3);
        Debug.Log("hope는" + token.token_hope);

    }
    public void peaceUp()
    {
        token.token_peace += Random.Range(1, 3);
        Debug.Log("peace는" + token.token_peace);

    }
    public void sadUp()
    {
        token.token_sad += Random.Range(1, 3);
        Debug.Log("sad는" + token.token_sad);

    }
    public void angerUp()
    {
        token.token_anger += Random.Range(1, 3);
        Debug.Log("anger는" + token.token_anger);

    }
    public void tiredUp()
    {
        token.token_tired += Random.Range(1, 3);
        Debug.Log("tired는" + token.token_tired);

    }
    public void fearUp()
    {
        token.token_fear += Random.Range(1, 3);
        Debug.Log("fear는" + token.token_fear);

    }

    public void RealToken(int customertoken)
    {
        token.real_token++;

        if (customertoken == 1)
        {
            happyUp();
        }
        else if (customertoken == 2)
        {
            loveUp();
        }
        else if (customertoken == 3)
        {
            hopeUp();
        }
        else if (customertoken == 4)
        {
            peaceUp();
        }
        else if (customertoken == 5)
        {
            sadUp();
        }
        else if (customertoken == 6)
        {
            angerUp();
        }
        else if (customertoken == 7)
        {
            tiredUp();
        }
        else
        {
            fearUp();
        }
    }

    public void FakeToken(int number)
    {
        token.fake_token++;

        if(number == 1) //Customer의 진짜 감정이 happy일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1: loveUp();
                        break;
                case 2:
                        hopeUp();
                        break;
                case 3:
                       peaceUp();
                        break;
                case 4:
                        sadUp();
                        break;
                case 5:
                        angerUp();
                        break;
                case 6:
                        tiredUp();
                        break;
                case 7:
                        fearUp();
                        break;

            }

        }
        else if (number == 2) //Customer의 진짜 감정이 love일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    hopeUp();
                    break;
                case 3:
                    peaceUp();
                    break;
                case 4:
                    sadUp();
                    break;
                case 5:
                    angerUp();
                    break;
                case 6:
                    tiredUp();
                    break;
                case 7:
                    fearUp();
                    break;

            }
        }
        else if (number == 3) //Customer의 진짜 감정이 hope일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    loveUp();
                    break;
                case 3:
                    peaceUp();
                    break;
                case 4:
                    sadUp();
                    break;
                case 5:
                    angerUp();
                    break;
                case 6:
                    tiredUp();
                    break;
                case 7:
                    fearUp();
                    break;

            }
        }
        else if (number == 4) //Customer의 진짜 감정이 peace일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    loveUp();
                    break;
                case 3:
                    hopeUp();
                    break;
                case 4:
                    sadUp();
                    break;
                case 5:
                    angerUp();
                    break;
                case 6:
                    tiredUp();
                    break;
                case 7:
                    fearUp();
                    break;

            }
        }
        else if (number == 5) //Customer의 진짜 감정이 sad일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    loveUp();
                    break;
                case 3:
                    hopeUp();
                    break;
                case 4:
                    peaceUp();
                    break;
                case 5:
                    angerUp();
                    break;
                case 6:
                    tiredUp();
                    break;
                case 7:
                    fearUp();
                    break;

            }
        }
        else if (number == 6) //Customer의 진짜 감정이 anger일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    loveUp();
                    break;
                case 3:
                    hopeUp();
                    break;
                case 4:
                    peaceUp();
                    break;
                case 5:
                    sadUp();
                    break;
                case 6:
                    tiredUp();
                    break;
                case 7:
                    fearUp();
                    break;

            }
        }
        else if (number == 7) //Customer의 진짜 감정이 tired일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    loveUp();
                    break;
                case 3:
                    hopeUp();
                    break;
                case 4:
                    peaceUp();
                    break;
                case 5:
                    sadUp();
                    break;
                case 6:
                    angerUp();
                    break;
                case 7:
                    fearUp();
                    break;

            }
        }
        else//Customer의 진짜 감정이 fear일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    happyUp();
                    break;
                case 2:
                    loveUp();
                    break;
                case 3:
                    hopeUp();
                    break;
                case 4:
                    peaceUp();
                    break;
                case 5:
                    sadUp();
                    break;
                case 6:
                    angerUp();
                    break;
                case 7:
                    tiredUp();
                    break;

            }
        }



    }


}
