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
    public int totalToken;
    public int tokenToGive;
    public Text GiveTokenText;
    List<int> TokenList = new List<int>();
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

    void Start()
    {
        GiveTokenText = GameObject.Find("GiveTokenText").GetComponent<Text>();
    }
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
        totalToken = happy + love + hope + peace + sad + anger + tired + fear;

    }


    public void HappyUp()
    {
        token.token_happy += Random.Range(1, 3);
        Debug.Log("happy는" + token.token_happy);

    }
    public void LoveUp()
    {
        token.token_love += Random.Range(1, 3);
        Debug.Log("love는" + token.token_love);

    }
    public void HopeUp()
    {
        token.token_hope += Random.Range(1, 3);
        Debug.Log("hope는" + token.token_hope);

    }
    public void PeaceUp()
    {
        token.token_peace += Random.Range(1, 3);
        Debug.Log("peace는" + token.token_peace);

    }
    public void SadUp()
    {
        token.token_sad += Random.Range(1, 3);
        Debug.Log("sad는" + token.token_sad);

    }
    public void AngerUp()
    {
        token.token_anger += Random.Range(1, 3);
        Debug.Log("anger는" + token.token_anger);

    }
    public void TiredUp()
    {
        token.token_tired += Random.Range(1, 3);
        Debug.Log("tired는" + token.token_tired);

    }
    public void FearUp()
    {
        token.token_fear += Random.Range(1, 3);
        Debug.Log("fear는" + token.token_fear);

    }

    public void RealToken(int customertoken)
    {
        token.real_token++;

        if (customertoken == 1)
        {
            HappyUp();
        }
        else if (customertoken == 2)
        {
            LoveUp();
        }
        else if (customertoken == 3)
        {
            HopeUp();
        }
        else if (customertoken == 4)
        {
            PeaceUp();
        }
        else if (customertoken == 5)
        {
            SadUp();
        }
        else if (customertoken == 6)
        {
            AngerUp();
        }
        else if (customertoken == 7)
        {
            TiredUp();
        }
        else
        {
            FearUp();
        }
    }

    public void FakeToken(int number)
    {
        token.fake_token++;

        if (number == 1) //Customer의 진짜 감정이 happy일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    LoveUp();
                    break;
                case 2:
                    HopeUp();
                    break;
                case 3:
                    PeaceUp();
                    break;
                case 4:
                    SadUp();
                    break;
                case 5:
                    AngerUp();
                    break;
                case 6:
                    TiredUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }

        }
        else if (number == 2) //Customer의 진짜 감정이 love일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    HopeUp();
                    break;
                case 3:
                    PeaceUp();
                    break;
                case 4:
                    SadUp();
                    break;
                case 5:
                    AngerUp();
                    break;
                case 6:
                    TiredUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }
        }
        else if (number == 3) //Customer의 진짜 감정이 hope일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    LoveUp();
                    break;
                case 3:
                    PeaceUp();
                    break;
                case 4:
                    SadUp();
                    break;
                case 5:
                    AngerUp();
                    break;
                case 6:
                    TiredUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }
        }
        else if (number == 4) //Customer의 진짜 감정이 peace일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    LoveUp();
                    break;
                case 3:
                    HopeUp();
                    break;
                case 4:
                    SadUp();
                    break;
                case 5:
                    AngerUp();
                    break;
                case 6:
                    TiredUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }
        }
        else if (number == 5) //Customer의 진짜 감정이 sad일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    LoveUp();
                    break;
                case 3:
                    HopeUp();
                    break;
                case 4:
                    PeaceUp();
                    break;
                case 5:
                    AngerUp();
                    break;
                case 6:
                    TiredUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }
        }
        else if (number == 6) //Customer의 진짜 감정이 anger일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    LoveUp();
                    break;
                case 3:
                    HopeUp();
                    break;
                case 4:
                    PeaceUp();
                    break;
                case 5:
                    SadUp();
                    break;
                case 6:
                    TiredUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }
        }
        else if (number == 7) //Customer의 진짜 감정이 tired일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    LoveUp();
                    break;
                case 3:
                    HopeUp();
                    break;
                case 4:
                    PeaceUp();
                    break;
                case 5:
                    SadUp();
                    break;
                case 6:
                    AngerUp();
                    break;
                case 7:
                    FearUp();
                    break;

            }
        }
        else//Customer의 진짜 감정이 fear일때
        {
            int b = Random.Range(1, 7);

            switch (b)
            {
                case 1:
                    HappyUp();
                    break;
                case 2:
                    LoveUp();
                    break;
                case 3:
                    HopeUp();
                    break;
                case 4:
                    PeaceUp();
                    break;
                case 5:
                    SadUp();
                    break;
                case 6:
                    AngerUp();
                    break;
                case 7:
                    TiredUp();
                    break;

            }
        }



    }


    public void ClickTokenUp()
    {
        if (tokenToGive < totalToken && tokenToGive < 10)
        {
            tokenToGive++;
        }
        GiveTokenText.text = tokenToGive.ToString();
        Debug.Log("tokenToGive = " + tokenToGive);
    }
    public void ClickTokenDown()
    {
        if (tokenToGive > 0)
        {
            tokenToGive--;
        }
        GiveTokenText.text = tokenToGive.ToString();
        Debug.Log("tokenToGive = " + tokenToGive);
    }
    public void GiveToken(int n)
    {

        if (token.token_happy >= n)
        {
            token.token_happy = token.token_happy - n;
            return;
        }
        else
        {
            token.token_happy = 0;
            n = n - token.token_happy;

            if (token.token_love >= n)
            {
                token.token_love = token.token_love - n;
                return;
            }
            else
            {
                token.token_love = 0;
                n = n - token.token_love;

                if (token.token_hope >= n)
                {
                    token.token_hope = token.token_hope - n;
                    return;
                }
                else
                {
                    token.token_hope = 0;
                    n = n - token.token_hope;

                    if (token.token_peace >= n)
                    {
                        token.token_peace = token.token_peace - n;
                        return;
                    }
                    else
                    {
                        token.token_peace = 0;
                        n = n - token.token_peace;

                        if (token.token_sad >= n)
                        {
                            token.token_sad = token.token_sad - n;
                            return;
                        }
                        else
                        {
                            token.token_sad = 0;
                            n = n - token.token_sad;

                            if (token.token_anger >= n)
                            {
                                token.token_anger = token.token_anger - n;
                                return;
                            }
                            else
                            {
                                token.token_anger = 0;
                                n = n - token.token_anger;

                                if (token.token_tired >= n)
                                {
                                    token.token_tired = token.token_tired - n;
                                    return;
                                }
                                else
                                {
                                    token.token_tired = 0;
                                    n = n - token.token_tired;

                                    if (token.token_fear >= n)
                                    {
                                        token.token_tired = token.token_fear - n;
                                        return;
                                    }
                                    else
                                    {
                                        token.token_fear = 0;
                                        n = n - token.token_fear;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }

}
