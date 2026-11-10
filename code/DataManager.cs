using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class Player
{
    
    public string name;
    public int score;
}
public class PlayerList
{
    public List<Player> playerList = new List<Player>();
}

public class DataManager : MonoBehaviour
{
    public PlayerList list = new PlayerList();

    public void GenerrateData( string name, int score)
    {
        Player nailong = new Player();
        nailong.name = name;
        nailong.score = score;
        list.playerList.Add(nailong);
    }
    
    public void SaveData()
    {
        string json = JsonUtility.ToJson(list,true);
        string filepath = Application.streamingAssetsPath + "/playerlist.json";

        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
    }
    
   public Player LoadDate()
    {
        string json;
        string filepath = Application.streamingAssetsPath + "/playerlist.json";

        using (StreamReader sr = new StreamReader(filepath))
        {
            json = sr.ReadToEnd();
            sr.Close();
        }
        list = JsonUtility.FromJson<PlayerList>(json);
        return list.playerList[0];
    }
}
