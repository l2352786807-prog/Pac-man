using TMPro;
using UnityEngine;

public class shopping : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UIcontrol control;
    public Speedtool bag;
    public TMP_Text num;
    public TMP_Text num1;
    public TMP_Text glod;

    public void speedshop()
    {
        if (control.mega >= 3)
        {
            control.mega -= 3;
            bag.n += 1;
            num.text = "สฃำเ" + bag.n;
            glod.text = ":"+control.mega;
        }
    }
    public void hpshop()
    {
        if (control.mega >= 5)
        {
            control.mega -= 5;
            bag.n1 += 1;
            num1.text = "สฃำเ" + bag.n1;
            glod.text = ":" + control.mega;
        }
    }
}
