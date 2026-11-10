using UnityEditor;
using UnityEngine;

public class CreateWaypoints : MonoBehaviour
{
    [MenuItem("GameObject/Create Track Waypoints", false, 0)]
    static void CreateTrack()
    {
        GameObject track = new GameObject("Track");
        int pointCount = 5;

        for (int i = 0; i < pointCount; i++)
        {
            GameObject waypoint = new GameObject($"Waypoint_{i}");
            waypoint.transform.SetParent(track.transform);
            waypoint.transform.position = new Vector3(i * 2, Mathf.Sin(i) * 2, 0);

            // 添加图标便于识别
            EditorGUIUtility.SetIconForObject(waypoint,
                EditorGUIUtility.IconContent("d_Animation.Signal").image as Texture2D);
        }

        Selection.activeGameObject = track;
    }
}
