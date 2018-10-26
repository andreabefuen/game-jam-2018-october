using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Slider timerSlider;
    public Text informationText;
    bool showingInformationText;

    public static UIController instance;
    void Awake() { instance = this; }

    float levelSeconds;
   

    public void InitializeTimer(int levelSeconds) { timerSlider.value = timerSlider.maxValue = this.levelSeconds = levelSeconds; }
    public void InitializeTimer(float levelSeconds) { timerSlider.value = timerSlider.maxValue = this.levelSeconds = levelSeconds; }

    public void UpdateTimerGraphic(float currentSeconds)
    {
        timerSlider.value = currentSeconds;
        timerSlider.targetGraphic.color = Color.Lerp( Color.red, Color.green, currentSeconds / levelSeconds);
    }


    void HideInformationText()
    {
        informationText.GetComponent<Animation>().Play("HideInformationText");
        showingInformationText = false;
    }

    public void ShowInformationText(string textToShow, float howLongFor)
    {
        if (!showingInformationText)
        {
            showingInformationText = true;
            informationText.text = textToShow;
            informationText.GetComponent<Animation>().Play("ShowInformationText");
            Invoke("HideInformationText", howLongFor);
        } 
    }


}
