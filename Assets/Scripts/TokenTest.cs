using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenTest : MonoBehaviour
{

    public Token token = new Token();

    // Start is called before the first frame update
    void Start() // 토큰을 PlayerPrefs에서 불러온다.
    {

    }

    /*
    토큰 종류 
    public int token_happy;
    public int token_love;
    public int token_hope;
    public int token_peace;
    public int token_sad;
    public int token_anger;
    public int token_tired;
    public int token_fear;
    */

    // Update is called once per frame
    void Update() // 토큰을 PlayerPrefs에 저장한다.
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            int a = Random.Range(1, 8);
            if (a == 1)
            {
                token.token_happy++;
                Debug.Log("happy는" + token.token_happy);
            }
            if (a == 2)
            {
                token.token_love++;
                Debug.Log("love는" + token.token_love);
            }
            if (a == 3)
            {
                token.token_hope++;
                Debug.Log("hope는" + token.token_hope);
            }
            if (a == 4)
            {
                token.token_peace++;
                Debug.Log("peace는" + token.token_peace);
            }
            if (a == 5)
            {
                token.token_sad++;
                Debug.Log("sad는" + token.token_sad);
            }
            if (a == 6)
            {
                token.token_anger++;
                Debug.Log("anger는" + token.token_anger);
            }
            if (a == 7)
            {
                token.token_tired++;
                Debug.Log("tired는" + token.token_tired);

            }
            if (a == 8)
            {
                token.token_fear++;
                Debug.Log("fear는" + token.token_fear);

            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Space를 누르면 지금까지 체크
        {
            token.SaveCheck();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            token.Reset();

        }

    }

}
