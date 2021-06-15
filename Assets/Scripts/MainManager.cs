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
}


