using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class OpenDoor : MonoBehaviour
{
    public Transform bone;
    public bool hasRotated = false;
    public GameObject panelToHide;

    public TMP_Text interactionText;

    private void Start()
    {
        panelToHide.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        panelToHide.SetActive(true);
        
        if (!hasRotated)
        {
            interactionText.text = "F :开门";
        }
        else
        {
            interactionText.text = "F :关门";
        }
        if (other.CompareTag("Player") && Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (!hasRotated)
            {
                bone.Rotate(90, 0, 0);
                hasRotated = true;
                Debug.Log("骨骼已旋转！");
            }
            else
            {
                bone.Rotate(-90, 0, 0);
                hasRotated = false;
                Debug.Log("骨骼已复位！");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            panelToHide.SetActive(false);
    }
}
