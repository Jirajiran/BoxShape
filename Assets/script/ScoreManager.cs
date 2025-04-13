
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEngine.UI; // ����Ѻ UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ���ҧ Instance
    public int score = 0; // ��ṹ�������
    public Text scoreText; // UI Text ����Ѻ�ʴ���ṹ

    public class GameData
    {
        public int score;
        public string playerName;
        public string message;
    }

        private void Awake()
    {
        LoadGame();
        // ����� ScoreManager �� Singleton
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
        scoreText.text = "" + score; // �Ѿവ��ͤ��� UI
    }

    public void AddScore(int amount)
    {
        score += amount; // ������ṹ
        
        UpdateScoreText(); // �Ѿവ UI
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
