using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{

    public int a = 0;
    public Color c;
    private Image img;
    public TokenTest token;
    public int[] tokenCol = new int[8];

    private void Start()
    {
        img = transform.GetComponent<Image>();
        c = img.color;

    }

    void Update()
    {
        tokenCol[0] = token.happy;
        tokenCol[1] = token.love;
        tokenCol[2] = token.hope;
        tokenCol[3] = token.peace;
        tokenCol[4] = token.sad;
        tokenCol[5] = token.anger;
        tokenCol[6] = token.tired;
        tokenCol[7] = token.fear;


        for (int i = 0; i < 8; i++) //제일 많은 토큰을 선정
        {
            if (tokenCol[a] <= tokenCol[i])
            {
                a = i;
            }
        }

        if (tokenCol[0] + tokenCol[1] + tokenCol[2] + tokenCol[3] + tokenCol[4] + tokenCol[5] + tokenCol[6] + tokenCol[7] > 0) //시작하자마자 색깔이 바뀌는걸 방지
        {
            if (a == 0)
            {

                img.color = Color.HSVToRGB((float)0.125, (float)0.3, 1);
            }
            else if (a == 1)
            {

                img.color = Color.HSVToRGB((float)0.25, (float)0.3, 1);

            }
            else if (a == 2)
            {
                img.color = Color.HSVToRGB((float)0.375, (float)0.3, 1);

            }

            else if (a == 3)
            {
                img.color = Color.HSVToRGB((float)0.5, (float)0.3, 1);

            }
            else if (a == 4)
            {

                img.color = Color.HSVToRGB((float)0.625, (float)0.3, 1);
            }
            else if (a == 5)
            {
                img.color = Color.HSVToRGB((float)0.75, (float)0.3, 1);

            }
            else if (a == 6)
            {
                img.color = Color.HSVToRGB((float)0.875, (float)0.3, 1);

            }
            else if (a == 7)
            {
                img.color = Color.HSVToRGB((float)1.0, (float)0.3, 1);

            }

        }


    }
}
