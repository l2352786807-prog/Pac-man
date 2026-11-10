using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameCollector : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public plearer player;
    public int score;
    public int scoreGoal1=10;
    public int scoreGoal2=30;
    public int scoreGoal3=50;
    public TMP_Text txt;
    void Start()
    {
        score =0;
        txt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        score = player.score;

        if (score >= scoreGoal1)
        {
            Destroy(door1);
            txt.text = "大门1已开启！";
        }
        if (score >= scoreGoal2)
        {
            Destroy(door2);
            txt.text = "大门2已开启！";
        }
        if (score >= scoreGoal3)
        {
            Destroy(door3);
            txt.text = "大门3已开启！";
        }
    }
}
