using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receipt : MonoBehaviour
{
    public Text detailLeft;
    public Text detailRight;
    public Text day;
    public GameTime gameTime;
    private int curDay;
    private int offset;
    private int month;
    public Recipe recipe;
    public CsvLoadCustomer customer;

    private int money;
    private int moneyPerCustomer;
    private int moneyPerMistake;
    private int tax;
    private int bonus;
    private int totalMoney;
    private int tipRate;
    private int tipMoney;
    public int bankMoney = 0;

    // Start is called before the first frame update
    void Start()
    {

        money = 0;
        moneyPerCustomer = 5385;
        moneyPerMistake = 375;
        tax = 10;
        month = 2;
        offset = 8;
        bonus = 7600;
        tipRate = 5;
        tipMoney = money * tipRate / 100;
        totalMoney = money + bonus + tipMoney;

        curDay = gameTime.day + offset;
        if (curDay > 30)
        {
            curDay %= 30;
            month++;
        }
        if (recipe.dayMistakeCount == 0)
        {
            detailLeft.text = "�� �Ǹŷ�\n�Ǽ�\n����\n������ �޷�\n�Ϻ� ���ʽ�!\n��\n�� �޿�";
            detailRight.text = "" + customer.successCustomer + "\n" + recipe.dayMistakeCount + "\n10%\n" + money + "\n" + bonus + "\n" + tipMoney + "\n" + totalMoney;
        }
        else
        {
            detailLeft.text = "�� �Ǹŷ�\n�Ǽ�\n������\n������ �޷�\n��\n�� �޿�";
            detailRight.text = "" + customer.successCustomer + "\n" + recipe.dayMistakeCount + "\n10%\n" + money + "\n" + tipMoney + "\n" + totalMoney;
        }
        day.text = "2061 �� " + month + "�� " + curDay + "��";
    }

    public void UpdateGameTime()
    {
        tipRate = Random.Range(3, 6);
        money = customer.successCustomer * moneyPerCustomer - recipe.dayMistakeCount * moneyPerMistake;
        money *= ((100-tax) / 100);
        tipMoney = money * tipRate / 100;
        totalMoney = money + bonus + tipMoney;

        curDay = gameTime.day + offset;
       
        if (curDay > 30)
        {
            curDay %= 30;
            month++;
        }
        if (recipe.dayMistakeCount == 0)
        {
            detailLeft.text = "�� �Ǹŷ�\n�Ǽ�\n����\n������ �޷�\n�Ϻ� ���ʽ�!\n��\n�� �޿�";
            detailRight.text = "" + customer.successCustomer + "\n" + recipe.dayMistakeCount + "\n10%\n" + money + "\n" + bonus + "\n" + tipMoney + "\n" + totalMoney;
            bankMoney += totalMoney;
        }
        else
        {
            detailLeft.text = "�� �Ǹŷ�\n�Ǽ�\n������\n������ �޷�\n��\n�� �޿�";
            detailRight.text = "" + customer.successCustomer + "\n" + recipe.dayMistakeCount + "\n10%\n" + money + "\n" + tipMoney + "\n" + totalMoney;
            bankMoney += totalMoney;
        }
    }
}
