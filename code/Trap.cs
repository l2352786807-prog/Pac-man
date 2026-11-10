using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("移动设置")]
    [Tooltip("从起点向前移动的距离（沿Z轴负方向）")]
    public float moveDistance = 5f;
    [Tooltip("移动速度（单位/秒）")]
    public float moveSpeed = 2f;
    [Tooltip("到达端点后的停顿时间（秒）")]
    public float pauseTime = 0.5f;
    [Tooltip("是否在端点转身")]
    public bool rotateAtEnds = true;
    [Tooltip("转身速度（度/秒），0表示瞬间转身")]
    public float rotateSpeed = 180f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true; // true:向目标点移动, false:返回起点
    private float pauseTimer = 0f;
    private bool isRotating = false;
    private Quaternion targetRotation;

    void Start()
    {
        // 记录起点位置
        startPos = transform.position;
        // 计算目标位置（沿Z轴负方向移动）
        targetPos = startPos + Vector3.back * moveDistance;
    }

    void Update()
    {
        // 如果在转身过程中
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            // 检查是否完成转身
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
            return;
        }

        // 如果在暂停状态，倒计时
        if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;
            return;
        }

        // 根据当前移动方向确定终点
        Vector3 destination = movingToTarget ? targetPos : startPos;
        // 向目标点移动
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        // 检查是否到达
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            // 精确到达目标点
            transform.position = destination;

            // 切换方向
            movingToTarget = !movingToTarget;

            // 处理转身
            if (rotateAtEnds)
            {
                // 计算新的朝向：移动方向的反方向
                Vector3 newDirection = movingToTarget ? Vector3.back : Vector3.forward;
                targetRotation = Quaternion.LookRotation(newDirection);

                if (rotateSpeed <= 0)
                {
                    // 瞬间转身
                    transform.rotation = targetRotation;
                }
                else
                {
                    // 平滑转身
                    isRotating = true;
                }
            }

            // 开始暂停
            pauseTimer = pauseTime;
        }
    }

    // 可视化辅助：在编辑器中显示移动范围线（不运行时也可见）
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            // 设计时预览：沿Z轴负方向
            Vector3 previewStart = transform.position;
            Vector3 previewTarget = previewStart + Vector3.back * moveDistance;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(previewStart, previewTarget);
            Gizmos.DrawWireSphere(previewStart, 0.1f);
            Gizmos.DrawWireSphere(previewTarget, 0.1f);

            // 显示朝向箭头
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(previewStart, Vector3.forward * 0.5f);
            Gizmos.DrawRay(previewTarget, Vector3.back * 0.5f);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(startPos, targetPos);
            Gizmos.DrawWireSphere(startPos, 0.1f);
            Gizmos.DrawWireSphere(targetPos, 0.1f);
        }
    }
}
