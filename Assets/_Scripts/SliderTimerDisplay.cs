using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CountdownTimer))]
public class SliderTimerDisplay : MonoBehaviour
{
    private CountdownTimer countdownTimer;
    private Slider sliderUI;

    void Awake()
    {
        countdownTimer = GetComponent<CountdownTimer>();
        sliderUI = GetComponent<Slider>();
    }
    
    void Start()
    {
        SetupSlider();
        countdownTimer.ResetTimer(30);
    }
    
    void Update()
    {
        sliderUI.value = countdownTimer.GetProportionTimeRemaining();
        print(countdownTimer.GetProportionTimeRemaining());
    }
    
    private void SetupSlider()
    {
        sliderUI.minValue = 0;
        sliderUI.maxValue = 1;
        sliderUI.wholeNumbers = false;
    }

}