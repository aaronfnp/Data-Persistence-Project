using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string PlayerName;
    public Button startButton;
    public int playerScore;
    public int highScore;
    public GameObject mainManager;

    public GameManager Instance;
    // Start is called before the first frame update

    private void Start()
    {
        LoadFunction();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        LoadFunction();

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }
    public void SaveGameData(string inputName, int scoreToAdd)
    {
        SaveData data = new SaveData();
        data.PlayerName = inputName;
        data.HighScore = scoreToAdd;

        string json = JsonUtility.ToJson(data);

        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
        
    public void LoadFunction()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.HighScore;
            PlayerName = data.PlayerName;
        }
    }
    public void ResetHighScore()
    {
        playerScore = 0;
        PlayerName = "none";
       
        SaveData data = new SaveData();
        data.HighScore = playerScore;
        data.PlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("High Score Reset!");        
    }
}   
