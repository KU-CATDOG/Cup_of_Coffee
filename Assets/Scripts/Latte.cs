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
    string[] latte = new string[13]; //순서를 위해서 배열 설정, 배열을 살짝 크게 잡았다.
    int i = 0;

    void MakeLatte()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            vanilla_syrup++;
            latte[i] = "Q";
            i++;
            Debug.Log("바닐라 시럽 추가했습니다.");

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            shot++;
            latte[i] = "W";
            i++;
            Debug.Log("샷 추가했습니다.");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            milk++;
            latte[i] = "E";
            i++;
            Debug.Log("우유 추가했습니다.");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            greentea_powder++;
            latte[i] = "R";
            i++;
            Debug.Log("녹차 파우더 추가했습니다.");

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            strawberry_powder++;
            latte[i] = "T";
            i++;
            Debug.Log("딸기 파우더 추가했습니다.");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (milkbubble == false)
            {
                latte[i] = "1";
                i++;
                milkbubble = true;
                Debug.Log("우유 거품 넣었습니다.");
            }
            else
                Debug.Log("이미 우유 거품 넣었습니다.");

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (ice == false)
            {
                latte[i] = "2";
                i++;
                ice = true;
                Debug.Log("얼음 넣었습니다.");
            }
            else Debug.Log("이미 얼음 넣었습니다.");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (greentea_drizzle == false)
            {
                latte[i] = "3";
                i++;

                greentea_drizzle = true;
                Debug.Log("녹차 드리즐 추가했습니다.");

            }
            else Debug.Log("이미 녹차 드리즐 넣었습니다.");

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
        if (Input.GetKeyDown(KeyCode.Return)) // 엔터를 눌러서 순서 확인
        {
            //바닐라 시럽, 샷, 우유, 우유거품, 얼음, 녹차파우더, 딸기 파우더, 녹차소스 -> Q,W,E,1,2,R,T,3


            if (latte[0] == "Q" && latte[1] == "Q" && latte[2] == "W" && latte[3] == "W" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "E" && latte[8] == "E" && latte[9] == "E" && latte[10] == "1")
            {
                Debug.Log("따뜻한 바닐라 라떼 나왔습니다.");
                Reset();
            }
            else if (latte[0] == "Q" && latte[1] == "Q" && latte[2] == "W" && latte[3] == "W" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "2")
            {
                Debug.Log("아이스 바닐라 라떼 나왔습니다.");
                Reset();
            }
            else if (latte[0] == "W" && latte[1] == "W" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "2")
            {
                Debug.Log("아이스 카페 라떼 나왔습니다.");
                Reset();
            }
            else if (latte[0] == "W" && latte[1] == "W" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "E" && latte[8] == "1")
            {
                Debug.Log("따뜻한 카페 라떼 나왔습니다.");
                Reset();
            }
            else if (latte[0] == "R" && latte[1] == "R" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "2")
            {
                Debug.Log("아이스 녹차 라떼 나왔습니다.");
                Reset();
            }
            else if (latte[0] == "R" && latte[1] == "R" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "E" && latte[6] == "E" && latte[7] == "E" && latte[8] == "1" && latte[9] == "3")
            {
                Debug.Log("따뜻한 녹차 라떼 나왔습니다.");
                Reset();
            }
            else if (latte[0] == "T" && latte[1] == "T" && latte[2] == "E" && latte[3] == "E" && latte[4] == "E" && latte[5] == "E" && latte[6] == "2")
            {
                Debug.Log("아이스 딸기 라떼 나왔습니다.");
                Reset();

            }
            else
            {
                Debug.Log("잘못 만들었으니 다시 만들자..");
                Reset();

            }
        }


    }

    //바닐라 시럽, 샷, 우유, 우유거품, 얼음, 녹차파우더, 딸기 파우더, 녹차소스

    void Check()
    {
        Debug.Log("========================================");
        Debug.Log("바닐라 시럽 =" + vanilla_syrup);
        Debug.Log("샷 =" + shot);
        Debug.Log("우유 =" + milk);
        Debug.Log("우유거품 =" + milkbubble);
        Debug.Log("얼음 =" + ice);
        Debug.Log("녹차 파우더 =" + greentea_powder);
        Debug.Log("딸기 파우더 =" + strawberry_powder);
        Debug.Log("녹차 드리즐 =" + greentea_drizzle);
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
