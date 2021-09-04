using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class milkDisplay : MonoBehaviour
{
    public Text milkAmount;
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        milkAmount.text = "" + (recipe.pitcherMilkCount * 50) + " mL";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMilkAmount()
    {
        milkAmount.text = "" + (recipe.pitcherMilkCount * 50) + " mL";
    }
}
