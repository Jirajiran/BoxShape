using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // เพิ่มสำหรับใช้งาน UI


public class MainMean : MonoBehaviour
{
    private string filePath;
    public static string sceneName;


    public class GameData
    {
        public int score;
        public string playerName;
        public string message;
    }
    public void SaveGame()
    {
        var score = PlayerPrefs.GetInt("score");
        Debug.Log("get scrore: " + score);
        filePath = Application.persistentDataPath + "/gamedata.json";

        GameData data = new GameData();
        data.score = score;
        data.playerName = "Jame";  // Save Thai text
        data.message = "Done" ;  // Another example with Thai text              
        string json = JsonUtility.ToJson(data);

        //json = "{ "score" : score , playerName: "Jame" , "message": "Done"}";

        File.WriteAllText(filePath, json);
       
    }


    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StopGame()
    {
        Time.timeScale = 0;

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;

    }
    public void Quitgame()
    {
               
        SaveGame();
        
        Application.Quit();
    }

    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("SettingMean");
    }

    public void GoToMainManu()
    {
        SaveGame();
        SceneManager.LoadScene("MainMean");

    }

    public void Playgame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void SceneNow(string sceneNameNow)
    {
        sceneName = sceneNameNow;

        ReadData readPlayer = new ReadData();
        readPlayer.LoadData();
        var jsonData = readPlayer.playerData;

        string jsonString = JsonUtility.ToJson(jsonData);

        Debug.Log("jsonString: " + jsonString);

        if (jsonData!=null)
        {

            // Deserialize the JSON string into the SaveGameModel object
            Debug.Log("Casting SaveGameModel from playerData");

            var playerData = JsonUtility.FromJson<SaveGameModel>(jsonData.ToString());

            Debug.Log("Convert tot Model SaveGameModel is pass");
            // Check if the scene name is valid
            if (!string.IsNullOrEmpty(playerData.SceneCurrent))
            {
                SceneManager.LoadScene(playerData.SceneCurrent);
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            // Load the default scene if jsonData is null or empty
            SceneManager.LoadScene("Level000");
        }
    }
}
