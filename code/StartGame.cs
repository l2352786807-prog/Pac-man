using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int SceneNum;
    public DataManager datamanager;

    public GameObject Login;
    public GameObject History;


    public TMP_Text name;
    public TMP_Text score;
    private void Start()
    {
        Login.SetActive(false);
        History.SetActive(false);
    }
    public void gamestart() 
    {
        Login.SetActive(true);

    }

    public void historystart()
    {
        History.SetActive(true);
        Player nailong = datamanager.LoadDate();
        Debug.Log(nailong.name);

        name.text = nailong.name;
        score.text = ""+nailong.score;

    }
    public void historyclose()
    {
        History.SetActive(false);

    }

    public void exitgame() 
    {
        Application.Quit();
    
    }

    public void sceneChange()
    {

        SceneManager.LoadScene(SceneNum);
    }
}
