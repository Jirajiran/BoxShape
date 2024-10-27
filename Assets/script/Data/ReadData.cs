
using System.IO;
using UnityEngine;


public class ReadData : MonoBehaviour
{
    public SaveGameModel playerData = new SaveGameModel();

    // Path where the file is saved
    private string path;  

    public void LoadData()
    {
        path = Application.persistentDataPath + "/playerData.json";

        // Check if the file exists before trying to load it
        if (File.Exists(path))
        {
            // Read the JSON string from the file
            string json = File.ReadAllText(path);

            // Deserialize the JSON string back into the PlayerData object
            playerData = JsonUtility.FromJson<SaveGameModel>(json);

            Debug.Log("Data loaded. Player Name: " + playerData.playerName + ", Score: " + playerData.playerScore);
        }
        else
        {
            playerData = null;
            Debug.LogWarning("Read file not found at " + path);
        }
    }
}
