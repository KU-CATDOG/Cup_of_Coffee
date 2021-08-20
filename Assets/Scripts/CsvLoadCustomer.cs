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
    public int b; // 에스프레소, 룽고, 리스트레토 중 무엇인가를 담당
    public int real; // real = 진짜 감정을 줄 확률
    public int customertoken; //손님이 들어올 때 결정되는 토큰

    void Start()
    {
        isActive = false;
        Customertextbox.SetActive(false);
        text[0] = "안녕하세요";
        b = 0;
        real = 80;
        token = GameObject.Find("TokenObject");
        recipe = GameObject.Find("RecipeTest");
    }

    private void SetRandom() //랜덤으로 들어오는 것들 설정 = 메뉴, 토큰
    {
        menunumber = Random.Range(1, 29); //메뉴 1~29까지 랜덤 선택
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
                if (isLock == false) // 반복해서 주문이 오지 않도록 설정
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
        Customertext.text = "감사합니다. 수고하세요~";
        int random = Random.Range(0, 100);
        if(random < real) // 진짜 감정을 줄 때
        {
            token.GetComponent<TokenTest>().RealToken(customertoken);

        }
        else // 가짜 감정을 줄 떄
        {
            token.GetComponent<TokenTest>().FakeToken(customertoken);
        }
    }

    public void Fail()
    {
        Customertext.text = "아니 이걸 시킨 적이 없는데... 이게 왜 나와요;;";
    }

    public void menu(int number)
    {
        switch (number)
        {
            case 1: // 에스프레소는 리조트레또, 에스프레소, 룽고;
                b = Random.Range(1, 100);
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

            case 2:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "시원한 카라멜 마끼아또로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "caramel_macchiato_cold_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "카라멜 마끼아또로 한 잔 주세요";
                    menustring = "caramel_macchiato_cold";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "시원한 카라멜 마끼아또로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "caramel_macchiato_cold_lungo";
                    break;
                }
                break;
            case 3:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "caramel_macchiato_hot_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요";
                    menustring = "caramel_macchiato_hot";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "caramel_macchiato_hot_lungo";
                    break;
                }
                break;
            case 4:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 아메리카노로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "americano_hot_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 아메리카노로 한 잔 주세요";
                    menustring = "americano_hot";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "따뜻한 아메리카노로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "americano_hot_lungo";
                    break;
                }
                break;
            case 5:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "아이스 아메리카노로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "americano_ice_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "아이스 아메리카노로 한 잔 주세요";
                    menustring = "americano_ice";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "아이스 아메리카노로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "americano_ice_lungo";
                    break;
                }
                break;
            case 6:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "아이스 카페모카로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "caffe_mocha_ice_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "아이스 카페모카로 한 잔 주세요";
                    menustring = "caffe_mocha_ice";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "아이스 카페모카로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "caffe_mocha_ice_lungo";
                    break;
                }
                break;
            case 7:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 카페모카로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "caffe_mocha_hot_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 카페모카로 한 잔 주세요";
                    menustring = "caffe_mocha_hot";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "따뜻한 카페모카로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "caffe_mocha_hot_lungo";
                    break;
                }
                break;
            case 8:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소 콘 파냐로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "espresso_con_panna_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소 콘 파냐로 한 잔 주세요";
                    menustring = "espresso_con_panna";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "에스프레소 콘 파냐로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "espresso_con_panna_lungo";
                    break;
                }
                break;
            case 9:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소 마끼아또로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "espresso_macchiato_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소 마끼아또로 한 잔 주세요";
                    menustring = "espresso_macchiato";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "에스프레소 마끼아또로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "espresso_macchiato_lungo";
                    break;
                }
                break;
            case 10:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "카푸치노로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "cappuccino_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "카푸치노로 한 잔 주세요";
                    menustring = "cappuccino";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "카푸치노로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "cappuccino_lungo";
                    break;
                }
                break;
            case 11:
                text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요";
                menustring = "vanilla_latte_hot";
                break;
            case 12:
                text[1] = "시원한 바닐라 라떼로 한 잔 주세요";
                menustring = "vanilla_latte_ice";
                break;
            case 13:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 카페 라떼로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "caffe_latte_hot_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 카페 라떼로 한 잔 주세요";
                    menustring = "caffe_latte_hot";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "따뜻한 카페 라떼로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "caffe_latte_hot_lungo";
                    break;
                }
                break;
            case 14:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "시원한 카페 라떼로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "caffe_latte_ice_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "시원한 카페 라떼로 한 잔 주세요";
                    menustring = "caffe_latte_ice";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "시원한 카페 라떼로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "caffe_latte_ice_lungo";
                    break;
                }
                break;
            case 15:
                text[1] = "아이스 녹차 라떼로 한 잔 주세요";
                menustring = "greentea_latte_ice";
                break;
            case 16:
                text[1] = "따뜻한 녹차 라떼로 한 잔 주세요";
                menustring = "greentea_latte_hot ";
                break;
            case 17:
                text[1] = "딸기 라떼로 한 잔 주세요";
                menustring = "strawberry_latte ";
                break;
            case 18:
                text[1] = "따뜻한 쵸코로 한 잔 주세요";
                menustring = "hot_chocolate";
                break;
            case 19:
                text[1] = "시원한 쵸코로 한 잔 주세요";
                menustring = "ice_chocolate ";
                break;
            case 20:
                text[1] = "요거트 스무디로 한 잔 주세요";
                menustring = "yogurt_smoothie ";
                break;
            case 21:
                text[1] = "녹차 스무디로 한 잔 주세요";
                menustring = "greentea_smoothie";
                break;
            case 22:
                text[1] = "딸기 스무디로 한 잔 주세요";
                menustring = "strawberry_smoothie ";
                break;
            case 23:
                text[1] = "요거트 펄로 한 잔 주세요";
                menustring = "yogurt_pearl ";
                break;
            case 24:
                text[1] = "녹차 펄로 한 잔 주세요";
                menustring = "greentea_pearl ";
                break;
            case 25:
                text[1] = "딸기 펄 음료 한 잔 주세요";
                menustring = "strawberry_pearl ";
                break;
            case 26:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소 프라푸치노로 한 잔 주세요. 쓰지 않게 해서 주세요";
                    menustring = "espresso_frapp_ristretto";
                    break;
                }
                if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소 프라푸치노로 한 잔 주세요";
                    menustring = "espresso_frapp";
                    break;
                }
                if (b >= 85)
                {
                    text[1] = "에스프레소 프라푸치노로 한 잔 주세요. 시지 않게 해서 주세요";
                    menustring = "espresso_frapp_lungo";
                    break;
                }
                break;
            case 27:
                text[1] = "녹차 프라푸치노 한 잔 주세요";
                menustring = "greentea_frapp";
                break;
            case 28:
                text[1] = "딸기 프라푸치노 한 잔 주세요";
                menustring = "strawberry_frapp";
                break;
            case 29:
                text[1] = "쵸코 프라푸치노 한 잔 주세요";
                menustring = "chocolate_frapp";
                break;

        }




    }
}
