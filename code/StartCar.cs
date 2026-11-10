using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartCar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text interactionText;
    public GameObject panelToHide;
    private bool hasRotated = false;
    public TheCar car;
    public float speed = 1.0f;
    public Transform bone;
    public OpenDoor door;

    private void Start()
    {
        panelToHide.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        panelToHide.SetActive(true);

        if (!hasRotated)
        {
            interactionText.text = "F :启动";

        }
        else
        {
            interactionText.text = "已启动，禁止操作";
        }
        if (other.CompareTag("Player") && Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (!hasRotated)
            {
                car.maxSpeed = speed;
                hasRotated = true;
            }

            bone.Rotate(-90, 0, 0);
            
            Debug.Log("骨骼已复位！");
            door.hasRotated = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            panelToHide.SetActive(false);
    }
}
