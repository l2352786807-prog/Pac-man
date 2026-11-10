using StarterAssets;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class plearer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text ui;
    public int score = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public int hurt = 20;
    public UIcontrol control;
    public TMP_Text glod;
    public int winscore = 100;
    public GameObject door;

    public health healthBar;

    public GameObject car;

    [Header("摄像头控制")]
    private MonoBehaviour cameraController;

    
    void Start()
    {
       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 禁用摄像头控制脚本
            if (cameraController != null)
                cameraController.enabled = false;
            SceneManager.LoadScene(2);
        }

        if (score >= winscore)
        {
            Destroy(door);
           /* Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 禁用摄像头控制脚本
            if (cameraController != null)
                cameraController.enabled = false;
            SceneManager.LoadScene(3);*/
        }
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("pac"))
        { score++;
            ui.text = "分数:" +score;

            control.mega += 1;
            glod.text = ":" + control.mega;
           Destroy(other.gameObject);
        }
        if (other.tag.Equals("speed"))
        {
            Destroy(other.gameObject);
            
        }
        if (other.tag.Equals("enemy")) 
        {
            currentHealth -= hurt;
            healthBar.SetHealth(currentHealth);
            

        }
        if (other.tag.Equals("door"))
        {
            
        }

        
    }
    
}
