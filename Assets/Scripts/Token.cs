using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token : MonoBehaviour
{
    public int token_happy;
    public int token_love;
    public int token_hope;
    public int token_peace;
    public int token_sad;
    public int token_anger;
    public int token_tired;
    public int token_fear;

    void Start()
    {
        SaveCheck();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            token_happy++;
            PlayerPrefs.SetInt("happy", token_happy);
            Debug.Log(token_happy);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            token_love++;
            PlayerPrefs.SetInt("love", token_love);
            Debug.Log(token_love);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            token_hope++;
            PlayerPrefs.SetInt("hope", token_hope);
            Debug.Log(token_hope);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            token_peace++;
            PlayerPrefs.SetInt("peace", token_peace);
            Debug.Log(token_peace);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            token_sad++;
            PlayerPrefs.SetInt("sad", token_sad);
            Debug.Log(token_sad);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            token_anger++;
            PlayerPrefs.SetInt("anger", token_anger);
            Debug.Log(token_anger);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            token_tired++;
            PlayerPrefs.SetInt("tired", token_tired);
            Debug.Log(token_tired);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            token_fear++;
            PlayerPrefs.SetInt("fear", token_fear);
            Debug.Log(token_fear);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey("happy");
        }

    }
    public void SaveCheck()
    {
       
        Debug.Log(PlayerPrefs.GetInt("happy"));
        Debug.Log(PlayerPrefs.GetInt("love"));
        Debug.Log(PlayerPrefs.GetInt("hope"));
        Debug.Log(PlayerPrefs.GetInt("peace"));
        Debug.Log(PlayerPrefs.GetInt("sad"));
        Debug.Log(PlayerPrefs.GetInt("anger"));
        Debug.Log(PlayerPrefs.GetInt("tired"));
        Debug.Log(PlayerPrefs.GetInt("fear"));

    }
}
