using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Token // Token에 필요한 변수를 정의한다.
{

    public int token_happy;
    public int token_love;
    public int token_hope;
    public int token_peace;
    public int token_sad;
    public int token_anger;
    public int token_tired;
    public int token_fear;

    public Token()
    {
        token_happy = 0;
        token_love = 0;
        token_hope = 0;
        token_peace = 0;
        token_sad = 0;
        token_anger = 0;
        token_tired = 0;
        token_fear = 0;
    }

    public void SaveCheck() // 토큰이 몇개 있는지 확인한다.
    {
        Debug.Log("=======================================");
        Debug.Log("happy가" + token_happy);
        Debug.Log("love는" + token_love);
        Debug.Log("hope는" + token_hope);
        Debug.Log("peace는" + token_peace);
        Debug.Log("sad는" + token_sad);
        Debug.Log("anger는" + token_anger);
        Debug.Log("tired는" + token_tired);
        Debug.Log("fear는" + token_fear);
        Debug.Log("=======================================");
    }
    public void Reset() // 토큰을 리셋
    {

        token_anger = 0;
        token_fear = 0;
        token_happy = 0;
        token_hope = 0;
        token_love = 0;
        token_peace = 0;
        token_sad = 0;
        token_tired = 0;
        Debug.Log("토큰을 전부 초기화했습니다.");

    }

    public void TokenUp()
    {


    }

}
