using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public string playingUser;
    public HighScore highScore;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        Debug.Log(highScore.value);
    }

    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(highScore);
        string highScoreFile = Application.persistentDataPath + "/highscore.json";
        File.WriteAllText(highScoreFile, json);
        Debug.Log("Save high score " + json + " to " + highScoreFile);
    }

    public void LoadHighScore()
    {
        string highScoreFile = Application.persistentDataPath + "/highscore.json";
        Debug.Log(highScoreFile);
        if (File.Exists(highScoreFile))
        {
            string json = File.ReadAllText(highScoreFile);
            highScore = JsonUtility.FromJson<HighScore>(json);
        } else
        {
            highScore = new HighScore();
        }
    }

    [Serializable]
    public class HighScore
    {
        public int value;
        public string userName;
    }
}
