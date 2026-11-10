using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class UIcontrol : MonoBehaviour
{
    /*public GameObject uiObject; // 拖拽你的Canvas到这里
    void Start()
    {
        // 初始隐藏
        if (uiObject != null)
        {
            uiObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {

            if (uiObject != null)
            {
                uiObject.SetActive(!uiObject.activeSelf);
            }
        }

    }
    */
    public int mega = 100;
    public TMP_Text glod;
    [Header("UI设置")]
    public Canvas backpackUI;
    public bool hideOnStart = true;

    [Header("摄像头控制")]
    public MonoBehaviour cameraController; // 拖拽你的摄像头控制脚本到这里

    public bool isBackpackOpen = false;

    void Start()
    {
        glod.text = ":" + mega;
        if (backpackUI != null && hideOnStart)
        {
            backpackUI.enabled = false;
            isBackpackOpen = false;
        }

        // 初始锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            ToggleBackpack();
        }
    }

    void ToggleBackpack()
    {
        isBackpackOpen = !isBackpackOpen;

        // 切换UI
        if (backpackUI != null)
        {
            backpackUI.enabled = isBackpackOpen;
        }

        // 控制鼠标
        if (isBackpackOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 禁用摄像头控制脚本
            if (cameraController != null)
                cameraController.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // 启用摄像头控制脚本
            if (cameraController != null)
                cameraController.enabled = true;
        }
    }
}
