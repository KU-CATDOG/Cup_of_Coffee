using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientLog : MonoBehaviour
{
    public Recipe recipe;
    public Text logText;
    public Text specialText;

    private bool isOpened = false;

    private void Start()
    {
        CloseLog();
    }

    public void ButtonPressEvent()
    {
        if (isOpened == true)
        {
            CloseLog();
            isOpened = false;
        }
        else
        {
            ShowLog();
            isOpened = true;
        }
    }

    private void ShowLog()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 225f / 255f);

        List<string> log = recipe.GetAddedIngredientLog();

        if (log.Count == 0)
        {
            logText.gameObject.SetActive(false);
            specialText.gameObject.SetActive(true);
        }
        else
        {
            logText.gameObject.SetActive(true);
            specialText.gameObject.SetActive(false);

            logText.text = "";
            for (int i = log.Count - 1; i >= 0; i--)
            {
                Debug.Log(log.Count);
                logText.text += "\n" + log[i];
            }

            logText.text.Replace("\\n", "\n");
        }
    }

    private void CloseLog()
    {
        logText.gameObject.SetActive(false);
        specialText.gameObject.SetActive(false);
        gameObject.GetComponent<Image>().color = Color.clear;
    }
}
