using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receipt : MonoBehaviour
{
    public Text detail;
    public Text day;
    public GameTime gameTime;
    private int curDay;
    private int offset;
    private int month;

    // Start is called before the first frame update
    void Start()
    {
        month = 2;
        offset = 8;
        curDay = gameTime.day + offset;
        if (curDay > 30)
        {
            curDay %= 30;
            month++;
        }
        detail.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vehicula viverra turpis a congue. Sed congue sodales sem, ac aliquet nulla mollis eget. In auctor, lectus at euismod blandit, libero nibh finibus nulla, quis cursus ante elit sit amet leo. In libero ante, sollicitudin id elit id, scelerisque interdum nunc.";
        day.text = "2061 년 " + month + "월 " + curDay + "일";
    }

    public void UpdateGameTime()
    {
        curDay = gameTime.day + offset;
        if (curDay > 30)
        {
            curDay %= 30;
            month++;
        }
        detail.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vehicula viverra turpis a congue. Sed congue sodales sem, ac aliquet nulla mollis eget. In auctor, lectus at euismod blandit, libero nibh finibus nulla, quis cursus ante elit sit amet leo. In libero ante, sollicitudin id elit id, scelerisque interdum nunc.";
        day.text = "2061 년 2월 " + curDay + "일";
    }
}
