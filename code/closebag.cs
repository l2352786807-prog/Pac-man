using TMPro.Examples;
using UnityEngine;

public class closebag : MonoBehaviour
{
    public UIcontrol conrtol;
    [Header("UI设置")]
    public Canvas backpackUI;
    public bool hideOnStart = true;

    [Header("摄像头控制")]
    public MonoBehaviour cameraController; // 拖拽你的摄像头控制脚本到这里

    public void close()
    {
       
            ToggleBackpack();

        Debug.Log("关闭。");
    }

    void ToggleBackpack()
    {
        conrtol.isBackpackOpen = false;
        backpackUI.enabled = false;



        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 启用摄像头控制脚本
        if (cameraController != null)
            cameraController.enabled = true;
        
    }
}
