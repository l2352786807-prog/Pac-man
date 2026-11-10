using StarterAssets;
using UnityEngine;

public class Rush : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rushMultiplier = 5f;
    private ThirdPersonController controller;
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入的是否是玩家
        if (other.CompareTag("Player"))
        {
            // 获取玩家的跳跃脚本
            controller = other.GetComponent<ThirdPersonController>();

            if (controller != null)
            {
                controller.MoveSpeed += rushMultiplier;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        // 检查离开的是否是玩家
        if (other.CompareTag("Player"))
        {
            controller = other.GetComponent<ThirdPersonController>();
            // 恢复原始跳跃能力
            controller.MoveSpeed -= rushMultiplier;

        }
    }
}
