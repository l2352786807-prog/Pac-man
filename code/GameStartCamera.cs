using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class GameStartCamera : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public CinemachineVirtualCamera startCamera;   // 开场相机
    public CinemachineVirtualCamera followCamera;  // 跟随相机

    void Start()
    {
        if (timelineDirector != null)
        {
            // 确保开场时只有开场相机激活
            startCamera.Priority = 100;
            followCamera.Priority = 0;

            // 注册结束事件
            timelineDirector.stopped += OnTimelineFinished;

            // 播放动画
            timelineDirector.Play();
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Timeline结束后切换相机
        startCamera.Priority = 0;
        followCamera.Priority = 100;

        // 清理事件
        timelineDirector.stopped -= OnTimelineFinished;

        // 可选：禁用此脚本
        this.enabled = false;
    }

    void OnDestroy()
    {
        if (timelineDirector != null)
            timelineDirector.stopped -= OnTimelineFinished;
    }
}
