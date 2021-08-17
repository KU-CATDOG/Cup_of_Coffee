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
        text[0] = "안녕하세요";
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
        Customertext.text = "감사합니다. 수고하세요~";
        token.GetComponent<TokenTest>().TokenUp();
    }

    public void Fail()
    {
        Customertext.text = "아니 이걸 시킨 적이 없는데... 이게 왜 나와요;;";
    }

    public void menu(int number)
    {
        switch (number)
        {
            case 0: // 에스프레소는 리조트레또, 에스프레소, 룽고;
                int b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소로 쓰지 않게 한 잔 주세요";
                    menustring = "espresso_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소로 한 잔 주세요";
                    menustring = "espresso";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "에스프레소로 시지 않게 한 잔 주세요";
                    menustring = "espresso_lungo";
                    break;
                }
                break;

            case 1:
                text[1] = "시원한 카라멜 마끼아또로 한 잔 주세요";
                menustring = "caramel_macchiato_ice";
                break;
            case 2:
                text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요";
                menustring = "caramel_macchiato_hot";
                break;
            case 3:
                text[1] = "아이스 아메리카노로 한 잔 주세요";
                menustring = "americano_ice";
                break;
            case 4:
                text[1] = "따뜻한 아메리카노로 한 잔 주세요";
                menustring = "americano_hot ";
                break;
            case 5:
                text[1] = "아이스 카페모카로 한 잔 주세요";
                menustring = "caffe_mocha_ice ";
                break;
            case 6:
                text[1] = "아이스 카페모카로 한 잔 주세요";
                menustring = "caffe_mocha_hot";
                break;
            case 7:
                text[1] = "에스프레소 콘 파냐로 한 잔 주세요";
                menustring = "espresso_con_panna ";
                break;
            case 8:
                text[1] = "에스프레소 마끼아또로 한 잔 주세요";
                menustring = "espresso_macchiato";
                break;
            case 9:
                text[1] = "카푸치노로 한 잔 주세요";
                menustring = "cappuccino";
                break;
            case 10:
                text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요";
                menustring = "vanilla_latte_hot";
                break;
            case 11:
                text[1] = "시원한 바닐라 라떼로 한 잔 주세요";
                menustring = "vanilla_latte_ice";
                break;
            case 12:
                text[1] = "따뜻한 카페 라떼로 한 잔 주세요";
                menustring = "caffe_latte_hot";
                break;
            case 13:
                text[1] = "시원한 카페 라떼로 한 잔 주세요";
                menustring = "caffe_latte_ice";
                break;
            case 14:
                text[1] = "아이스 녹차 라떼로 한 잔 주세요";
                menustring = "greentea_latte_ice";
                break;
            case 15:
                text[1] = "따뜻한 녹차 라떼로 한 잔 주세요";
                menustring = "greentea_latte_hot ";
                break;
            case 16:
                text[1] = "딸기 라떼로 한 잔 주세요";
                menustring = "strawberry_latte ";
                break;
            case 17:
                text[1] = "따뜻한 쵸코로 한 잔 주세요";
                menustring = "hot_chocolate";
                break;
            case 18:
                text[1] = "시원한 쵸코로 한 잔 주세요";
                menustring = "ice_chocolate ";
                break;
            case 19:
                text[1] = "요거트 스무디로 한 잔 주세요";
                menustring = "yogurt_smoothie ";
                break;
            case 20:
                text[1] = "녹차 스무디로 한 잔 주세요";
                menustring = "greentea_smoothie";
                break;
            case 21:
                text[1] = "딸기 스무디로 한 잔 주세요";
                menustring = "strawberry_smoothie ";
                break;
            case 22:
                text[1] = "요거트 펄로 한 잔 주세요";
                menustring = "yogurt_pearl ";
                break;
            case 23:
                text[1] = "녹차 펄로 한 잔 주세요";
                menustring = "greentea_pearl ";
                break;
            case 24:
                text[1] = "딸기 펄 음료 한 잔 주세요";
                menustring = "strawberry_pearl ";
                break;
            case 25:
                text[1] = "에스프레소 프라푸치노 한 잔 주세요";
                menustring = "espresso_frapp";
                break;
            case 26:
                text[1] = "녹차 프라푸치노 한 잔 주세요";
                menustring = "greentea_frapp";
                break;
            case 27:
                text[1] = "딸기 프라푸치노 한 잔 주세요";
                menustring = "strawberry_frapp";
                break;
            case 28:
                text[1] = "쵸코 프라푸치노 한 잔 주세요";
                menustring = "chocolate_frapp";
                break;



        }




    }
}
