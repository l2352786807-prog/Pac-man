using System.Collections.Generic;
using System;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;



public class Glass : MonoBehaviour
{
    
    public int SceneNum;
    public DataManager datamanager;

    public plearer player;
    //Player wanjia;
 
    [Header("摄像头控制")]
    private MonoBehaviour cameraController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 禁用摄像头控制脚本
            if (cameraController != null)
                cameraController.enabled = false;

            datamanager.GenerrateData("123", player.score);
            
            datamanager.SaveData();

            SceneManager.LoadScene(SceneNum);
            
        }
    }
}
