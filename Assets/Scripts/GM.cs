using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    //[SerializeField]
    //private GameObject leftScreenButton;
    //[SerializeField]
    //private GameObject rightScreenButton;

    public int screenPosition = 0;
    [SerializeField]
    private GameObject tableImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseTrack();
        
    }

    private void mouseTrack()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse left clicked at " + Input.mousePosition);
        }
    }


    public void leftButtonDown()
    {
        Debug.Log("Left button pressed");
        if (screenPosition != -1)
        {
            RectTransform rt = tableImg.GetComponent<RectTransform>();
            screenPosition -= 1;
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + 1280, 0);
        }

    }

    public void rightButtonDown()
    {
        Debug.Log("Right button pressed");
        if (screenPosition != 1)
        {
            RectTransform rt = tableImg.GetComponent<RectTransform>();
            screenPosition += 1;
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x - 1280, 0);
        }

    }


}
