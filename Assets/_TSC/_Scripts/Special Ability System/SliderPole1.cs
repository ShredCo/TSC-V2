using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPole1 : MonoBehaviour
{
    public FloatVariable Pole1;
    public Slider Slider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateSlider()
    {
        Slider.value = Pole1.RuntimeValue;
    }
}
