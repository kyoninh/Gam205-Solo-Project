using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   

public class FadeOnEnabled : MonoBehaviour
{
    [SerializeField]
    private Color start;
    [SerializeField]
    private Color end;
    [SerializeField]
    private float fadeTime;
    [SerializeField]
    private Image image;
    [SerializeField]
    private AnimationCurve fadeCurve;
    
    void OnEnable()
    {
        StartCoroutine(ChangeColorOverTime(start, end, fadeTime));
    }

    //Changes the color from one value to the next over a specified amount of time. 
    IEnumerator ChangeColorOverTime(Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.unscaledDeltaTime)
        {
            float normalizedT = t/duration;
            Debug.Log(normalizedT);
            image.color = Color.Lerp(start, end, fadeCurve.Evaluate(normalizedT));
            yield return null;
        }
         
    }
}
