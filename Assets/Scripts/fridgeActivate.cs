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
        
    }

    public void FridgeActivate()
    {
        fridge.SetActive(true);
    }

    public void FridgeDeactivate()
    {
        fridge.SetActive(false);
    }
}
