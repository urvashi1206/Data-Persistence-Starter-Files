using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManagerUI : MonoBehaviour
{
    public static MainManagerUI Instance;
    public string Name;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadNameandScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int HighScore;
    }

    public void SaveNameandScore()
    { 
        SaveData data = new SaveData();
        data.Name = Name;
        data.HighScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameandScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            highScore = data.HighScore;
        }
        else
        {
            Name = "Player";
            highScore = 0;
        }
    }
}
