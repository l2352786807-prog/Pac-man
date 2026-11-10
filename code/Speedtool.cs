using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Speedtool : MonoBehaviour
{

    public plearer play;
    public health healthBar;
    public int maxHealth;
    public ThirdPersonController player;
    public TMP_Text num;
    public TMP_Text num1;
    public int n = 5;
    public int n1 = 5;
    public void Start()
    {
        num.text = "สฃำเ" + n;
        num1.text = "สฃำเ" + n1;
    }
    public void speedup() {
        if (n > 0)
        {
            n -= 1;
            player.MoveSpeed += 0.5f;
            num.text = "สฃำเ"+n;
        }

    }
    public void Hpup()
    {
        if (n1 > 0)
        {
            if (play.currentHealth <= 180)
            {
                n1 -= 1;
                play.currentHealth += 20;
                maxHealth = play.currentHealth;

                healthBar.SetHealth(maxHealth);
                num1.text = "สฃำเ" + n1;
            }
        }
    }
}
