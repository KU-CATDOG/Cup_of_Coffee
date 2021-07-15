using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVisible : MonoBehaviour
{
    [SerializeField]
    private GameObject GMObject;
    private GM refer;
    [SerializeField]
    private GameObject leftButton;
    [SerializeField]
    private GameObject rightButton;

    // Start is called before the first frame update
    void Start()
    {
        refer = GMObject.GetComponent<GM>();

    }

    // Update is called once per frame
    void Update()
    {
        if (refer.screenPosition == -1)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }
        if (refer.screenPosition == 1)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }
    }
}
