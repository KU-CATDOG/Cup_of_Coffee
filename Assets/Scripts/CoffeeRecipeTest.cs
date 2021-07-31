using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeRecipeTest : MonoBehaviour
{
    public Text resultText;

    // 0: 샷
    // 1: 물 (50ml씩)
    // 2: 우유 (50ml씩)
    // 3: 우유 스팀 (50ml씩)
    // 4: 우유 거품
    // 5: 얼음
    // 6: 초코펌프
    // 7: 휘핑크림
    // 8: 초코시럽
    int[] coffee = new int[9];

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { // 초기화
            for (int i = 0; i < coffee.Length; i++)
            {
                coffee[i] = 0;
            }
            Debug.Log("초기화 되었습니다.");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        { // 샷 1개
            coffee[0]++;
            Debug.Log("샷 1 추가");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        { // 물 50ml
            coffee[1]++;
            Debug.Log("물 50ml 추가");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        { // 우유 50ml
            coffee[2]++;
            Debug.Log("우유 50ml 추가");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        { // 우유 50ml 스팀
            coffee[3]++;
            Debug.Log("우유 50ml 스팀 추가");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        { // 우유 거품
            coffee[4]++;
            Debug.Log("우유 거품 추가");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        { // 얼음
            coffee[5]++;
            Debug.Log("얼음 추가");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        { // 초코펌프 1스푼
            coffee[6]++;
            Debug.Log("초코펌프 1 추가");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        { // 휘핑크림
            coffee[7]++;
            Debug.Log("휘핑크림 추가");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        { // 초코시럽
            coffee[8]++;
            Debug.Log("초코시럽 추가");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        { // 확인
            resultText.text = "커피: " + CheckRecipe();
            Debug.Log(CheckRecipe() + "\n초기화 되었습니다.");
            for (int i = 0; i < coffee.Length; i++)
            {
                coffee[i] = 0;
            }
        }
    }

    private string CheckRecipe()
    {
        if (Compare(1, 0, 0, 0, 0, 0, 0, 0, 0))
        {
            return "에스프레소";
        }
        else if (Compare(2, 6, 0, 0, 0, 0, 0, 0, 0))
        {
            return "아메리카노 H";
        }
        else if (Compare(2, 3, 0, 0, 0, 1, 0, 0, 0))
        {
            return "아메리카노 I";
        }
        else if (Compare(2, 0, 0, 6, 1, 0, 2, 1, 0) || Compare(2, 0, 0, 6, 1, 0, 2, 1, 1))
        {
            return "카페모카 H";
        }
        else if (Compare(2, 0, 3, 0, 0, 1, 2, 1, 0) || Compare(2, 0, 3, 0, 0, 1, 2, 1, 1))
        {
            return "카페모카 I";
        }

        return "???";
    }

    private bool Compare(int shot, int water, int milk, int milkSteam, int milkBubble, int ice, int chocolatePump, int whippingCream, int chocolateSyrup)
    {
        if (coffee[0] != shot)
        {
            return false;
        }
        else if (coffee[1] != water)
        {
            return false;
        }
        else if (coffee[2] != milk)
        {
            return false;
        }
        else if (coffee[3] != milkSteam)
        {
            return false;
        }
        else if (coffee[4] != milkBubble)
        {
            return false;
        }
        else if (coffee[5] != ice)
        {
            return false;
        }
        else if (coffee[6] != chocolatePump)
        {
            return false;
        }
        else if (coffee[7] != whippingCream)
        {
            return false;
        }
        else if (coffee[8] != chocolateSyrup)
        {
            return false;
        }

        return true;
    }
}
