using UnityEngine;
using UnityEngine.UI;
public class MpBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider slider;

    public void SetMaxMp(float hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }
    public void SetMp(float hp)
    {
        slider.value = hp;


    }
}
