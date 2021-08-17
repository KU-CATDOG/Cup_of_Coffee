using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CsvLoadCustomer : MonoBehaviour
{
    public Text Customertext;
    public GameObject Customertextbox;
    public GameObject token;

    public bool isActive;
    public bool isSuccess;
    public bool isFail;
    public int menunumber;
    public string menustring;
    public int currentorder = 0;
    public string[] text = new string[4];


    void Start()
    {
        isActive = false;
        Customertextbox.SetActive(false);
        text[0] = "�ȳ��ϼ���";
        SetMenuNum();
        Customer();
        token = GameObject.Find("TokenObject");
    }

    private void SetMenuNum()
    {
        menunumber = Random.Range(1, 28);
        menu(menunumber);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Customer();
        }
        if (isSuccess == true)
        {
            Pass();
            isSuccess = false;
        }
        if (isFail == true)
        {
            Fail();
            isFail = false;
        }

    }
    public void Customer()
    {
        if (isActive == true)
        {
            if (currentorder == 2)
            {
                //isActive = false;
                currentorder = 0;
                SetMenuNum();
                return;
            }
            Customertext.text = text[currentorder];
            currentorder++;
        }
    }

    public void Pass()
    {
        Customertext.text = "�����մϴ�. �����ϼ���~";
        token.GetComponent<TokenTest>().TokenUp();
    }

    public void Fail()
    {
        Customertext.text = "�ƴ� �̰� ��Ų ���� ���µ�... �̰� �� ���Ϳ�;;";
    }

    public void menu(int number)
    {
        switch (number)
        {
            case 0: // ���������Ҵ� ����Ʈ����, ����������, ���;
                int b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���������ҷ� ���� �ʰ� �� �� �ּ���";
                    menustring = "espresso_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "���������ҷ� �� �� �ּ���";
                    menustring = "espresso";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "���������ҷ� ���� �ʰ� �� �� �ּ���";
                    menustring = "espresso_lungo";
                    break;
                }
                break;

            case 1:
                text[1] = "�ÿ��� ī��� �����ƶǷ� �� �� �ּ���";
                menustring = "caramel_macchiato_ice";
                break;
            case 2:
                text[1] = "������ ī��� �����ƶǷ� �� �� �ּ���";
                menustring = "caramel_macchiato_hot";
                break;
            case 3:
                text[1] = "���̽� �Ƹ޸�ī��� �� �� �ּ���";
                menustring = "americano_ice";
                break;
            case 4:
                text[1] = "������ �Ƹ޸�ī��� �� �� �ּ���";
                menustring = "americano_hot ";
                break;
            case 5:
                text[1] = "���̽� ī���ī�� �� �� �ּ���";
                menustring = "caffe_mocha_ice ";
                break;
            case 6:
                text[1] = "���̽� ī���ī�� �� �� �ּ���";
                menustring = "caffe_mocha_hot";
                break;
            case 7:
                text[1] = "���������� �� �ĳķ� �� �� �ּ���";
                menustring = "espresso_con_panna ";
                break;
            case 8:
                text[1] = "���������� �����ƶǷ� �� �� �ּ���";
                menustring = "espresso_macchiato";
                break;
            case 9:
                text[1] = "īǪġ��� �� �� �ּ���";
                menustring = "cappuccino";
                break;
            case 10:
                text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���";
                menustring = "vanilla_latte_hot";
                break;
            case 11:
                text[1] = "�ÿ��� �ٴҶ� �󶼷� �� �� �ּ���";
                menustring = "vanilla_latte_ice";
                break;
            case 12:
                text[1] = "������ ī�� �󶼷� �� �� �ּ���";
                menustring = "caffe_latte_hot";
                break;
            case 13:
                text[1] = "�ÿ��� ī�� �󶼷� �� �� �ּ���";
                menustring = "caffe_latte_ice";
                break;
            case 14:
                text[1] = "���̽� ���� �󶼷� �� �� �ּ���";
                menustring = "greentea_latte_ice";
                break;
            case 15:
                text[1] = "������ ���� �󶼷� �� �� �ּ���";
                menustring = "greentea_latte_hot ";
                break;
            case 16:
                text[1] = "���� �󶼷� �� �� �ּ���";
                menustring = "strawberry_latte ";
                break;
            case 17:
                text[1] = "������ ���ڷ� �� �� �ּ���";
                menustring = "hot_chocolate";
                break;
            case 18:
                text[1] = "�ÿ��� ���ڷ� �� �� �ּ���";
                menustring = "ice_chocolate ";
                break;
            case 19:
                text[1] = "���Ʈ ������� �� �� �ּ���";
                menustring = "yogurt_smoothie ";
                break;
            case 20:
                text[1] = "���� ������� �� �� �ּ���";
                menustring = "greentea_smoothie";
                break;
            case 21:
                text[1] = "���� ������� �� �� �ּ���";
                menustring = "strawberry_smoothie ";
                break;
            case 22:
                text[1] = "���Ʈ �޷� �� �� �ּ���";
                menustring = "yogurt_pearl ";
                break;
            case 23:
                text[1] = "���� �޷� �� �� �ּ���";
                menustring = "greentea_pearl ";
                break;
            case 24:
                text[1] = "���� �� ���� �� �� �ּ���";
                menustring = "strawberry_pearl ";
                break;
            case 25:
                text[1] = "���������� ����Ǫġ�� �� �� �ּ���";
                menustring = "espresso_frapp";
                break;
            case 26:
                text[1] = "���� ����Ǫġ�� �� �� �ּ���";
                menustring = "greentea_frapp";
                break;
            case 27:
                text[1] = "���� ����Ǫġ�� �� �� �ּ���";
                menustring = "strawberry_frapp";
                break;
            case 28:
                text[1] = "���� ����Ǫġ�� �� �� �ּ���";
                menustring = "chocolate_frapp";
                break;



        }




    }
}
