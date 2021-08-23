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
    public GameObject recipe;

    public bool isActive;
    public bool isSuccess;
    public bool isFail;
    public bool isLock;

    public int menunumber;
    public string menustring;
    public int currentorder = 0;
    public string[] text = new string[4];
    public int recipe_number;
    public int b; // ����������, ���, ����Ʈ���� �� �����ΰ��� ���
    public int real; // real = ��¥ ������ �� Ȯ��
    public int customertoken; //�մ��� ���� �� �����Ǵ� ��ū

    void Start()
    {
        isActive = false;
        Customertextbox.SetActive(false);
        text[0] = "�ȳ��ϼ���";
        b = 0;
        real = 80;
        token = GameObject.Find("TokenObject");
        recipe = GameObject.Find("RecipeTest");
    }

    private void SetRandom() //�������� ������ �͵� ���� = �޴�, ��ū
    {
        menunumber = Random.Range(1, 29); //�޴� 1~29���� ���� ����
        Debug.Log("SetRandom()");
        menu(menunumber);
        customertoken = Random.Range(1, 8);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Customer();
        }


    }
    public void RecipeCheck()
    {
        if (menunumber == recipe_number)
        {
            Pass();
            b = 0;
            Debug.Log("pass");
        }
        else
        {
            Fail();
            b = 0;
            Debug.Log("fail");
        }

    }

    public void Customer()
    {
        if (isActive == true)
        {
            if (currentorder == 2)
            {
                //isActive = false;
                if (isLock == false) // �ݺ��ؼ� �ֹ��� ���� �ʵ��� ����
                {
                    SetRandom();
                    isLock = true;
                }
                return;
            }

            Customertext.text = text[currentorder];
            currentorder++;

        }
    }

    public void Pass()
    {
        Customertext.text = "�����մϴ�. �����ϼ���~";
        int random = Random.Range(0, 100);
        if (random < real) // ��¥ ������ �� ��
        {
            token.GetComponent<TokenTest>().RealToken(customertoken);

        }
        else // ��¥ ������ �� ��
        {
            token.GetComponent<TokenTest>().FakeToken(customertoken);
        }
    }

    public void Fail()
    {
        Customertext.text = "�ƴ� �̰� ��Ų ���� ���µ�... �̰� �� ���Ϳ�;;";
    }

    public void menu(int number)
    {
        switch (number)
        {
            case 1: // ���������Ҵ� ����Ʈ����, ����������, ���;
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���������ҷ� ���� �ʰ� �� �� �ּ���.";
                    menustring = "espresso_ristretto";
                    menunumber = 30;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "���������ҷ� �� �� �ּ���.";
                    menustring = "espresso";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "���������ҷ� ���� �ʰ� �� �� �ּ���.";
                    menustring = "espresso_lungo";
                    menunumber = 31;
                    break;
                }
                break;

            case 2:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "�ÿ��� ī��� �����ƶǷ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caramel_macchiato_ice_ristretto";
                    menunumber = 32;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "ī��� �����ƶǷ� �� �� �ּ���.";
                    menustring = "caramel_macchiato_ice";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "�ÿ��� ī��� �����ƶǷ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caramel_macchiato_ice_lungo";
                    menunumber = 33;
                    break;
                }
                break;
            case 3:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "������ ī��� �����ƶǷ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caramel_macchiato_hot_ristretto";
                    menunumber = 34;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "������ ī��� �����ƶǷ� �� �� �ּ���.";
                    menustring = "caramel_macchiato_hot";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "������ ī��� �����ƶǷ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caramel_macchiato_hot_lungo";
                    menunumber = 35;
                    break;
                }
                break;
            case 4:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "������ �Ƹ޸�ī��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "americano_hot_ristretto";
                    menunumber = 38;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "������ �Ƹ޸�ī��� �� �� �ּ���.";
                    menustring = "americano_hot";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "������ �Ƹ޸�ī��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "americano_hot_lungo";
                    menunumber = 39;
                    break;
                }
                break;
            case 5:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���̽� �Ƹ޸�ī��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "americano_ice_ristretto";
                    menunumber = 36;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "���̽� �Ƹ޸�ī��� �� �� �ּ���.";
                    menustring = "americano_ice";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "���̽� �Ƹ޸�ī��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "americano_ice_lungo";
                    menunumber = 37;
                    break;
                }
                break;
            case 6:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���̽� ī���ī�� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_mocha_ice_ristretto";
                    menunumber = 40;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "���̽� ī���ī�� �� �� �ּ���.";
                    menustring = "caffe_mocha_ice";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "���̽� ī���ī�� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_mocha_ice_lungo";
                    menunumber = 41;
                    break;
                }
                break;
            case 7:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "������ ī���ī�� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_mocha_hot_ristretto";
                    menunumber = 42;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "������ ī���ī�� �� �� �ּ���.";
                    menustring = "caffe_mocha_hot";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "������ ī���ī�� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_mocha_hot_lungo";
                    menunumber = 43;
                    break;
                }
                break;
            case 8:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���������� �� �ĳķ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "espresso_con_panna_ristretto";
                    menunumber = 44;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "���������� �� �ĳķ� �� �� �ּ���.";
                    menustring = "espresso_con_panna";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "���������� �� �ĳķ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "espresso_con_panna_lungo";
                    menunumber = 45;
                    break;
                }
                break;
            case 9:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���������� �����ƶǷ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "espresso_macchiato_ristretto";
                    menunumber = 46;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "���������� �����ƶǷ� �� �� �ּ���.";
                    menustring = "espresso_macchiato";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "���������� �����ƶǷ� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "espresso_macchiato_lungo";
                    menunumber = 47;
                    break;
                }
                break;
            case 10:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "īǪġ��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "cappuccino_ristretto";
                    menunumber = 48;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "īǪġ��� �� �� �ּ���.";
                    menustring = "cappuccino";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "īǪġ��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "cappuccino_lungo";
                    menunumber = 49;
                    break;
                }
                break;
            case 11:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "vanilla_latte_hot_ristretto";
                    menunumber = 50;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���.";
                    menustring = "vanilla_latte_hot";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "vanilla_latte_hot_lungo";
                    menunumber = 51;
                    break;
                }
                break;
            case 12:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "vanilla_latte_ice_ristretto";
                    menunumber = 52;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���.";
                    menustring = "vanilla_latte_ice";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "������ �ٴҶ� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "vanilla_latte_ice_lungo";
                    menunumber = 53;
                    break;
                }
                break;
            case 13:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "������ ī�� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_latte_hot_ristretto";
                    menunumber = 54;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "������ ī�� �󶼷� �� �� �ּ���.";
                    menustring = "caffe_latte_hot";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "������ ī�� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_latte_hot_lungo";
                    menunumber = 55;
                    break;
                }
                break;
            case 14:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "�ÿ��� ī�� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_latte_ice_ristretto";
                    menunumber = 56;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "�ÿ��� ī�� �󶼷� �� �� �ּ���.";
                    menustring = "caffe_latte_ice";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "�ÿ��� ī�� �󶼷� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "caffe_latte_ice_lungo";
                    menunumber = 57;
                    break;
                }
                break;
            case 15:
                text[1] = "���̽� ���� �󶼷� �� �� �ּ���.";
                menustring = "greentea_latte_ice";
                break;
            case 16:
                text[1] = "������ ���� �󶼷� �� �� �ּ���.";
                menustring = "greentea_latte_hot ";
                break;
            case 17:
                text[1] = "���� �󶼷� �� �� �ּ���.";
                menustring = "strawberry_latte ";
                break;
            case 18:
                text[1] = "������ ���ڷ� �� �� �ּ���.";
                menustring = "hot_chocolate";
                break;
            case 19:
                text[1] = "�ÿ��� ���ڷ� �� �� �ּ���.";
                menustring = "ice_chocolate ";
                break;
            case 20:
                text[1] = "���Ʈ ������� �� �� �ּ���.";
                menustring = "yogurt_smoothie ";
                break;
            case 21:
                text[1] = "���� ������� �� �� �ּ���.";
                menustring = "greentea_smoothie";
                break;
            case 22:
                text[1] = "���� ������� �� �� �ּ���.";
                menustring = "strawberry_smoothie ";
                break;
            case 23:
                text[1] = "���Ʈ �޷� �� �� �ּ���.";
                menustring = "yogurt_pearl ";
                break;
            case 24:
                text[1] = "���� �޷� �� �� �ּ���.";
                menustring = "greentea_pearl ";
                break;
            case 25:
                text[1] = "���� �� ���� �� �� �ּ���.";
                menustring = "strawberry_pearl ";
                break;
            case 26:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "���������� ����Ǫġ��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "espresso_frapp_ristretto";
                    menunumber = 58;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "���������� ����Ǫġ��� �� �� �ּ���.";
                    menustring = "espresso_frapp";
                    break;
                }
                else if (b >= 85)
                {
                    text[1] = "���������� ����Ǫġ��� �� �� �ּ���. ���� �ʰ� �ؼ� �ּ���.";
                    menustring = "espresso_frapp_lungo";
                    menunumber = 59;
                    break;
                }
                break;
            case 27:
                text[1] = "���� ����Ǫġ�� �� �� �ּ���.";
                menustring = "greentea_frapp";
                break;
            case 28:
                text[1] = "���� ����Ǫġ�� �� �� �ּ���.";
                menustring = "strawberry_frapp";
                break;
            case 29:
                text[1] = "���� ����Ǫġ�� �� �� �ּ���.";
                menustring = "chocolate_frapp";
                break;

        }




    }
}
