using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public plearer play;
    public int sence1;
    public int sence2;
   
    public void nextgame()
    {
        SceneManager.LoadScene(sence1);
    }
    public void gamesreturn()
    {
        SceneManager.LoadScene(sence2);

    }
}
