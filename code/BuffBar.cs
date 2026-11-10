using UnityEngine;
using UnityEngine.UI;
public class BuffBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBuff(float time)
    {
        slider.maxValue = time;
        slider.value = 0;
    }
    public void SetBuff(float time)
    {
        slider.value = time;


    }
}
