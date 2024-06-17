using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManagerUI : MonoBehaviour
{
    public static MainManagerUI Instance;
    public string Name = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.Name = Name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
        }
    }

}
