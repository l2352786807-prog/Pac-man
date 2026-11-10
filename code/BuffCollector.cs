using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuffCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ThirdPersonController player;
    public plearer Me;
    public GameObject glass;
    public float mpMax = 20f;
    public float mp = 0;
    public MpBar Mp;
    public float hpRecover = 0.5f;

    [Header("Buff设置")]
    public float speedBuffValue = 5f;      // 加速Buff的数值
    public float speedBuffDuration = 5f;   // Buff持续时间
    private float speedBuffRemainingTime;   // Buff剩余时间
    private bool isSpeedBuffActive = false;         // Buff是否激活
    public TMP_Text buff;
    public float mpcost = 5f;
    public int hurt;
    public BuffBar buff1;

    void Start()
    {
        glass.SetActive(isSpeedBuffActive);
        mp = mpMax;
        Mp.SetMaxMp(mp);
        hurt = Me.hurt;
        buff1.SetMaxBuff(speedBuffDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if (mp < mpMax)
        {
            mp += Time.deltaTime * hpRecover;
            Mp.SetMp(mp);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame&&mp>=mpcost)
        {   
            mp -= mpcost;
            Mp.SetMp(mp);

            isSpeedBuffActive = true;
            speedBuffRemainingTime = speedBuffDuration;
            glass.SetActive(isSpeedBuffActive);
            buff.text = "无敌玩家，启动！";
           
            player.MoveSpeed += speedBuffValue;
            Me.hurt = 0;
        }
        if (isSpeedBuffActive)
        {
            speedBuffRemainingTime -= Time.deltaTime;

            buff1.SetBuff(speedBuffRemainingTime);

            if (speedBuffRemainingTime <= 0)
            {
                isSpeedBuffActive = false;
                glass.SetActive(isSpeedBuffActive);
                Debug.Log("速度Buff已结束");
                buff.text = "";

                player.MoveSpeed -= speedBuffValue;
                Me.hurt = hurt;
            }
        }
        
    }
}
