using UnityEngine;
using System.Collections;
public class elvator : MonoBehaviour
{
    public float height = 2f;      // 移动高度
    public float speed = 2f;       // 移动速度
    public float waitTime = 0.5f;  // 等待时间

    private Vector3 startPos;
    private Vector3 topPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
        topPos = startPos + Vector3.up * height;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (movingUp)
            {
                // 向上移动
                transform.position = Vector3.MoveTowards(transform.position, topPos, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, topPos) < 0.01f)
                {
                    movingUp = false;
                    yield return new WaitForSeconds(waitTime);
                }
            }
            else
            {
                // 向下移动
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPos) < 0.01f)
                {
                    movingUp = true;
                    yield return new WaitForSeconds(waitTime);
                }
            }
            yield return null;
        }
    }
}
