using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOutside : MonoBehaviour
{
    public static ChangeOutside instance;

    [Header("Images")]
    public Image day;
    public Image twilight;
    public Image night1;
    public Image night2;

    [Header("Time")]
    public int dayToTwilight;
    public int twilightToNight;
    
    [Space(10)]
    public float changeTime;
    public float animateTime;
    public float animateInterval;

    private float[] animateAlpha = new float[2];

    private float sec = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(AnimationCor());
    }

    public void ChangeImageToTwilight()
    {
        StartCoroutine(ImageChangeCor(day));
    }

    public void ChangeImageToNight()
    {
        StartCoroutine(ImageChangeCor(twilight));
    }

    public void InitiateOutside()
    {
        day.color = Color.white;
        twilight.color = Color.white;
    }

    private IEnumerator ImageChangeCor(Image target)
    {
        float sec = 0;
        while(sec <= changeTime)
        {
            target.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), sec / changeTime);

            sec += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator AnimationCor()
    {
        Image target = night1;
        while (true)
        {
            target = (target == night1) ? night2 : night1;
            float sec = 0;
            while (sec <= animateTime)
            {
                target.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), sec / animateTime);

                sec += Time.deltaTime;
                yield return null;
            }

            if (target == night2)
            {
                night1.color = Color.white;
                night2.color = Color.white;
            }

            yield return new WaitForSeconds(animateInterval);
        }
    }
}
