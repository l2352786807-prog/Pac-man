using UnityEngine;

public class pacCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float amplitude = 0.2f;   // 浮动幅度
    public float frequency = 1f;      // 浮动频率

    private Vector3 startPos;          // 记录起始位置
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // 应用新位置
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
