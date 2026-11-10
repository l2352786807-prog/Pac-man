using UnityEngine;

public class FerrisWheelRotation : MonoBehaviour
{
    [Header("旋转设置")]
    public float rotationSpeed = 30f;  // 旋转速度（度/秒）
    public bool clockwise = true;       // 是否顺时针旋转

    [Header("舱室设置")]
    public Transform[] cabins;          // 舱室数组
    public bool keepCabinsUpright = true;

    void Update()
    {
        // 计算旋转方向
        float direction = clockwise ? -1f : 1f;
        float rotationThisFrame = rotationSpeed * direction * Time.deltaTime;

        // 旋转整个摩天轮
        transform.Rotate(rotationThisFrame, 0, 0);

        // 保持舱室竖直向上（解决倒挂问题）
        if (keepCabinsUpright && cabins != null)
        {
            foreach (Transform cabin in cabins)
            {
                // 恢复舱室的竖直方向，但保留水平旋转
                Vector3 currentEuler = cabin.eulerAngles;
                cabin.eulerAngles = new Vector3(0, currentEuler.y, 0);
            }
        }
    }
}
