using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;
using System; // For Exception handling


[System.Serializable] // This allows the class to be serialized to JSON

public class SaveData : MonoBehaviour
{
    

    // Path where the file will be saved
    private string path;

    //private void Start()
    //{
    //    // Set the path for the file to save
    //    path = Application.persistentDataPath + "/playerData.json";

    //    SaveGameModel playerData = new SaveGameModel();
    //    playerData.playerName = "Player0002";
    //    playerData.playerScore = 2200;        
    //    playerData.SceneCurrent = SceneManager.GetActiveScene().name;

    //    SaveDataInfo(playerData);

        
        
    //}
   
    public void SaveDataInfo(SaveGameModel playerData)
    {
        playerData.playerName = "Player0002";
        playerData.playerScore = 2200;         Debug.Log("Model: " + playerData.ToString());
        playerData.SceneCurrent = SceneManager.GetActiveScene().name;     // Convert the PlayerData object to JSON string        
        string json = JsonUtility.ToJson(playerData, true);
       

        try
        {
            // Log the JSON string
            Debug.Log("json: " + json); // No need to call .ToString() on a string

            path = Application.persistentDataPath + "/playerData.json";
            Debug.Log("Path name Jame : "+path);
            // Write the JSON string to a file
            File.WriteAllText(path, json);

            Debug.Log("Data saved to " + path);
        }
        catch (Exception ex)
        {
            // Log the exception message if an error occurs
            Debug.Log("Error saving data: " + ex.Message);
            Debug.Log("path: " + path);
            Debug.Log("json: " + json.ToString());
        }
    }

}
