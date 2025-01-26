using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxValue(float Value)
    {
        Slider.maxValue = Value;
        Slider.value = Value;
    }
    public void SetValue(float Value)
    {
        Slider.value = Value;
    }
}
