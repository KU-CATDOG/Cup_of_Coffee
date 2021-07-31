using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeRecipeTest : MonoBehaviour
{
    public Text resultText;

    // 0: ��
    // 1: �� (50ml��)
    // 2: ���� (50ml��)
    // 3: ���� ���� (50ml��)
    // 4: ���� ��ǰ
    // 5: ����
    // 6: ��������
    // 7: ����ũ��
    // 8: ���ڽ÷�
    int[] coffee = new int[9];

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { // �ʱ�ȭ
            for (int i = 0; i < coffee.Length; i++)
            {
                coffee[i] = 0;
            }
            Debug.Log("�ʱ�ȭ �Ǿ����ϴ�.");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        { // �� 1��
            coffee[0]++;
            Debug.Log("�� 1 �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        { // �� 50ml
            coffee[1]++;
            Debug.Log("�� 50ml �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        { // ���� 50ml
            coffee[2]++;
            Debug.Log("���� 50ml �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        { // ���� 50ml ����
            coffee[3]++;
            Debug.Log("���� 50ml ���� �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        { // ���� ��ǰ
            coffee[4]++;
            Debug.Log("���� ��ǰ �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        { // ����
            coffee[5]++;
            Debug.Log("���� �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        { // �������� 1��Ǭ
            coffee[6]++;
            Debug.Log("�������� 1 �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        { // ����ũ��
            coffee[7]++;
            Debug.Log("����ũ�� �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        { // ���ڽ÷�
            coffee[8]++;
            Debug.Log("���ڽ÷� �߰�");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        { // Ȯ��
            resultText.text = "Ŀ��: " + CheckRecipe();
            Debug.Log(CheckRecipe() + "\n�ʱ�ȭ �Ǿ����ϴ�.");
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
            return "����������";
        }
        else if (Compare(2, 6, 0, 0, 0, 0, 0, 0, 0))
        {
            return "�Ƹ޸�ī�� H";
        }
        else if (Compare(2, 3, 0, 0, 0, 1, 0, 0, 0))
        {
            return "�Ƹ޸�ī�� I";
        }
        else if (Compare(2, 0, 0, 6, 1, 0, 2, 1, 0) || Compare(2, 0, 0, 6, 1, 0, 2, 1, 1))
        {
            return "ī���ī H";
        }
        else if (Compare(2, 0, 3, 0, 0, 1, 2, 1, 0) || Compare(2, 0, 3, 0, 0, 1, 2, 1, 1))
        {
            return "ī���ī I";
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
