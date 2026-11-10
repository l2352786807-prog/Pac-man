using StarterAssets;
using UnityEngine;

public class speedpac : MonoBehaviour
{
    public AudioClip coinSound;
    public float speedIncrease = 10f;
    public float boostDuration = 5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            ThirdPersonController controller = other.GetComponent<ThirdPersonController>();

            if (controller != null)
            {
                // 开始协程处理速度提升
                StartCoroutine(TemporarySpeedBoost(controller));

                // 销毁速度道具
                Destroy(gameObject);
            }

            // 销毁速度道具

            Destroy(gameObject);
            
        }
        System.Collections.IEnumerator TemporarySpeedBoost(ThirdPersonController controller)
        {
            // 记录原始速度并提升
            float originalSpeed = controller.MoveSpeed;
            controller.MoveSpeed += speedIncrease;
            Debug.Log($"速度提升！当前速度: {controller.MoveSpeed}");

            // 等待5秒
            yield return new WaitForSeconds(boostDuration);

            // 5秒后恢复原速度
            controller.MoveSpeed = originalSpeed;
            Debug.Log($"速度恢复！当前速度: {controller.MoveSpeed}");
        }

    }
}
