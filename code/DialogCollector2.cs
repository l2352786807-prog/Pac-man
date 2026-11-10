using TMPro;
using UnityEngine;

public class DialogCollector2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string[] dialog = { "奶龙脱离了游荡着吃豆人的迷宫，进入了吃豆乐园，并获得了超能眼镜", "终于到了这里。", "据迷宫的居民说，这里有一件神器，持有者将获得无可匹敌的力量。", "拥有这份力量，我就有击败贝利亚的可能了" };
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
        //UI.SetActive(false);
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
        DialogCollector1 = GetComponent<Transform>();
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
        else if (index < dialog.Length)
        {
            if (index == 1)
            {
                charcter.SetActive(true);
            }
            dialogtext.text = dialog[index];
        }
        else if (index == dialog.Length + 2)
        {
            title.SetActive(false);
            DialogCollector1.GetComponent<DialogCollector2>().enabled = false;
            enemy.SetActive(true);
            UI.SetActive(true);
        }
        index++;
    }
}
