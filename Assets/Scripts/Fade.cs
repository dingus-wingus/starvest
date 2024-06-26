using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// Fade  Script
/// Kozeng Yang 
// 4/30/24
public class Fade : MonoBehaviour

 
{
    // Start is called before the first frame update
    public float fadeTime;
    private TextMeshProUGUI fadeAwayText;
    private float alphaValue;
    private float fadeAwayPerSecond;
    void Start()
    {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = fadeAwayText.color.a;
    }

    // Update is called once per frame
    /// <summary>
    /// Makes the Text fade after 10 seconds
    /// </summary>
    void Update()
    {
        if(fadeTime > 0)
        {
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }
    }
}
