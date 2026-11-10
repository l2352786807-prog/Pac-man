using UnityEngine;
using System.Collections.Generic;
public class TheCar : MonoBehaviour
{
    [Header("轨道设置")]
    public Transform[] waypoints;        // 路径点
    public bool loop = true;              // 是否循环

    [Header("速度控制")]
    public AnimationCurve speedCurve = AnimationCurve.EaseInOut(0, 0, 1, 10);
    // 横坐标：进度(0-1)，纵坐标：速度

    public bool useAcceleration = true;   // 是否使用加速
    public float maxSpeed = 10f;          // 最大速度
    public float acceleration = 5f;       // 加速度

    private int currentTarget = 1;
    private float currentSpeed = 0f;
    private float t = 0f;                 // 当前段进度
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        if (waypoints.Length < 2)
        {
            Debug.LogError("至少需要2个路径点");
            return;
        }

        startPos = waypoints[0].position;
        endPos = waypoints[1].position;
        transform.position = startPos;
    }

    void Update()
    {
        if (waypoints.Length < 2) return;

        // 计算当前段的速度
        if (useAcceleration)
        {
            // 方式1：使用加速度
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        }
        else
        {
            // 方式2：使用曲线（基于整体进度）
            float overallProgress = GetOverallProgress();
            currentSpeed = speedCurve.Evaluate(overallProgress);
        }

        // 移动
        float step = currentSpeed * Time.deltaTime;
        float distance = Vector3.Distance(startPos, endPos);
        t += step / distance;

        transform.position = Vector3.Lerp(startPos, endPos, t);

        // 到达下一个路径点
        if (t >= 1f)
        {
            NextWaypoint();
        }

        // 可选：让物体面朝运动方向
        if (step > 0)
        {
            Vector3 direction = (endPos - startPos).normalized;
            if (direction != Vector3.zero)
                transform.forward = direction;
        }
    }

    void NextWaypoint()
    {
        currentTarget++;

        if (currentTarget >= waypoints.Length)
        {
            if (loop)
            {
                currentTarget = 1;
                startPos = waypoints[0].position;
                endPos = waypoints[1].position;
            }
            else
            {
                enabled = false;
                return;
            }
        }
        else
        {
            startPos = endPos;
            endPos = waypoints[currentTarget].position;
        }

        t = 0f;

        // 非循环模式下重置速度
        if (!useAcceleration && !loop && currentTarget == 1)
            currentSpeed = 0f;
    }

    float GetOverallProgress()
    {
        int totalSegments = waypoints.Length - 1;
        float segmentProgress = (currentTarget - 1 + t) / totalSegments;
        return Mathf.Clamp01(segmentProgress);
    }

    // 可视化路径
    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }

        if (loop && waypoints[0] != null && waypoints[waypoints.Length - 1] != null)
            Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);

        Gizmos.color = Color.red;
        foreach (var wp in waypoints)
        {
            if (wp != null)
                Gizmos.DrawWireSphere(wp.position, 0.3f);
        }
    }
}