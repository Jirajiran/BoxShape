
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEngine.UI; // สำหรับ UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // สร้าง Instance
    public int score = 0; // คะแนนเริ่มต้น
    public Text scoreText; // UI Text สำหรับแสดงคะแนน

    public class GameData
    {
        public int score;
        public string playerName;
        public string message;
    }

        private void Awake()
    {
        LoadGame();
        // ทำให้ ScoreManager เป็น Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "" + score; // อัพเดตข้อความ UI
    }

    public void AddScore(int amount)
    {
        score += amount; // เพิ่มคะแนน
        
        UpdateScoreText(); // อัพเดต UI
        PlayerPrefs.SetInt("score", score);
    }
    public void LoadGame()
    {        
        string filePath = Application.persistentDataPath + "/gamedata.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Load Score: " + data.score);
            Debug.Log("Player Name: " + data.playerName);
            Debug.Log("Message: " + data.message);
            PlayerPrefs.SetInt("score", data.score);
            score = data.score;
            UpdateScoreText();
        }
        else
        {
            PlayerPrefs.SetInt("score", 0);
        }
    }
}
