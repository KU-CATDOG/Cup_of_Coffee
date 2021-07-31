using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latte : MonoBehaviour
{
    int vanilla_syrup = 0;
    int shot = 0;
    int milk = 0;
    bool milkbubble = false;
    bool ice = false;
    int greentea_powder = 0;
    int strawberry_powder = 0;
    bool greentea_drizzle = false;
    string[] latte = new string[13]; //������ ���ؼ� �迭 ����, �迭�� ��¦ ũ�� ��Ҵ�.
    int i = 0;

    void MakeLatte()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            vanilla_syrup++;
            latte[i] = "Q";
            i++;
            Debug.Log("�ٴҶ� �÷� �߰��߽��ϴ�.");

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            shot++;
            latte[i] = "W";
            i++;
            Debug.Log("�� �߰��߽��ϴ�.");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            milk++;
            latte[i] = "E";
            i++;
            Debug.Log("���� �߰��߽��ϴ�.");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            greentea_powder++;
            latte[i] = "R";
            i++;
            Debug.Log("���� �Ŀ�� �߰��߽��ϴ�.");

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            strawberry_powder++;
            latte[i] = "T";
            i++;
            Debug.Log("���� �Ŀ�� �߰��߽��ϴ�.");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (milkbubble == false)
            {
                latte[i] = "1";
                i++;
                milkbubble = true;
                Debug.Log("���� ��ǰ �־����ϴ�.");
            }
            else
                Debug.Log("�̹� ���� ��ǰ �־����ϴ�.");

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (ice == false)
            {
                latte[i] = "2";
                i++;
                ice = true;
                Debug.Log("���� �־����ϴ�.");
            }
            else Debug.Log("�̹� ���� �־����ϴ�.");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (greentea_drizzle == false)
            {
                latte[i] = "3";
                i++;

                greentea_drizzle = true;
                Debug.Log("���� �帮�� �߰��߽��ϴ�.");

            }
            else Debug.Log("�̹� ���� �帮�� �־����ϴ�.");

        }

    }


    // Update is called once per frame
    void Update()
    {

        MakeLatte();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Check();
        }
        if (Input.GetKeyDown(KeyCode.Return)) // ���͸� ������ ���� Ȯ��
        {
            //�ٴҶ� �÷�, ��, ����, ������ǰ, ����, �����Ŀ��, ���� �Ŀ��, �����ҽ� -> Q,W,E,1,2,R,T,3


            if (latte[0] == "Q" && latte[1] == "Q" && latte[2] == "W" && latte[3] == "W" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "E" && latte[8] == "E" && latte[9] == "E" && latte[10] == "1")
            {
                Debug.Log("������ �ٴҶ� �� ���Խ��ϴ�.");
                Reset();
            }
            else if (latte[0] == "Q" && latte[1] == "Q" && latte[2] == "W" && latte[3] == "W" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "2")
            {
                Debug.Log("���̽� �ٴҶ� �� ���Խ��ϴ�.");
                Reset();
            }
            else if (latte[0] == "W" && latte[1] == "W" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "2")
            {
                Debug.Log("���̽� ī�� �� ���Խ��ϴ�.");
                Reset();
            }
            else if (latte[0] == "W" && latte[1] == "W" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "E" && latte[8] == "1")
            {
                Debug.Log("������ ī�� �� ���Խ��ϴ�.");
                Reset();
            }
            else if (latte[0] == "R" && latte[1] == "R" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "2")
            {
                Debug.Log("���̽� ���� �� ���Խ��ϴ�.");
                Reset();
            }
            else if (latte[0] == "R" && latte[1] == "R" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "E" && latte[8] == "1" && latte[9] == "3")
            {
                Debug.Log("������ ���� �� ���Խ��ϴ�.");
                Reset();
            }
            else if (latte[0] == "T" && latte[1] == "T" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "E" && latte[6] == "2")
            {
                Debug.Log("���̽� ���� �� ���Խ��ϴ�.");
                Reset();

            }
            else
            {
                Debug.Log("�߸� ��������� �ٽ� ������..");
                Reset();

            }
        }


    }

    //�ٴҶ� �÷�, ��, ����, ������ǰ, ����, �����Ŀ��, ���� �Ŀ��, �����ҽ�

    void Check()
    {
        Debug.Log("========================================");
        Debug.Log("�ٴҶ� �÷� =" + vanilla_syrup);
        Debug.Log("�� =" + shot);
        Debug.Log("���� =" + milk);
        Debug.Log("������ǰ =" + milkbubble);
        Debug.Log("���� =" + ice);
        Debug.Log("���� �Ŀ�� =" + greentea_powder);
        Debug.Log("���� �Ŀ�� =" + strawberry_powder);
        Debug.Log("���� �帮�� =" + greentea_drizzle);
        Debug.Log("========================================");

    }

    void Reset()
    {
        vanilla_syrup = 0;
        shot = 0;
        milk = 0;
        milkbubble = false;
        ice = false;
        greentea_powder = 0;
        strawberry_powder = 0;
        greentea_drizzle = false;
        i = 0;

    }
}
