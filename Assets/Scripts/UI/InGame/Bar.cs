using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider Slider;
    public PlayerState State;

    public void Start()
    {
        SetMaxValue(State.MaxHealth);
        SetMaxValue(State.MaxMana);
    }

    public void Update()
    {
        SetValue(State.Health);
        SetValue(State.Mana);
    }

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
