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
        blenderInside.SetActive(true);
        StartCoroutine(Waiter());
    }
    public void DeactivateBlenderLiquid()
    {
        blenderInside.SetActive(false);
    }

    IEnumerator Waiter()
    {
        SoundManager.Instance.PlaySFXSound("blender", 0.7f);
        yield return new WaitForSeconds(5);
        recipe.Add_blend();
        DeactivateBlenderLiquid();
    }

}
