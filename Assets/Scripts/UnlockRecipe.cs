using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRecipe : MonoBehaviour
{
    private static UnlockRecipe instance;
    public static UnlockRecipe Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UnlockRecipe>();
            }

            return instance;
        }
    }

    public GameTime gameTime;
    public int syrupUnlockDay = 1;
    public int milkUnlockDay = 1;
    public int yogurtUnlockDay = 2;
    public int bubblePearlUnlockDay = 3;
    public int blenderUnlockDay = 4;

    [HideInInspector]
    public bool[] recipeUnlockStatus = new bool[29];

    private void Start()
    {
        UpdateUnlockStatus();
    }

    public void UpdateUnlockStatus()
    {
        for (int i = 0; i < recipeUnlockStatus.Length; i++)
        {
            recipeUnlockStatus[i] = false;
        }

        if (gameTime.day >= 0)
        {
            // 기본 음료
            recipeUnlockStatus[0] = true;
            recipeUnlockStatus[3] = true;
            recipeUnlockStatus[4] = true;
        }

        if (gameTime.day >= syrupUnlockDay)
        {
            // 시럽 해금 필요
            recipeUnlockStatus[1] = true;
            recipeUnlockStatus[2] = true;
            recipeUnlockStatus[17] = true;
            recipeUnlockStatus[18] = true;
        }

        if (gameTime.day >= milkUnlockDay)
        {
            // 우유 해금 필요
            recipeUnlockStatus[8] = true;
            recipeUnlockStatus[9] = true;
            recipeUnlockStatus[10] = true;
            recipeUnlockStatus[11] = true;
            recipeUnlockStatus[12] = true;
            recipeUnlockStatus[13] = true;
            recipeUnlockStatus[14] = true;
            recipeUnlockStatus[15] = true;
            recipeUnlockStatus[16] = true;
        }

        if (gameTime.day >= yogurtUnlockDay)
        {
            // 요거트 해금 필요
            recipeUnlockStatus[19] = true;
            recipeUnlockStatus[20] = true;
            recipeUnlockStatus[21] = true;
        }

        if (gameTime.day >= bubblePearlUnlockDay)
        {
            // 버블 펄 해금 필요
            recipeUnlockStatus[22] = true;
        }

        if (gameTime.day >= blenderUnlockDay)
        {
            // 믹서기 해금 필요
            recipeUnlockStatus[23] = true;
            recipeUnlockStatus[24] = true;
            recipeUnlockStatus[25] = true;
            recipeUnlockStatus[26] = true;
        }
    }

    public bool IsSyrupUnlocked()
    {
        return gameTime.day >= syrupUnlockDay;
    }

    public bool IsMilkUnlocked()
    {
        return gameTime.day >= milkUnlockDay;
    }

    public bool IsYogurtUnlocked()
    {
        return gameTime.day >= yogurtUnlockDay;
    }

    public bool IsBubblePearlUnlocked()
    {
        return gameTime.day >= bubblePearlUnlockDay;
    }

    public bool IsBlenderUnlocked()
    {
        return gameTime.day >= blenderUnlockDay;
    }
}
