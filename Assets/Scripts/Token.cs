using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Token // Token�� �ʿ��� ������ �����Ѵ�.
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

    public void SaveCheck() // ��ū�� � �ִ��� Ȯ���Ѵ�.
    {
        Debug.Log("=======================================");
        Debug.Log("happy��" + token_happy);
        Debug.Log("love��" + token_love);
        Debug.Log("hope��" + token_hope);
        Debug.Log("peace��" + token_peace);
        Debug.Log("sad��" + token_sad);
        Debug.Log("anger��" + token_anger);
        Debug.Log("tired��" + token_tired);
        Debug.Log("fear��" + token_fear);
        Debug.Log("=======================================");
    }
    public void Reset() // ��ū�� ����
    {

        token_anger = 0;
        token_fear = 0;
        token_happy = 0;
        token_hope = 0;
        token_love = 0;
        token_peace = 0;
        token_sad = 0;
        token_tired = 0;
        Debug.Log("��ū�� ���� �ʱ�ȭ�߽��ϴ�.");

    }

    public void TokenUp()
    {


    }

}
