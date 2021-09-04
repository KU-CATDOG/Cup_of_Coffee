using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridgeActivate : MonoBehaviour
{
    public GameObject fridge;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fridge.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FridgeDeactivate();
            }
        }
    }

    public void FridgeActivate()
    {
        SoundManager.Instance.PlaySFXSound("fridge_open");
        fridge.SetActive(true);
    }

    public void FridgeDeactivate()
    {
        SoundManager.Instance.PlaySFXSound("fridge_close");
        fridge.SetActive(false);
    }
}
