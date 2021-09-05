using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CsvLoadCustomer : MonoBehaviour
{
    public Text Customertext;
    public GameObject Customertextbox;
    public GameObject TextImg;
    public GameObject token;
    public GameObject recipe;
    public GameObject tokenDisplay;

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
    public int AgentButtonCount = 0; //�ǽ� ��ư ���� Ƚ��
    int recentClick = 0; //�ǽ� ��ư �ߺ� Ŭ�� ����

    public Image CustomerSprite;
    public Image RealEmotionSprite;

    public int successCustomer = 0;
    public int numberOfCustomer = 0;
    public int totalNumberOfCustomer = 0;

    private int customerTextType;

    void Start()
    {
        isActive = false;
        Customertextbox.SetActive(false);
        text[0] = "�ȳ��ϼ���";
        b = 0;
        real = 80;
        token = GameObject.Find("TokenObject");
        recipe = GameObject.Find("RecipeTest");
        TextImg = GameObject.Find("TextImage");
    }

    private void SetRandom() //�������� ������ �͵� ���� = �޴�, ��ū
    {
        do
        {
            menunumber = Random.Range(1, 29); //�޴� 1~29���� ���� ����
        }
        while (UnlockRecipe.Instance.recipeUnlockStatus[menunumber - 1] == false);
        Debug.Log("SetRandom()");
        customerTextType = Random.Range(0, 4);

        text[0] = customerTextType switch
        {
            0 => "�ȳ��ϼ���.",
            1 => "����.",
            2 => "��...",
            3 => "�ȳ��ϼ���?",
            _ => "",
        };

        Menu(menunumber);
        customertoken = Random.Range(1, 8);

        LoadCustomerSprite(); //�մ� ��������Ʈ
        LoadEmotionSprite(customertoken);  //���� ��������Ʈ �ε�
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (tokenDisplay.GetComponent<TokenControl>().isHidden)
            {
                Customer();
            }
        }
    }

    public void RecipeCheck()
    {
        TextImg.SetActive(true);
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
            text[0] = customerTextType switch
            {
                0 => "�ȳ��ϼ���.",
                1 => "����.",
                2 => "��...",
                3 => "�ȳ��ϼ���?",
                _ => "",
            };
            Customertext.text = text[currentorder];
            Debug.Log(currentorder);

            if (currentorder >= 2)
            {
                TextImg.SetActive(false);
            }
            if (currentorder < 3) // �ڲ� �迭 ũ�� ���� ���� �̷��� ����
            {
                currentorder++;
            }
            if (currentorder == 1)
            {

                if (isLock == false) // �ݺ��ؼ� �ֹ��� ���� �ʵ��� ����
                {

                    SetRandom();
                    SoundManager.Instance.PlaySFXSound("door_open");
                    SoundManager.Instance.PlaySFXSound("door_bell");
                    numberOfCustomer++;
                    totalNumberOfCustomer++;
                    isLock = true;

                    return;
                }
            }

        }
    }

    public void CustomerReset()
    {
        currentorder = 0;
        isLock = false;
        isSuccess = false;
        isFail = false;
    }

    public void Pass()
    {
        Customertext.text = customerTextType switch
        {
            0 => "�����մϴ�.",
            1 => "������.",
            2 => "�����մϴ�...",
            3 => "��, ���־��! �����մϴ�.",
            _ => "",
        };
        CustomerReset();
        successCustomer++;
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
        Customertext.text = customerTextType switch
        {
            0 => "�� �̰� �� ���״µ�...�ƹ�ư �����մϴ�.",
            1 => "����? ���� ��Ų �� �ƴ��ݾ�!",
            2 => "��... ���Ḧ �߸� �ֽ� �� ��������...",
            3 => "��... �̰� ���� �̻��ѵ���.",
            _ => "",
        };
        //Customertext.text = "�ƴ� �̰� ��Ų ���� ���µ�... �̰� �� ���Ϳ�;;";
        CustomerReset();
    }

    public void Menu(int number) // �޴� ȣ��
    {
        switch (number)
        {
            case 1: // ���������Ҵ� ����Ʈ����, ����������, ���;
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� �� �� ��. ����.",
                        2 => "���� ���� ���������� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������ҷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_ristretto";
                    menunumber = 30;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���������� �� �� �ֽðھ��?",
                        1 => "���������� �� �� ��. ����.",
                        2 => "���������� �� �ܸ� �ּ���.",
                        3 => "���������ҷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� �� �� ��. ����.",
                        2 => "���� ���� ���������� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������ҷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_lungo";
                    menunumber = 31;
                    break;
                }

            case 2:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� ī��� �������� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� ī��� �������� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� ī��� �������� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� ī��� ��������� �ּ���~",
                        _ => "",
                    };
                    menustring = "caramel_macchiato_ice_ristretto";
                    menunumber = 32;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "�ÿ��� ī��� �������� �� �� �ֽðھ��?",
                        1 => "�ÿ��� ī��� �������� �� �� ��. ����.",
                        2 => "�ÿ��� ī��� �������� �� �ܸ� �ּ���.",
                        3 => "�ÿ��� ī��� ��������� �ּ���~",
                        _ => "",
                    };
                    menustring = "caramel_macchiato_ice";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� ī��� �������� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� ī��� �������� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� ī��� �������� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� ī��� ��������� �ּ���~",
                        _ => "",
                    };
                    menustring = "caramel_macchiato_ice_lungo";
                    menunumber = 33;
                    break;
                }
            case 3:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ ī��� �����ƶ� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ ī��� �����ƶ� �� �� ��. ����.",
                        2 => "���� ���� ������ ī��� �����ƶ� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ ī��� �����ƶǷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "caramel_macchiato_hot_ristretto";
                    menunumber = 34;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "������ ī��� �����ƶ� �� �� �ֽðھ��?",
                        1 => "������ ī��� �����ƶ� �� �� ��. ����.",
                        2 => "������ ī��� �����ƶ� �� �ܸ� �ּ���.",
                        3 => "������ ī��� �����ƶǷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "caramel_macchiato_hot";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ ī��� �����ƶ� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ ī��� �����ƶ� �� �� ��. ����.",
                        2 => "���� ���� ������ ī��� �����ƶ� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ ī��� �����ƶǷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "caramel_macchiato_hot_lungo";
                    menunumber = 35;
                    break;
                }
            case 4:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ �Ƹ޸�ī�� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ �Ƹ޸�ī�� �� �� ��. ����.",
                        2 => "���� ���� ������ �Ƹ޸�ī�� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ �Ƹ޸�ī��� �ּ���~",
                        _ => "",
                    };
                    menustring = "americano_hot_ristretto";
                    menunumber = 38;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "������ �Ƹ޸�ī�� �� �� �ֽðھ��?",
                        1 => "������ �Ƹ޸�ī�� �� �� ��. ����.",
                        2 => "������ �Ƹ޸�ī�� �� �ܸ� �ּ���.",
                        3 => "������ �Ƹ޸�ī��� �ּ���~",
                        _ => "",
                    };
                    menustring = "americano_hot";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ �Ƹ޸�ī�� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ �Ƹ޸�ī�� �� �� ��. ����.",
                        2 => "���� ���� ������ �Ƹ޸�ī�� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ �Ƹ޸�ī��� �ּ���~",
                        _ => "",
                    };
                    menustring = "americano_hot_lungo";
                    menunumber = 39;
                    break;
                }
            case 5:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� �Ƹ޸�ī�� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� �Ƹ޸�ī�� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� �Ƹ޸�ī�� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� �Ƹ޸�ī��� �ּ���~",
                        _ => "",
                    };
                    menustring = "americano_ice_ristretto";
                    menunumber = 36;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "�ÿ��� �Ƹ޸�ī�� �� �� �ֽðھ��?",
                        1 => "�ÿ��� �Ƹ޸�ī�� �� �� ��. ����.",
                        2 => "�ÿ��� �Ƹ޸�ī�� �� �ܸ� �ּ���.",
                        3 => "�ÿ��� �Ƹ޸�ī��� �ּ���~",
                        _ => "",
                    };
                    menustring = "americano_ice";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� �Ƹ޸�ī�� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� �Ƹ޸�ī�� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� �Ƹ޸�ī�� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� �Ƹ޸�ī��� �ּ���~",
                        _ => "",
                    };
                    menustring = "americano_ice_lungo";
                    menunumber = 37;
                    break;
                }
            case 6:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� ī���ī �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� ī���ī �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� ī���ī �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� ī���ī�� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_mocha_ice_ristretto";
                    menunumber = 40;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "�ÿ��� ī���ī �� �� �ֽðھ��?",
                        1 => "�ÿ��� ī���ī �� �� ��. ����.",
                        2 => "�ÿ��� ī���ī �� �ܸ� �ּ���.",
                        3 => "�ÿ��� ī���ī�� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_mocha_ice";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� ī���ī �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� ī���ī �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� ī���ī �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� ī���ī�� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_mocha_ice_lungo";
                    menunumber = 41;
                    break;
                }
            case 7:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ ī���ī �� �� �ֽðھ��?",
                        1 => "���� ���� ������ ī���ī �� �� ��. ����.",
                        2 => "���� ���� ������ ī���ī �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ ī���ī�� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_mocha_hot_ristretto";
                    menunumber = 42;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = customerTextType switch
                    {
                        0 => "������ ī���ī �� �� �ֽðھ��?",
                        1 => "������ ī���ī �� �� ��. ����.",
                        2 => "������ ī���ī �� �ܸ� �ּ���.",
                        3 => "������ ī���ī�� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_mocha_hot";
                    break;
                }
                else
                {
                    text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ ī���ī �� �� �ֽðھ��?",
                        1 => "���� ���� ������ ī���ī �� �� ��. ����.",
                        2 => "���� ���� ������ ī���ī �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ ī���ī�� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_mocha_hot_lungo";
                    menunumber = 43;
                    break;
                }
            case 8:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� �� �ĳ� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� �� �ĳ� �� �� ��. ����.",
                        2 => "���� ���� ���������� �� �ĳ� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������� �� �ĳķ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_con_panna_ristretto";
                    menunumber = 44;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���������� �� �ĳ� �� �� �ֽðھ��?",
                        1 => "���������� �� �ĳ� �� �� ��. ����.",
                        2 => "���������� �� �ĳ� �� �ܸ� �ּ���.",
                        3 => "���������� �� �ĳķ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_con_panna";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� �� �ĳ� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� �� �ĳ� �� �� ��. ����.",
                        2 => "���� ���� ���������� �� �ĳ� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������� �� �ĳķ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_con_panna_lungo";
                    menunumber = 45;
                    break;
                }
            case 9:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� �����ƶ� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� �����ƶ� �� �� ��. ����.",
                        2 => "���� ���� ���������� �����ƶ� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������� �����ƶǷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_macchiato_ristretto";
                    menunumber = 46;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���������� �����ƶ� �� �� �ֽðھ��?",
                        1 => "���������� �����ƶ� �� �� ��. ����.",
                        2 => "���������� �����ƶ� �� �ܸ� �ּ���.",
                        3 => "���������� �����ƶǷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_macchiato";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� �����ƶ� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� �����ƶ� �� �� ��. ����.",
                        2 => "���� ���� ���������� �����ƶ� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������� �����ƶǷ� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_macchiato_lungo";
                    menunumber = 47;
                    break;
                }
            case 10:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� īǪġ�� �� �� �ֽðھ��?",
                        1 => "���� ���� īǪġ�� �� �� ��. ����.",
                        2 => "���� ���� īǪġ�� �� �ܸ� �ּ���.",
                        3 => "���� ���� īǪġ��� �ּ���~",
                        _ => "",
                    };
                    menustring = "cappuccino_ristretto";
                    menunumber = 48;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "īǪġ�� �� �� �ֽðھ��?",
                        1 => "īǪġ�� �� �� ��. ����.",
                        2 => "īǪġ�� �� �ܸ� �ּ���.",
                        3 => "īǪġ��� �ּ���~",
                        _ => "",
                    };
                    menustring = "cappuccino";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� īǪġ�� �� �� �ֽðھ��?",
                        1 => "���� ���� īǪġ�� �� �� ��. ����.",
                        2 => "���� ���� īǪġ�� �� �ܸ� �ּ���.",
                        3 => "���� ���� īǪġ��� �ּ���~",
                        _ => "",
                    };
                    menustring = "cappuccino_lungo";
                    menunumber = 49;
                    break;
                }
            case 11:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ �ٴҶ� �� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ �ٴҶ� �� �� �� ��. ����.",
                        2 => "���� ���� ������ �ٴҶ� �� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ �ٴҶ� �󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "vanilla_latte_hot_ristretto";
                    menunumber = 50;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "������ �ٴҶ� �� �� �� �ֽðھ��?",
                        1 => "������ �ٴҶ� �� �� �� ��. ����.",
                        2 => "������ �ٴҶ� �� �� �ܸ� �ּ���.",
                        3 => "������ �ٴҶ� �󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "vanilla_latte_hot";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ �ٴҶ� �� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ �ٴҶ� �� �� �� ��. ����.",
                        2 => "���� ���� ������ �ٴҶ� �� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ �ٴҶ� �󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "vanilla_latte_hot_lungo";
                    menunumber = 51;
                    break;
                }
            case 12:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� �ٴҶ� �� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� �ٴҶ� �� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� �ٴҶ� �� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� �ٴҶ� �󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "vanilla_latte_ice_ristretto";
                    menunumber = 52;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "�ÿ��� �ٴҶ� �� �� �� �ֽðھ��?",
                        1 => "�ÿ��� �ٴҶ� �� �� �� ��. ����.",
                        2 => "�ÿ��� �ٴҶ� �� �� �ܸ� �ּ���.",
                        3 => "�ÿ��� �ٴҶ� �󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "vanilla_latte_ice";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� �ٴҶ� �� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� �ٴҶ� �� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� �ٴҶ� �� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� �ٴҶ� �󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "vanilla_latte_ice_lungo";
                    menunumber = 53;
                    break;
                }
            case 13:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ ī��� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ ī��� �� �� ��. ����.",
                        2 => "���� ���� ������ ī��� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ ī��󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_latte_hot_ristretto";
                    menunumber = 54;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "������ ī��� �� �� �ֽðھ��?",
                        1 => "������ ī��� �� �� ��. ����.",
                        2 => "������ ī��� �� �ܸ� �ּ���.",
                        3 => "������ ī��󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_latte_hot";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ������ ī��� �� �� �ֽðھ��?",
                        1 => "���� ���� ������ ī��� �� �� ��. ����.",
                        2 => "���� ���� ������ ī��� �� �ܸ� �ּ���.",
                        3 => "���� ���� ������ ī��󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_latte_hot_lungo";
                    menunumber = 55;
                    break;
                }
            case 14:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� ī��� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� ī��� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� ī��� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� ī��󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_latte_ice_ristretto";
                    menunumber = 56;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "�ÿ��� ī��� �� �� �ֽðھ��?",
                        1 => "�ÿ��� ī��� �� �� ��. ����.",
                        2 => "�ÿ��� ī��� �� �ܸ� �ּ���.",
                        3 => "�ÿ��� ī��󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_latte_ice";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� �ÿ��� ī��� �� �� �ֽðھ��?",
                        1 => "���� ���� �ÿ��� ī��� �� �� ��. ����.",
                        2 => "���� ���� �ÿ��� ī��� �� �ܸ� �ּ���.",
                        3 => "���� ���� �ÿ��� ī��󶼷� �ּ���~",
                        _ => "",
                    };
                    menustring = "caffe_latte_ice_lungo";
                    menunumber = 57;
                    break;
                }
            case 15:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "�ÿ��� ������ �� �� �ֽðھ��?",
                    1 => "�ÿ��� ������ �� �� ��. ����.",
                    2 => "�ÿ��� ������ �� �ܸ� �ּ���.",
                    3 => "�ÿ��� �����󶼷� �ּ���~",
                    _ => "",
                };
                menustring = "greentea_latte_ice";
                break;
            case 16:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "������ ������ �� �� �ֽðھ��?",
                    1 => "������ ������ �� �� ��. ����.",
                    2 => "������ ������ �� �ܸ� �ּ���.",
                    3 => "������ �����󶼷� �ּ���~",
                    _ => "",
                };
                menustring = "greentea_latte_hot ";
                break;
            case 17:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "����� �� �� �ֽðھ��?",
                    1 => "����� �� �� ��. ����.",
                    2 => "����� �� �ܸ� �ּ���.",
                    3 => "����󶼷� �ּ���~",
                    _ => "",
                };
                menustring = "strawberry_latte ";
                break;
            case 18:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "������ �� �� �ֽðھ��?",
                    1 => "������ �� �� ��. ����.",
                    2 => "������ �� �ܸ� �ּ���.",
                    3 => "�����ڷ� �ּ���~",
                    _ => "",
                };
                menustring = "hot_chocolate";
                break;
            case 19:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���̽� ���� �� �� �ֽðھ��?",
                    1 => "���̽� ���� �� �� ��. ����.",
                    2 => "���̽� ���� �� �ܸ� �ּ���.",
                    3 => "���̽� ���ڷ� �ּ���~",
                    _ => "",
                };
                menustring = "ice_chocolate ";
                break;
            case 20:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���Ʈ ������ �� �� �ֽðھ��?",
                    1 => "���Ʈ ������ �� �� ��. ����.",
                    2 => "���Ʈ ������ �� �ܸ� �ּ���.",
                    3 => "���Ʈ ������� �ּ���~",
                    _ => "",
                };
                menustring = "yogurt_smoothie ";
                break;
            case 21:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� ������ �� �� �ֽðھ��?",
                    1 => "���� ������ �� �� ��. ����.",
                    2 => "���� ������ �� �ܸ� �ּ���.",
                    3 => "���� ������� �ּ���~",
                    _ => "",
                };
                menustring = "greentea_smoothie";
                break;
            case 22:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� ������ �� �� �ֽðھ��?",
                    1 => "���� ������ �� �� ��. ����.",
                    2 => "���� ������ �� �ܸ� �ּ���.",
                    3 => "���� ������� �ּ���~",
                    _ => "",
                };
                menustring = "strawberry_smoothie ";
                break;
            case 23:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���Ʈ �� �� �� �ֽðھ��?",
                    1 => "���Ʈ �� �� �� ��. ����.",
                    2 => "���Ʈ �� �� �ܸ� �ּ���.",
                    3 => "���Ʈ �޷� �ּ���~",
                    _ => "",
                };
                menustring = "yogurt_pearl ";
                break;
            case 24:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� �� �� �� �ֽðھ��?",
                    1 => "���� �� �� �� ��. ����.",
                    2 => "���� �� �� �ܸ� �ּ���.",
                    3 => "���� �޷� �ּ���~",
                    _ => "",
                };
                menustring = "greentea_pearl ";
                break;
            case 25:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� �� �� �� �ֽðھ��?",
                    1 => "���� �� �� �� ��. ����.",
                    2 => "���� �� �� �ܸ� �ּ���.",
                    3 => "���� �޷� �ּ���~",
                    _ => "",
                };
                menustring = "strawberry_pearl ";
                break;
            case 26:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� ����Ǫġ�� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� ����Ǫġ�� �� �� ��. ����.",
                        2 => "���� ���� ���������� ����Ǫġ�� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������� ����Ǫġ��� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_frapp_ristretto";
                    menunumber = 58;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���������� ����Ǫġ�� �� �� �ֽðھ��?",
                        1 => "���������� ����Ǫġ�� �� �� ��. ����.",
                        2 => "���������� ����Ǫġ�� �� �ܸ� �ּ���.",
                        3 => "���������� ����Ǫġ��� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_frapp";
                    break;
                }
                else
                {
                    text[1] = text[1] = customerTextType switch
                    {
                        0 => "���� ���� ���������� ����Ǫġ�� �� �� �ֽðھ��?",
                        1 => "���� ���� ���������� ����Ǫġ�� �� �� ��. ����.",
                        2 => "���� ���� ���������� ����Ǫġ�� �� �ܸ� �ּ���.",
                        3 => "���� ���� ���������� ����Ǫġ��� �ּ���~",
                        _ => "",
                    };
                    menustring = "espresso_frapp_lungo";
                    menunumber = 59;
                    break;
                }
            case 27:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� ����Ǫġ�� �� �� �ֽðھ��?",
                    1 => "���� ����Ǫġ�� �� �� ��. ����.",
                    2 => "���� ����Ǫġ�� �� �ܸ� �ּ���.",
                    3 => "���� ����Ǫġ��� �ּ���~",
                    _ => "",
                };
                menustring = "greentea_frapp";
                break;
            case 28:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� ����Ǫġ�� �� �� �ֽðھ��?",
                    1 => "���� ����Ǫġ�� �� �� ��. ����.",
                    2 => "���� ����Ǫġ�� �� �ܸ� �ּ���.",
                    3 => "���� ����Ǫġ��� �ּ���~",
                    _ => "",
                };
                menustring = "strawberry_frapp";
                break;
            case 29:
                text[1] = text[1] = customerTextType switch
                {
                    0 => "���� ����Ǫġ�� �� �� �ֽðھ��?",
                    1 => "���� ����Ǫġ�� �� �� ��. ����.",
                    2 => "���� ����Ǫġ�� �� �ܸ� �ּ���.",
                    3 => "���� ����Ǫġ��� �ּ���~",
                    _ => "",
                };
                menustring = "chocolate_frapp";
                break;

        }




    }

    void LoadCustomerSprite()
    {
        int i = Random.Range(1, 24);
        CustomerSprite.sprite = Resources.Load<Sprite>("CustomerSprites/�մ�" + i);
        CustomerSprite.gameObject.SetActive(true);
    }

    void LoadEmotionSprite(int customertoken)
    {
        switch (customertoken)
        {
            case 1:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/�ູ");
                break;
            case 2:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/���");
                break;
            case 3:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/���");
                break;
            case 4:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/���");
                break;
            case 5:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/����");
                break;
            case 6:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/�г�");
                break;
            case 7:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/�Ƿ�");
                break;
            case 8:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/����");
                break;

        }
        RealEmotionSprite.gameObject.SetActive(true);
    }


    public void ResetNumberOfCustomer()
    {
        numberOfCustomer = 0;
        return;
    }

    public void ClickAgentButton()
    {
        if (!isActive)
        {
            return;
        }

        if (numberOfCustomer != recentClick)
        {
            recentClick = numberOfCustomer;
            AgentButtonCount++;
        }

    }
}
