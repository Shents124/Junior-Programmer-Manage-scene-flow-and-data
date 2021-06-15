using System;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now
    public static MainManager Instance;
    public Color teamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Load the color is stored
        LoadColor();
    }
    
    [System.Serializable]
    class SaveData
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        // Initial data
        SaveData data = new SaveData();
        // Assign teamColor of data by team color saved in MainManager 
        data.teamColor = teamColor;
        // Transform data to Json
        string json = JsonUtility.ToJson(data);
        // Create file savefile.json to store text json 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadColor()
    {
        // get file stored data
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            // Read all text in path and assign to json variable
            string json = File.ReadAllText(path);
            // Transform json data to SaveData
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            // Set teamColor in menu to the color saved in SaveData
            teamColor = data.teamColor;
        }
    }
}


