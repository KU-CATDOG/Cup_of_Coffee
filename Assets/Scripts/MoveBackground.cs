using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveBackground : MonoBehaviour
{

    public GameObject background;

    private RectTransform rectTransform;

    public Button Leftbtn;
    public Button Rightbtn;
    public Button ZoomOut;
    public Button ZoomOut2;

    public GameObject Rightbg;
    private RectTransform bgScale;

    public Button espressoMachineButton;
    public GameObject MachineButtons;

    public float timeInterval = 0.5f;


    float xpos = 0;
    float movepos = 2560;

    IEnumerator steamFinished;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = background.GetComponent<RectTransform>();
        bgScale = Rightbg.GetComponent<RectTransform>();
        movepos = rectTransform.rect.width;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Leftbtn.interactable && Rightbtn.interactable)
        {
            Leftbtn.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Leftbtn.interactable && Rightbtn.interactable)
        {
            Rightbtn.onClick.Invoke();
        }
    }

    public void ClickMoveLeft()
    {
        Rightbtn.interactable = false;
        Leftbtn.interactable = false;
        xpos = rectTransform.anchoredPosition.x;

        if (xpos == 0)
        {
            Leftbtn.gameObject.SetActive(false);
        }

        if (xpos < movepos)
        {
            StartCoroutine(Transition(movepos, timeInterval));
        }
        Rightbtn.gameObject.SetActive(true);
    }

    public void ClickMoveRight()
    {
        Rightbtn.interactable = false;
        Leftbtn.interactable = false;

        xpos = rectTransform.anchoredPosition.x;

        if (xpos == 0)
        {
            Rightbtn.gameObject.SetActive(false);
        }

        if (xpos > -movepos)
        {
            StartCoroutine(Transition(-movepos, timeInterval));
        }

        Leftbtn.gameObject.SetActive(true);
    }

    // Steam Nozzle zoom in
    public void SteamNozzleClicked(MoveSteamCup steamCup)
    {
        bgScale.localScale = new Vector2(1.95f, 1.95f);
        rectTransform.anchoredPosition -= Vector2.right * 700;
        steamCup.StartSteaming();

        MachineButtons.SetActive(false);
        espressoMachineButton.interactable = false;

        ZoomOut.gameObject.SetActive(false);
        ZoomOut2.gameObject.SetActive(true);

        steamFinished = SteamFinished(steamCup);
        StartCoroutine(steamFinished);
    }

    public void SteamNozzleZoomOutClicked(MoveSteamCup steamCup)
    {
        bgScale.localScale = new Vector2(1.75f, 1.75f);
        rectTransform.anchoredPosition += Vector2.right * 700;
        steamCup.StopSteaming();

        MachineButtons.SetActive(true);
        espressoMachineButton.interactable = true;

        ZoomOut.gameObject.SetActive(true);
        ZoomOut2.gameObject.SetActive(false);

        StopCoroutine(steamFinished);
    }

    IEnumerator SteamFinished(MoveSteamCup steamCup)
    {
        yield return new WaitForSeconds(5f);
        steamCup.FinishedSteaming();
        SteamNozzleZoomOutClicked(steamCup);
    }


    //Transition between backgrounds
    IEnumerator Transition(float dir, float time)
    {
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 finalPos = new Vector2(rectTransform.anchoredPosition.x + dir, 0);

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = finalPos;
        Leftbtn.interactable = true;
        Rightbtn.interactable = true;
    }


    //Espresso Machine zoom in
    public void EspressomachineClicked()
    {
        bgScale.localScale = new Vector2(1.75f, 1.75f);

        Leftbtn.gameObject.SetActive(false);
        Rightbtn.gameObject.SetActive(false);
        Leftbtn.interactable = false;
        Rightbtn.interactable = false;

        MachineButtons.SetActive(true);

        ZoomOut.gameObject.SetActive(true);
    }

    //Espresso Machine zoom out
    public void ZoomOutClicked()
    {
        bgScale.localScale = new Vector2(1, 1);

        Leftbtn.gameObject.SetActive(true);
        Leftbtn.interactable = true;

        MachineButtons.SetActive(false);

        ZoomOut.gameObject.SetActive(false);

    }

}
