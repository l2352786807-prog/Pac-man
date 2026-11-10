using TMPro;
using UnityEngine;

public class DialogCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string[] dialog = { "奶龙与贝利亚的战斗撕裂了时空，将他们传送到了吃豆人的世界。", "呃...","可恶的贝利亚。竟然如此难缠。","这里是？吃豆人的世界吗。","不好，贝利亚似乎已经提前来过这里了，吃豆人都被控制住了。","可恶，不过还好我在，我会打败贝利亚，拯救这个星球的。" };
    public GameObject dialogect;
    public GameObject charcter;
    public GameObject title;
    public GameObject enemy;
    public GameObject UI;
    public TMP_Text dialogtext;
    private Transform DialogCollector1;
    private int index = 0;
    private float changetime = 0;
    void Start()
    {
        dialogect.SetActive(false);
        title.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        changetime += Time.deltaTime;
        
        if (changetime >= 4)
        {
            ChangeText();
            changetime = 0;
        }
    }

   public void ChangeText()
    {
        DialogCollector1 = GetComponent<Transform> ();
        if (index == 0)
        {
            dialogect.SetActive(true);
            charcter.SetActive(false);
            dialogtext.text = dialog[index];

        }
        else if (index == dialog.Length)
        {
            dialogect.SetActive(false);
            title.SetActive(true);
           
        }
        else if(index<dialog.Length)
        {
            if (index == 1)
            {
                charcter.SetActive(true);
            }
            dialogtext.text = dialog[index];
        }else if(index == dialog.Length + 2)
        {
            title.SetActive(false);
            DialogCollector1.GetComponent<DialogCollector>().enabled = false;
            enemy.SetActive(true);
            UI.SetActive(true);
        }
        index++;
    }
}
