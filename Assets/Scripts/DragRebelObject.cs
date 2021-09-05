using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragRebelObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject RebelSmth;
    
    private RectTransform rectTr;
    //private Dictionary<string, Sprite> drinkImagesDic = new Dictionary<string, Sprite>();

    private Vector2 initPos;

    public DialogueEvent DEvent;

    private void Start()
    {
        RebelSmth = GameObject.Find("RebelObject");
        DEvent = GameObject.FindObjectOfType(typeof(DialogueEvent)) as DialogueEvent;
        rectTr = gameObject.GetComponent<RectTransform>();
    }

    public void ShowObject(){
        rectTr.anchoredPosition = new Vector2(200, -250);
    }
    public void HideObject(){
        rectTr.anchoredPosition = new Vector2(200, -800);
    }

    public void OnBeginDrag(PointerEventData data)
    {
        initPos = rectTr.anchoredPosition;
    }

    public void OnDrag(PointerEventData data)
    {
        if(DEvent.gameTime.day == 9){
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
            rectTr.position = mousePos;
            
            if(rectTr.anchoredPosition.y > -100){
                RebelSmth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "주기";
            }
            else if(rectTr.anchoredPosition.y < -400){
                RebelSmth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "주지 않기";
            }
            else{
                RebelSmth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
            }
        }

    }
    public void OnEndDrag(PointerEventData data)
    {
        
        if (rectTr.anchoredPosition.y > -100){
            DEvent.RebelObjectChoice = true;
            DEvent.RebelObject = 2;
            DEvent.Day9(3);
            RebelSmth.SetActive(false);
            
        }
        else if(rectTr.anchoredPosition.y < -400){
            DEvent.RebelObjectChoice = true;
            DEvent.RebelObject = 3;
            DEvent.Day9(3);
            RebelSmth.SetActive(false);
        }
        else{
            rectTr.anchoredPosition = initPos;
        }

    }
}
