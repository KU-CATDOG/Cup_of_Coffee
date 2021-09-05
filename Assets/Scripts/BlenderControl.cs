using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderControl : MonoBehaviour
{
    public GameObject blenderInside;
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        blenderInside.SetActive(false);
    }

    public void ActivateBlenderLiquid()
    {
        StartCoroutine(Waiter());
    }
    public void DeactivateBlenderLiquid()
    {
        blenderInside.SetActive(false);
    }

    IEnumerator Waiter()
    {
        if (UnlockRecipe.Instance.IsBlenderUnlocked() == false)
        {
            yield break;
        }

        else
        {
            blenderInside.SetActive(true);
            SoundManager.Instance.PlaySFXSound("blender", 0.7f);
            yield return new WaitForSeconds(5);
            recipe.Add_blend();
            DeactivateBlenderLiquid();
        }

    }

}
